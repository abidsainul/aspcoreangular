using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aspnetcore_spa.Models
{
    public class Feature
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}