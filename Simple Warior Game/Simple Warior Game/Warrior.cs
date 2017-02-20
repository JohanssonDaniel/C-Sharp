using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Warior_Game
{
    class Warrior
    {
        public string name { get; set; } = "No Name";
        public int health { get; set; } = 0;
        public int maxAttack { get; set; } = 0;
        public int maxBlock { get; set; } = 0;

        private Random randAttack = new Random(Guid.NewGuid().GetHashCode());
        private Random randBlock = new Random(Guid.NewGuid().GetHashCode());

        public Warrior(string name, int health, int maxAttack, int maxBlock)
        {
            this.name = name;
            this.health = health;
            this.maxAttack = maxAttack;
            this.maxBlock = maxBlock;
        }

        // Generates a random attack value between 1 and the maximum attack value of a warrior
        public int Attack()
        {
            return randAttack.Next(1, maxAttack);
        }
        // Generates a random block value between 1 and the maximum block value of a warrior
        public int Block()
        {
            return randBlock.Next(1, maxBlock);
        }
        // Shows the statistics of a warrior
        public void ShowWarriorStats()
        {
            Console.WriteLine($"{name} has {health} hp, {maxAttack} attack strength and {maxBlock} block strength");
        }
    }
}
