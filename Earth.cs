using System;

namespace pa2_blstonge
{
    public class Earth : IAttack
    {
        // performs the earth character attack
        public void Attack(Character attackingPlayer, Character defendingPlayer)
        {
            Console.WriteLine(attackingPlayer.Name + " attacked with a mighty boulder!");

            int attackPower;
            // gives a 20% boost if they have the type advantage
            if (defendingPlayer.GetType().ToString() == "pa2_blstonge.AirCharacter")
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