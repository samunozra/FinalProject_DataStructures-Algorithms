using System.Diagnostics;
using Xunit;
internal class ProgramTests
{
    [Fact]
    public void TestGraphEfficiency()
    {
        // Given
        Graph<Node> graph= new Graph<Node>();
        Stopwatch time = new Stopwatch();
    
        // When
        time.Start();
        for (int i = 0; i < 1000; i++)
        {
            graph.AddNode(new Node(i));
        }
        time.Stop();
        // Then

        Assert.True(time.ElapsedMilliseconds > Math.Log(1000));
    }
}
