using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace vega2.Models
{
    public class MakeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ModelViewModel> Models { get; set; }

        public MakeViewModel()
        {
            Models = new Collection<ModelViewModel>();
        }
    }
}