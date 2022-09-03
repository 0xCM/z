//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    /// <summary>
    /// Adapter for client code that expects to interface with the System.Random class
    /// </summary>
    public class PolySystem : System.Random
    {
        /// <summary>
        /// Derives the system random rng from polyrand
        /// </summary>
        /// <param name="source">The source rng</param>
        public static System.Random From(IPolySource source)
            => new PolySystem(source);

        public PolySystem(IPolySource source)
            => Source = source;

        readonly IPolySource Source;

        public override int Next()
            => Source.Next(Int32.MaxValue);

        public override int Next(int maxValue)
            => Source.Next(maxValue);

        public override int Next(int minValue, int maxValue)
            => Source.Next(minValue, maxValue);

        public override void NextBytes(byte[] buffer)
        {
            var src = Source.Bytes().Take(buffer.Length);
            var i = 0;
            var it = src.GetEnumerator();
            while(it.MoveNext())
                buffer[i++] = it.Current;
        }

        public override void NextBytes(Span<byte> buffer)
        {
            var src = Source.Bytes().Take(buffer.Length);
            var i = 0;
            var it = src.GetEnumerator();
            while(it.MoveNext())
                buffer[i++] = it.Current;
        }

        public override double NextDouble()
            => Source.Next<double>();
    }
}