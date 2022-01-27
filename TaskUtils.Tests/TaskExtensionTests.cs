using System;
using System.Threading.Tasks;
using Xunit;

namespace TaskUtils.Tests;

public class TaskExtensionTests
{
    [Fact]
    public void WhenAll_WhenNoException_ShouldNoException()
    {
        var task1 = Task.Delay(1);
        var task2 = Task.Delay(1);

        _ = Task.Run(() => TaskExtension.WhenAll(task1, task2));

        Assert.True(true);
    }

    [Fact]
    public void WhenAll_WhenException_ShouldAggregateException()
    {
        var task1 = Task.Delay(1);
#pragma warning disable CS1998
        var task2 = Task.Run(async () => throw new Exception());
#pragma warning restore CS1998

        Assert.Throws<AggregateException>(() => TaskExtension.WhenAll(task1, task2));
    }

    [Fact]
    public void WhenAllT_WhenNoException_ShouldNoException()
    {
        var task1 = GetIntAsync();
        var task2 = GetIntAsync();

        _ = Task.Run(() => TaskExtension.WhenAll(task1, task2));

        Assert.True(true);

        async Task<int> GetIntAsync()
        {
            await Task.Delay(1);
            return 1;
        }
    }

    [Fact]
    public void WhenAllT_WhenException_ShouldAggregateException()
    {
        var task1 = GetIntAsync();
        var task2 = ThrowIntAsync();

        Assert.ThrowsAsync<AggregateException>(async () => await TaskExtension.WhenAll(task1, task2));

        async Task<int> GetIntAsync()
        {
            await Task.Delay(1);
            return 1;
        }

#pragma warning disable CS1998
        async Task<int> ThrowIntAsync()
#pragma warning restore CS1998
        {
            throw new Exception();
        }
    }
}