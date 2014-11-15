using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LAC.Functions.Image
{
    public class ImageFunctions
    {
        #region Functions


        /// <summary>
        /// This static method creates an image from the source image, 
        /// resizing if needed, and using a background color if the 
        /// new size of the source image is lesser than the new image.
        /// </summary>
        /// <param name="sourceImage"></param>
        /// <param name="panelWidth"></param>
        /// <param name="panelHeight"></param>
        /// <param name="imageWidth"></param>
        /// <param name="imageHeigth"></param>
        /// <param name="backGroundColor"></param>
        /// <returns>The new generated image</returns>
        public static System.Drawing.Image CreateImageFromImage(System.Drawing.Image sourceImage, int panelWidth, int panelHeight, int imageWidth, int imageHeigth, Color backGroundColor)
        {
            Bitmap resultImage;
            Graphics g;
            resultImage = new Bitmap(panelWidth, panelHeight);
            g = Graphics.FromImage(resultImage);
            g.Clear(backGroundColor);
            g.DrawImage(sourceImage, new Rectangle(0, 0, imageWidth, imageHeigth), 0, 0, sourceImage.Width, sourceImage.Height, GraphicsUnit.Pixel, null);
            sourceImage.Dispose();
            sourceImage = (Bitmap)resultImage.Clone();
            resultImage.Dispose();
            return sourceImage;
        }

        #endregion
    }
}
