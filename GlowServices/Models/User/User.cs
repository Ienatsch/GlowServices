using System;
using System.ComponentModel.DataAnnotations;

namespace GlowServices.Models.user
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string UserUsername { get; set; }
        public string UserPassword { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneNumber { get; set; }
    }
}
