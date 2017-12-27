using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bryan.Architecture.DomainModel.Dto.User
{
    /// <summary>The login dto.</summary>
    public class LoginDto
    {
        /// <summary>Gets or sets the account.</summary>
        public string Account { get; set; }

        /// <summary>Gets or sets the password.</summary>
        public string Password { get; set; }
    }
}