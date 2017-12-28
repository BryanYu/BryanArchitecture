using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bryan.Architecture.Utility.Email.Interface
{
    /// <summary>The EmailSender interface.</summary>
    public interface IEmailSender
    {
        /// <summary>The send.</summary>
        void Send();
    }
}