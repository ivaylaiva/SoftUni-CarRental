using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SoftUni_CarRental.ViewModels.CarCard
{
    public class CarCardFormViewModel
    {
        public string ButtonLabel { get; set; } = null!;
        public int CarId { get; set; }
        
    }
}
