using System.ComponentModel.DataAnnotations;

namespace KoshApp.Models
{
    public class Person : BaseEntity
    {

        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email Address ")]
        public string Email { get; set; }
        public Gender Gender { get; set; }

        [Display(Name = "Joined Date ")]
        public DateTime? DateOfJoin { get; set; }

        public byte[]? Photo { get; set; }

    }
}

