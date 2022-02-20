using System.Collections;
using System.Collections.Generic;

namespace TransparentImage.Common
{
    public class Optional<T> : IEnumerable<T>
    {
        private IEnumerable<T> Content { get; }
        private Optional(IEnumerable<T> content)
        {
            this.Content = content;
        }
        public static Optional<T> Some(T value) => new Optional<T>(new[] { value });

        public static Optional<T> None() => new Optional<T>(new T[0]);

        public IEnumerator<T> GetEnumerator() => this.Content.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
