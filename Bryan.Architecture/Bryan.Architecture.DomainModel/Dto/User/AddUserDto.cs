using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bryan.Architecture.DomainModel.Dto.User
{
    /// <summary>The add user dto.</summary>
    public class AddUserDto
    {
        /// <summary>Gets or sets the account.</summary>
        public string Account { get; set; }

        /// <summary>Gets or sets the password.</summary>
        public string Password { get; set; }

        /// <summary>Gets or sets the phone.</summary>
        public string Phone { get; set; }
    }
}