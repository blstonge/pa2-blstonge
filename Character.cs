using System;

namespace pa2_blstonge
{
    public class Character
    {
        // all autoimplemented variables for a Character
        public string Name{get; set;}
        public int MaxPower{get; set;}
        public int Health{get; set;}
        public int AttackPower{get; set;}
        public double DefensePower{get; set;}
        public int Speed{get; set;}

        // behavior variables
        public IAttack attackBehavior;
        public IDefend defendBehavior;

        // generates stats for a character
        public void GenerateStats()
        {
            var randomNum = new Random();
            MaxPower = randomNum.Next(1,100);
            Health = 100;
            AttackPower = randomNum.Next(1, MaxPower);
            DefensePower = randomNum.NextDouble(); // characters are allowed to resist up to 99% of their opponents attack
            Speed = randomNum.Next(1, MaxPower); // speed stat is used to decide who attacks first
            defendBehavior = new Defense();
        }

        // sets the attack behavior
        public void SetAttackBehavior(IAttack value)
        {
            attackBehavior = value;
        }

        // sets the defensebehavior
        public void SetDefenseBehavior(IDefend value)
        {
            defendBehavior = value;
        }

        // calculates the damage done andupdates the health stat
        public void Defend(int damage, Character defendingPlayer)
        {
            damage = defendBehavior.Defend(damage, defendingPlayer);
            Health -= damage;
            Console.WriteLine($"{damage} damage was done to {this.Name}!");
        }

        // displays stats
        public void ViewStats()
        {
            Console.WriteLine($"{Name}\nHealth: {Health}\nAttack: {AttackPower}\nDefense: {DefensePower * 100}%\nSpeed: {Speed}");
        }
    }
}