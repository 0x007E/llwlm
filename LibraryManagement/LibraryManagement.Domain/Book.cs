using System.ComponentModel.DataAnnotations;
using LibraryManagement.Domain.Attributes;

namespace LibraryManagement.Domain
{
    public class Book : BaseModel
    {
        [Required]
        [StringLength(13, MinimumLength = 13)]
        [ISBN]
        public string ISBN { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        [RegularExpression("[a-zA-Z ]+$")]
        public string Author { get; set; }
    }
}
