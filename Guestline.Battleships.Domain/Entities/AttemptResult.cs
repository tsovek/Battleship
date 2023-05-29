namespace Guestline.Battleships.Domain.Entities
{
    public sealed class AttemptResult // to SmartEnum
    {
        public static readonly AttemptResult Unknown = new("Unknown", ' ');
        public static readonly AttemptResult Miss = new("Miss", 'x');
        public static readonly AttemptResult Hit = new("Hit", 'c');
        public static readonly AttemptResult HitAndSunk = new("Hit and sunk", 'o');

        private AttemptResult(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        public string Name { get; }
        public char Symbol { get; }

        internal static IEnumerable<AttemptResult> GetAll()
        {
            yield return Unknown; 
            yield return Miss; 
            yield return Hit; 
            yield return HitAndSunk; 
        }

        public override string ToString() => $"{Name}";
    }
}
