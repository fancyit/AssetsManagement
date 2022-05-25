namespace AssetsManagement.DL.Models
{
    public abstract class AppUser
    {        
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }       
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
