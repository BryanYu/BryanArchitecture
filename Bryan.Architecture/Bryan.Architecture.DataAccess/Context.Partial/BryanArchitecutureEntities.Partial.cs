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
            this.HandleChange();
            return base.SaveChanges();
        }

        /// <summary>The add audit log.</summary>
        /// <param name="entityEntry">The entity entry.</param>
        private void AddAuditLog(DbEntityEntry entityEntry)
        {
            var entityName = entityEntry.Entity.GetType().Name;
            object primaryKey = null;
            AuditLog auditLog = null;

            if (entityEntry.State == EntityState.Deleted)
            {
                auditLog = new AuditLog()
                {
                    ChangedDate = DateTime.Now,
                    FieldName = null,
                    Memo = EntityState.Deleted.ToString(),
                    NewValue = null,
                    OldValue = null,
                    PrimaryKeyValue = primaryKey.ToString(),
                    TableName = entityName
                };
            }
            else if (entityEntry.State == EntityState.Added)
            {
                base.SaveChanges();
                primaryKey = this.GetPrimaryKeyValue(entityEntry);
                auditLog = new AuditLog()
                {
                    ChangedDate = DateTime.Now,
                    FieldName = null,
                    Memo = EntityState.Added.ToString(),
                    NewValue = null,
                    OldValue = null,
                    PrimaryKeyValue = primaryKey.ToString(),
                    TableName = entityName
                };
            }
            else
            {
                primaryKey = this.GetPrimaryKeyValue(entityEntry);
                foreach (var prop in entityEntry.OriginalValues.PropertyNames)
                {
                    var originalValue = entityEntry.OriginalValues[prop].ToString();
                    var currentValue = entityEntry.CurrentValues[prop].ToString();

                    if (originalValue != currentValue)
                    {
                        auditLog = new AuditLog
                        {
                            TableName = entityName,
                            PrimaryKeyValue = primaryKey.ToString(),
                            FieldName = prop,
                            OldValue = originalValue,
                            NewValue = currentValue,
                            ChangedDate = DateTime.Now
                        };
                    }
                }
            }

            this.AuditLog.Add(auditLog);
        }

        /// <summary>The handle change.</summary>
        private void HandleChange()
        {
            var entities = this.ChangeTracker.Entries().ToList();
            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Property("CreateDate").CurrentValue = DateTime.Now;
                }

                entity.Property("UpdateDate").CurrentValue = DateTime.Now;
                this.AddAuditLog(entity);
            }
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