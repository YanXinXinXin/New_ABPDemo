using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.BookStore.Users
{
     public class StaffUserDto
    {
   
        public string UserName { get; set; }
      
        public string GanWei { get; set; }
   
        public string Supervisor { get; set; }
    }
}
