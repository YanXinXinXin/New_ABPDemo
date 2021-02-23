using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.BookStore.Users
{
    public class CreateStaffUserDto
    {
        [Required]
        [StringLength(10)]
        public string UserName { get; set; }
        [Required]
        [StringLength(20)]
        public string GanWei { get; set; }
        [Required]
        [StringLength(10)]
        public string Supervisor { get; set; }
    }
}
