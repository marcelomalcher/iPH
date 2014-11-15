using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Text;
using System.Collections;
using System.IO;
using System.Reflection;
using LAC.Ink.Enums;

namespace LAC.Ink
{

    public class InkControl : Control
    {

        #region Local Variables

        private Ink ink;
        private ArrayList Points = new ArrayList();
        private Bitmap SpecificBitmap;
        private Bitmap BackGroundImage;
        private Graphics GraphicsHandle;
        private Point LastMouseCoordinates = new Point(0, 0);
        private bool CaptureMouseCoordinates = false;
        private InkActionType inkAction = InkActionType.WriteType;
        private string AppPath = "";
        private string ImageFileName = "";
        private InkControlType type;
        

        #endregion        

        #region Constructor
        public InkControl(Ink ink)
        {
            this.ink = ink;
            this.type = InkControlType.BitmapClean;
        }

        public InkControl(Ink ink, string ApplicationPath, string BaseImageFileName)
        {
            this.ink = ink;
            AppPath = ApplicationPath;
            ImageFileName = BaseImageFileName;
            this.type = InkControlType.ExternFile;
        }

        public InkControl(Ink ink, Bitmap bmp)
        {
            this.ink = ink;
            SpecificBitmap = bmp;
            this.type = InkControlType.SpecificBitmap;
        }
        #endregion

        #region Initialize
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
        #endregion
        
        #region On Paint
        protected override void OnPaint(PaintEventArgs e)
        {
            LoadBackgroundImageIfInvalid();
            e.Graphics.DrawImage(BackGroundImage, 0, 0);
        }
        #endregion

        #region On Paint Background
        protected override void OnPaintBackground(PaintEventArgs e)
        {

        }
        #endregion

        #region On Mouse Down
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (CaptureMouseCoordinates) { return; }
            
            CaptureMouseCoordinates = true;
            
            inkAction = this.ink.Action;

            if (inkAction.Equals(InkActionType.WriteType))
            {
                WriteMouseDown(e);               
            }
            else
            {
                EraseMouseAction(e);                                
            }
        }

        private void WriteMouseDown(MouseEventArgs e)
        {
            Points.Add(new Point(e.X, e.Y));
            LastMouseCoordinates.X = e.X;
            LastMouseCoordinates.Y = e.Y; 
        }
        
        #endregion

        #region On Mouse Move
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (!CaptureMouseCoordinates) { return; }

            if (inkAction.Equals(InkActionType.WriteType))
            {
                WriteMouseMove(e);
            }
            else
            {
                EraseMouseAction(e);
            }
        }

        private void WriteMouseMove(MouseEventArgs e)
        {
            Points.Add(new Point(e.X, e.Y));

            GraphicsHandle.DrawLine(ink.PenInk, LastMouseCoordinates.X, LastMouseCoordinates.Y, e.X, e.Y);

            LastMouseCoordinates.X = e.X;
            LastMouseCoordinates.Y = e.Y;

            Invalidate();
        }

        #endregion

        #region On Mouse Up
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            CaptureMouseCoordinates = false;
            if (inkAction.Equals(InkActionType.WriteType))
            {
                WriteMouseUp(e);
            }
            else
            {
                EraseMouseAction(e);
            }
        }

        private void WriteMouseUp(MouseEventArgs e)
        {
            Points.Add(new Point(e.X, e.Y));
            Point[] pts = new Point[Points.Count];
            Points.CopyTo(pts, 0);
            Points.Clear();
            ink.AddNewStroke(pts);
            if (ink.Optimize)
                this.ReDraw();
        }
        #endregion

        private void EraseMouseAction(MouseEventArgs e)
        {
            ink.EraseStrokeAtPoint(new Point(e.X, e.Y), 0.5);
        }

        
        #region On Resize
        // TODO: Vefify resizing control
        /*
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.Size = this.ink.Owner.Size;

            this.ReDraw();
        }
         */
        #endregion

        #region ReDraw
        public void ReDraw()
        {
            try
            {
                if (ink.Strokes.Count < 1) { return; }

                Pen pen = new Pen(Color.Black);
                foreach (Stroke s in (ink.Strokes as Strokes).StrokeLines)
                {
                    pen.Color = s.Color;
                    pen.DashStyle = s.DashStyle;
                    pen.Width = s.Width;
                    if (s.Points.Length > 1)
                        GraphicsHandle.DrawLines(pen, s.Points);
                }
                pen.Dispose();

                Invalidate();
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                throw; 
            }
        }
        #endregion

        #region Clear
        public void Clear()
        {
            try
            {
                LoadBackgroundImage();
                Invalidate();
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Load Background Image If Invalid
        private void LoadBackgroundImageIfInvalid()
        {
            try
            {
                if (BackGroundImage == null || BackGroundImage.Width != this.Width || BackGroundImage.Height != this.Height)                
                {
                    LoadBackgroundImage();
                }
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Load Background Images
        private void LoadBackgroundImage()
        {
            try
            {
                bool cleanBmp = false;
                if (BackGroundImage != null)
                    BackGroundImage.Dispose();
                switch (type)
                {
                    case InkControlType.BitmapClean:
                        BackGroundImage = new Bitmap(Width, Height);
                        cleanBmp = true;
                        break;
                    case InkControlType.ExternFile:
                        BackGroundImage = new Bitmap(Path.Combine(AppPath, ImageFileName));
                        BackGroundImage = (Bitmap)ResizeImage(BackGroundImage, Width, Height);
                        break;
                    case InkControlType.SpecificBitmap:
                        BackGroundImage = (Bitmap)SpecificBitmap.Clone();
                        BackGroundImage = (Bitmap)ResizeImage(BackGroundImage, Width, Height);
                        break;
                    default:
                        throw new Exception();
                }
                GraphicsHandle = Graphics.FromImage(BackGroundImage);
                if (cleanBmp)
                    GraphicsHandle.Clear(Color.Wheat); 
            }
            catch (Exception) { throw; }
        }

        private Image ResizeImage(Image img, int newWidth, int newHeight)
        {
            Bitmap result;
            Graphics g;

            result = new Bitmap(newWidth, newHeight);
            g = Graphics.FromImage(result);
            g.DrawImage(img, new Rectangle(0, 0, newWidth, newHeight), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, null);
            img.Dispose();
            img = (Bitmap)result.Clone();
            result.Dispose();
            return img;
        }
        #endregion

    }

}
