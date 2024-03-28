namespace DAL
{
    public class User
    {
        public int UserID { get; set; }
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressCity { get; set; }
        public string AddressStreet { get; set; }
        public string AddressNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public DateTime? PositiveResultDate { get; set; }
        public DateTime? RecoveryDate { get; set; }
    }
}
