using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Warior_Game
{
    class Battle
    {
        public static void StartFight()
        {
            Warrior warrior1 = new Warrior("Danne", 100, 125, 85);
            Warrior warrior2 = new Warrior("Nany", 100, 85, 125);

            while ((warrior1.health > 0) && (warrior2.health > 0 ))
            {
                GetAttackResult(warrior1, warrior2);
                GetAttackResult(warrior2, warrior1);
            }
        }

        private static void GetAttackResult(Warrior warriorA, Warrior warriorB)
        {
            int aAttack = warriorA.Attack();
            int bBlock = warriorB.Block();

            if (aAttack > bBlock)
            {
                int damage = aAttack - bBlock;
                warriorB.health -= damage;
                Console.WriteLine("{0} was attacked by {1} for {2} damage", warriorB.name, warriorA.name, damage);
            }
            else
            {
                Console.WriteLine("{0} blocked {1}'s attack", warriorB.name, warriorA.name);
            }
            Console.WriteLine("{0} has {1} hp", warriorB.name, warriorB.health);
        }
    }
}
