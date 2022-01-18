﻿using System.Collections.Generic;

namespace iTechArt.Shook.DomainModel.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
