using System;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using LAC.Ink.Interfaces;
using LAC.Ink.Enums;
using LAC.Ink.Events.Arguments;

namespace LAC.Ink
{
    public delegate void NewStrokeEventHandler(object sender, NewStrokeArgs e);

    public delegate void StrokeRemovedEventHandler(object sender, StrokeRemovedArgs e);

    public class Ink : IInk
    {
        #region Constants

        //Default Color
        private Color DEFAULT_COLOR = Color.Black;
        //Default Transparency
        private int DEFAULT_TRANSPARENCY = 255;
        //Default DashStyle
        private const DashStyle DEFAULT_DASH_STYLE = DashStyle.Solid;
        //Default Width
        private const int DEFAULT_WIDTH = 1;

        #endregion

        #region Attributes
        //Control 
        private Control owner;
        //Action Type
        private InkActionType inkAction = InkActionType.WriteType;
        //Strokes
        private Strokes strokes;
        //InkControl
        private InkControl inkControl;
        //Enabling drawing
        private bool enabled = false;
        //Color
        private Color currentColor;
        //Transparency
        private int currentTransparency;
        //Dash Style
        private DashStyle currentDashStyle;
        //Width
        private int currentWidth;
        //Pen
        private Pen pen;
        //optimize draw
        private bool makeOptimal = false;
        #endregion

        #region Constructors
        //No-args constructor
        public Ink()
        {
            this.strokes = new Strokes();
            this.CurrentColor = DEFAULT_COLOR;
            this.CurrentDashStyle = DEFAULT_DASH_STYLE;
            this.CurrentWidth = DEFAULT_WIDTH;
            this.CurrentTransparency = DEFAULT_TRANSPARENCY;
        }

        //Main constructor BitmapClean
        public Ink(Control owner)
            : this()
        {
            this.owner = owner;
            try
            {
                inkControl = new InkControl(this);
                inkControl.Location = new Point(0, 0);
                inkControl.Size = this.Owner.Size;
                //inkControl.Dock = DockStyle.Fill;
                this.Owner.Controls.Add(inkControl);
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }

        //Main Construnctor SpecificBitmap
        public Ink(Control owner, Bitmap bmpBackGround)
            : this()
        {
            this.owner = owner;
            try
            {
                inkControl = new InkControl(this, bmpBackGround);
                inkControl.Location = new Point(0, 0);
                inkControl.Size = this.Owner.Size;
                //inkControl.Dock = DockStyle.Fill;
                this.Owner.Controls.Add(inkControl);
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }

        //Main Construnctor ExternFile
        public Ink(Control owner, string ApplicationPath, string BaseImageFileName)
            : this()
        {
            this.owner = owner;
            try
            {
                inkControl = new InkControl(this, ApplicationPath, BaseImageFileName);
                inkControl.Location = new Point(0, 0);
                inkControl.Size = this.Owner.Size;
                //inkControl.Dock = DockStyle.Fill;
                this.Owner.Controls.Add(inkControl);
            }
            catch (Exception err) { MessageBox.Show(err.Message); }

        }

        #endregion

        #region Properties

        //Enabling ink
        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                enabled = value;
            }

        }

        //Owner 
        public Control Owner
        {
            get
            {
                return owner;
            }
        }

        //Action Type
        public InkActionType Action
        {
            get
            {
                return inkAction;
            }
            set
            {
                inkAction = value;
            }
        }

        //Current Color
        public Color CurrentColor
        {
            get
            {
                return currentColor;
            }
            set
            {
                currentColor = value;
            }
        }

        //Current Transparency
        public int CurrentTransparency
        {
            get
            {
                return currentTransparency;
            }
            set
            {
                if (value < 0)
                    currentTransparency = 0;
                else if (value > 255)
                    currentTransparency = 255;
                else
                    currentTransparency = value;
            }
        }

        //DashStyle
        public DashStyle CurrentDashStyle
        {
            get
            {
                return currentDashStyle;
            }
            set
            {
                currentDashStyle = value;
            }
        }

        //Width
        public int CurrentWidth
        {
            get
            {
                return currentWidth;
            }
            set
            {
                currentWidth = value;
            }
        }

        public Pen PenInk
        {
            get
            {
                if (pen == null)
                {
                    pen = new Pen(DEFAULT_COLOR, DEFAULT_WIDTH);
                    pen.DashStyle = DEFAULT_DASH_STYLE;
                }
                pen.Color = CurrentColor;
                pen.Width = CurrentWidth;
                pen.DashStyle = CurrentDashStyle;
                return pen;
            }
        }

        public bool Optimize
        {
            get
            {
                return makeOptimal;
            }
            set
            {
                makeOptimal = value;
            }
        }

        #endregion

        #region Erase Events

        public void Clear()
        {
            Stroke[] allStrokes = (Stroke[])strokes.StrokeLines.ToArray(typeof(Stroke));
            strokes.Clear();
            
            inkControl.Clear();
            this.Repaint();

            StrokeRemovedArgs e = new StrokeRemovedArgs(allStrokes);
            OnStrokesRemovedEvent(e);
        }

        public void EraseLastStroke()
        {
            if (strokes.Count <= 0)
                return;
            
            int index = strokes.Count - 1;
            Stroke stroke = (Stroke)strokes[index];
            
            this.strokes.StrokeLines.RemoveAt(index);

            inkControl.Clear();
            this.Repaint();

            StrokeRemovedArgs e = new StrokeRemovedArgs(stroke);
            OnStrokesRemovedEvent(e);
        }

        public bool EraseStrokeAtPoint(Point point, double radius)
        {
            if (Strokes.Count < 1) { return false; }
            foreach (Stroke stroke in strokes.StrokeLines)
            {
                if (stroke.IntersectPoint(point, radius))
                {
                    strokes.Remove(stroke);
                    
                    inkControl.Clear();
                    this.Repaint();

                    StrokeRemovedArgs e = new StrokeRemovedArgs(stroke);
                    OnStrokesRemovedEvent(e);                    
                    return true ;
                }                               
            }
            return false;
        }

        #endregion

        #region Stroke Draw Events

        public void AddStroke(Stroke strokeAdd)
        {
            if (strokes.GetStroke(strokeAdd.Id) == null)
            {
                this.strokes.Add(strokeAdd);
            }
        }

        public void AddNewStroke(Point[] points)
        {
            Stroke stroke = new Stroke(this, points, CurrentColor, CurrentTransparency, CurrentDashStyle, CurrentWidth);
            this.strokes.Add(stroke);

            NewStrokeArgs e = new NewStrokeArgs(stroke);
            OnNewStrokeEvent(e);
        }

        public void Repaint()
        {
            inkControl.ReDraw();
        }

        public void ScaleInk(int originalWidth, int originalHeight, int newWidth, int newHeight)
        {
            this.strokes.ScaleStrokes(originalWidth, originalHeight, newWidth, newHeight);
        }
        #endregion

        #region IInk Members
        public IStrokes Strokes
        {
            get
            {
                return this.strokes;
            }
        }

        public void Load(byte[] inkData)
        {
            MemoryStream mem = new MemoryStream(inkData);
            BinaryReader binReader = new BinaryReader(mem);
            try
            {
                //number of strokes
                int nS = binReader.ReadInt32();
                for (int i = 0; i < nS; i++)
                {
                    //id
                    String sId = binReader.ReadString();
                    Guid id = new Guid(sId);
                    //color
                    int colorR = binReader.ReadInt32();
                    int colorG = binReader.ReadInt32();
                    int colorB = binReader.ReadInt32();
                    Color colorStroke = Color.FromArgb(colorR, colorG, colorB);
                    //transparency
                    int transparency = binReader.ReadInt32();
                    //dash style
                    int dsHS = binReader.ReadInt32();
                    DashStyle ds;
                    if (dsHS == 0)
                        ds = DashStyle.Solid;
                    else
                        ds = DashStyle.Dash;
                    //width
                    int width = binReader.ReadInt32();
                    //points
                    int pointsNumber = binReader.ReadInt32();
                    Point[] points = new Point[pointsNumber];
                    for (int j = 0; j < pointsNumber; j++)
                    {
                        //X
                        int X = binReader.ReadInt32();
                        //Y
                        int Y = binReader.ReadInt32();

                        //new point
                        points[j] = new Point(X, Y);
                    }
                    Stroke stroke = new Stroke(this, points, colorStroke, transparency, ds, width, id);
                    this.strokes.Add(stroke);
                }
                mem.Flush();
                binReader.Close();
            }
            catch (Exception e)
            {
                binReader.Close();
                Console.WriteLine(e.Message);
            }
        }

        public byte[] Save()
        {
            MemoryStream mem = new MemoryStream();
            BinaryWriter binWriter = new BinaryWriter(mem);
            try
            {
                //number of strokes
                binWriter.Write(strokes.Count);
                foreach (Stroke s in strokes.StrokeLines)
                {
                    //Id
                    binWriter.Write(s.Id.ToString());
                    //color
                    binWriter.Write((int)s.Color.R);
                    binWriter.Write((int)s.Color.G);
                    binWriter.Write((int)s.Color.B);
                    //transparency
                    binWriter.Write(s.Transparency);
                    //Dash style
                    if (s.DashStyle == DashStyle.Solid)
                        binWriter.Write(0);
                    else
                        binWriter.Write(1);
                    //Width
                    binWriter.Write(s.Width);
                    //Points
                    binWriter.Write(s.Points.Length);
                    foreach (Point p in s.Points)
                    {
                        //X
                        binWriter.Write(p.X);
                        //Y
                        binWriter.Write(p.Y);
                    }
                    //ExtendedProperties
                }
                binWriter.Flush();
                //                
                byte[] inkData = new byte[mem.Length];
                inkData = mem.ToArray();
                binWriter.Close();
                return inkData;
            }
            catch (Exception e)
            {
                binWriter.Close();
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public IStrokes CreateStrokes(Guid[] ids)
        {
            //TODO: Implement
            return null;
        }

        public IInk ExtractStrokes(IStrokes strokes, ExtractFlags extractionFlags)
        {
            //TODO: Implement
            return null;
        }

        #endregion

        #region Delegate Events

        public event NewStrokeEventHandler NewStrokeEvent;

        protected virtual void OnNewStrokeEvent(NewStrokeArgs e)
        {
            if (NewStrokeEvent != null)
            {
                NewStrokeEvent(this, e);
            }
        }

        public event StrokeRemovedEventHandler StrokesRemovedEvent;

        protected virtual void OnStrokesRemovedEvent(StrokeRemovedArgs e)
        {
            if (StrokesRemovedEvent != null)
            {
                StrokesRemovedEvent(this, e);
            }
        }
        #endregion
    }
}