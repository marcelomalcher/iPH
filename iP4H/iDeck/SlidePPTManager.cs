using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Text;
using System.IO;
using System.Collections;
using System.Drawing;
using iPH.Commons.Presentation;
using Core = Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace iPH.iDeck
{
    public class SlidePPTManager
    {
        #region Members

        private const string DEFAULT_SLIDE_NAME = "slide";

        System.CodeDom.Compiler.TempFileCollection tempFileCollection;

        private string outpath;

        private string fileName;

        private string formatString;

        private Size slideSize;

        private PowerPoint.Application app;

        private PowerPoint.Presentation pres;

        private bool alreadyOpen = false;

        #endregion

        #region Ctors

        public SlidePPTManager(string pptFile, string formatString, Size size)
        {
            tempFileCollection = new System.CodeDom.Compiler.TempFileCollection();
            outpath = tempFileCollection.BasePath;
            try
            {
                if (Directory.Exists(outpath))
                    Directory.Delete(outpath, true);
                Directory.CreateDirectory(outpath);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            this.fileName = pptFile;
            this.formatString = formatString;
            this.slideSize = size;
        }

        #endregion

        #region Methods

        public iPH.Commons.Presentation.Slide[] GetSlides()
        {
            iPH.Commons.Presentation.Slide[] slides;

            app = new PowerPoint.Application();

            alreadyOpen = app.Visible == Core.MsoTriState.msoTrue;

            pres = app.Presentations.Open(this.fileName, Microsoft.Office.Core.MsoTriState.msoTrue, Core.MsoTriState.msoFalse, Core.MsoTriState.msoFalse);

            pres.SlideShowSettings.ShowWithAnimation = Core.MsoTriState.msoFalse;

            slides = new iPH.Commons.Presentation.Slide[pres.Slides.Count];

            for (int i = 1; i <= pres.Slides.Count; i++)
            {
                //PowerPoint.Slide pptSlide = (PowerPoint.Slide)pres.Slides.Item(i);
                PowerPoint.Slide pptSlide = (PowerPoint.Slide)pres.Slides[i];

                string slideComment = "";

                for (int j = 1; j <= pptSlide.Comments.Count; j++)
                {
                    //slideComment += pptSlide.Comments.Item(j).Text + System.Environment.NewLine;
                    slideComment += pptSlide.Comments[j].Text + System.Environment.NewLine;
                }

                string slideName = Path.Combine(outpath, DEFAULT_SLIDE_NAME + i.ToString() + "." + formatString);

                tempFileCollection.AddFile(slideName, false);

                pptSlide.Export(slideName, formatString, slideSize.Width, slideSize.Height);

                PresentationSlide presentationSlide = this.LoadPresentationSlide(pptSlide, slideName, slideComment);

                slides[i - 1] = presentationSlide;
            }

            if (pres != null)
            {
                pres.Close();
                pres = null;
            }

            if (app != null && !alreadyOpen)
            {
                app.Quit();
                app = null;
            }

            GC.Collect();
            
            tempFileCollection.Delete();    

            return slides;
        }

        private PresentationSlide LoadPresentationSlide(PowerPoint.Slide pptSlide, string slideFileName, string slideComment)
        {
            if (!File.Exists(slideFileName))
                return null;

            Image slideImage = new Bitmap(slideFileName);

            Image newSlideImage = (Bitmap)slideImage.Clone();

            slideImage = null;

            //
            MemoryStream ms = new MemoryStream();
            newSlideImage.Save(ms, ImageFormat.Jpeg);
            byte[] bits = ms.ToArray();

            //PresentationSlide pSlide = new PresentationSlide("", newSlideImage);
            PresentationSlide pSlide = new PresentationSlide("", bits);

            pSlide.Title = pptSlide.Name;
            pSlide.Info = slideComment;

            return pSlide;
        }

        #endregion
    }

}
