//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        /// <summary>
        /// Returns the text right of, but not including, a specified index; or empty if invalid index is provided
        /// </summary>
        /// <param name="src"></param>
        /// <param name="index"></param>
        [MethodImpl(Inline), Op]
        public static string right(string src, int index)
        {
            if(empty(src) || index < 0)
                return EmptyString;

            var length = src.Length;
            if(length == 0)
                return EmptyString;

            if(index < length - 1)
                return slice(src, index + 1);
            else
                return EmptyString;
        }

        [Op]
        public static string right(string src, char match)
        {
            var i = index(src,match);
            if(i>0)
                return right(src,i);
            else
                return EmptyString;
        }

        [Op]
        public static string right(string src, string match)
        {
            var i = index(src, match);
            if(i>0)
                return right(src, i + match.Length - 1);
            else
                return EmptyString;
        }
    }
}