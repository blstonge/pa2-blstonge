using System;

namespace pa2_blstonge
{
    public class Fire : IAttack
    {
        // performs the fire character attack
        public void Attack(Character attackingPlayer, Character defendingPlayer)
        {
            Console.WriteLine(attackingPlayer.Name + " attacked with a blast of fire!");

            int attackPower;
            // gives a 20% boost if they have the type advantage
            if (defendingPlayer.GetType().ToString() == "pa2_blstonge.EarthCharacter")
            {
                attackPower = Convert.ToInt32(attackingPlayer.AttackPower * 1.2);
            }
            else
            {
                attackPower = attackingPlayer.AttackPower;
            }
            
            defendingPlayer.Defend(attackPower, defendingPlayer);
        }
    }
}