namespace day02tests;

public class UnitTests
{
    [Theory]
    [InlineData("11-22", 2, new long[] { 11, 22 })]
    [InlineData("95-115", 1, new long[] { 99 })]
    public void Test1(string rangeKey, int expectedInvalidCount, long[] expectedInvalidIds)
    {
        var db = new GiftShopDatabase("11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124");
        var invalidIds = db.GetInvalidProductIds(rangeKey);
        Assert.Equal(expectedInvalidCount, invalidIds.Length);
        Assert.Equal(expectedInvalidIds, invalidIds);
    }

    [Fact]
    public void Test2()
    {
        var db = new GiftShopDatabase("11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124");
        var sumOfAllInvalidProductIds = db.GetSumOfAllInvalidProductIds();
        Assert.Equal(1227775554, sumOfAllInvalidProductIds);
    }

    [Theory]
    [InlineData("11-22", 2, new long[] { 11, 22 })]
    [InlineData("95-115", 2, new long[] { 99, 111 })]
    public void Test3(string rangeKey, int expectedInvalidCount, long[] expectedInvalidIds)
    {
        var db = new GiftShopDatabase("11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124");
        var invalidIds = db.GetExtendedInvalidProductIds(rangeKey);
        Assert.Equal(expectedInvalidCount, invalidIds.Length);
        Assert.Equal(expectedInvalidIds, invalidIds);
    }

    [Fact]
    public void Test4()
    {
        var db = new GiftShopDatabase("11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124");
        var sumOfAllExtendedInvalidProductIds = db.GetSumOfAllExtendedInvalidProductIds();
        Assert.Equal(4174379265, sumOfAllExtendedInvalidProductIds);
    }

}

