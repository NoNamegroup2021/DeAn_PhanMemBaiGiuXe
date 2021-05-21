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

namespace PhanMemBaiGiuXeBLL
{
    public class SegmentChar
    {
		private Bitmap img;
		private Rectangle[] rects_areas;

		public SegmentChar()
		{
		}

		public Bitmap Img { get => img; set => img = value; }
		public Rectangle[] Rects_areas { get => rects_areas; set => rects_areas = value; }

		public void setData(Bitmap img)
		{
			this.img = img;
			Rects_areas = null;
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

		public Rectangle[] findContours(Image src,Image<Bgr,Byte> input,int w,int h)
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
				Rectangle[] rect_found = new Rectangle[count];
				int jumpstep = 0;
				Image<Bgr, Byte> img_brg_draw = new Image<Bgr, byte>(src as Bitmap);
				for (int i = 0; i < count; i++)
				{
					int width = CvInvoke.BoundingRectangle(contours[i]).Width;
					int height = CvInvoke.BoundingRectangle(contours[i]).Height;
					int x = CvInvoke.BoundingRectangle(contours[i]).X;
					int y = CvInvoke.BoundingRectangle(contours[i]).Y;



					if (height >= 45 && height <= 80 && width >= 12 && width <= 40 && width <= height && (float)width / height > 0.2 && (float)width / height < 0.5)
					{

						Rectangle rect = new Rectangle(x, y, width, height);
						rect_found[jumpstep] = rect;
						jumpstep++;
					}
				}
				return rect_found;
            }
            catch
            {
				return null;
            }
        }

		/// <summary>
		/// Ham thuc hien lam mo anh voi GuassianBlur
		/// ham su dung kernel 5x5 
		/// </summary>
		/// <param name="img"></param>
		/// <returns></returns>
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
	}
}
