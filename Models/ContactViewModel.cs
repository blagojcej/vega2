using System.ComponentModel.DataAnnotations;

namespace vega2.Models
{
    public class ContactViewModel
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(255)]
        public string Phone { get; set; }
    }
}