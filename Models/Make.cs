using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace aspnetcore_spa.Models
{
    public class Make
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Model> Models { get; set; }

        public Make()
        {
            Models = new Collection<Model>();
        }

    }
}