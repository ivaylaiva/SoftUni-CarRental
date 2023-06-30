using SoftUni_CarRental.Models.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUni_CarRental.Models.Models
{
    public class Photo : EntityAbstraction
    {
        public byte[] PhotoBytes { get; set; } = null!;
    }
}
