using System.ComponentModel.DataAnnotations;

namespace TaskSample.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }

        [Required]
        public string GroupName { get; set; }

        [Required]
        public int Age { get; set; }
    }
}