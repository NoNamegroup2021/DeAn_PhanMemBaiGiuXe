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

		public Bitmap Img1
        {
            get {	return img; }
			set {   img = value; }
        }			

		public List<Rectangle> Rects_areas
        {
            get { return rects_areas; }
			set { rects_areas = value; }
        }			

        public List<Rectangle> getFirstLine 
		{ 
			get { return firstLine; }

		}

		public List<Rectangle> getSecondLine
        {
            get { return secondLine; }
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

		private Bitmap findEdge(Image<Bgr, Byte> src,int w,int h)
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

		public List<Rectangle> findContours(Image src,Image<Bgr,Byte> input,int w,int h,out List<Rectangle> fl,out List<Rectangle> sl,out Rectangle area1,out Rectangle area2)
        {
            try
            {
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
				area1 = getAreaRect_Line1(firstLine);
				area2 = getAreaRect_Line2(secondLine);
				return rects_areas;
            }
            catch
            {
				area1 = new Rectangle();
				area2 = new Rectangle();
				fl = null;
				sl = null;
				return null;
            }
        }

		private Mat Gaussianblur(Image<Gray, Byte> img)
		{
			Mat src = img.Mat;
			CvInvoke.GaussianBlur(src, src, new Size(5, 5), 3);
			return src;
		}

		private Mat MedianBlur (Image <Gray,Byte> img)
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

		public ImageList CharList(Rectangle[] rects,Image src)
        {
			try
            {
				ImageList output = new ImageList();

				int count = rects.Length;
				if(count >0)
                {
					for( int i = 0 ; i <count ; i++ )
                    {
						var boundingBox = rects[i];
						if(boundingBox.Width != 0 && boundingBox.Height != 0)
                        {
							Bitmap src_bm = src as Bitmap;
							Bitmap char_bm = new Bitmap(boundingBox.Width, boundingBox.Height);
							using (Graphics g = Graphics.FromImage(char_bm))
                            {
								g.DrawImage(src_bm, new Rectangle(0, 0, boundingBox.Width, boundingBox.Height), boundingBox, GraphicsUnit.Pixel);
                            }
							Image<Bgr, Byte> output_img = resizeImage(new Image<Bgr,Byte>(char_bm), 28, 28);
							Bitmap output_bm = output_img.ToBitmap();
							output.Images.Add(output_bm);
                        }
                    }
                }

				return output;
            }
			catch
            {
				return null;
            }
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

		private Rectangle getAreaRect_Line1(List<Rectangle> rects)
		{
			int count = rects.Count;
			Rectangle frect = rects[0];
			Rectangle lrect = rects[count - 1];
			int maxH = rects.Max(r => r.Height);

			Rectangle[] bg_hr = rects.Where(r => r.Height == maxH).ToArray();
			bg_hr = bg_hr.OrderByDescending(t => t.X).ToArray();
			return new Rectangle(new Point(firstX_Line1, bg_hr[0].Y), new Size(Math.Abs(lrect.X + lrect.Width - firstX_Line1), bg_hr[0].Height + 1));
		}

		private Rectangle getAreaRect_Line2(List<Rectangle> rects)
		{
			int count = rects.Count;
			Rectangle frect = rects[0];
			Rectangle lrect = rects[count - 1];
			int maxH = rects.Max(r => r.Height);

			Rectangle[] bg_hr = rects.Where(r => r.Height == maxH).ToArray();
			bg_hr = bg_hr.OrderByDescending(t => t.X).ToArray();
			return new Rectangle(new Point(firstX_Line2, bg_hr[0].Y), new Size(Math.Abs(lrect.X + lrect.Width - firstX_Line2), bg_hr[0].Height + 1));
		}
	}
}
