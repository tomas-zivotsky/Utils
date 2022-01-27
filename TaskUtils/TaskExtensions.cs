namespace TaskUtils;

public static class TaskExtensions
{
    public static Task WhenAll(params Task[] tasks)
    {
        var allTasks = Task.WhenAll(tasks);

        if (allTasks.Exception is null) return allTasks;

        throw allTasks.Exception ?? throw new Exception("Aggregated exception is not set.");
    }

    public static async Task<IEnumerable<T>> WhenAll<T>(params Task<T>[] tasks)
    {
        var allTasks = Task.WhenAll(tasks);

        try
        {
            return await allTasks;
        }
        catch (Exception)
        {
            // ignored
        }

        throw allTasks.Exception ?? throw new Exception("Aggregated exception is not set.");
    }
}
