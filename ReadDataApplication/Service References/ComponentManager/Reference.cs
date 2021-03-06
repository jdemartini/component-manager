﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReadDataApplication.ComponentManager {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PersonalData", Namespace="http://schemas.datacontract.org/2004/07/ReaderComponentService")]
    [System.SerializableAttribute()]
    public partial class PersonalData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AgeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CountryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Age {
            get {
                return this.AgeField;
            }
            set {
                if ((this.AgeField.Equals(value) != true)) {
                    this.AgeField = value;
                    this.RaisePropertyChanged("Age");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Country {
            get {
                return this.CountryField;
            }
            set {
                if ((object.ReferenceEquals(this.CountryField, value) != true)) {
                    this.CountryField = value;
                    this.RaisePropertyChanged("Country");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ComponentManager.IComponentManager")]
    public interface IComponentManager {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IComponentManager/ReadData", ReplyAction="http://tempuri.org/IComponentManager/ReadDataResponse")]
        ReadDataApplication.ComponentManager.PersonalData[] ReadData();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IComponentManager/ReadData", ReplyAction="http://tempuri.org/IComponentManager/ReadDataResponse")]
        System.Threading.Tasks.Task<ReadDataApplication.ComponentManager.PersonalData[]> ReadDataAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IComponentManager/ReadData_", ReplyAction="http://tempuri.org/IComponentManager/ReadData_Response")]
        ReadDataApplication.ComponentManager.PersonalData[] ReadData_();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IComponentManager/ReadData_", ReplyAction="http://tempuri.org/IComponentManager/ReadData_Response")]
        System.Threading.Tasks.Task<ReadDataApplication.ComponentManager.PersonalData[]> ReadData_Async();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IComponentManagerChannel : ReadDataApplication.ComponentManager.IComponentManager, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ComponentManagerClient : System.ServiceModel.ClientBase<ReadDataApplication.ComponentManager.IComponentManager>, ReadDataApplication.ComponentManager.IComponentManager {
        
        public ComponentManagerClient() {
        }
        
        public ComponentManagerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ComponentManagerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ComponentManagerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ComponentManagerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ReadDataApplication.ComponentManager.PersonalData[] ReadData() {
            return base.Channel.ReadData();
        }
        
        public System.Threading.Tasks.Task<ReadDataApplication.ComponentManager.PersonalData[]> ReadDataAsync() {
            return base.Channel.ReadDataAsync();
        }
        
        public ReadDataApplication.ComponentManager.PersonalData[] ReadData_() {
            return base.Channel.ReadData_();
        }
        
        public System.Threading.Tasks.Task<ReadDataApplication.ComponentManager.PersonalData[]> ReadData_Async() {
            return base.Channel.ReadData_Async();
        }
    }
}
