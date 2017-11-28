using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bryan.Architecture.DataAccess
{
    public partial class BryanArchitecutureEntities
    {
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}