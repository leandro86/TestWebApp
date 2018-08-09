using System.Collections.Generic;

namespace TestWebApp.Models
{
    /// <summary>
    /// Defines a strongly typed paged collection of objects.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    public interface IPagedList<out T> : IReadOnlyCollection<T>, IPagedList
    {
    }
}
