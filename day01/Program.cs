using System.Text.RegularExpressions;

var lines = File.ReadAllLines("day01/input.txt");
var inputRegex = new Regex(@"^(?<direction>[LR])(?<steps>\d+)$");

var dial = new Dial(100, 50);
foreach (var line in lines)
{
    var match = inputRegex.Match(line);
    var direction = match.Groups["direction"].Value;
    var steps = int.Parse(match.Groups["steps"].Value);

    if (direction == "L")
    {
        dial.Turn(-steps);
    }
    else if (direction == "R")
    {
        dial.Turn(steps);
    }
}
Console.WriteLine($"The dial returned to position 0 a total of {dial.GetZeroPositionStopCount()} times.");
Console.WriteLine($"The dial visited position 0 a total of {dial.GetZeroPositionVisitCount()} times.");

public class Dial
{
    private int position;
    private readonly int size;
    private int countZeroPositionStops = 0;
    private int countZeroPositionVisits = 0;

    public Dial(int size, int startPosition)
    {
        this.size = size;
        this.position = startPosition;
    }

    public void Turn(int steps)
    {
        int previousPosition = position;
        int entireRotations = steps / size;
        countZeroPositionVisits += Math.Abs(entireRotations);
        position = (position + steps) % size;
        if (position < 0)
        {
            position += size;
        }
        if (Math.Sign(steps) < 0 && position > previousPosition && previousPosition != 0)
        {
            countZeroPositionVisits++;
        }
        else if (Math.Sign(steps) > 0 && position < previousPosition && position != 0)
        {
            countZeroPositionVisits++;
        }
        if (position == 0)
        {
            countZeroPositionStops++;
            countZeroPositionVisits++;
        }
    }

    public int GetPosition()
    {
        return position;
    }

    public int GetZeroPositionStopCount()
    {
        return countZeroPositionStops;
    }

    public int GetZeroPositionVisitCount()
    {
        return countZeroPositionVisits;
    }
}