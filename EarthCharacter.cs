namespace pa2_blstonge
{
    public class EarthCharacter : Character
    {
        public EarthCharacter() : base()
        {
            SetAttackBehavior(new Earth());
        }
    }
}