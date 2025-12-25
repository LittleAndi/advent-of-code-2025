// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

var lines = File.ReadAllLines("day02/input.txt");

var db = new GiftShopDatabase(lines[0]);
Console.WriteLine($"Sum of all invalid product IDs: {db.GetSumOfAllInvalidProductIds()}");

Console.WriteLine($"Sum of all extended invalid product IDs: {db.GetSumOfAllExtendedInvalidProductIds()}");

public class GiftShopDatabase
{
    private readonly Dictionary<string, (long Start, long End)> productIdRanges = [];
    public GiftShopDatabase(string init)
    {
        var initParser = new Regex(@"((\d+)-(\d+))");
        var matches = initParser.Matches(init);
        foreach (Match match in matches)
        {
            var productIdRangeKey = match.Groups[0].Value;
            var rangeStart = long.Parse(match.Groups[2].Value);
            var rangeEnd = long.Parse(match.Groups[3].Value);
            productIdRanges[productIdRangeKey] = (rangeStart, rangeEnd);
        }
    }

    public long[] GetInvalidProductIds(string rangeKey)
    {
        var start = productIdRanges[rangeKey].Start;
        var end = productIdRanges[rangeKey].End;

        var invalidIds = new List<long>();

        for (long id = start; id <= end; id++)
        {
            if (id.ToString().Length % 2 != 0)
            {
                continue;
            }
            var idStr = id.ToString();
            var leftHalf = idStr[..(idStr.Length / 2)];
            var rightHalf = idStr[(idStr.Length / 2)..];
            if (leftHalf == rightHalf)
            {
                invalidIds.Add(id);
            }
        }
        return [.. invalidIds];
    }

    public long[] GetExtendedInvalidProductIds(string rangeKey)
    {
        var start = productIdRanges[rangeKey].Start;
        var end = productIdRanges[rangeKey].End;
        var regex = new Regex(@"^(\d+)\1+$");

        var invalidIds = new List<long>();

        for (long id = start; id <= end; id++)
        {
            var idStr = id.ToString();

            bool isInvalid = false;
            if (regex.IsMatch(idStr))
            {
                isInvalid = true;
            }
            else
            {
                var leftHalf = idStr[..(idStr.Length / 2)];
                var rightHalf = idStr[(idStr.Length / 2)..];
                if (leftHalf == rightHalf)
                {
                    isInvalid = true;
                }
            }

            if (isInvalid)
            {
                invalidIds.Add(id);
            }
        }
        return [.. invalidIds];
    }

    public long GetSumOfAllInvalidProductIds()
    {
        var allInvalidIds = new List<long>();
        foreach (var rangeKey in productIdRanges.Keys)
        {
            var invalidIds = GetInvalidProductIds(rangeKey);
            allInvalidIds.AddRange(invalidIds);
        }
        return allInvalidIds.Sum(id => (long)id);
    }

    public long GetSumOfAllExtendedInvalidProductIds()
    {
        var allInvalidIds = new List<long>();
        foreach (var rangeKey in productIdRanges.Keys)
        {
            var invalidIds = GetExtendedInvalidProductIds(rangeKey);
            allInvalidIds.AddRange(invalidIds);
        }
        return allInvalidIds.Sum(id => (long)id);
    }
}