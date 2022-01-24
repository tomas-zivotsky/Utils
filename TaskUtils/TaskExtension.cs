namespace TaskUtils;

public static class TaskExtension
{
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
