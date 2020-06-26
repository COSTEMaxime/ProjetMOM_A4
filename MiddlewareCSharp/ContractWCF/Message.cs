using System;
using System.Collections.Generic;

namespace ContractWCF
{
    [Serializable]
    [System.Runtime.Serialization.DataContract]
    [System.Runtime.Serialization.KnownType(typeof(List<string>))]
    [System.Runtime.Serialization.KnownType(typeof(Dictionary<string, string>))]
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
