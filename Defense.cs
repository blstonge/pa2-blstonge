using System;
namespace pa2_blstonge
{
    public class Defense : IDefend
    {
        public int Defend(int power, Character defendingPlayer)
        {
            power = Convert.ToInt32(power * defendingPlayer.DefensePower);
            return power;
        }
    }
}