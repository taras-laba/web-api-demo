using System;
using System.Drawing;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace WebApi.Common.Models
{
    public class ProcessModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TimeSpan ProcessorTime { get; set; }

        public string Title { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public Icon Icon { get; set; }
    }
}