using System.ComponentModel.DataAnnotations;

namespace TaskSample.Dtos
{
    public class UserCreateDto
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string GroupName { get; set; }

        [Required]
        public int Age { get; set; }
    }
}