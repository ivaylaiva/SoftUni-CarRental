using SoftUni_CarRental.Models.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUni_CarRental.Models.Models
{
    public class UserRentCar:EntityAbstraction
    {
        //This class will be use to store user cars

        [ForeignKey(nameof(CarCard))]
        public int CarCardId { get; set; }
        public CarCard CarCard { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
        public DateTime RentedOn { get; set; }
        public DateTime FreeOn { get; set; }
    }
}
