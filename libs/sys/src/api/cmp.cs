//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Compares two <see cref='string'/> operands via the default <see cref='IComparable'/> implementation
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [Op]
        public static int cmp(string a, string b)
            => string.Compare(a,b);

        /// <summary>
        /// Compares two <see cref='char'/> operands via the default <see cref='IComparable'/> implementation
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Op]
        public static int cmp(char a, char b)
            => a.CompareTo(b);

        [MethodImpl(Inline)]
        public static int cmp<C>(string a, string b, C @case)
            where C : ILetterCase
                => @case.Kind == 0 ? string.Compare(a,b,true) : string.Compare(a,b);
    }
}