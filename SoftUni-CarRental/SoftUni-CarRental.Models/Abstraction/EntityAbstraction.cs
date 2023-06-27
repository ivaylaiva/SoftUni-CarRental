using System.ComponentModel.DataAnnotations;

namespace SoftUni_CarRental.Models.Abstraction
{
    public abstract class EntityAbstraction
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
