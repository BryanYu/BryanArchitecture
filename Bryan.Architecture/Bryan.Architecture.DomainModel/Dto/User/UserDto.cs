using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bryan.Architecture.DomainModel.Dto.User
{
    /// <summary>The user dto.</summary>
    public class UserDto
    {
        /// <summary>Gets or sets the id.</summary>
        public string Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the password.</summary>
        public string Password { get; set; }
    }
}