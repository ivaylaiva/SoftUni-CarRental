using SoftUni_CarRental.ViewModels.CarCard;

namespace SoftUni_CarRental.ViewModels.Message
{
    public class AllMessagesViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
