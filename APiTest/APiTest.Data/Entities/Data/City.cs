using System.ComponentModel.DataAnnotations;

namespace APiTest.Data.Entities.Data
{
    public class City 
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "City")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Name { get; set; }
    }
}
