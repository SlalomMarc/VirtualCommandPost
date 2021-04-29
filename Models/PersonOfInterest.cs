using System;

namespace sdcs.vcp
{
    public class PersonOfInterest : CpEntryType
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Notes { get; set; }
        public PoiTypes PoiType { get; set; }
        public bool IsCaseFeedItem { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        public string LastNameFirst
        {
            get
            {
                return string.Format("{0}, {1}", LastName, FirstName);
            }
        }
        public override EntryTypes SetEntryType()
        {
            return EntryTypes.PERSON_OF_INTEREST;
        }
    }


}