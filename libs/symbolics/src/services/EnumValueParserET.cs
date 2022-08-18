//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EnumValueParser<E,T> : IParser<T>
        where E : unmanaged, Enum
        where T : unmanaged
    {
        readonly Symbols<E> Syms;

        public EnumValueParser()
        {
            Syms = Symbols.index<E>();
        }

        public Outcome Parse(string src, out T dst)
        {
            dst = default;
            var result = Outcome.Failure;
            if(typeof(T).IsSignedInt())
            {
                result = DataParser.parse(src, out long value);
                if(result)
                    dst = Numeric.force<T>(value);
            }
            else if(typeof(T).IsUnsignedInt())
            {
                result = DataParser.parse(src, out ulong value);
                if(result)
                    dst = Numeric.force<T>(value);
            }
            return result;
        }
    }
}
