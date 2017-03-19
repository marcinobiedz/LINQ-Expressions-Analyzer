using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LINQapi.Views
{
    [DataContract]
    public abstract class BaseResponse
    {
        public BaseResponse()
        {
            isResponseValid = false;
            errors = new List<string>();
        }

        [DataMember(IsRequired = true)]
        public bool isResponseValid { get; set; }

        [DataMember]
        public List<string> errors { get; set; }
    }
}