using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace LAC.Functions.Drawing
{
    public class DrawingFunctions
    {
        #region Functions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageBytes"></param>
        /// <returns></returns>
        public static Image GetImageFromBytes(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes);       
            return new Bitmap(ms);
        }

        /// <summary>
        /// This static method creates an image from the source image, 
        /// resizing if needed, and using a background color if the 
        /// new size of the source image is smaller than the new image.
        /// </summary>
        /// <param name="sourceImage"></param>
        /// <param name="panelWidth"></param>
        /// <param name="panelHeight"></param>
        /// <param name="imageWidth"></param>
        /// <param name="imageHeigth"></param>
        /// <param name="backGroundColor"></param>
        /// <returns>The new generated image</returns>
        public static Image CreateImageFromImage(Image sourceImage, int panelWidth, int panelHeight, int imageWidth, int imageHeigth, Color backGroundColor)
        {
            //Creating image with specific width and height
            Bitmap resultImage = new Bitmap(panelWidth, panelHeight);
            //Retrieving graphics from image
            Graphics g = Graphics.FromImage(resultImage);
            //Clearing image with background color
            g.Clear(backGroundColor);
            //Drawing image with sourceImage
            Rectangle rectImg = new Rectangle(0, 0, imageWidth, imageHeigth);
            ImageAttributes imgAtt = new ImageAttributes();
            g.DrawImage(sourceImage, rectImg, 0, 0, sourceImage.Width, sourceImage.Height, GraphicsUnit.Pixel, imgAtt);
            //Disposing source image
            sourceImage.Dispose();
            //returning modified source image...
            g.Dispose();
            return resultImage;
        }

        public static Size GetRelativeSize(int width, int height, int relationWidth, int relationHeight)
        {
            int imageWidth;
            int imageHeight;
            if (height <= width && ((double)height / (double)width) <= ((double)relationHeight / (double)relationWidth))
            {
                imageHeight = height;
                imageWidth = (int)Math.Round(((double)relationWidth / (double)relationHeight) * (double)imageHeight, 0);
            }
            else
            {
                imageWidth = width;
                imageHeight = (int)Math.Round(((double)relationHeight / (double)relationWidth) * (double)imageWidth, 0);
            }
            return new Size(imageWidth, imageHeight);
        }

        #endregion
    }
}
