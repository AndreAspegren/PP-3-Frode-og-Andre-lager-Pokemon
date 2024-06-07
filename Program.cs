namespace PP_3_Frode_og_Andre_lager_Pokemon
{
    class start
    {
        public static void Main()
        {
            new Program().Run();
        }
    }

    class Program
    {
        private string _name;
        private Random _random = new Random();
        List<Pokemon> pokemonList = new List<Pokemon>()
        {
            new Pokemon("Bulbasaur", 5, "Grass", 39, 39, 52),
            new Pokemon("Squirtle", 5, "Water", 45, 45, 49),
            new Pokemon("Charmander", 5, "Fire", 44, 44, 48),
            new Pokemon("Vulpix", 10, "Fire", 38, 38, 41),
            new Pokemon("Oddish", 10, "Grass", 45, 45, 50),
            new Pokemon("Psyduck", 10, "Water", 50, 50, 52),
            new Pokemon("Growlithe", 15, "Fire", 55, 55, 70),
            new Pokemon("Bellsprout", 15, "Grass", 50, 50, 75),
            new Pokemon("Poliwag", 15, "Water", 40, 40, 50),
            new Pokemon("Cyndaquil", 5, "Fire", 39, 39, 52)
        };
        public List<Pokemon> PlayerPokemon = new List<Pokemon>();
        private List<Trainer> player = new List<Trainer>();
        public Trainer CurrentPlayer;

        public void Run()
        {
            Console.WriteLine("Hva vil du hete?");
            _name = Console.ReadLine();

            Console.WriteLine(@$"Hva skal din starter pokemon være?");
            var starterList = new List<Pokemon>()
            {
                new Pokemon("Bulbasaur", 5, "Grass", 20, 20, 8),
                new Pokemon("Squirtle", 5, "Water", 15, 15, 10),
                new Pokemon("Charmander", 5, "Fire", 12, 12, 12),
            };

            for(int i = 0; i < starterList.Count; i++) {
                Console.WriteLine($"{i}. Name: {starterList[i].Name} Type: {starterList[i].Type}");
            }

            var chosenPokemon = Convert.ToInt32(Console.ReadLine());
            PlayerPokemon.Add(starterList[chosenPokemon]);

            player.Add(new Trainer(_name, 100, PlayerPokemon, 5, 5));
            CurrentPlayer = player[0];

            while (true)
            {
                Console.Clear();
                Console.WriteLine
                    ($"1 for å shoppe, " +
                    $"2 for å sloss med ville pokemon, " +
                    $"3 for å se dine pokemon," +
                    $"4 for å gå til pokemon center");

                
                var shopOrFIght = Console.ReadLine();
                Console.Clear();
                if (shopOrFIght == "1") shopItems();
                if (shopOrFIght == "2") fightWildPokemon();
                else if (shopOrFIght == "3") showPokemon();
                else if (shopOrFIght == "4") pokemonCenter();
            }
        }

        private void pokemonCenter()
        {
            foreach(var pokemon in player[0].pokemon)
            {
                pokemon.HP = pokemon.Max_HP;
                Console.Clear();
            }
            Console.Clear();
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.WriteLine("..");
            Thread.Sleep(500);
            Console.WriteLine("...");
            Thread.Sleep(500);

            Console.WriteLine("Dine pokemon har blitt helbreda");
            Console.WriteLine("(Trykk på ein knapp for å fortsette)");
            Console.ReadKey(true);
        }

        private void shopItems()
        {
            Console.WriteLine(@$"Hva vil du kjøpe? Du har {player[0].Gold} gull.
Priser:
Potion = 20 gull (trykk 1)
Pokeball = 20 gull (trykk 2)
");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    if (player[0].Gold >= 20)
                    {
                        player[0].Gold -= 20;
                        player[0].potions++;
                        Console.WriteLine("Du kjøpte en potion.");
                        Console.WriteLine("(Trykk på ein knapp for å fortsette)");
                        Console.ReadKey(true);
                    }
                    else
                        Console.WriteLine("Ikke nok penger.");
                        Console.WriteLine("(Trykk på ein knapp for å fortsette)");
                        Console.ReadKey(true);
                    ;

                    break;
                case "2":
                    if (player[0].Gold >= 20)
                    {
                        player[0].Gold -= 20;
                        player[0].pokeballs++;
                        Console.WriteLine("Du kjøpte en pokeball.");
                        Console.WriteLine("(Trykk på ein knapp for å fortsette)");
                        Console.ReadKey(true);
                    }
                    else
                        Console.WriteLine("Ikke nok penger.");
                        Console.WriteLine("(Trykk på ein knapp for å fortsette)");
                        Console.ReadKey(true);
                    ;
                    break;
            }
        }

        private void showPokemon()
        {
            foreach (var pokemon in CurrentPlayer.pokemon)
            {
                Console.WriteLine($"{pokemon.Name}\t lvl: {pokemon.Level} \t HP:{pokemon.HP}/{pokemon.Max_HP}");
                Console.ReadKey(true);
            };
        }

        private void fightWildPokemon()
            {
                Console.Clear();
                Console.WriteLine("Hvilket terreng vil du gå i? 1 for vann, 2 for gress, 3 for flamme");
                var terrainInput = Convert.ToInt32(Console.ReadLine());
                var filteredPokemonList = new List<Pokemon>();
                foreach (var filteredPokemon in pokemonList)
                {
                    if (terrainInput == 1 && filteredPokemon.Type == "Water") filteredPokemonList.Add(filteredPokemon);
                    else if (terrainInput == 2 && filteredPokemon.Type == "Grass") filteredPokemonList.Add(filteredPokemon);
                    else if (terrainInput == 3 && filteredPokemon.Type == "Fire") filteredPokemonList.Add(filteredPokemon);
                }
                wildEncounter(filteredPokemonList[_random.Next(0, filteredPokemonList.Count)]);
            }

            private void wildEncounter(Pokemon pokemon)
            {
                
                var runAway = _random.Next(0, 100);
                var gameOn = true;
                while (gameOn && CurrentPlayer.pokemon[0].HP > 0 && pokemon.HP > 0)
                {
                    Console.Clear();
                    Console.WriteLine(@$"
Din pokemon: {CurrentPlayer.pokemon[0].Name}   Wild pokemon: {pokemon.Name}
Hp: {CurrentPlayer.pokemon[0].HP}                          {pokemon.HP}
");
                    if (runAway < 20)
                    {
                        Console.WriteLine($"{pokemon.Name} stakk av!");
                        Thread.Sleep(4000);
                        return;
                    }
                    Console.WriteLine("Vil du angripe eller fange pokemon? 0 for angripe, 1 for fange.");
                    var input = Console.ReadLine();
                    if (input == "0") attackPokemon(pokemon);
                    if (input == "1") gameOn = catchPokemon(pokemon, gameOn);
                }
            }

            private bool catchPokemon(Pokemon pokemon, bool gameOn)
            {
                var random = _random.Next(0, 100);

                Console.Clear();
                Console.WriteLine(".");
                Thread.Sleep(500);
                Console.WriteLine("..");
                Thread.Sleep(500);
                Console.WriteLine("...");
                Thread.Sleep(500);

                if (random < 50)
                {
                    PlayerPokemon.Add(pokemon);
                    Console.WriteLine($"Du fanget {pokemon.Name}");
                    gameOn = false;
                }
                else if (random >= 50) Console.WriteLine($"{pokemon.Name} gikk ikke i ballen. Unlucky!");
                return gameOn;
            }

            private void attackPokemon(Pokemon pokemon)
            {
                CurrentPlayer.pokemon[0].HP -= pokemon.Attack;
                Console.Clear();
                Console.WriteLine($"{pokemon.Name} angripte {CurrentPlayer.pokemon[0].Name} for {pokemon.Attack} skade");
                Thread.Sleep(500);
                pokemon.HP -= CurrentPlayer.pokemon[0].Attack;
                Console.WriteLine($"{CurrentPlayer.pokemon[0].Name} angripte {pokemon.Name} for {CurrentPlayer.pokemon[0].Attack} skade");
                Thread.Sleep(500);

                if (pokemon.HP <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Du beseiret {pokemon.Name}");
                    Console.WriteLine("(Trykk på ein knapp for å fortsette)");
                    Console.ReadKey(true);
                } else if (CurrentPlayer.pokemon[0].HP <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"{CurrentPlayer.pokemon[0].Name} har blitt beseiret");
                    Console.WriteLine("(Trykk på ein knapp for å fortsette)");
                    Console.ReadKey(true);
                }
            }
    }
    }

