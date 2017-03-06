namespace raklet
{
    internal static class ArrayExtensions
    {
        internal static bool IsNullOrEmpty<T>(this T[] arr)
        {
            return arr == null || arr.Length == 0;
        }
    }
}
