using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Models
{
    public class Contact
    {
        private int _id=0;

        public int Id { get => _id; set => _id = value; }
        [Required]
        [MaxLength(50, ErrorMessage = "First Name field should not exceed 50 characters")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Last Name field should not exceed 50 characters")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"[\w-]+@([\w-]+\.)+[\w-]+", ErrorMessage = "Invalid Mail")]
        public string Email { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        public string Status { get; set; }
    }
}
