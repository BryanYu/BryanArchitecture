using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bryan.Architecture.DomainModel.Dto.User
{
    /// <summary>The update user dto.</summary>
    public class UpdateUserDto
    {
        /// <summary>Gets or sets the id.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the phone.</summary>
        public string Phone { get; set; }
    }
}