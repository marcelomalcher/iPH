using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

//iPH
using iPH.Commons.Configuration;
using iPH.Commons.Context;
using iPH.Commons.Context.Timer;
using iPH.Commons.Functions;
using iPH.Commons.Manager;
using iPH.Commons.Parameters;
using iPH.Commons.Presentation;
using iPH.Commons.Presentation.Arguments;
using iPH.Commons.Presentation.Controls;
using iPH.Commons.Session;
using iPH.Commons.User;
using iPH.Commons.User.Role;

//Contribution
using LAC.Contribution;
using LAC.Contribution.Enums;
using LAC.Contribution.Objects;

//Communications
using LAC.Communications;
using LAC.Communications.Interfaces;

//Context Information
using LAC.ContextInformation;

//Functions
using LAC.Functions.Forms;


namespace iPH.Commons.Forms
{
    public partial class InteractivePresentationForm : Form, ICommunications
    {
        #region Members

        #region Private

        #region Main

        //Session
        private SessionInfo mySession;

        //Participant
        private Participant myParticipant;

        //Control
        private CommunicationControl myCommunicationControl;

        #endregion

        #region Presentation

        //DeckSet Opened
        private string myDeckSetOpened = "";

        //Deck Panel
        private DeckPanel myMainDeckPanel;
        private DeckPanel myContributionDeckPanel;

        //Slide Panel
        private SlidePanel mySlidePanel;

        //Decks
        private Deck myMainDeck;
        private Deck myContributionDeck;

        //Slide
        private Slide myCurrentSlide;

        //Copy & Paste
        private Slide myCurrentCopySlide = null;
        private Contributions myCurrentCopySlideContributions = null;

        #endregion
        
        #region Managers

        //Functions Manager
        private FunctionsManager myFunctionsManager;

        //Contributions Manager
        private ContributionsManager myContributionsManager;

        //Message Manager
        private MessageManager myMessageManager;

        //Participants Manager
        private ParticipantsManager myParticipantsManager;

        //ContextInformation Manager
        private ContextInformationManager myContextInformationManager;

        //Parameters
        private PresentationParameters myPresentationParameters;

        //Configuration
        private InteractiveConfiguration myConfiguration;

        #endregion

        #region Context

        private BaseContextTimer myContextTimer;

        #endregion

        #region Session

        private SessionContextTimer mySessionTimer;

        #endregion

        #region New ones

        private List<String> messages = new List<String>();

        private bool searchSessions = true;

        #endregion


        #region Handlers

        private Contributions.NewContributionEventHandler newContribution = null;

        private Contributions.ContributionRemovedEventHandler contributionRemoved = null;

        #endregion

        #endregion             

        #endregion

        #region Constructors

        #region Public

        public InteractivePresentationForm()
        {
            InitializeComponent();

            //Session
            this.mySession = new SessionInfo();

            //Participant
            this.myParticipant = new Participant();

            //Communication
            this.myCommunicationControl = new CommunicationControl(this);

            //PresentationControls
            this.CreatePresentationControls();

            //Managers
            this.CreateManagers();

            //Parameters
            this.myPresentationParameters = new PresentationParameters();

            //Configuration
            this.CreateConfiguration();

            //Registrando timer de sessão
            this.RegisterSessionTimer();
        }

        #endregion

        #endregion        

        #region Properties

        #region Public 

        public string DeckSetOpened
        {
            get
            {
                return myDeckSetOpened;
            }
            set
            {
                if (value is string)
                    this.myDeckSetOpened = value;
            }
        }

        public SessionInfo Session
        {
            get
            {
                return this.mySession;
            }
        }

        public Participant Participant
        {
            get
            {
                return this.myParticipant;
            }
        }

        public CommunicationControl CommunicationControl
        {
            get
            {
                return this.myCommunicationControl;
            }
        }

        public Deck MainDeck
        {
            get
            {
                return this.myMainDeck;
            }
        }

        public Deck ContributionDeck
        {
            get
            {
                return this.myContributionDeck;
            }
        }

        public Slide CurrentSlide
        {
            get
            {
                return this.myCurrentSlide;
            }
        }

        public SlidePanel SlidePanel
        {
            get
            {
                return this.mySlidePanel;
            }
        }

        public PresentationParameters Parameters
        {
            get
            {
                return this.myPresentationParameters;
            }
        }

        public InteractiveConfiguration Configuration
        {
            get
            {
                return this.myConfiguration;
            }
        }

        public FunctionsManager FunctionsManager
        {
            get
            {
                return this.myFunctionsManager;
            }
        }

        public ContributionsManager ContributionsManager
        {
            get
            {
                return this.myContributionsManager;
            }
        }

        public ParticipantsManager ParticipantsManager
        {
            get
            {
                return this.myParticipantsManager;
            }
        }

        public ContextInformationManager ContextInformationManager
        {
            get
            {
                return this.myContextInformationManager;
            }
        }

        public List<String> Messages
        {
            get
            {
                return this.messages;
            }
        }

        public bool SearchSessions
        {
            get
            {
                return this.searchSessions;
            }
            set
            {
                this.searchSessions = value;
            }
        }

        #endregion

        #endregion

        #region Messages

        public void InsertMessage(String message)
        {
            this.messages.Add(message);
            this.OnNewMessage(message);
        }

        public virtual void OnNewMessage(String message) {}
        

        #endregion

        #region Methods

        // Private Methods

        #region Private

        #region On Creating Form ...

        private void CreatePresentationControls()
        {
            //Main
            this.myMainDeckPanel = new DeckPanel();
            this.myMainDeckPanel.Dock = DockStyle.Fill;
            this.myMainDeckPanel.SelectedSlideEvent += new DeckPanel.SelectedSlideEventHandler(this.MainDeckSelectedSlide);

            //Contribution
            this.myContributionDeckPanel = new DeckPanel();
            this.myContributionDeckPanel.Dock = DockStyle.Fill;
            this.myContributionDeckPanel.SelectedSlideEvent += new DeckPanel.SelectedSlideEventHandler(this.ContributionDeckSelectedSlide);

            //SlidePanel
            this.mySlidePanel = new SlidePanel();
            this.mySlidePanel.Dock = DockStyle.Fill;
            this.mySlidePanel.Click += new EventHandler(OnSlidePanelClick);
        }

        private void CreateManagers()
        {
            this.myFunctionsManager = new FunctionsManager();
            this.myContributionsManager = new ContributionsManager();
            this.myMessageManager = new MessageManager(this);
            this.myParticipantsManager = new ParticipantsManager();
            this.myContextInformationManager = new ContextInformationManager();
        }

        private void CreateConfiguration()
        {
            this.myConfiguration = new InteractiveConfiguration();

            this.myConfiguration.UsesContextInformation = this.GetUsesContextInformation();
            this.myConfiguration.ContextTimerInterval = this.GetContextTimerInterval();
            this.myConfiguration.MocaWSRequestTimeOut = this.GetMocaWSRequestTimeOut();
            this.myConfiguration.MocaWebServiceURL = this.GetMocaWebServiceURL();
            this.myConfiguration.SearchActiveSessions = this.GetSearchActiveSessions();
            this.myConfiguration.SessionTimeInterval = this.GetSessionTimerInterval();
            this.myConfiguration.SessionServiceURL = this.GetSessionServiceURL();
            this.myConfiguration.PublicSlideColor = this.GetPublicSlideColor();
            this.myConfiguration.PrivateSlideColor = this.GetPrivateSlideColor();
        }

        #endregion

        #region Form Events

        private void InteractivePresentationForm_Load(object sender, EventArgs e)
        {
            ///Setting Controls' parents
            this.myMainDeckPanel.Parent = this.GetMainDeckPanelParent();
            this.myContributionDeckPanel.Parent = this.GetContributionsDeckPanelParent();
            this.mySlidePanel.Parent = this.GetSlidePanelParent();
            
            //Creating a new class presentation
            this.ClearPresentation();
            //Update
            this.UpdateVisualControlsAndFunctions();

            #if Test
            MessageBox.Show("*TEST VERSION*", "iPH");
            #endif

        }

        private void InteractivePresentationForm_Closing(object sender, CancelEventArgs e)
        {
            //Disconnecting before close...
            this.Disconnect();
        }

        #endregion

        #region Reset Values

        private void ResetInitialValues()
        {
            //Session
            this.mySession.InitialValues();

            //Participant
            this.myParticipant.InitialValues();

            //Parameters
            this.myPresentationParameters.InitialValues();

            //Participants
            this.myParticipantsManager.Clear();

            //ContextInformationRules
            this.myContextInformationManager.Clear();
        }

        #endregion

        #region Visualize Controls And Functions

        protected virtual void UpdateVisualControlsAndFunctions() { }

        protected void VisualizeControls()
        {
            this.VisualizeMainFunctionsPanel(this.myParticipant.Role.VisualizeMainFunctionsPanel());
            this.VisualizeCoFunctionsPanel(this.myParticipant.Role.VisualizeCoFunctionsPanel());
            this.VisualizeMainDeckPanel(this.myParticipant.Role.VisualizeMainDeckPanel());
            this.VisualizeContributionsDeckPanel(this.myParticipant.Role.VisualizeContributionsDeckPanel());
            this.VisualizeSlidePanel(this.myParticipant.Role.VisualizeSlidePanel());
        }

        protected void UpdateFunctions()
        {
            foreach (BaseFunction baseFunction in this.myFunctionsManager.List)
            {
                this.UpdateFunction(baseFunction);
            }
        }

        private void UpdateFunction(BaseFunction function)
        {
            bool hasFunction = this.myFunctionsManager.HasFunction(this.myParticipant.Role, function);

            if (function is ClassroomPersistenceFunction)
                this.HasClassroomPersistenceFunction(hasFunction);
            else if (function is ContributionFunction)
                this.HasContributionFunction(hasFunction);
            else if (function is ParticipantsManagerFunction)
                this.HasParticipantsManagerFunction(hasFunction);
            else if (function is PresentationEditionFunction)
                this.HasPresentationEditionFunction(hasFunction);
            else if (function is PresentationSendFunction)
                this.HasPresentationSendFunction(hasFunction);
            else if (function is SubmitModificationsFunction)
                this.HasSubmitModificationFunction(hasFunction);
        }

        #endregion

        #region ContextTimer

        private void RegisterContextTimer()
        {
            this.myContextTimer = ContexTimerFactory.GetContextTimer(this.myParticipant.Role, this, this.myConfiguration.ContextTimerInterval, this.myConfiguration.UsesContextInformation);

            if (this.myContextTimer != null && this.myConfiguration.UsesContextInformation)
                this.myContextTimer.Start();
        }

        private void UnregisterContextTimer()
        {
            if (this.myContextTimer != null)
            {
                this.myContextTimer.Stop();
                this.myContextTimer = null;
            }
        }

        private void UpdateContextTimer()
        {
            //Timer de contexto para regras
            if (this.myContextTimer != null)
            {
                this.myContextTimer.SetInterval((int)this.myConfiguration.ContextTimerInterval);

                if (this.myConfiguration.UsesContextInformation)
                    this.myContextTimer.Start();
                else
                    this.myContextTimer.Stop();
            }
        }

        #endregion

        #region SessionService

        private void RegisterSessionTimer()
        {
            this.mySessionTimer = new SessionContextTimer(this, this.myConfiguration.SessionTimeInterval);

            if (this.mySessionTimer != null && this.myConfiguration.SearchActiveSessions)
                this.mySessionTimer.Start();
        }

        private void UnregisterSessionTimer()
        {
            if (this.mySessionTimer != null)
            {
                this.mySessionTimer.Stop();
                this.mySessionTimer = null;
            }
        }

        private void UpdateSessionTimer()
        {
            //Timer de sessão
            if (this.mySessionTimer != null)
            {
                this.mySessionTimer.SetInterval((int)this.myConfiguration.SessionTimeInterval);

                if (this.myConfiguration.SearchActiveSessions)
                    this.mySessionTimer.Start();
                else
                    this.mySessionTimer.Stop();
            }
        }

        //Used by timer and gui widget like button or menu
        public void SearchActiveSessions()
        {
            if (this.Session.Connected)
                return;

            if (this.myConfiguration.SessionServiceURL == "")
                return;

            try
            {
                SessionServiceWrapper sessionFinder = new SessionServiceWrapper(this.myConfiguration.SessionServiceURL);
                string region = GetCurrentRegion();
                if (region == null)
                {                   
                    //MessageBox.Show("Error attempting to recover region. Impossible to look up for session on the service.");
                    InsertMessage("#Error attempting to recover region. Impossible to look up for session on the service.");
                    return;
                }
                SessionService.collaborativeSession[] sessions = sessionFinder.GetSessions(GetCurrentRegion());
                if (sessions != null && sessions.Length > 0)
                {
                    ActiveSessionsForm form = new ActiveSessionsForm(this, sessions);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (form.SelectedSession != null)
                        {   
                            this.Connect(form.SelectedSession.ip, form.SelectedSession.port, form.SelectedSession.password);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                String msgError = "Error has occurred while creating the wrapper object to connect to the iPHSessionService: " + ex.Message;
                Console.WriteLine(msgError);
                InsertMessage(msgError);
                //MessageBox.Show(msgError);
            }            
                        
        }

        private void CreateSession()
        {
            if (!this.Session.Connected)
                return;

            if (!this.myParticipant.Role.Equals(Master.Instance))
                return;

            String region = GetCurrentRegion();
            if (region == null)
            {
                MessageBox.Show("Error attempting to recover region. Impossible to save session on the service.");
                InsertMessage("Error attempting to recover region. Impossible to save session on the service.");
                return;
            }

            try
            {
                SessionServiceWrapper sessionCreator = new SessionServiceWrapper(this.myConfiguration.SessionServiceURL);
                sessionCreator.addSession(region, this.mySession.MulticastIp, this.mySession.Port, this.mySession.Key.Key, this.myParticipant.NickName);

            }
            catch (Exception ex)
            {
                String msgError = "Error has occurred while creating the wrapper object to connect to the iPHSessionService: " + ex.Message;
                Console.WriteLine(msgError);
                InsertMessage(msgError);
                MessageBox.Show(msgError);
            }
        }

        private string GetCurrentRegion()
        {
            string region = "";

            //recovering moca web service            
            try
            {
                ContextWrapper contextwrapper = new ContextWrapper(this.myConfiguration.MocaWebServiceURL);
                region = contextwrapper != null ? contextwrapper.GetAreaFromDevice(this.myParticipant.MacAddress) : "";
            }
            catch (Exception ex)
            {
                Console.WriteLine("error has occurred while creating the wrapper object to connect to the moca/ws: " + ex.Message, "information");
                InsertMessage("error has occurred while creating the wrapper object to connect to the moca/ws: " + ex.Message);
                return null;
            }
            return region;
        }
        

        #endregion

        #region Private Senders

        private void BroadcastConnection()
        {
            //Send only if it is connected
            if (!this.mySession.Connected)
                return;
            //sending message
            this.myMessageManager.SendConnectMessage();
        }

        private void BroadcastDisconnection()
        {
            //Send only if it is connected
            if (!this.mySession.Connected)
                return;
            //sending message
            this.myMessageManager.SendDisconnectMessage();
        }

        private void BroadcastPing()
        {
            //Send only if it is connected
            if (!this.mySession.Connected)
                return;
            //sending message
            this.myMessageManager.SendPingMessage();
        }

        private void BroadcastDeck(Deck deck)
        {
            //Send only if it is connected
            if (!this.mySession.Connected || deck == null || deck.Slides.Count == 0)
                return;
            //Retrieving all contributions
            SlideContribution[] slideContributions = new SlideContribution[deck.Slides.Count];
            int index = 0;
            foreach (Slide s in deck.Slides.List)
            {
                SlideContribution slideContribution = this.myContributionsManager.GetSlideContribution(s.Guid);
                slideContributions[index] = slideContribution;
                index += 1;
            }
            //Sending messages
            this.myMessageManager.SendDeckMessage(deck, slideContributions);
        }

        private void BroadcastSlide(Slide slide)
        {
            //Send only if it is connected
            if (!this.mySession.Connected || slide == null || !slide.SendContributions())
                return;
            //retrieving previous slide guid
            Slide previousSlide = slide.Deck.Slides.PreviousSlide(slide);
            Guid previousSlideGuid = Guid.Empty;
            if (previousSlide != null)
                previousSlideGuid = previousSlide.Guid;
            //retrieving contributions
            Contributions slideContributions = this.GetContributions(slide.Guid);
            //sending 
            this.myMessageManager.SendSlideMessage(slide, previousSlideGuid, slideContributions, 0, true);
        }

        private void BroadcastSubmission(Slide slide)
        {
            //Send only if it is connected
            if (!this.mySession.Connected || slide == null)
                return;
            //retrieving contributions
            Contributions slideContributions = this.GetContributions(slide.Guid);
            //Creating Slide Copy
            Slide submissionSlide = (Slide)slide.Clone();
            //Customizing title for identification
            submissionSlide.Title = submissionSlide.Title + " : " + this.myParticipant.NickName;
            submissionSlide.GenerateNewGuid();
            //sending 
            this.myMessageManager.SendSlideSubmissionMessage(submissionSlide, slideContributions);
        }

        private void BroadcastSubmissionMaster(Slide slide)
        {
            //Send only if it is connected
            if (!this.mySession.Connected || slide == null)
                return;
            //retrieving contributions
            Contributions slideContributions = this.GetContributions(slide.Guid);
            //Creating Slide Copy
            Slide submissionSlide = slide;
            //sending 
            this.myMessageManager.SendSlideSubmissionMasterMessage(submissionSlide, slideContributions);
        }

        private void BroadcastSelectedSlide(Slide slide)
        {
            //Send only if it is connected
            if (!this.mySession.Connected || slide == null)
                return;
            //sending message if the slide belongs to main deck
            if (slide.Deck.Guid.Equals(this.myMainDeck.Guid))
                this.myMessageManager.SendSlideSelectedMessage(slide.Guid, this.myPresentationParameters.SyncViewer);
        }

        private void BroadcastSelectedContributionSlide(Slide slide)
        {
            //Send only if it is connected
            if (!this.mySession.Connected || slide == null)
                return;
            //sending message if the slide belongs to contribution deck
            if (slide.Deck.Guid.Equals(this.myContributionDeck.Guid))
                this.myMessageManager.SendSlideSelectedContributionMessage(slide.Guid, this.myPresentationParameters.SyncViewer);
        }

        private void BroadcastSelectedAttentionSlide(Slide slide)
        {
            //Send only if it is connected
            if (!this.mySession.Connected || slide == null)
                return;
            //sending message if the slide belongs to main deck
            if (slide.Deck.Guid.Equals(this.myMainDeck.Guid))
                this.myMessageManager.SendSlideSelectedAttentionMessage(slide.Guid);
        }

        private void BroadcastContribution(Guid slideGuid, ContributionBaseObject contribution)
        {
            //Send only if it is connected
            if (!this.mySession.Connected || slideGuid == Guid.Empty || contribution == null)
                return;
            //sending
            this.myMessageManager.SendContributionMessage(slideGuid, contribution);
        }

        private void BroadcastContributionRemove(Guid slideGuid, ContributionBaseObject contribution)
        {
            //Send only if it is connected
            if (!this.mySession.Connected || slideGuid == Guid.Empty || contribution == null)
                return;
            //sending
            this.myMessageManager.SendContributionRemoveMessage(slideGuid, contribution.Guid);
        }

        private void BroadcastContextInformationRules()
        {
            //Send only if it is connected
            if (!this.mySession.Connected || this.myContextInformationManager.List.Count <= 0)
                return;
            //sending
            this.myMessageManager.SendContextInformationRulesMessage(this.myContextInformationManager.List.ToArray());
        }

        private void BroadcastAck(int messageId, int type, string observations)
        {
            //Send only if it is connected
            if (!this.mySession.Connected)
                return;
            //sending
            this.myMessageManager.SendAckMessage(messageId, type, observations);
        }
        

        #endregion

        #region Presentation Controls

        private void ClearPresentation()
        {
            //Panels
            //Clearing Deck
            this.myMainDeckPanel.Clear();
            this.myContributionDeckPanel.Clear();
            //Clearing Slide
            if (this.myCurrentSlide != null)
                this.UnregisterContributionComponent(this.myCurrentSlide.Guid);
            this.mySlidePanel.Clear();           
            //Restarting
            this.CreateBlankPresentation();
            //Updating persistence controls
            this.UpdatePersistenceControls(false);
        }

        #endregion

        #region Presentation

        private void CreateBlankPresentation()
        {
            //Deck
            this.myMainDeck = new Deck();
            this.myContributionDeck = new Deck();
            //Slide
            this.myCurrentSlide = null;

            //Setting decks to panels
            this.myMainDeckPanel.Deck = this.myMainDeck;
            this.myContributionDeckPanel.Deck = this.myContributionDeck;

            //Contributions
            this.myContributionsManager.Clear();
        }

        #region Insert Slide

        private bool InsertSlide(Deck deck, int index, Slide slide)
        {
            //Inserting slide
            bool inserted = deck.Slides.InsertSlide(index, slide);
            //Creating component
            this.myContributionsManager.Add(slide.Guid);
            //updating menu options
            if (deck.Slides.Count == 1)
                this.UpdatePersistenceControls(true);
            
            return inserted;
        }

        private void AddSlide(Slide slide)
        {
            this.InsertSlideAtMainDeck(slide, Guid.Empty, 0, false, true);
            
            //sending
            this.BroadcastSlide(slide);
        }

        private void CreateNewSlide(Slide slide)
        {
            InputBoxForm inputBox = new InputBoxForm("Slide", "Title:", "", false);
            if (inputBox.ShowDialog() == DialogResult.OK)
            {
                slide.Title = inputBox.Result;
                this.AddSlide(slide);
            }
            inputBox.Dispose();
        }

        #endregion

        #region Select Slide

        private void SelectSlide(Slide slide)
        {
            this.UpdateCurrentSlide(slide);
        }

        #endregion

        #region Get Slide

        private Slide GetSlide(Deck deck, Guid slideGuid)
        {
            return deck.Slides.GetSlide(slideGuid);
        }

        private Slide GetSlideFromMainDeck(Guid slideGuid)
        {
            return this.GetSlide(this.myMainDeck, slideGuid);
        }

        private Slide GetSlideFromContributionDeck(Guid slideGuid)
        {
            return this.GetSlide(this.myContributionDeck, slideGuid);
        }

        #endregion

        #endregion

        #region Contributions

        private Contributions GetContributions(Guid slideGuid)
        {
            //Getting proper contribution component 
            SlideContribution slideContribution = this.myContributionsManager.GetSlideContribution(slideGuid);
            if (slideContribution != null)
            {
                //Removing Clone()...
                //Contributions cContribuitons = (Contributions)slideContribution.ContributionComponent.Contributions.Clone();
                //return cContribuitons;
                return slideContribution.ContributionComponent.Contributions;
            }
            return null;
        }

        #endregion

        #region Events

        #region Slide Panel Events

        /// <summary>
        /// When a contribuitor clicks at the slide panel,
        /// it stops synchonizing with master
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSlidePanelClick(object sender, EventArgs e)
        {
            //Checking if already is connected
            if (this.mySession.Connected && (this.myParticipant.Role is Contribuitor))
            {
                this.SetSyncMaster(false);
            }
        }

        #endregion

        #region Deck Panel Events

        private void MainDeckSelectedSlide(object sender, SelectedSlideArgs e)
        {
            //Selecting 
            this.SelectSlideAtMainDeck(e.Slide.Guid, true);
        }

        private void ContributionDeckSelectedSlide(object sender, SelectedSlideArgs e)
        {
            //Selecting slide at contribution deck
            this.SelectSlideAtContributionDeck(e.Slide.Guid, true);
        }

        #endregion

        #region Contribution Component Events

        private void NewContributionEvent(object sender, LAC.Contribution.Arguments.NewContributionArgs e)
        {
            //checking if slide is public and if automatic contributions is true
            if (this.myCurrentSlide.SendContributions() && this.myPresentationParameters.AutomaticContributions)
            {
                this.BroadcastContribution(this.myCurrentSlide.Guid, e.Object);
            }
        }

        private void ContributionRemovedEvent(object sender, LAC.Contribution.Arguments.ContributionRemovedArgs e)
        {
            //checking if slide is public and if automatic contributions is true
            if (this.myCurrentSlide.SendContributions() && this.myPresentationParameters.AutomaticContributions)
            {
                this.BroadcastContributionRemove(this.myCurrentSlide.Guid, e.Objects[0]);
            }
        }

        #endregion

        #endregion

        #region Update Slide And Contributions

        private void UpdateCurrentSlide(Slide newCurrentSlide)
        {
            //checking if current slide is not equal to new current slide
            if (this.myCurrentSlide == null || newCurrentSlide == null || (this.myCurrentSlide != null && !this.myCurrentSlide.Guid.Equals(newCurrentSlide.Guid)))
            {
                //Unregistering Contribution Component
                this.UnregisterCurrentSlideContributionComponent();
                //Updating Deck Panels
                this.UpdateDeckPanel(newCurrentSlide);
                //Clearing slide panel
                this.mySlidePanel.Clear();
                //Updating current slide and slide panel
                this.myCurrentSlide = newCurrentSlide;
                //Registering Contribution Component
                this.RegisterCurrentSlideContributionComponent();
                //Setting new Slide;
                this.mySlidePanel.Slide = this.myCurrentSlide;
                //Updating information
                this.UpdateSlideInformationControls();
            }
            //Refreshing slide panel
            this.mySlidePanel.Refresh();
        }

        //iDeck function only shown here for comparison with the correspondent iPH function
        //
        //public void UpdateCurrentSlide(Slide selectedSlide, bool invalidate, bool deckPanelChange)
        //{
        //    this.currentSlide = selectedSlide;
        //    this.mySlidePanel.Slide = this.currentSlide;
        //    if (!deckPanelChange)
        //        this.myDeckPanel.SelectedSlide = this.currentSlide;
        //    this.UpdateInfo();
        //    if (invalidate)
        //    {
        //        if (selectedSlide == null)
        //        {
        //            this.mySlidePanel.Clear();
        //        }
        //        else
        //        {
        //            this.mySlidePanel.Refresh();
        //        }
        //    }
        //}

        private void UpdateDeckPanel(Slide newCurrentSlide)
        {
            //Passing null to selected slides...
            this.myMainDeckPanel.SelectedSlide = null;
            this.myContributionDeckPanel.SelectedSlide = null;
            //Selecting slide at specific deck panel
            if (newCurrentSlide != null && newCurrentSlide.Deck.Guid.Equals(this.myMainDeck.Guid))
            {
                this.myMainDeckPanel.SelectedSlide = newCurrentSlide;
            }
            else if (newCurrentSlide != null && newCurrentSlide.Deck.Guid.Equals(this.myContributionDeck.Guid))
            {
                this.myContributionDeckPanel.SelectedSlide = newCurrentSlide;
            }
        }

        private void UnregisterCurrentSlideContributionComponent()
        {
            //If current slide is not null, disable all contribution functions
            if (this.myCurrentSlide != null)
                this.UnregisterContributionComponent(this.myCurrentSlide.Guid);
        }

        private void UnregisterContributionComponent(Guid slideGuid)
        {
            SlideContribution slideContribution;
            if (slideGuid != Guid.Empty)
            {
                slideContribution = this.myContributionsManager.GetSlideContribution(slideGuid);
                if (slideContribution != null)
                {
                    slideContribution.ContributionComponent.Enabled = false;
                    if (newContribution != null)
                        slideContribution.ContributionComponent.Contributions.NewContributionEvent -= newContribution;
                    if (contributionRemoved == null)
                        slideContribution.ContributionComponent.Contributions.ContributionRemovedEvent -= contributionRemoved;
                    slideContribution.ContributionComponent.Owner = null;
                    if (this.myCurrentSlide != null && slideGuid.Equals(this.myCurrentSlide.Guid))
                        this.mySlidePanel.ContributionComponent = null;
                }
            }
        }


        private void RegisterCurrentSlideContributionComponent()
        {
            //Getting specific contribution component from slide
            if (this.myCurrentSlide != null)
                this.RegisterContributionComponent(this.myCurrentSlide.Guid);
        }

        private void RegisterContributionComponent(Guid slideGuid)
        {
            SlideContribution slideContribution;
            //Getting specific contribution component from slide
            if (slideGuid != Guid.Empty)
            {
                slideContribution = this.myContributionsManager.GetSlideContribution(slideGuid);
                if (slideContribution != null)
                {
                    //Control is only enabled if participant has contribution function
                    slideContribution.ContributionComponent.Enabled = this.myPresentationParameters.MakeContributions;
                    if (newContribution == null)
                        newContribution = new Contributions.NewContributionEventHandler(NewContributionEvent);
                    if (contributionRemoved == null)
                        contributionRemoved = new Contributions.ContributionRemovedEventHandler(ContributionRemovedEvent);
                    slideContribution.ContributionComponent.Contributions.NewContributionEvent += newContribution;
                    slideContribution.ContributionComponent.Contributions.ContributionRemovedEvent += contributionRemoved;
                    slideContribution.ContributionComponent.Owner = this.mySlidePanel;
                    this.mySlidePanel.ContributionComponent = slideContribution.ContributionComponent;
                }
            }
        }

        #endregion

        #endregion

        // Protected Methods

        #region Protected

        #region Virtual

        #region Presentation Controls

        protected virtual Control GetMainDeckPanelParent() 
        { 
            return null; 
        }
        
        protected virtual Control GetContributionsDeckPanelParent() 
        { 
            return null; 
        }
        
        protected virtual Control GetSlidePanelParent() 
        { 
            return null; 
        }

        #endregion

        #region Visual Controls

        #region User has functions?

        protected virtual void HasClassroomPersistenceFunction(bool flag) { }
        protected virtual void HasContributionFunction(bool flag) { }
        protected virtual void HasParticipantsManagerFunction(bool flag) { }
        protected virtual void HasPresentationEditionFunction(bool flag) { }
        protected virtual void HasPresentationSendFunction(bool flag) { }
        protected virtual void HasSubmitModificationFunction(bool flag) { }

        #endregion

        #region Available Functions

        protected virtual void AvailableSubmitModificationsFunction(bool flag) { }

        #endregion

        #region Visualize

        protected virtual void VisualizeMainFunctionsPanel(bool flag){ }
        
        protected virtual void VisualizeCoFunctionsPanel(bool flag) { }
        
        protected virtual void VisualizeMainDeckPanel(bool flag) { }
        
        protected virtual void VisualizeContributionsDeckPanel(bool flag) { }
        
        protected virtual void VisualizeSlidePanel(bool flag) { }

        #endregion

        #region Update

        protected virtual void UpdateConnectionControls(bool flag) { }

        protected virtual void UpdateSlideInformationControls() { }

        protected virtual void UpdateCopyAndPasteSlideControls(bool flag) { }

        #region Presentation Parameters Controls

        protected virtual void UpdateMakeContributionsControls(bool flag) { }

        protected virtual void UpdateAutomaticContributionsControls(bool flag) { }

        protected virtual void UpdateAllowParticipantsToSendContributionControls(bool flag) { }
      
        protected virtual void UpdateSyncMasterControls(bool flag) { }

        protected virtual void UpdateSyncMasterAttentionControls() { }

        protected virtual void UpdateSyncViewerControls(bool flag) { }

        protected virtual void UpdatePersistenceControls(bool flag) { }

        #endregion

        #endregion

        #endregion

        #region Presentation

        protected void ClosePresentation()
        {
            this.ClearPresentation();
            this.UpdateSlideInformationControls();
        }

        protected void CreateNewPublicSlide()
        {
            PublicWhiteBoard publicWhiteBoard = new PublicWhiteBoard();
            publicWhiteBoard.BoardColor = this.myConfiguration.PublicSlideColor;
            this.CreateNewSlide(publicWhiteBoard);
        }

        protected void CreateNewPrivateSlide()
        {
            PrivateWhiteBoard privateWhiteBoard = new PrivateWhiteBoard();
            privateWhiteBoard.BoardColor = this.myConfiguration.PrivateSlideColor;
            this.CreateNewSlide(privateWhiteBoard);
        }

        protected void CopySlide()
        {
            if (this.myCurrentSlide == null)
                return;
            this.myCurrentCopySlide = (Slide)this.myCurrentSlide.Clone();
            this.myCurrentCopySlide.GenerateNewGuid();
            this.myCurrentCopySlideContributions = (Contributions)this.GetContributions(this.myCurrentSlide.Guid).Clone();
            this.myCurrentCopySlideContributions.NewGuid();
            this.UpdateCopyAndPasteSlideControls(true);
        }

        protected void PasteSlide()
        {
            if (this.myCurrentCopySlide == null)
                return;
            this.AddSlide(this.myCurrentCopySlide);
            if (this.myCurrentCopySlideContributions != null)
            {
                this.AddContributions(this.myCurrentCopySlide.Guid, this.myCurrentCopySlideContributions);
            }
            this.myCurrentCopySlide = null;
            this.myCurrentCopySlideContributions = null;
            this.UpdateCopyAndPasteSlideControls(false);
        }

        protected void NextSlide(Slide baseSlide)
        {
            if (baseSlide == null)
                return;
            Slide slide = baseSlide.Deck.Slides.NextSlide(baseSlide);
            //checking from wich deck slide belongs
            if (slide.Deck.Guid.Equals(this.myMainDeck.Guid))
            {
                this.SelectSlideAtMainDeck(slide.Guid, true);
            }
            else
            {
                this.SelectSlideAtContributionDeck(slide.Guid, true);
            }
        }

        protected void PreviousSlide(Slide baseSlide)
        {
            if (baseSlide == null)
                return;
            Slide slide = baseSlide.Deck.Slides.PreviousSlide(baseSlide);
            //checking from wich deck slide belongs
            if (slide.Deck.Guid.Equals(this.myMainDeck.Guid))
            {
                this.SelectSlideAtMainDeck(slide.Guid, true);
            }
            else
            {
                this.SelectSlideAtContributionDeck(slide.Guid, true);
            }
        }

        #endregion

        #endregion

        #region Connection        

        protected void Connect()
        {
            this.Connect("", -1, "");
        }

        protected void Connect(String IP, int port, String password)
        {
            //Checking if already is connected
            if (this.mySession.Connected)
                return;

            SessionForm sessionForm = null;
            if (port > 0)
                sessionForm = new SessionForm(this.mySession, this.myParticipant, IP, port, password);
            else 
                sessionForm = new SessionForm(this.mySession, this.myParticipant);

            if (sessionForm.ShowDialog() == DialogResult.OK)
            {
                lock (this)
                {
                    if (this.myCommunicationControl.Connect(this.mySession.MulticastIp, this.mySession.Port, this.mySession.TTL, this.myParticipant.MacAddress, this.mySession.FECPerc))
                    {
                        //Changing flag to true
                        this.mySession.Connected = true;

                        //Connection
                        this.BroadcastConnection();
                        
                        //Updating functions management
                        this.UpdateVisualControlsAndFunctions();

                        //Updating Connection Controls
                        this.UpdateConnectionControls(true);

                        //
                        this.RegisterContextTimer();

                        //
                        this.UnregisterSessionTimer();

                        //
                        if (sessionForm.RegisterSession)
                        {
                            CreateSession();
                        }

                        InsertMessage("Connected at " + this.mySession.MulticastIp + ":" + this.mySession.Port.ToString() + " as " + this.myParticipant.NickName + "(" + this.myParticipant.Role.ToString() + ")");
                    }
                }
            }
            sessionForm.Dispose();
        }

        protected void Disconnect()
        {
            //Checking if already is disconnected
            if (!this.mySession.Connected)
                return;
            
            //Disconnection
            this.BroadcastDisconnection();
            
            //Closing connections...
            this.myCommunicationControl.CloseRtpConnections();

            //Reseting initial values
            this.ResetInitialValues();
            
            //Updating functions management
            this.UpdateVisualControlsAndFunctions();
            
            //Updating Connection Controls
            this.UpdateConnectionControls(false);

            //Unregistering Context Timer
            this.UnregisterContextTimer();


            //Register session search
            if (this.searchSessions)
            {
                this.RegisterSessionTimer();
            }

            InsertMessage("Disconnected from session");
        }

        #endregion

        #region Forms

        protected void ShowContextInformationForm()
        {
            //Create information form, show and dispose..
            InformationForm informationForm = new InformationForm(this.myConfiguration.MocaWebServiceURL, this.myParticipant.MacAddress);
            informationForm.ShowDialog();
            informationForm.Dispose();
        }

        protected void ShowConfigurations()
        {
            this.ShowConfigurationForm();
            //Atualiza os timers
            this.UpdateContextTimer();
            this.UpdateSessionTimer();
        }

        protected virtual void ShowConfigurationForm()
        {
            ConfigurationForm configForm = new ConfigurationForm(this.myConfiguration);
            configForm.ShowDialog();
            configForm.Dispose();
        }

        protected void ShowParticipantsForm()
        {
            ParticipantsForm participantsForm = new ParticipantsForm(this);
            participantsForm.ShowDialog();
            participantsForm.Dispose();
        }

        protected void ShowContextInformationRulesForm()
        {
            ContextInformationRulesForm contextRulesForm = new ContextInformationRulesForm(this);
            if (contextRulesForm.ShowDialog() == DialogResult.OK)
            {
                this.SendContextInformationRules();
            }
            contextRulesForm.Dispose();
        }

        #endregion

        #region Presentation Parameters

        protected void SetMakeContributions(bool flag)
        {
            this.myPresentationParameters.MakeContributions = flag;
            this.UpdateMakeContributionsControls(flag);
        }

        protected void SetAutomaticContributions(bool flag)
        {
            this.myPresentationParameters.AutomaticContributions = flag;
            this.UpdateAutomaticContributionsControls(flag);
        }

        protected void SetAllowParticipantsToSendContribution(bool flag)
        {
            this.myPresentationParameters.AllowSubmissions = flag;
            this.UpdateAllowParticipantsToSendContributionControls(flag);
        }

        protected void SetSyncViewer(bool flag)
        {
            this.myPresentationParameters.SyncViewer = flag;
            if (flag)
            {
                if (this.CurrentSlide != null && this.CurrentSlide.Deck.Guid.Equals(this.myMainDeck.Guid))
                    this.BroadcastSelectedSlide(this.CurrentSlide);
                else if (this.CurrentSlide != null && this.CurrentSlide.Deck.Guid.Equals(this.myContributionDeck.Guid))
                    this.BroadcastSelectedContributionSlide(this.CurrentSlide);
            }
            this.UpdateSyncViewerControls(flag);
        }

        #endregion

        #region Format

        protected void SetContributionAction(ActionType actionType)
        {
            this.myContributionsManager.Action = actionType;
        }

        protected void SetInkColor(Color inkColor)
        {
            this.myContributionsManager.InkColor = inkColor;
        }

        protected Color GetInkColor()
        {
            return this.myContributionsManager.InkColor;
        }

        protected void SetTextFont(Font textFont)
        {
            this.myContributionsManager.TextFont = textFont;
        }

        protected Font GetTextFont()
        {
            return this.myContributionsManager.TextFont;
        }

        protected void SetTextColor(Color textColor)
        {
            this.myContributionsManager.TextColor = textColor;
        }

        protected Color GetTextColor()
        {
            return this.myContributionsManager.TextColor;
        }

        #endregion

        #region Send Methods

        //protected void SendMainDeck()
        public void SendMainDeck()
        {
            //Creating deck to broadcast
            Deck broadDeck = new Deck(this.MainDeck.Guid);
            //Index for insert
            int index = 0;
            //Copying public slides
            foreach (Slide s in this.MainDeck.Slides.List)
            {
                if (s.SendContributions())
                {
                    broadDeck.Slides.InsertSlide(index, s);
                    index = index + 1;
                }
            }
            //Broacasting deck
            this.BroadcastDeck(broadDeck);
        }

        protected void SendCurrentSlide()
        {
            this.BroadcastSlide(this.myCurrentSlide);
        }

        protected void SendSubmissionToMaster()
        {
            this.BroadcastSubmission(this.myCurrentSlide);
        }

        protected void SendRequestSync()
        {
            this.BroadcastSelectedAttentionSlide(this.myCurrentSlide);
        }

        #endregion

        #endregion

        // Public Methods

        #region Public

        #region Virtual

        #region Configuration

        public virtual bool GetUsesContextInformation() { return true; }

        public virtual long GetContextTimerInterval() { return InteractiveConfiguration.DEFAULT_INTERVAL; }

        public virtual long GetMocaWSRequestTimeOut() { return InteractiveConfiguration.REQUEST_TIMEOUT; } 

        public virtual string GetMocaWebServiceURL() { return ""; }

        public virtual bool GetSearchActiveSessions() { return true; }

        public virtual long GetSessionTimerInterval() { return InteractiveConfiguration.DEFAULT_INTERVAL; }

        public virtual string GetSessionServiceURL() { return ""; }

        public virtual Color GetPublicSlideColor() { return InteractiveConfiguration.DEFAULT_PUBLIC_COLOR; }

        public virtual Color GetPrivateSlideColor() { return InteractiveConfiguration.DEFAULT_PRIVATE_COLOR; }

        #endregion

        #endregion

        #region Implements CommunicationsForm Method

        public void ReceiveObject(object obj)
        {
            this.myMessageManager.ReceiveMessage(obj);
        }

        #endregion

        #region Presentation

        public void InsertSlideAtMainDeck(Slide slide, Guid previousSlideGuid, int originalIndex, bool previousInsert, bool updateSlidePanel)
        {
            //Recovering index - the default is the first
            int index = 0;
            if (previousSlideGuid != Guid.Empty)
            {
                Slide previousSlide = this.myMainDeck.Slides.GetSlide(previousSlideGuid);
                if (previousSlide != null)
                {
                    index = this.myMainDeck.Slides.IndexOf(previousSlide) + 1;
                }
                else
                {
                    index = originalIndex;
                }
            }
            else if (this.myCurrentSlide != null)
            {
                index = this.myMainDeck.Slides.Count;
                if (this.myCurrentSlide.Deck.Guid.Equals(this.myMainDeck.Guid))
                {
                    index = this.myMainDeck.Slides.IndexOf(this.myCurrentSlide);
                    if (!previousInsert)
                        index = index + 1;
                }
            }
            //Calling Insert Slide
            if (!this.InsertSlide(this.myMainDeck, index, slide))
                slide = this.myMainDeck.Slides.GetSlide(slide);
                        
            //Updating gui with current slide
            if (updateSlidePanel)
                this.UpdateCurrentSlide(slide);
        }

        public void InsertSlideAtContributionDeck(Slide slide, bool updateSlidePanel)
        {
            //Recovering index - the default is the last
            int index = this.myContributionDeck.Slides.Count;
            
            //Calling Insert Slide
            this.InsertSlide(this.myContributionDeck, index, slide);
            
            //Refreshing
            this.myContributionDeckPanel.RefreshDeckSlidePanel();
            
            //Updating gui with current slide
            if (updateSlidePanel)
                this.UpdateCurrentSlide(slide);
        }

        public void AppendDeckAtMainDeck(Deck deck, bool updateSlidePanel)
        {
            //writer usado somente para testes
            //TextWriter writer = new StreamWriter("logAppendTime.txt");
            //writer.WriteLine("Start: " + DateTime.Now.ToLongTimeString());

            //Uses slideGuid to insert slide at proper position
            Guid slideGuid = Guid.Empty;
            //Slide No
            int i = 0;
            //For each slide in deck insert slide
            foreach (Slide s in deck.Slides.List)
            {
                //Updating slide guid 
                slideGuid = s.Guid;
                //Inserting slide at main deck
                this.InsertSlideAtMainDeck(s, slideGuid, i, true, false);
                //Increasing
                i++;
            }
            //refreshing
            this.myMainDeckPanel.RefreshDeckSlidePanel();
            //Updating GUI with current slide
            if (updateSlidePanel)
                this.UpdateCurrentSlide(MainDeck.Slides[0]);

            //writer.WriteLine("Appended Deck: " + DateTime.Now.ToLongTimeString());
            //writer.Close(); 
        }

        public void AppendDeckAtContributionDeck(Deck deck, bool updateSlidePanel)
        {
            foreach (Slide s in deck.Slides.List)
            {
                //Inserting slide at main deck
                this.InsertSlideAtContributionDeck(s, false);
            }
            //refreshing
            this.myContributionDeckPanel.RefreshDeckSlidePanel();
            //Updating GUI with current slide
            if (updateSlidePanel)
                this.UpdateCurrentSlide(ContributionDeck.Slides[0]);
        }

        public void SelectSlideAtMainDeck(Guid slideGuid, bool sendMessage)
        {
            Slide slide = this.GetSlideFromMainDeck(slideGuid);
            if (slide != null)
            {
                this.SelectSlide(slide);
                //sending
                if (sendMessage)
                    this.BroadcastSelectedSlide(slide);
            }
        }

        public void SelectSlideAtContributionDeck(Guid slideGuid, bool sendMessage)
        {
            Slide slide = this.GetSlideFromContributionDeck(slideGuid);
            if (slide != null)
            {
                this.SelectSlide(slide);
                //sending
                if (sendMessage)
                    this.BroadcastSelectedContributionSlide(slide);
            }
        }

        //Saves both Decks and the ContributionsManager in a file.
        public void SaveDeckSet(string fileName)
        {
            try
            {
                //CompactFormatter.CompactFormatter cf = new CompactFormatter.CompactFormatter(CompactFormatter.CFormatterMode.SAFE);
                FileStream fs = new FileStream(fileName, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);

                this.myMainDeck.SaveDeckToWriter(bw);
                this.myContributionDeck.SaveDeckToWriter(bw);
                this.myContributionsManager.SaveManagerToWriter(bw);                

                bw.Flush();
                bw.Close();
                fs.Close();
                System.GC.Collect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        // Load and append the Decks with the contributions, if they exist
        // index 1 for MainDeck, 2 for ContributionDeck, 3 for ContributionsManager; 
        public void LoadDeckSet(string fileName)
        {
            if (myMainDeck.Slides.Count != 0 || myContributionDeck.Slides.Count != 0)
            {
                this.ClearPresentation();
            }
            try
            {
                //int dataLength = 0;
                Deck loadedMainDeck = null;
                Deck loadedContributionDeck = null;
                ContributionsManager loadedContributionsManager = null;

                //CompactFormatter.CompactFormatter cf = new CompactFormatter.CompactFormatter(CompactFormatter.CFormatterMode.SAFE);
                FileStream fs = new FileStream(fileName, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);

                loadedMainDeck = Deck.GetDeckFromReader(br);
                if (br.PeekChar() >= 0) 
                    loadedContributionDeck = Deck.GetDeckFromReader(br);                
                if (br.PeekChar() >= 0)
                    loadedContributionsManager = ContributionsManager.GetManagerFromReader(br);

                if (loadedMainDeck != null)
                {
                    this.AppendDeckAtMainDeck(loadedMainDeck, false);
                }
                if (loadedContributionDeck != null)
                {
                    this.AppendDeckAtContributionDeck(loadedContributionDeck, false);
                }
                if (loadedContributionsManager != null)
                {
                    foreach (SlideContribution slideContribution in loadedContributionsManager.List)
                    {
                        this.AddContributions(slideContribution.SlideGuid, slideContribution.ContributionComponent.Contributions);
                    }
                }

                //clearing...
                loadedMainDeck = null;
                loadedContributionDeck = null;
                loadedContributionsManager = null;

                br.Close();
                fs.Close();
                System.GC.Collect();
                this.DeckSetOpened = fileName; 
                this.UpdateCurrentSlide(this.MainDeck.Slides[0]);
            }
            catch (FileNotFoundException fex)
            {
                Console.WriteLine(fex.Message);
                throw fex;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        #endregion

        #region Contributions

        public void AddContributions(Guid slideGuid, Contributions contributions)
        {
            //Getting proper contribution component 
            SlideContribution slideContribution = this.myContributionsManager.GetSlideContribution(slideGuid);
            if (slideContribution != null && contributions != null)
            {
                //inserting all contributions
                foreach (ContributionBaseObject contributionBaseObject in contributions.List)
                {
                    //Setting size of stroke
                    if (contributionBaseObject is Stroke)
                        (contributionBaseObject as Stroke).Width = Ink.InkProperties.GetSizeByPlatform(System.Environment.OSVersion.Platform);
                    //inserting stroke
                    slideContribution.ContributionComponent.Contributions.InsertContribution(contributionBaseObject, false);
                }
                //Checking if is the slide is the current slide
                if ((this.myCurrentSlide != null) && (slideGuid.Equals(this.myCurrentSlide.Guid)))
                    this.UpdateCurrentSlide(this.myCurrentSlide);
            }
        }

        public void ClearSlideContributions(Guid slideGuid)
        {
            ContributionsManager.ClearSlideContributions(slideGuid);
        }

        public void RemoveContributionObject(Guid slideGuid, Guid contributionBaseObjectGuid)
        {
            //Getting proper contribution component 
            SlideContribution slideContribution = this.myContributionsManager.GetSlideContribution(slideGuid);
            if (slideContribution != null)
            {
                //Removing contribution if exists
                slideContribution.ContributionComponent.Contributions.RemoveContribution(contributionBaseObjectGuid, false);
                //Checking if the slide is the current slide
                if (slideGuid.Equals(this.myCurrentSlide.Guid))
                    this.UpdateCurrentSlide(this.myCurrentSlide);
            }
        }

        #endregion

        #region ContextInformation

        public void AppendContextInformationRules(ContextInformationRule[] rules)
        {
            this.myContextInformationManager.AppendRules(rules);
            //
            this.myContextTimer.Tick(this);
        }

        #endregion

        #region Presentation Parameters

        public void SetSyncMaster(bool flag)
        {
            //setting flag
            this.myPresentationParameters.SyncMaster = flag;
            //updating slide
            if (flag && this.myPresentationParameters.SlideViewGuid != Guid.Empty)
            {
                this.SelectSlideAtMainDeck(this.myPresentationParameters.SlideViewGuid, false);
                this.myPresentationParameters.SlideViewGuid = Guid.Empty;
            }
            //updating controls
            this.UpdateSyncMasterControls(flag);
        }

        public void SetSyncMasterAttention()
        {
            this.UpdateSyncMasterAttentionControls();
        }

        public void SetSyncSlideToView(Guid slideGuid)
        {
            //
            this.myPresentationParameters.SlideViewGuid = slideGuid;
        }

        #endregion

        #region Enable/Disable Functions

        private delegate void AvailableAllFunctionsDelegate();
        public void AvailableAllFunctions()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new AvailableAllFunctionsDelegate(AvailableAllFunctions));
                return;
            }

            foreach (BaseFunction b in this.myFunctionsManager.List)
            {
                this.AvailableFunction(b, true);
            }
        }

        public void AvailableFunction(BaseFunction function, bool isEnabled) 
        {
            bool hasFunction = this.myFunctionsManager.HasFunction(this.myParticipant.Role, function);

            if ((hasFunction) && (function is SubmitModificationsFunction))
                this.AvailableSubmitModificationsFunction(isEnabled);
        }

        #endregion     

        #region Send Methods

        private delegate void SendSubmissionToViewerDelegate(Guid slideGuid);
        public void SendSubmissionToViewer(Guid slideGuid)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SendSubmissionToViewerDelegate(SendSubmissionToViewer), new Object[] { slideGuid });
                return;
            }
            Slide slide = this.GetSlideFromContributionDeck(slideGuid);
            if (slide != null)
            {
                this.BroadcastSubmissionMaster(slide);
            }
        }

        public void SendPingToParticipants()
        {
            this.BroadcastPing();
        }

        public void SendParticipant()
        {
            this.BroadcastConnection();
        }

        private delegate void SendContextInformationRulesDelegate();
        public void SendContextInformationRules()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SendContextInformationRulesDelegate(SendContextInformationRules));
                return;
            }
            
            this.BroadcastContextInformationRules();            
        }

        private delegate void SendAckMessageDelegate(int messageId, int type, string observations);
        public void SendAckMessage(int messageId, int type, string observations)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SendAckMessageDelegate(SendAckMessage), new Object[] { messageId, type, observations });
                return;
            }

            this.BroadcastAck(messageId, type, observations);
        }

        #endregion

        #endregion

        #endregion
    }
}