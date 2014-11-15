using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using LAC.Contribution.Enums;
using LAC.Contribution.Objects;

namespace LAC.Contribution
{
    public class Controller
    {
        #region Members

        //Owner
        private ContributionComponent myOwner;

        //Event handlers
        private PaintEventHandler controlPaint = null;
        private MouseEventHandler controlMouseDown = null;
        private MouseEventHandler controlMouseMove = null;
        private MouseEventHandler controlMouseUp = null;
        private EventHandler controlResize = null;

        //Ink
        private Pen myPen;
        private ArrayList Points = new ArrayList();
        private Point LastMouseCoordinates = new Point(0, 0);
        private bool CaptureMouseCoordinates = false;

        #endregion

        #region Ctors

        public Controller(ContributionComponent owner)
        {
            this.myOwner = owner;
        }

        #endregion

        #region Properties

        private Pen InkPen
        {
            get
            {
                if (this.myPen == null)
                {
                    this.myPen = new Pen(this.myOwner.InkColor, this.myOwner.InkWidth);
                }
                else
                {
                    this.myPen.Color = this.myOwner.InkColor;
                    this.myPen.Width = this.myOwner.InkWidth;
                }
                return this.myPen;
            }
        }

        private Image PaintImage
        {
            get
            {
                if (this.myOwner.Owner.Image == null || this.myOwner.Owner.Image.Width != this.myOwner.Owner.Width || this.myOwner.Owner.Image.Height != this.myOwner.Owner.Height)
                {
                    this.myOwner.Owner.Image = this.myOwner.Owner.GetImage();
                    Graphics g = Graphics.FromImage(this.myOwner.Owner.Image);
                    this.RedrawContributions(g);
                    g.Dispose();
                }
                return this.myOwner.Owner.Image;
            }
        }

        #endregion

        #region Methods

        public void AddPaintEvents()
        {
            //OnPaint
            controlPaint = new PaintEventHandler(ControlPaint);
            this.myOwner.Owner.Paint += controlPaint;

            //OnMouseDown
            controlMouseDown = new MouseEventHandler(ControlMouseDown);
            this.myOwner.Owner.MouseDown += controlMouseDown;

            //OnMouseMove
            controlMouseMove = new MouseEventHandler(ControlMouseMove);
            this.myOwner.Owner.MouseMove += controlMouseMove;

            //OnMouseUp
            controlMouseUp = new MouseEventHandler(ControlMouseUp);
            this.myOwner.Owner.MouseUp += controlMouseUp;

            //OnResize
            controlResize = new EventHandler(ControlResize);
            this.myOwner.Owner.Resize += controlResize;

            //Invalidate
            this.myOwner.Owner.Invalidate();
        }

        public void RemovePaintEvents()
        {
            //OnPaint
            if (controlPaint != null)
            {
                this.myOwner.Owner.Paint -= controlPaint;
                controlPaint = null;
            }

            //OnMouseDown
            if (controlMouseDown != null)
            {
                this.myOwner.Owner.MouseDown -= controlMouseDown;
                controlMouseDown = null;
            }

            //OnMouseMove
            if (controlMouseMove != null)
            {
                this.myOwner.Owner.MouseMove -= controlMouseMove;
                controlMouseMove = null;
            }

            //OnMouseUp
            if (controlMouseUp != null)
            {
                this.myOwner.Owner.MouseUp -= controlMouseUp;
                controlMouseUp = null;
            }

            //OnResize
            if (controlResize != null)
            {
                this.myOwner.Owner.Resize -= controlResize;
                controlResize = null;
            }

            //Invalidate
            this.myOwner.Owner.Invalidate();
        }

        #endregion

        #region PaintEvents

        private void ControlPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(PaintImage, 0, 0);
        }

        private void ControlMouseDown(object sender, MouseEventArgs e)
        {
            if (!this.myOwner.Enabled) { return; }
            
            ContributionBaseObject cbObj = null; 
            switch (this.myOwner.Action)
            {
                case ActionType.InkWriteType:
                    if (CaptureMouseCoordinates) { return; }
                    CaptureMouseCoordinates = true;
                    Points.Add(new Point(e.X, e.Y));
                    LastMouseCoordinates.X = e.X;
                    LastMouseCoordinates.Y = e.Y;
                    break;
                case ActionType.InkEraseType:
                    cbObj = this.myOwner.Contributions.IntersectObject(typeof(Stroke), new Point(e.X, e.Y), this.myOwner.InkWidth);
                    if (cbObj != null)
                    {
                        this.myOwner.RemoveContribution(cbObj, true);
                        this.myOwner.Owner.Image = null;
                        this.myOwner.Owner.Invalidate();
                    }
                    break;
                case ActionType.TextWriteType:                    
                    break;
                case ActionType.TextEraseType:
                    cbObj = this.myOwner.Contributions.IntersectObject(typeof(Text), new Point(e.X, e.Y), 0);
                    if (cbObj != null)
                    {
                        this.myOwner.RemoveContribution(cbObj, true);
                        this.myOwner.Owner.Image = null;
                        this.myOwner.Owner.Invalidate();
                    }
                    break;
                default:
                    throw new Exception("Action Type is undefined.");
            }
        }

        private void ControlMouseMove(object sender, MouseEventArgs e)
        {
            if (!this.myOwner.Enabled) { return; }

            switch (this.myOwner.Action)
            {
                case ActionType.InkWriteType:
                    if (!CaptureMouseCoordinates) { return; }
                    Points.Add(new Point(e.X, e.Y));
                    Graphics g = Graphics.FromImage(this.PaintImage);
                    g.DrawLine(this.InkPen, LastMouseCoordinates.X, LastMouseCoordinates.Y, e.X, e.Y);
                    g.Dispose();
                    this.myOwner.Owner.Invalidate();                                       
                    LastMouseCoordinates.X = e.X;
                    LastMouseCoordinates.Y = e.Y;                    
                    break;
                case ActionType.InkEraseType:
                    break;
                case ActionType.TextWriteType:
                    break;
                case ActionType.TextEraseType:
                    break;
                default:
                    throw new Exception("Action Type is undefined.");
            }
        }

        private void ControlMouseUp(object sender, MouseEventArgs e)
        {
            if (!this.myOwner.Enabled) { return; }

            switch (this.myOwner.Action)
            {
                case ActionType.InkWriteType:
                    CaptureMouseCoordinates = false;
                    Points.Add(new Point(e.X, e.Y));
                    Point[] pts = new Point[Points.Count];
                    Points.CopyTo(pts, 0);
                    Points.Clear();
                    Stroke stroke = new Stroke(pts, this.myOwner.InkColor, this.myOwner.InkWidth);
                    this.myOwner.AddContribution(stroke, true);
                    break;
                case ActionType.InkEraseType:
                    break;
                case ActionType.TextWriteType:
                    InputBoxForm frmIB = new InputBoxForm("Contribution", "Text:", "", false);
                    if (frmIB.ShowDialog() == DialogResult.OK)
                    {
                        if (frmIB.Result.Length > 0)
                        {
                            Text text = new Text(new Point(e.X, e.Y), frmIB.Result, this.myOwner.TextFont, this.myOwner.TextColor);
                            Graphics g = Graphics.FromImage(this.PaintImage);
                            text.Draw(g);
                            g.Dispose();
                            this.myOwner.Owner.Invalidate();
                            this.myOwner.AddContribution(text, true);
                        }
                    }
                    frmIB.Dispose();
                    break;
                case ActionType.TextEraseType:
                    break;
                default:
                    throw new Exception("Action Type is undefined.");
            }
        }

        private void ControlResize(object sender, EventArgs e)
        {
            this.myOwner.Owner.Invalidate();
        }


        #endregion

        #region Draw

        private void RedrawContributions(Graphics g)
        {
            for (int i = 0; i < this.myOwner.Contributions.Count; i++)
            {
                this.myOwner.Contributions[i].Draw(g);
            }
        }

        #endregion
    }
}
