using System.ComponentModel.DataAnnotations;

namespace AntiXSSDemo.Model
{
    public class InputModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }
    }
}