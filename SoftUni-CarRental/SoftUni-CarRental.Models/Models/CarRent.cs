using SoftUni_CarRental.Models.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUni_CarRental.Models.Models
{
    public class CarRent : EntityAbstraction
    {
        //This is the history of rented cars. This class kave collection in the car model.
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; } = null!;

        public DateTime RentedOn { get; set; }
    }
}
