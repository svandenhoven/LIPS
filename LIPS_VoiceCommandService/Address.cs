using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LIPS.VoiceCommands
{
    [DataContract]
    internal class Address
    {
        [DataMember]
        public string addressLine { get; set; }

        [DataMember]
        public string adminDistrict { get; set; }
        [DataMember]
        public string adminDistrict2 { get; set; }
        [DataMember]
        public string countryRegion { get; set; }
        [DataMember]
        public string formattedAddress { get; set; }
        [DataMember]
        public string locality { get; set; }
        [DataMember]
        public string postalCode { get; set; }
    }
}
