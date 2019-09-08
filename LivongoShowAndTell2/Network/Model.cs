using System;
using System.Collections.Generic;

namespace LivongoShowAndTell2.Network
{
    public class Config
    {
        public Dictionary<string, Client> clients { get; set; }
    }

    public class Client
    {
        public string analyticsTrackingCode { get; set; }
        public string minimumVersion { get; set; }
        public string currentVersion { get; set; }
    }
}
