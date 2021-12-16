using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Web_Ankh_Mork.DB.Entity;

namespace Web_Ankh_Mork.DB
{
    public class AnkhMorokContext : DbContext
    {
        static private bool created = false;
        public AnkhMorokContext() : base("DefaultConnection")
        {
            if (!created)
            {
                
                Database.SetInitializer(new MyContextInitializer());
                created = true;
            }
        }

        public DbSet<Assasin> Assasins { get; set; }
        public DbSet<Beggar> Beggars { get; set; }
        public DbSet<Thief> Thiefs { get; set; }
        public DbSet<Fool> Fools { get; set; }

    }
}