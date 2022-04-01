
using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EtecFilmes.Models
{
    [Table("User")]
    public class User : IdentityUser
    {
        [StringLength(100)]
        public string Name { get; set; }

        public int UserNameChangeLimit { get; set; } =10;

        public byte[] ProfilePicture { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate {get; set; }
    }
}