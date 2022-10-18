using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace RestFulService
{
    [DataContract]
    public class UserInfo
    {
        [DataMember]
        public long ID { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}
