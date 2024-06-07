using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_3_Frode_og_Andre_lager_Pokemon
{
    internal class Trainer
    {
        public string Name { get; set; }
        public int Gold { get; set; }
        public List<Pokemon> pokemon = new List<Pokemon>();
        public int potions;
        public int pokeballs;
        public Trainer(string name, int gold, List<Pokemon> Poke, int Potions, int Pokeball)
        {
            Name = name;
            Gold = gold;
            pokemon = Poke;
            potions = Potions;
            pokeballs = Pokeball;
        }
    }
}
