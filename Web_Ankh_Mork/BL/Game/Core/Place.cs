using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Ankh_Mork.BL.Game.Bar;
using Web_Ankh_Mork.BL.Game.Guid;

namespace Web_Ankh_Mork.BL.Game.Core
{
    public static class Place
    {
        private static Random rnd;
        public static IGuild GetRandomPlace()
        {
            rnd = new Random();
            switch (rnd.Next(1,6))
            {
                case 1:
                    return new AssasinGuid();
                case 2:
                    return new BeggarsGuid();
                case 3:
                    return new GuildOfFools();
                case 4:
                    if (GuildOfThiefs.thefts > 0)
                        return new GuildOfThiefs();
                    else
                        return null;
                case 5:
                    return null;
                default:
                    return new GuildOfFools();
            }
        }
    }
}