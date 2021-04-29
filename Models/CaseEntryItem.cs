using System;
using System.Collections.Generic;

namespace sdcs.vcp
{
    public class CaseEntryItem : CpEntryType
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool IsCaseFeedItem { get; set; }
        public bool IsImportant { get; set; }
        public Statuses Status { get; set; }
        public TaskTypes TaskType { get; set; }

#nullable enable
        public CpUser? AssignedTo { get; set; }
        public DateTime? DueDate { get; set; }
        public PersonOfInterest? AssociatedPoi { get; set; }
#nullable disable
        public override EntryTypes SetEntryType()
        {
            return EntryTypes.TASK;
        }
    }
}