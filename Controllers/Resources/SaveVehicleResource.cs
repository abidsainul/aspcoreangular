using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aspnetcore_spa.Controllers.Resources
{
    public class SaveVehicleResource
    {
        public int Id { get; set; }
        public int ModelId { get; set; }

        public bool IsRegistered { get; set; }

        [Required]
       public ContactResource Contact { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual ICollection<int> Features { get; set; }
    }
}