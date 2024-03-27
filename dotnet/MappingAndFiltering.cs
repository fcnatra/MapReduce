
internal class MappingAndFiltering
{
    internal static void Run()
    {
                List<DailyTask> dailyTasks = CreateSomeDailyTasks();
        
        // map step
        var taskNames = dailyTasks.Select(t => t.Name);

        // filter step
        var difficultTasks = dailyTasks.Where(t => t.DurationInMins >= 120);

        var printableDailyTasks = System.Text.Json.JsonSerializer.Serialize(dailyTasks);
        var printableTasksNames = System.Text.Json.JsonSerializer.Serialize(taskNames);
        var printableDifficultTasks = System.Text.Json.JsonSerializer.Serialize(difficultTasks);

        Console.WriteLine($"Intial tasks: {printableDailyTasks}");
        Console.WriteLine($"Map tasks names: {printableTasksNames}");
        Console.WriteLine($"Map tasks where duration >= 120: {printableDifficultTasks}");
    }

    private static List<DailyTask> CreateSomeDailyTasks()
    {
        var dailyTasks = new List<DailyTask> {
            new DailyTask("Write for the blog", 120),
            new DailyTask("Work out", 60),
            new DailyTask("Procrastinate on Duolingo", 240)
        };

        return dailyTasks;
    }
}

internal record DailyTask(string Name, int DurationInMins);