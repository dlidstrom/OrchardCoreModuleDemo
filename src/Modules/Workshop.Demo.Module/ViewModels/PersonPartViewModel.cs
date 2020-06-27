using System;
using System.ComponentModel.DataAnnotations;

namespace Workshop.Demo.Module.ViewModels
{
    public class PersonPartViewModel
    {
        // [Required]
        public string Name { get; set; }

        // [Required]
        public Handedness Handedness { get; set; }

        // [Required]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime? BirthDateUtc { get; set; }
    }
}
