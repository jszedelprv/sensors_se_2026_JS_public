
using System.Drawing;


namespace MyKai.General
{
    internal class MyKaiJPGImageSaver : MyKaiImageSaverBase
    {
        public override void SaveImage(Image pImage, string pFilename)
        {
            using (var encoderParameters = new System.Drawing.Imaging.EncoderParameters(1))
            {
                encoderParameters.Param[0] = new System.Drawing.Imaging.EncoderParameter(
                    System.Drawing.Imaging.Encoder.Quality, 90L);

                var jpegCodec = GetEncoder(System.Drawing.Imaging.ImageFormat.Jpeg);
                
                pImage.Save(pFilename, jpegCodec, encoderParameters);
            }
        }

        private static System.Drawing.Imaging.ImageCodecInfo GetEncoder(System.Drawing.Imaging.ImageFormat format)
        {
            var codecs = System.Drawing.Imaging.ImageCodecInfo.GetImageDecoders();
            foreach (var codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}
