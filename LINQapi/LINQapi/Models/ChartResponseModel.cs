﻿using LINQapi.Analyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LINQapi.Models
{
    [DataContract]
    public class ChartResponseModel
    {
        public ChartResponseModel()
        {
            isResponseValid = false;
            errors = new List<string>();
        }

        [DataMember(IsRequired = true)]
        public bool isResponseValid { get; set; }

        [DataMember]
        public List<string> errors { get; set; }

        [DataMember]
        public int[] initialCounts { get; set; }

        [DataMember]
        public int[] finalCounts { get; set; }

        [DataMember]
        public long[] executionTimes { get; set; }
    }
}