using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrologMobile.Data
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool Blacklisted { get; set; }
        // Other properties and navigation properties
        public virtual User? User { get; set; }
    }
}
