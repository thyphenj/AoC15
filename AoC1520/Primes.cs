public static class PrimeTable
{
    public static IEnumerable<int> Primes()
    {
        return new[] { 2 }.Concat(OddInts().Where(x =>
        {
            var sqrt = Math.Sqrt(x);
            return !OddInts()
                        .TakeWhile(y => y <= sqrt)
                        .Any(y => x % y == 0);
        }));
    }

    private static IEnumerable<int> OddInts()
    {
        int start = 1;
        while (start > 0)
        {
            yield return start += 2;
        }
    }

}