using System;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.Shook.DomainModel.Models
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string UserName { get; set; }
    }
}
