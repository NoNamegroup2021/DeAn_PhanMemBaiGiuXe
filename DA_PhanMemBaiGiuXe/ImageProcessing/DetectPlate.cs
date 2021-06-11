using System;
using Emgu.CV;
using System.IO;
using System.Drawing;
using Emgu.CV.Structure;

namespace ImageProcessing
{
    public class DetectPlate
    {
        static CascadeClassifier carLicense_class;
        static string haarcascade_file = Directory.GetCurrentDirectory() + "\\car_lp_cascade.xml";
        public static Rectangle[] detect(Image input_src)
        {
            try
            {
                Bitmap bm = input_src as Bitmap;
                if (bm != null)
                {
                    carLicense_class = new CascadeClassifier(haarcascade_file);
                    Image<Bgr, Byte> img = new Image<Bgr, byte>(bm);
                    Image<Gray, Byte> gray = img.Convert<Gray, Byte>();
                    Bitmap transfr = input_src as Bitmap;
                    Image<Bgr, Byte> img_transfr_frame = new Image<Bgr, byte>(transfr);
                    Image<Gray, Byte> imgTransf_grayScale = img_transfr_frame.Convert<Gray, Byte>();

                    Rectangle[] rects = carLicense_class.DetectMultiScale(imgTransf_grayScale, 1.2, 3, Size.Empty);
                    return rects;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}
