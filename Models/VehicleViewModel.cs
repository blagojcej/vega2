using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace vega2.Models
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public bool IsRegistered { get; set; }
        [Required]
        public ContactViewModel Contact {get;set;}
        public ICollection<int> Features { get; set; }

        public VehicleViewModel()
        {
            Features=new Collection<int>();
        }
    }
}