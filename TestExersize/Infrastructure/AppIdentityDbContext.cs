﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TestExersize.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TestExersize.Infrastructure
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Task> Tasks { get; set; }

        public AppIdentityDbContext() : base("name=UsersTaskDB") { }

        static AppIdentityDbContext()
        {
            Database.SetInitializer(new IdentityDbInit());
        }

        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }
    }

    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<AppIdentityDbContext>
    {
        protected override void Seed(AppIdentityDbContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }

        private void PerformInitialSetup(AppIdentityDbContext context)
        {

        }
    }
}