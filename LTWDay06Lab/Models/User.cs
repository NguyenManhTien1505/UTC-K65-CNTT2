using System.ComponentModel.DataAnnotations;

namespace LTWDay06Lab.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}
