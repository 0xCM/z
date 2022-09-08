//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Lines
    {
        /// <summary>
        /// Calculates the length of each line in the source
        /// Adapted from: https://github.com/dotnet/source-indexer
        /// </summary>
        /// <param name="src"></param>
        public static Index<uint> lengths(ReadOnlySpan<char> src)
        {
            if (src == null)
                throw new ArgumentNullException();

            if (src.Length == 0)
                return new uint[0];

            var dst = new List<uint>();
            var length = 0u;
            var previousWasCarriageReturn = false;

            for (var i = 0; i<src.Length; i++)
            {
                ref readonly var c = ref skip(src,i);
                if (c == '\r')
                {
                    if (previousWasCarriageReturn)
                    {
                        dst.Add(length);
                        length = 1;
                    }
                    else
                    {
                        length++;
                        previousWasCarriageReturn = true;
                    }
                }
                else if (c == '\n')
                {
                    previousWasCarriageReturn = false;
                    length++;
                    dst.Add(length);
                    length = 0;
                }
                else
                {
                    length++;
                    previousWasCarriageReturn = false;
                }
            }

            dst.Add(length);

            if(previousWasCarriageReturn)
                dst.Add(0);

            return dst.ToArray();
        }
    }
}