﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.CompactFramework.Design.Data, Version 2.0.50727.42.
// 
namespace CF.MSR.LST.ConferenceXP.VenueService {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="VenueServiceSoap", Namespace="http://research.microsoft.com/lst")]
    public partial class VenueService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public VenueService() {
            this.Url = "http://venues.conferencexp.net/venueservice/venueservice.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://research.microsoft.com/lst/CheckAssemblyVersion", RequestNamespace="http://research.microsoft.com/lst", ResponseNamespace="http://research.microsoft.com/lst", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool CheckAssemblyVersion(string assemblyVersion, out string errorMessage) {
            object[] results = this.Invoke("CheckAssemblyVersion", new object[] {
                        assemblyVersion});
            errorMessage = ((string)(results[1]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginCheckAssemblyVersion(string assemblyVersion, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CheckAssemblyVersion", new object[] {
                        assemblyVersion}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndCheckAssemblyVersion(System.IAsyncResult asyncResult, out string errorMessage) {
            object[] results = this.EndInvoke(asyncResult);
            errorMessage = ((string)(results[1]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://research.microsoft.com/lst/GetVenue", RequestNamespace="http://research.microsoft.com/lst", ResponseNamespace="http://research.microsoft.com/lst", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Venue GetVenue(string venueIdentifier) {
            object[] results = this.Invoke("GetVenue", new object[] {
                        venueIdentifier});
            return ((Venue)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetVenue(string venueIdentifier, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetVenue", new object[] {
                        venueIdentifier}, callback, asyncState);
        }
        
        /// <remarks/>
        public Venue EndGetVenue(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Venue)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://research.microsoft.com/lst/GetVenues", RequestNamespace="http://research.microsoft.com/lst", ResponseNamespace="http://research.microsoft.com/lst", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Venue[] GetVenues(string participantIdentifier) {
            object[] results = this.Invoke("GetVenues", new object[] {
                        participantIdentifier});
            return ((Venue[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetVenues(string participantIdentifier, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetVenues", new object[] {
                        participantIdentifier}, callback, asyncState);
        }
        
        /// <remarks/>
        public Venue[] EndGetVenues(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Venue[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://research.microsoft.com/lst/AddParticipant", RequestNamespace="http://research.microsoft.com/lst", ResponseNamespace="http://research.microsoft.com/lst", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void AddParticipant(Participant p) {
            this.Invoke("AddParticipant", new object[] {
                        p});
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginAddParticipant(Participant p, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("AddParticipant", new object[] {
                        p}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndAddParticipant(System.IAsyncResult asyncResult) {
            this.EndInvoke(asyncResult);
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://research.microsoft.com/lst/UpdateParticipant", RequestNamespace="http://research.microsoft.com/lst", ResponseNamespace="http://research.microsoft.com/lst", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void UpdateParticipant(Participant p) {
            this.Invoke("UpdateParticipant", new object[] {
                        p});
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUpdateParticipant(Participant p, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("UpdateParticipant", new object[] {
                        p}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndUpdateParticipant(System.IAsyncResult asyncResult) {
            this.EndInvoke(asyncResult);
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://research.microsoft.com/lst/GetParticipant", RequestNamespace="http://research.microsoft.com/lst", ResponseNamespace="http://research.microsoft.com/lst", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Participant GetParticipant(string participantIdentifier) {
            object[] results = this.Invoke("GetParticipant", new object[] {
                        participantIdentifier});
            return ((Participant)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetParticipant(string participantIdentifier, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetParticipant", new object[] {
                        participantIdentifier}, callback, asyncState);
        }
        
        /// <remarks/>
        public Participant EndGetParticipant(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Participant)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://research.microsoft.com/lst/GetParticipants", RequestNamespace="http://research.microsoft.com/lst", ResponseNamespace="http://research.microsoft.com/lst", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Participant[] GetParticipants() {
            object[] results = this.Invoke("GetParticipants", new object[0]);
            return ((Participant[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetParticipants(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetParticipants", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public Participant[] EndGetParticipants(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Participant[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://research.microsoft.com/lst/PrivacyPolicyUrl", RequestNamespace="http://research.microsoft.com/lst", ResponseNamespace="http://research.microsoft.com/lst", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string PrivacyPolicyUrl() {
            object[] results = this.Invoke("PrivacyPolicyUrl", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginPrivacyPolicyUrl(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("PrivacyPolicyUrl", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string EndPrivacyPolicyUrl(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://research.microsoft.com/lst")]
    public partial class Venue {
        
        private string identifierField;
        
        private string iPAddressField;
        
        private int portField;
        
        private string nameField;
        
        private byte[] iconField;
        
        private SecurityPatterns accessListField;
        
        /// <remarks/>
        public string Identifier {
            get {
                return this.identifierField;
            }
            set {
                this.identifierField = value;
            }
        }
        
        /// <remarks/>
        public string IPAddress {
            get {
                return this.iPAddressField;
            }
            set {
                this.iPAddressField = value;
            }
        }
        
        /// <remarks/>
        public int Port {
            get {
                return this.portField;
            }
            set {
                this.portField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] Icon {
            get {
                return this.iconField;
            }
            set {
                this.iconField = value;
            }
        }
        
        /// <remarks/>
        public SecurityPatterns AccessList {
            get {
                return this.accessListField;
            }
            set {
                this.accessListField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://research.microsoft.com/lst")]
    public partial class SecurityPatterns {
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://research.microsoft.com/lst")]
    public partial class Participant {
        
        private string identifierField;
        
        private string nameField;
        
        private string emailField;
        
        private byte[] iconField;
        
        private System.DateTime lastAccessedField;
        
        /// <remarks/>
        public string Identifier {
            get {
                return this.identifierField;
            }
            set {
                this.identifierField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string Email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] Icon {
            get {
                return this.iconField;
            }
            set {
                this.iconField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime LastAccessed {
            get {
                return this.lastAccessedField;
            }
            set {
                this.lastAccessedField = value;
            }
        }
    }
}
