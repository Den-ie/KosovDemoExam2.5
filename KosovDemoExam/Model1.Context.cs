﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KosovDemoExam
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class user32Entities1 : DbContext
    {
        public user32Entities1()
            : base("name=user32Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<agent> agents { get; set; }
        public virtual DbSet<apartment> apartments { get; set; }
        public virtual DbSet<client> clients { get; set; }
        public virtual DbSet<ddd> ddds { get; set; }
        public virtual DbSet<house> houses { get; set; }
        public virtual DbSet<land> lands { get; set; }
        public virtual DbSet<supply> supplies { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<district> districts { get; set; }

        private static user32Entities1 _context;

        public static user32Entities1 GetContext()
        {
            if (_context == null)
            {
                _context = new user32Entities1();
            }
            return _context;
        }
    }
}
