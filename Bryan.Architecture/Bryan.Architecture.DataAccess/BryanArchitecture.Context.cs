﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------


namespace Bryan.Architecture.DataAccess
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class BryanArchitecutureEntities : DbContext
{
    public BryanArchitecutureEntities()
        : base("name=BryanArchitecutureEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<User> User { get; set; }

    public virtual DbSet<AuditLog> AuditLog { get; set; }

}

}

