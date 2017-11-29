using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bryan.Architecture.DataAccess
{
    public partial class BryanArchitecutureEntities
    {
        public override int SaveChanges()
        {
            var modifiedEntities = ChangeTracker.Entries().Where(p => p.State == EntityState.Modified).ToList();
            var now = DateTime.Now;

            foreach (var change in modifiedEntities)
            {
                var entityName = change.Entity.GetType().Name;
                var primaryKey = GetPrimaryKeyValue(change);

                foreach (var prop in change.OriginalValues.PropertyNames)
                {
                    var originalValue = change.OriginalValues[prop].ToString();
                    var currentValue = change.CurrentValues[prop].ToString();
                    if (originalValue != currentValue)
                    {
                    }
                }
            }
            return base.SaveChanges();
        }

        private object GetPrimaryKeyValue(DbEntityEntry entry)
        {
            var objectStateEntry =
                ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);

            return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        }
    }
}