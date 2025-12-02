namespace day01tests;

public class UnitTests
{
    [Fact]
    public void Test1()
    {
        var dial = new Dial(100, 50);
        dial.Turn(-68);
        Assert.Equal(82, dial.GetPosition());
        Assert.Equal(0, dial.GetZeroPositionStopCount());
        Assert.Equal(1, dial.GetZeroPositionVisitCount());
    }

    [Fact]
    public void Test2()
    {
        var dial = new Dial(100, 50);
        dial.Turn(-68);
        dial.Turn(-30);
        dial.Turn(48);
        Assert.Equal(0, dial.GetPosition());
        Assert.Equal(1, dial.GetZeroPositionStopCount());
        Assert.Equal(2, dial.GetZeroPositionVisitCount());
        dial.Turn(-5);
        dial.Turn(60);
        Assert.Equal(55, dial.GetPosition());
        Assert.Equal(1, dial.GetZeroPositionStopCount());
        Assert.Equal(3, dial.GetZeroPositionVisitCount());
        dial.Turn(-55);
        Assert.Equal(0, dial.GetPosition());
        Assert.Equal(2, dial.GetZeroPositionStopCount());
        Assert.Equal(4, dial.GetZeroPositionVisitCount());
        dial.Turn(-1);
        dial.Turn(-99);
        dial.Turn(14);
        dial.Turn(-82);
        Assert.Equal(32, dial.GetPosition());
        Assert.Equal(3, dial.GetZeroPositionStopCount());
        Assert.Equal(6, dial.GetZeroPositionVisitCount());
        dial.Turn(100);
        Assert.Equal(32, dial.GetPosition());
        Assert.Equal(3, dial.GetZeroPositionStopCount());
        Assert.Equal(7, dial.GetZeroPositionVisitCount());
    }

    [Fact]
    public void Test3()
    {
        var dial = new Dial(100, 50);
        dial.Turn(-399);
        Assert.Equal(51, dial.GetPosition());
        Assert.Equal(0, dial.GetZeroPositionStopCount());
        Assert.Equal(4, dial.GetZeroPositionVisitCount());
    }
}
