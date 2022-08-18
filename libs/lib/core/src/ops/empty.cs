//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Returns a canonical non-null empty value
        /// </summary>
        /// <typeparam name="T">The value type</typeparam>
        [MethodImpl(Inline)]
        public static T EmptyType<T>()
        {
            if(typeof(T) == typeof(string))
                return generic<T>(EmptyString);
            else if(typeof(T) == typeof(Type))
                return generic<T>(typeof(void));
            else
                return default;
        }

        /// <summary>
        /// Tests whether a specified <see cref='string'/> is either null or of zero length
        /// </summary>
        /// <param name="src">The source text</param>
        [MethodImpl(Inline)]
        public static bool empty(string src)
            => string.IsNullOrEmpty(src);

        /// <summary>
        /// Tests whether a specified <see cref='char'/> matches the <see cref='Chars.Null'/> character
        /// </summary>
        /// <param name="src">The source text</param>
        [MethodImpl(Inline), Op]
        public static bool empty(char src)
            => src == Chars.Null;
    }
}