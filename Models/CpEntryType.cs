using System.Text;
using System;
using Newtonsoft.Json;

namespace sdcs.vcp
{
    public abstract class CpEntryType
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        public abstract EntryTypes SetEntryType();

        [JsonProperty(PropertyName = "EntryType")]
        public EntryTypes EntryType { get; set; }

        [JsonProperty(PropertyName = "IsDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty(PropertyName = "Created")]
        public DateTime Created { get; set; }

        [JsonProperty(PropertyName = "LastUpdated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty(PropertyName = "CreatedBy")]
        public CpUser CreatedBy { get; set; }

        [JsonProperty(PropertyName = "LastUpdatedBy")]
        public CpUser LastUpdatedBy { get; set; }

    }
}