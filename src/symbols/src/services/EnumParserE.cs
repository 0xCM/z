//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EnumParser<E> : IParser<E>
        where E : unmanaged, Enum
    {
        public static EnumParser<E> Service = new();

        readonly Symbols<E> Syms;

        [MethodImpl(Inline)]
        public EnumParser()
        {
            Syms = Symbols.index<E>();
        }

        public Outcome Parse(string src, out E dst)
        {
            var input = text.ifempty(src,EmptyString);
            Outcome result = (false, AppMsgs.ParseFailure.Format(typeof(E).Name, input));
            dst = default;
            if(Syms.Lookup(input, out var sym))
            {
                dst = sym.Kind;
                result = true;
            }
            return result;
        }

        public Outcome Parse(string src, out EnumFormat<E> dst)
        {
            var result = Parse(src, out E e);
            if(result)
                dst = e;
            else
                dst = default;
            return result;
        }
    }
}