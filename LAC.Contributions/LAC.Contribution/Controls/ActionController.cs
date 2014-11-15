using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using LAC.Functions.Forms;
using LAC.Contribution.Enums;
using LAC.Contribution.Objects;

namespace LAC.Contribution
{
    /// <summary>
    /// This class adds events to the owner's contribution control 
    /// to insert and remove contributions.
    /// </summary>
    public class ActionController
    {
        #region Members

        //Owner
        private ContributionComponent myOwner;

        //Event handlers
        private MouseEventHandler controlMouseDown = null;
        private MouseEventHandler controlMouseMove = null;
        private MouseEventHandler controlMouseUp = null;

        //Ink
        private Pen myPen;
        private ArrayList Points = new ArrayList();
        private Point LastMouseCoordinates = new Point(0, 0);
        private bool CaptureMouseCoordinates = false;

        //Size
        Size contributionSize = new Size(0, 0);

        #endregion

        #region Ctors

        public ActionController(ContributionComponent owner)
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
                    this.myPen = new Pen(this.myOwner.InkColor);
                this.myPen.Color = this.myOwner.InkColor;
                this.myPen.Width = this.myOwner.InkWidth;
                return this.myPen;
            }
        }

        #endregion

        #region Events

        public void AddPaintEvents()
        {
            //OnMouseDown
            if (controlMouseDown == null)
                controlMouseDown = new MouseEventHandler(ControlMouseDown);
            this.myOwner.Owner.MouseDown += controlMouseDown;

            //OnMouseMove
            if (controlMouseMove == null)
                controlMouseMove = new MouseEventHandler(ControlMouseMove);
            this.myOwner.Owner.MouseMove += controlMouseMove;

            //OnMouseUp
            if (controlMouseUp == null)
                controlMouseUp = new MouseEventHandler(ControlMouseUp);
            this.myOwner.Owner.MouseUp += controlMouseUp;

            //Invalidate
            this.myOwner.Owner.ControlInvalidate();
        }

        public void RemovePaintEvents()
        {
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

            //Invalidate
            this.myOwner.Owner.ControlInvalidate();
        }

        #endregion

        #region Actions

        private void ControlMouseDown(object sender, MouseEventArgs e)
        {
            if (!this.myOwner.Enabled) { return; }

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
                    this.RemoveContribution(typeof(Stroke), e.X, e.Y, this.myOwner.InkWidth);
                    break;
                case ActionType.TextWriteType:                    
                    break;
                case ActionType.TextEraseType:
                    this.RemoveContribution(typeof(Text), e.X, e.Y, 0);
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
                    //Adding point to array of points
                    Points.Add(new Point(e.X, e.Y));
                    //Drawing stroke...
                    this.DrawStrokeLine(LastMouseCoordinates.X, LastMouseCoordinates.Y, e.X, e.Y);                                    
                    //Updating last mouse point with current
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
                    this.AddStroke(pts);
                    break;
                case ActionType.InkEraseType:
                    break;
                case ActionType.TextWriteType:
                    this.AddText(e.X, e.Y);                    
                    break;
                case ActionType.TextEraseType:
                    break;
                default:
                    throw new Exception("Action Type is undefined.");
            }
        }

        #endregion

        #region Contribution Draw

        private void DrawStrokeLine(int formerX, int formerY, int newX, int newY)
        {
            Graphics g = this.myOwner.Owner.GetGraphics();
            g.DrawLine(this.InkPen, formerX, formerY, newX, newY);
            g.Dispose();
            this.myOwner.Owner.ControlInvalidate();
        }

        private void DrawText(Text text)
        {
            Graphics g = this.myOwner.Owner.GetGraphics();
            text.Draw(g);
            g.Dispose();
        }

        #endregion

        #region Contribution 

        private void AddStroke(Point[] pts)
        {
            Size baseSize = this.myOwner.Owner.GetSize();
            Stroke stroke = new Stroke(baseSize.Width, baseSize.Height, pts, this.myOwner.InkColor, this.myOwner.InkWidth);
            this.myOwner.Contributions.InsertContribution(stroke, true);
            this.myOwner.Owner.ControlInvalidate();
        }

        private void AddText(int X, int Y)
        {
            InputBoxForm frmIB = new InputBoxForm("Contribution", "Text:", "", false);
            if (frmIB.ShowDialog() == DialogResult.OK)
            {
                if (frmIB.Result.Length > 0)
                {
                    Size baseSize = this.myOwner.Owner.GetSize();
                    Text text = new Text(baseSize.Width, baseSize.Height, new Point(X, Y), frmIB.Result, this.myOwner.TextFont, this.myOwner.TextColor);
                    this.DrawText(text);
                    this.myOwner.Contributions.InsertContribution(text, true);
                    this.myOwner.Owner.ControlInvalidate();
                }
            }
            frmIB.Dispose();
        }

        private void RemoveContribution(Type contributionType, int X, int Y, int eraserSize)
        {
            ContributionBaseObject cbObj = this.myOwner.Contributions.IntersectObject(contributionType, new Point(X, Y), eraserSize);
            if (cbObj != null)
            {
                this.myOwner.Contributions.RemoveContribution(cbObj, true);
                this.myOwner.Owner.Refresh();
            }
        }

        #endregion
    }
}
