using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    internal class Board
    {
        public Board(int size, List<Jumper> snake, List<Jumper> ladder, int dices)
        {
            Console.WriteLine("Please wait while we are initializing the game");
            _size = size;
            _Snake = snake;
            _Ladder = ladder;
            _players = new Queue<Player>();
            _numberOfDices = dices;
        }

        public int _size { get; set; }
        public int _numberOfDices { get; set; }
        public List<Jumper> _Snake { get; set; }
        public List<Jumper> _Ladder { get; set; }
        public Queue<Player> _players { get; set; }


        public Queue<Player> AddNewPlayer(string name)
        {
            Player p = new Player(name);
            _players.Enqueue(p);
            return _players;
        }


        public void StartGame()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("Starting New Game");
            bool win = false;

            while (!win)
            {
                Player player = _players.Dequeue();
                int pos = player.RollDices(_numberOfDices);
                int newPos = player.GetPlayerNewPosition(pos, _Snake, _Ladder);
                _players.Enqueue(player);

                if (newPos == 100)
                {
                    win = true;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Congradulations {0} for winning the game", player.Name);
                    Console.ForegroundColor = ConsoleColor.White;
                    
                }
            }
        }
    }
}
