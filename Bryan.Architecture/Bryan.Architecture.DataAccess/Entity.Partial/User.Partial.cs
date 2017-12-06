using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bryan.Architecture.DataAccess.Attribute;

namespace Bryan.Architecture.DataAccess
{
    /// <summary>The user.</summary>
    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
    }

    /// <summary>The user meta data.</summary>
    public partial class UserMetaData
    {
        /// <summary>Gets or sets the phone.</summary>
        [Audit]
        public string Phone { get; set; }
    }
}