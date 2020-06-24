using System;

namespace ContractWCF
{
    [System.Runtime.Serialization.DataContract]
    public struct Message
    {
        [System.Runtime.Serialization.DataMember]
        public string appVersion;
        [System.Runtime.Serialization.DataMember]
        public string operationVersion;
        [System.Runtime.Serialization.DataMember]
        public string operationName;
        [System.Runtime.Serialization.DataMember]
        public string userToken;
        [System.Runtime.Serialization.DataMember]
        public string appToken;
        [System.Runtime.Serialization.DataMember]
        public bool operationStatus;
        [System.Runtime.Serialization.DataMember]
        public string info;
        [System.Runtime.Serialization.DataMember]
        public object[] data;
    }
}
