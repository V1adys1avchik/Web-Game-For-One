using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web_Ankh_Mork.DB
{
    public class NPCContext : DbContext
    {
          public NPCContext():base("DefaultConnection") {}
    }
}