namespace sdcs.vcp
{
    public class CpUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string CellNumber { get; set; }
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
                return string.Format("{0} {1}", LastName, FirstName);
            }
        }


    }
}