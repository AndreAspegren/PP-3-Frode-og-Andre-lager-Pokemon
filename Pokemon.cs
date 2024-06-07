using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_3_Frode_og_Andre_lager_Pokemon
{
    internal class Pokemon
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string Type { get; set; }
        public int Max_HP { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }

        public Pokemon(string name, int level, string type, int maxHp, int hp, int attack)
        {
            Name = name;
            Level = level;
            Type = type;
            Max_HP = maxHp;
            HP = hp;
            Attack = attack;
        }
    }
}
