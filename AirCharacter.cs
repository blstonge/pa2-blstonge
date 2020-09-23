namespace pa2_blstonge
{
    public class AirCharacter :Character
    {
        public AirCharacter() : base()
        {
            SetAttackBehavior(new Air());
        }
    }
}