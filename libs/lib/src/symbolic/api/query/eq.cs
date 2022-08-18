//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct SymbolicQuery
    {
        /// <summary>
        /// Returns true if the character spans are equal as strings, false otherwise
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Op]
        public static bool eq(ReadOnlySpan<char> a, ReadOnlySpan<char> b)
            => a.CompareTo(b, StringComparison.InvariantCulture) == 0;

        /// <summary>
        /// Returns true if the character spans are equal as strings, false otherwise
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Op]
        public static bool eq(Span<char> a, ReadOnlySpan<char> b)
            => eq(a.ReadOnly(), b);

        /// <summary>
        /// Returns true if the character spans are equal as strings, false otherwise
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Op]
        public static bool eq(Span<char> a, Span<char> b)
            => eq(a.ReadOnly(), b.ReadOnly());

        [MethodImpl(Inline), Op]
        public static bool equals(in SegRef<char> a, ReadOnlySpan<char> b)
        {
            var count = a.Length;
            if(count != b.Length)
                return false;

            var match = true;
            ref readonly var left = ref a.First;
            ref readonly var right = ref first(b);
            for(var i=0; i<count; i++)
            {
                match &= (skip(left,i) == skip(right,i));
                if(!match)
                    break;
            }
            return match;
        }
    }
}