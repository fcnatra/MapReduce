

internal partial class Program
{
    internal class MapReduce
    {
        private const int OneMillion = 1000000;

        internal static void Run()
        {
            List<int> numbers = GenerateHugeListOfNumbers();

            // map step - group
            var mapped = numbers.GroupBy(x => x);

            // reduce step - count occurences of each number
            var reduced = mapped.Select(group => new {
                Number = group.Key,
                Count = group.Count()
            }).OrderBy(x => x.Number);

            var printableResult = System.Text.Json.JsonSerializer.Serialize(reduced);

            Console.WriteLine($"{nameof(OneMillion)} numbers reduced: {printableResult}");
        }

        private static List<int> GenerateHugeListOfNumbers()
        {

            List<int> numbers = [];
            var rnd = new Random();
            for(int i = 0; i < OneMillion; i++) numbers.Add(rnd.Next(1, 5));

            return numbers;
        }
    }
}