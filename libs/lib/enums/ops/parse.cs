//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Enums
    {
        [Parser]
        public static Outcome parse<E>(string src, out E dst)
            where E : unmanaged
        {
            if(Enum.TryParse(src, true, out dst))
                return true;
            else
            {
                dst = default;
                return false;
            }
        }

        public static Outcome parse(Type t, string src, out object dst)
            => Enum.TryParse(t, src, out dst);

        /// <summary>
        /// Attempts to parses an enumeration literal, ignoring case, and returns a default value if parsing failed
        /// </summary>
        /// <param name="name">The literal name</param>
        /// <typeparam name="E">The enum type</typeparam>
        public static E parse<E>(string name, E @default)
            where E : unmanaged, Enum
        {
            if(Enum.TryParse(name,true,out E result))
                return result;
            else
                return @default;
        }

        /// <summary>
        /// Attempts o parse an enum literal, ignoring case, and returns a null value if parsing failed
        /// </summary>
        /// <param name="name">The literal name</param>
        /// <typeparam name="E">The enum type</typeparam>
        public static ParseResult<E> parse<E>(string name)
            where E : unmanaged, Enum
        {
            if(Enum.TryParse(name, true, out E result))
                return ParseResult.parsed(name, result);
            else
                return ParseResult.unparsed<E>(name);
        }
    }
}