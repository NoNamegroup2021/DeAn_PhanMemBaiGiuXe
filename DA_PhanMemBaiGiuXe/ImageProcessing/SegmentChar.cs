using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu;
using Emgu.CV;
using Emgu.Util;
using System.IO;
using Emgu.CV.Structure;
using System.Linq;

namespace ImageProcessing
{
    public class SegmentChar
    {
		private Bitmap img;
		private List<Rectangle> rects_areas;
		private List<Rectangle> firstLine;
		private List<Rectangle> secondLine;
		int firstX_Line1, firstX_Line2;

		public SegmentChar()
		{
		}


		protected List<Rectangle> setFirstLine
		{
			set { firstLine = value; }
		}

		protected List<Rectangle> setSecondLine
		{
			set { secondLine = value; }
		}

		public void setData(Bitmap img)
		{
			this.img = img;
		}

		private Bitmap findEdge(Image<Bgr, Byte> src, int w, int h)
		{

			src = resizeImage(src, w, h);
			Image<Gray, Byte> input = new Image<Gray, byte>(src.ToBitmap());
			Mat input_mat = MedianBlur(input);
			Image<Gray, Byte> output_img = input_mat.ToImage<Gray, Byte>();

			CvInvoke.AdaptiveThreshold(input_mat, output_img, 255, Emgu.CV.CvEnum.AdaptiveThresholdType.MeanC, Emgu.CV.CvEnum.ThresholdType.BinaryInv, 51, 2);
			CvInvoke.Canny(input_mat, output_img, 50, 300);
			Bitmap output_bm = output_img.ToBitmap();
			return output_bm;
		}

		List<Rectangle> FirstLine = new List<Rectangle>();
		List<Rectangle> SecondLine = new List<Rectangle>();

		private void getLinesContours(Image src, int w, int h, out List<Rectangle> fl, out List<Rectangle> sl)
		{
			try
			{
				Image<Bgr, Byte> input = new Image<Bgr, byte>(src as Bitmap);
				Bitmap input_bm = findEdge(input, w, h);
				Image<Gray, Byte> input_img = new Image<Gray, byte>(input_bm);
				Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();
				Mat hier = new Mat();
				CvInvoke.FindContours(input_img, contours, hier, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
				CvInvoke.DrawContours(input_img, contours, -1, new MCvScalar(255, 0, 0));

				int count = contours.Size;
				rects_areas = new List<Rectangle>();
				Image<Bgr, Byte> img_brg_draw = new Image<Bgr, byte>(src as Bitmap);
				for (int i = 0; i < count; i++)
				{
					int width = CvInvoke.BoundingRectangle(contours[i]).Width;
					int height = CvInvoke.BoundingRectangle(contours[i]).Height;
					int x = CvInvoke.BoundingRectangle(contours[i]).X;
					int y = CvInvoke.BoundingRectangle(contours[i]).Y;



					if (height >= 40 && height <= 66 && width >= 12 && width <= 26 && (float)width / height > 0.2 && (float)width / height < 0.5)
					{

						Rectangle rect = new Rectangle(x, y, width, height);
						CvInvoke.Rectangle(img_brg_draw, rect, new MCvScalar(0, 0, 255), 2);
						int index = -1;
						index = rects_areas.FindIndex(r => r.X == rect.X && r.Y == rect.Y);
						if (index < 0)
							rects_areas.Add(rect);
					}
				}
				getLines(rects_areas, ref FirstLine, ref SecondLine);
				firstLine = firstLine.OrderBy(r => r.X).ToList();
				secondLine = secondLine.OrderBy(r => r.X).ToList();
				fl = firstLine;
				sl = secondLine;
				firstLine = firstLine.OrderBy(r => r.X).ToList();
				firstX_Line1 = firstLine[0].X;
				secondLine = secondLine.OrderBy(r => r.X).ToList();
				firstX_Line2 = secondLine[0].X;
				if (firstX_Line1 > firstX_Line2)
					firstX_Line1 = firstX_Line2;
				else
					firstX_Line2 = firstX_Line1;
				return;
			}
			catch
			{
				fl = null;
				sl = null;
				return;
			}
		}

		private Mat Gaussianblur(Image<Gray, Byte> img)
		{
			Mat src = img.Mat;
			CvInvoke.GaussianBlur(src, src, new Size(5, 5), 3);
			return src;
		}

		private Mat MedianBlur(Image<Gray, Byte> img)
		{
			Mat src = img.Mat;
			CvInvoke.MedianBlur(src, src, 3);
			return src;
		}

		private Image<Bgr, Byte> resizeImage(Image<Bgr, Byte> original, int width, int height)
		{
			Image<Bgr, Byte> img_resized = original.Resize(width, height, Emgu.CV.CvEnum.Inter.Linear);
			return img_resized;
		}


		private void getLines(List<Rectangle> rects, ref List<Rectangle> firstline, ref List<Rectangle> secondline)
		{
			rects = rects.OrderBy(r => r.Y).ThenBy(r => r.X).ToList();
			firstline.Add(rects[0]);
			for (int i = 1; i < rects.Count; i++)
			{
				if ((rects[i].Y - FirstLine[0].Y) < 10)
					firstline.Add(rects[i]);
				else
					secondline.Add(rects[i]);
			}
			setFirstLine = firstline;
			setSecondLine = secondline;
		}



		public string getLicensePLate(Image src, int w, int h)
		{
			string plate = "";
			try
			{

				var filename = Directory.GetCurrentDirectory() + @"\result";
				firstLine = new List<Rectangle>();
				secondLine = new List<Rectangle>();
				getLinesContours(src, w, h, out firstLine, out secondLine);
				if (firstLine == null || secondLine == null)
					return "";
				List<Image<Bgr, Byte>> line1 = new List<Image<Bgr, Byte>>();
				List<Image<Bgr, Byte>> line2 = new List<Image<Bgr, Byte>>();
				for (int i = 0, j = 0; i < firstLine.Count && j < secondLine.Count; i++, j++)
				{
					var boundingBox1 = firstLine[i];
					var boundingBox2 = secondLine[j];

					Bitmap src_map = src as Bitmap;
					Bitmap crop1 = new Bitmap(boundingBox1.Width, boundingBox1.Height);
					Bitmap crop2 = new Bitmap(boundingBox2.Width, boundingBox2.Height);

					using (Graphics g = Graphics.FromImage(crop1))
					{
						g.DrawImage(src_map, new Rectangle(0, 0, crop1.Width, crop1.Height), boundingBox1, GraphicsUnit.Pixel);
					}
					Image<Bgr, Byte> img_cropped1 = new Image<Bgr, byte>(crop1);


					using (Graphics g = Graphics.FromImage(crop2))
					{
						g.DrawImage(src_map, new Rectangle(0, 0, crop2.Width, crop2.Height), boundingBox2, GraphicsUnit.Pixel);
					}
					Image<Bgr, Byte> img_cropped2 = new Image<Bgr, byte>(crop2);

					line1.Add(img_cropped1);
					line2.Add(img_cropped2);
				}

				using (var mem = new MemoryStream())
				{
					for (int i = 0; i < line1.Count; i++)
					{
						Bitmap src_bm = line1[i].ToBitmap();
						var img = Image.FromStream(mem);

						string file_img = filename + @"\line1_" + i + ".jpg";
						img.Save(file_img);

					}
					plate += "-";
					//for (int i = 0; i < line2.Count; i++)
					//{
					//	line2[i].Save(filename);

					//	plate += getResult(filename);
					//}
				}
				return plate;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return plate;
			}
		}

	}
}
