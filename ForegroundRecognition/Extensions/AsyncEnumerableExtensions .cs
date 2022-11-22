
namespace ForegroundRecognition.Extensions;

internal static class AsyncEnumerableExtensions
{
    public static async IAsyncEnumerable<T> ToAsyncEnumerable<T>(this IEnumerable<T> enumerable)
    {
        using IEnumerator<T> enumerator = enumerable.GetEnumerator();

        while (await Task.Run(enumerator.MoveNext).ConfigureAwait(false))
        {
            yield return enumerator.Current;
        }
    }
}
