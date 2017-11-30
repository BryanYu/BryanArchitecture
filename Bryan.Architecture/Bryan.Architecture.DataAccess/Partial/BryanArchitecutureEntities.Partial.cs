using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bryan.Architecture.DataAccess
{
    /// <summary>The bryan architecuture entities.</summary>
    public partial class BryanArchitecutureEntities
    {
        /// <summary>The save changes.</summary>
        /// <returns>The <see cref="int"/>.</returns>
        public override int SaveChanges()
        {
            var modifiedEntities = this.ChangeTracker.Entries().Where(p => p.State == EntityState.Modified).ToList();
            var now = DateTime.Now;

            foreach (var change in modifiedEntities)
            {
                var entityName = change.Entity.GetType().Name;
                var primaryKey = this.GetPrimaryKeyValue(change);

                foreach (var prop in change.OriginalValues.PropertyNames)
                {
                    var originalValue = change.OriginalValues[prop].ToString();
                    var currentValue = change.CurrentValues[prop].ToString();
                    if (originalValue != currentValue)
                    {
                        var auditLog =
                            new AuditLog
                            {
                                TableName = entityName,
                                PrimaryKeyValue = primaryKey.ToString(),
                                FieldName = prop,
                                OldValue = originalValue,
                                NewValue = currentValue,
                                ChangedDate = now
                            };
                        this.AuditLog.Add(auditLog);
                    }
                }
            }

            return base.SaveChanges();
        }

        /// <summary>The get primary key value.</summary>
        /// <param name="entry">The entry.</param>
        /// <returns>The <see cref="object"/>.</returns>
        private object GetPrimaryKeyValue(DbEntityEntry entry)
        {
            var objectStateEntry =
                ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);

            return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        }
    }
}