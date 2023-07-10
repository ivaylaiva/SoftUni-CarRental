using SoftUni_CarRental.Models.Abstraction;

namespace SoftUni_CarRental.Models.Models
{
    public class Message : EntityAbstraction
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public string Description { get; set; }
    }
}
