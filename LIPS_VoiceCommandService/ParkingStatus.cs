using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LIPS.VoiceCommands
{
    internal enum ParkTrend
    {
        Stable,
        FillingSlow,
        FillingFast,
        EmptyingSlow,
        EmptyingFast
    }

    [DataContract]
    internal class ParkingStatus
    {
        [DataMember]
        public double Rate { get; set; }
        [DataMember]
        public int Current { get; set; }
        [DataMember]
        public int CurrentCapacity { get; set; }
        [DataMember]
        public ParkTrend Trend { get; set; }
        [DataMember]
        public int RemainingMinutes { get; set; }
        [DataMember]
        public string TrendString { get; set; }
    }
}
