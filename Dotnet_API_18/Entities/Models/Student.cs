using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dotnet_API_18.Entities.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string StudentName { get; set; }=string.Empty;
        public int MentorId { get; set; }
        [JsonIgnore]
        public Mentor? Mentor { get; set; }
    }
}
