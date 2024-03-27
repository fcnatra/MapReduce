

using System.Diagnostics.Tracing;

internal partial class Program
{
    private static void Main(string[] args)
    {
        MappingAndFiltering.Run();

        Console.WriteLine();
        MapReduce.Run();
    }
}
