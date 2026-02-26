using System.ComponentModel.DataAnnotations;

namespace Dotnet_API_18.Entities.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string StudentName { get; set; }=string.Empty;
        public int MentorId { get; set; }
        public Mentor? Mentor { get; set; }
    }
}
