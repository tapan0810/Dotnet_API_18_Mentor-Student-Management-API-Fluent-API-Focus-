using System.ComponentModel.DataAnnotations;

namespace Dotnet_API_18.Entities.Models
{
    public class Mentor
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string MentorName { get; set; }=string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; }=string.Empty;
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
