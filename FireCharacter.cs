namespace pa2_blstonge
{
    public class FireCharacter : Character
    {
        public FireCharacter() : base()
        {
            SetAttackBehavior(new Fire());
        }
    }
}