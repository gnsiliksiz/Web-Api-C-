using System;


namespace Özata_Review.Model
{
    public partial class ClientLog
    {
        public Guid UID { get; set; }
        public string HostName { get; set; }
        public string IPv6 { get; set; }
        public string IPv4 { get; set; }
        public DateTime LogDatetime { get; set; }
    }
}
