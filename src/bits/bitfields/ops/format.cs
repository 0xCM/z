//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Bitfields
    {
        public static string format<E>(BitVector64<E> src)
            where E : unmanaged, Enum
        {
            var symbols = Symbols.index<E>();
            var count = min(symbols.Length, 64);
            var dst = text.emitter();
            for(var i=z8; i<count; i++)
            {
                if(src[i])
                {
                    if(i>0)
                        dst.Append(", ");
                    dst.Append(symbols[i].Name);
                }
            }
            return dst.Emit();
        }

        [Op]
        public static string format(Bitfield8 src)
            => text.format(render(src));

        [Op]
        public static string format(Bitfield16 src)
            => text.format(render(src));

        [Op]
        public static string format(Bitfield32 src)
            => text.format(render(src));

        [Op]
        public static string format(Bitfield64 src)
            => text.format(render(src));

        /// <summary>
        /// Formats a field segments as {typeof(V):Name}:{TrimmedBits}
        /// </summary>
        /// <param name="value">The field value</param>
        /// <typeparam name="E">The field value type</typeparam>
        /// <typeparam name="T">The field data type</typeparam>
        public static string format<E,T>(E src, int? zpad = null)
            where E : unmanaged, Enum
            where T : unmanaged
                => format<E,T>(src, typeof(E).Name, zpad);

        /// <summary>
        /// Formats a field segments as {typeof(V):Name}:{TrimmedBits}
        /// </summary>
        /// <param name="value">The field value</param>
        /// <typeparam name="E">The field value type</typeparam>
        /// <typeparam name="T">The field data type</typeparam>
        public static string format<E,T>(E src, string name, int? zpad = null)
            where E : unmanaged, Enum
            where T : unmanaged
        {
            var data = Enums.scalar<E,T>(src);
            var limit = gbits.effwidth(data);
            var config = BitFormatter.limited(limit,zpad);
            var formatter = BitRender.formatter<T>(config);
            return string.Concat(name, Chars.Colon, formatter.Format(data));
        }
   }
}