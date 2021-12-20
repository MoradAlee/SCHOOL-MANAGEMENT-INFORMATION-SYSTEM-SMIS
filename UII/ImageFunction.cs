using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

namespace School_Management_System.UI
{
    class ImageFunction
    {
        public static Bitmap ByteArrayToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            mStream.Write(blob, 0, Convert.ToInt32(blob.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static byte[] VaryQualityLevel(MemoryStream ms)
        {
            try
            {
                // Get a bitmap.
                Bitmap bmp1 = new Bitmap(ms);
                ImageCodecInfo jgpEncoder = ImageFunction.GetEncoder(ImageFormat.Jpeg);
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);

                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 30L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                //return ImageToByte2(bmp1);

                byte[] byteArray = new byte[0];
                using (MemoryStream stream = new MemoryStream())
                {
                    bmp1.Save(stream, jgpEncoder, myEncoderParameters);
                    //stream.Close();
                    byteArray = stream.ToArray();


                    stream.Close();

                }
                myEncoderParameters.Dispose();
                return byteArray;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        public static byte[] ResizeImage(byte[] bytes, int NewWidth, int MaxHeight, bool AllowLargerImageCreation)
        {

            System.Drawing.Image FullsizeImage = null;
            System.Drawing.Image ResizedImage = null;
            //Cast bytes to an image
            FullsizeImage = ImageFunction.ByteArrayToImage(bytes);

            // Prevent using images internal thumbnail
            FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
            FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);

            // If we are re sizing upwards to a bigger size
            if (AllowLargerImageCreation)
            {
                if (FullsizeImage.Width <= NewWidth)
                {
                    NewWidth = FullsizeImage.Width;
                }
            }

            //Keep aspect ratio
            int NewHeight = FullsizeImage.Height * NewWidth / FullsizeImage.Width;
            if (NewHeight > MaxHeight)
            {
                // Resize with height instead
                NewWidth = FullsizeImage.Width * MaxHeight / FullsizeImage.Height;
                NewHeight = MaxHeight;
            }

            ResizedImage = FullsizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);

            // Clear handle to original file so that we can overwrite it if necessary
            FullsizeImage.Dispose();

            return imageToByteArray(ResizedImage);
        }
    }
}
