using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrologMobile.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string? Name { get; set; }

        public string? Avatar { get; set; }
        public virtual Organization? Organization { get; set; }
    }
}
