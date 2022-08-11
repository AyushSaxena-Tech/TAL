using System.ComponentModel.DataAnnotations;
using TAL.Enums;

namespace TAL.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Name is Required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is Required!")]
        [Range(1, 110)]
        public int? Age { get; set; }
        [Required(ErrorMessage = "DOB is Required!")]
        public DateTime? DOB { get; set; }
        [Required(ErrorMessage = "Occupation is Required!")]
        public OccupationEnum Occupation { get; set; }
        [Required(ErrorMessage = "Death Sum is Required!")]
        [Range(1, 100000)]
        public int? DeathSum{ get; set; }
        public double DeathPremium { get; set; }
    }
}
