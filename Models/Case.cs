using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace sdcs.vcp
{
    public class Case : CpEntryType
    {
        [JsonProperty(PropertyName = "Nickname")]
        public string Nickname { get; set; }

        [JsonProperty(PropertyName = "CaseNumber")]
        [JsonRequired]
        public string CaseNumber { get; set; }

        [JsonProperty(PropertyName = "CaseMembers")]
        public List<CpUser> CaseMembers { get; set; }

        [JsonProperty(PropertyName = "Tasks")]
        public List<CaseEntryItem> Tasks { get; set; }

        [JsonProperty(PropertyName = "CaseFeedItems")]
        public List<CaseEntryItem> CaseFeedItems { get; set; }

        [JsonProperty(PropertyName = "PersonsOfInterest")]
        public List<PersonOfInterest> PersonsOfInterest { get; set; }

        public Statuses Status { get; set; }

        public override EntryTypes SetEntryType()
        {
            EntryTypes myEntryType = EntryTypes.CASE;
            EntryType = myEntryType;
            return myEntryType;
        }
    }
}