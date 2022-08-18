//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class text
    {
        [MethodImpl(Inline), Op]
        public static bool equals(char a, char b)
            => a == b;

        /// <summary>
        /// Performs a string comparison according to a specified comparison type
        /// </summary>
        /// <param name="a">The first string</param>
        /// <param name="b">The second string</param>
        /// <param name="type">The comparison type</param>
        [MethodImpl(Inline), Op]
        public static bool equals(string a, string b, StringComparison type)
            => string.Equals(a,b, type);

        /// <summary>
        /// Performs a case-insensitive comparison on two source strings
        /// </summary>
        /// <param name="a">The first string</param>
        /// <param name="b">The second string</param>
        [MethodImpl(Inline), Op]
        public static bool equals(string a, string b)
            => string.Equals(a,b, NoCase);

        /// <summary>
        /// Performs a string comparison according to a specified comparison type
        /// </summary>
        /// <param name="a">The first string</param>
        /// <param name="b">The second string</param>
        /// <param name="type">The comparison type</param>
        [MethodImpl(Inline), Op]
        public static bool neq(string a, string b, StringComparison type)
            => !equals(a, b, type);

        [Op]
        public static bool equals(ReadOnlySpan<string> a, ReadOnlySpan<string> b, bool matchcase = true)
        {
            var result = true;
            var ct = matchcase ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase;
            var count = a.Length;
            result = (count == b.Length);
            if(result)
            {
                for(var i=0; i<count; i++)
                {
                    result = string.Equals(skip(a,i), skip(b,i), ct);
                    if(!result)
                        break;
                }
            }

            return result;
        }
    }
}