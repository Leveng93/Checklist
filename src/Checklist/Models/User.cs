using System;
using System.Collections.Generic;

namespace Checklist.Models
{
    class User : IEntityBase
    {
        public User()
        {
            UserRoles = new List<UserRole>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public bool IsLocked { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Division Division { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}