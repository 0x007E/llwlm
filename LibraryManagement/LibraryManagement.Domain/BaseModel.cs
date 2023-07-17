using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Domain
{
    public class BaseModel
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Id { get; set; }
    }
}
