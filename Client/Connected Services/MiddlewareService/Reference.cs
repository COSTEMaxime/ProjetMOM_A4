﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.MiddlewareService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Message", Namespace="http://schemas.datacontract.org/2004/07/ContractWCF")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(object[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(string[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Collections.Generic.Dictionary<string, byte[]>))]
    public partial struct Message : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string appTokenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string appVersionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object[] dataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string infoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string operationNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool operationStatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string operationVersionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string userTokenField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string appToken {
            get {
                return this.appTokenField;
            }
            set {
                if ((object.ReferenceEquals(this.appTokenField, value) != true)) {
                    this.appTokenField = value;
                    this.RaisePropertyChanged("appToken");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string appVersion {
            get {
                return this.appVersionField;
            }
            set {
                if ((object.ReferenceEquals(this.appVersionField, value) != true)) {
                    this.appVersionField = value;
                    this.RaisePropertyChanged("appVersion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object[] data {
            get {
                return this.dataField;
            }
            set {
                if ((object.ReferenceEquals(this.dataField, value) != true)) {
                    this.dataField = value;
                    this.RaisePropertyChanged("data");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string info {
            get {
                return this.infoField;
            }
            set {
                if ((object.ReferenceEquals(this.infoField, value) != true)) {
                    this.infoField = value;
                    this.RaisePropertyChanged("info");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string operationName {
            get {
                return this.operationNameField;
            }
            set {
                if ((object.ReferenceEquals(this.operationNameField, value) != true)) {
                    this.operationNameField = value;
                    this.RaisePropertyChanged("operationName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool operationStatus {
            get {
                return this.operationStatusField;
            }
            set {
                if ((this.operationStatusField.Equals(value) != true)) {
                    this.operationStatusField = value;
                    this.RaisePropertyChanged("operationStatus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string operationVersion {
            get {
                return this.operationVersionField;
            }
            set {
                if ((object.ReferenceEquals(this.operationVersionField, value) != true)) {
                    this.operationVersionField = value;
                    this.RaisePropertyChanged("operationVersion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string userToken {
            get {
                return this.userTokenField;
            }
            set {
                if ((object.ReferenceEquals(this.userTokenField, value) != true)) {
                    this.userTokenField = value;
                    this.RaisePropertyChanged("userToken");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MiddlewareService.IServiceEntryPoint")]
    public interface IServiceEntryPoint {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceEntryPoint/AccessService", ReplyAction="http://tempuri.org/IServiceEntryPoint/AccessServiceResponse")]
        Client.MiddlewareService.Message AccessService(Client.MiddlewareService.Message message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceEntryPoint/AccessService", ReplyAction="http://tempuri.org/IServiceEntryPoint/AccessServiceResponse")]
        System.Threading.Tasks.Task<Client.MiddlewareService.Message> AccessServiceAsync(Client.MiddlewareService.Message message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceEntryPointChannel : Client.MiddlewareService.IServiceEntryPoint, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceEntryPointClient : System.ServiceModel.ClientBase<Client.MiddlewareService.IServiceEntryPoint>, Client.MiddlewareService.IServiceEntryPoint {
        
        public ServiceEntryPointClient() {
        }
        
        public ServiceEntryPointClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceEntryPointClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceEntryPointClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceEntryPointClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Client.MiddlewareService.Message AccessService(Client.MiddlewareService.Message message) {
            return base.Channel.AccessService(message);
        }
        
        public System.Threading.Tasks.Task<Client.MiddlewareService.Message> AccessServiceAsync(Client.MiddlewareService.Message message) {
            return base.Channel.AccessServiceAsync(message);
        }
    }
}
