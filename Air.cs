using System;

namespace pa2_blstonge
{
    public class Air : IAttack
    {
        // performs the air caracter attack
        public void Attack(Character attackingPlayer, Character defendingPlayer)
        {
            Console.WriteLine(attackingPlayer.Name + " attacked with a mighty gust of wind!");

            int attackPower;
            // gives a 20% boost if they have the type advantage
            if (defendingPlayer.GetType().ToString() == "pa2_blstonge.FireCharacter")
            {
                attackPower = Convert.ToInt32(attackingPlayer.AttackPower * 1.2);
            }
            else
            {
                attackPower = attackingPlayer.AttackPower;
                Console.WriteLine(defendingPlayer.GetType());
            }
            
            defendingPlayer.Defend(attackPower, defendingPlayer);
        }
    }
}