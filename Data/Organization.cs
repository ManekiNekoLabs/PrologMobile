using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrologMobile.Data
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        // Other properties and navigation properties
    }
}
