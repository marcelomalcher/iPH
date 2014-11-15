using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using iPH.Commons.Presentation.Arguments;

namespace iPH.Commons.Presentation.Controls
{
    public partial class DeckPanel : UserControl
    {
        #region Constants
        
        private const int PEN_WIDTH = 5;

        private static readonly Color PEN_COLOR = Color.Red;
        
        #endregion

        #region Members       
        
        private Deck myDeck;
        
        private Slide mySelectedSlide;
        
        private List<DeckSlidePanel> myDeckSlidePanelList;
        
        private int selectedWidth = PEN_WIDTH;
        
        private Color selectedColor = PEN_COLOR;
       
        #endregion

        #region Ctors

        public DeckPanel()
        {
            InitializeComponent();
            this.myDeckSlidePanelList = new List<DeckSlidePanel>();
        }

        #endregion

        #region Props

        public Deck Deck
        {
            get
            {
                return this.myDeck;
            }
            set
            {
                if (this.myDeck != null)
                {
                    this.Clear();
                    this.myDeck.Slides.NewSlideEvent -= new Slides.NewSlideEventHandler(this.NewSlide);
                    this.myDeck.Slides.SlidesRemovedEvent -= new Slides.SlidesRemovedEventHandler(this.SlidesRemoved);
                }
                this.myDeck = value;
                this.myDeck.Slides.NewSlideEvent += new Slides.NewSlideEventHandler(this.NewSlide);
                this.myDeck.Slides.SlidesRemovedEvent += new Slides.SlidesRemovedEventHandler(this.SlidesRemoved);
                this.GenerateDeckSlidePanelList();
            }
        }

        public Slide SelectedSlide
        {
            get
            {
                return this.mySelectedSlide;
            }
            set
            {
                if (this.mySelectedSlide == null || value == null || !this.mySelectedSlide.Guid.Equals(value.Guid))
                {
                    Slide formerSelectedSlide = this.mySelectedSlide;
                    this.mySelectedSlide = value;
                    this.RefreshDeckSlidePanel(formerSelectedSlide);
                    this.RefreshDeckSlidePanel(this.mySelectedSlide);
                }
            }
        }

        public int SelectedWidth
        {
            get
            {
                return this.selectedWidth;
            }
            set
            {
                this.selectedWidth = value;
                this.RefreshDeckSlidePanel(this.mySelectedSlide);
            }
        }

        public Color SelectedColor
        {
            get
            {
                return this.selectedColor;
            }
            set
            {
                this.selectedColor = value;
                this.RefreshDeckSlidePanel(this.mySelectedSlide);
            }
        }

        #endregion

        #region Operations

        public void Clear()
        {
            this.mySelectedSlide = null;
            foreach (DeckSlidePanel d in this.myDeckSlidePanelList)
                d.UpdateControlDispose();
            this.myDeckSlidePanelList.Clear();
        }

        public void RefreshDeckSlidePanel(Slide slide)
        {
            DeckSlidePanel d = this.GetDeckSlidePanel(slide);
            if (d != null)
            {
                d.Refresh();
            }
        }

        public void RefreshDeckSlidePanel()
        {
            foreach(DeckSlidePanel d in this.myDeckSlidePanelList)
            if (d != null)
            {
                d.Refresh();
            }
        }

        /// <summary>
        /// Generate list of slides
        /// </summary>
        private void GenerateDeckSlidePanelList()
        {
            int index = 0;
            foreach (Slide s in myDeck.Slides.List)
            {
                this.InsertDeckPanelSlide(index, s);
                index = index + 1;
            }
        }

        public void SetDeckSlidePanel(DeckSlidePanel deckSlidePanel)
        {
            if (!deckSlidePanel.Slide.Equals(this.SelectedSlide))
            {
                //Update SelectedSlide with slide from the item that was clicked
                this.SelectedSlide = deckSlidePanel.Slide;
                //Fire event..
                SelectedSlideArgs e = new SelectedSlideArgs(this.SelectedSlide);
                OnSelectedSlideEvent(e);
            }
            else
            {
                deckSlidePanel.Refresh();
            }
        }

        #endregion

        #region Methods

        private DeckSlidePanel GetDeckSlidePanel(Slide s)
        {
            foreach (DeckSlidePanel d in this.myDeckSlidePanelList)
            {
                if (d.Slide.Equals(s))
                    return d;
            }
            return null;
        }

        private bool InsertDeckPanelSlide(int index, Slide slide)
        {
            //Checking if already exists a DeckSlidePanel 
            DeckSlidePanel deckSlidePanel = this.GetDeckSlidePanel(slide);
            if (deckSlidePanel == null)
            {
                deckSlidePanel = this.CreateNewDeckSlidePanel(index, slide);                
                this.myDeckSlidePanelList.Insert(index, deckSlidePanel);
                return true;
            }
            else
            {
                if (this.myDeckSlidePanelList.IndexOf(deckSlidePanel) != index)
                {
                    this.myDeckSlidePanelList.Remove(deckSlidePanel);
                    this.myDeckSlidePanelList.Insert(index, deckSlidePanel);
                    this.UpdateControlsSetChild(deckSlidePanel, ((this.GetControlsCount() - 1) - index));
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Remove item with the slide
        /// </summary>
        /// <param name="slide"></param>
        /// <returns></returns>
        private bool RemoveDeckPanelSlide(Slide slide)
        {
            DeckSlidePanel deckSlidePanel = this.GetDeckSlidePanel(slide);
            if (deckSlidePanel == null)
                return false;
            this.myDeckSlidePanelList.Remove(deckSlidePanel);
            deckSlidePanel.UpdateControlDispose();
            return true;
        }


        #endregion

        #region Events

        private void NewSlide(object sender, NewSlideArgs e)
        {
            this.InsertDeckPanelSlide(e.Index, e.Slide);
        }

        private void SlidesRemoved(object sender, SlidesRemovedArgs e)
        {
            foreach (Slide s in e.Slides)
            {
                this.RemoveDeckPanelSlide(s);
            }
        }

        #endregion

        #region Delegate Events

        public delegate void SelectedSlideEventHandler(object sender, SelectedSlideArgs e);
        public event SelectedSlideEventHandler SelectedSlideEvent;
        protected virtual void OnSelectedSlideEvent(SelectedSlideArgs e)
        {
            if (SelectedSlideEvent != null)
            {
                SelectedSlideEvent(this, e);
            }
        }

        #endregion

        #region Delegates
        private delegate DeckSlidePanel CreateNewDeckSlidePanelDelegate(int index, Slide slide);
        public DeckSlidePanel CreateNewDeckSlidePanel(int index, Slide slide)
        {
            DeckSlidePanel deckSlidePanel;
            //Invoking.. 
            if (this.InvokeRequired)
            {
                return (DeckSlidePanel)this.Invoke(new CreateNewDeckSlidePanelDelegate(CreateNewDeckSlidePanel), new Object[] { index, slide });                
            }
            //Creating deckSlidePanel..
            deckSlidePanel = new DeckSlidePanel(this, slide);
            //Adding control...
            this.Controls.Add(deckSlidePanel);
            //Setting corrent index
            this.Controls.SetChildIndex(deckSlidePanel, (this.Controls.Count - 1) - index);
            //returning deckSlidePanel...
            return deckSlidePanel;
        }

        private delegate int GetControlsCountDelegate();
        public int GetControlsCount()
        {
            if (this.InvokeRequired)
            {
                return (int)this.Invoke(new GetControlsCountDelegate(GetControlsCount), new Object[] { });
            }
            return this.Controls.Count;
        }

        private delegate void UpdateControlsSetChildDelegate(DeckSlidePanel deckSlidePanel, int index);
        public void UpdateControlsSetChild(DeckSlidePanel deckSlidePanel, int index)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateControlsSetChildDelegate(UpdateControlsSetChild), new Object[] { deckSlidePanel, index });
                return;
            }
            this.Controls.SetChildIndex(deckSlidePanel, index);
        }
        #endregion

    }
}
