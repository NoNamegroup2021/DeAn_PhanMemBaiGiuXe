using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Emgu;
//using Emgu.CV;
//using Emgu.Util;
//using System.IO;
//using Emgu.CV.Structure;

namespace PhanMemBaiGiuXeBLL
{
    //public class SegmentChar
    //{
    //    private Bitmap img;
    //    private Rectangle[] rects_areas;

    //    public SegmentChar()
    //    {
    //    }

    //    public Bitmap Img { get => img; set => img = value; }
    //    public Rectangle[] Rects_areas { get => rects_areas; set => rects_areas = value; }

    //    public void setData(Bitmap img)
    //    {
    //        this.img = img;
    //        Rects_areas = null;
    //    }

    //    public void contour(Image<Gray, Byte> src)
    //    {
    //        Image<Gray, Byte> img_contours = new Image<Gray, byte>(src.ToBitmap());
    //        src = AdaptiveThreshold(src);


    //    }

    //    /// <summary>
    //    /// Ham thuc hien lam mo anh voi GuassianBlur
    //    /// ham su dung kernel 5x5 
    //    /// </summary>
    //    /// <param name="img"></param>
    //    /// <returns></returns>
    //    private Mat Gaussianblur(Image<Gray, Byte> img)
    //    {
    //        Mat src = img.Mat;
    //        CvInvoke.GaussianBlur(src, src, new Size(5, 5), 3);
    //        return src;
    //    }


    //    /// <summary>
    //    /// AdaptiveThreshold dung de phan nguong anh ve nhi phan
    //    /// Tang kha nang tach ky tu trong bien so
    //    /// Ham AdaptiveThreshold su dung cac tham so
    //    /// src : Array dau vo
    //    /// dest : Array dau ra
    //    /// maxValue : Value toi da cua diem anh 
    //    /// AdaptiveThresholdType
    //    /// ThresholdType
    //    /// Blocksize : so cac pixel lan can dung de tinh gia tri cho 1 pixel
    //    /// </summary>
    //    /// <param name="InputImage"></param>
    //    /// <returns></returns>
    //    private Image<Gray, Byte> AdaptiveThreshold(Image<Gray, Byte> InputImage)
    //    {
    //        Mat input_mat = Gaussianblur(InputImage);
    //        CvInvoke.AdaptiveThreshold(input_mat, input_mat, 255, Emgu.CV.CvEnum.AdaptiveThresholdType.MeanC, Emgu.CV.CvEnum.ThresholdType.BinaryInv, 51, 2);
    //        Image<Gray, Byte> Output_image = input_mat.ToImage<Gray, Byte>();
    //        return Output_image;
    //    }
    //}
}
