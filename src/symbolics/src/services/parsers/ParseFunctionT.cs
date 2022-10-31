//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public delegate Outcome ParserDelegate<T>(string src, out T dst);

    public readonly struct ParseFunction<T> : IParser<T>
    {
        readonly ParserDelegate<T> F;

        [MethodImpl(Inline)]
        public ParseFunction(ParserDelegate<T> f)
            => F = f;

        [MethodImpl(Inline)]
        public Outcome Parse(string src, out T dst)
            => F(src, out dst);

        [MethodImpl(Inline)]
        public static implicit operator ParseFunction<T>(ParserDelegate<T> src)
            => new ParseFunction<T>(src);

        static Outcome empty(string src, out T dst)
        {
            dst = default;
            return (false, RpOps.Empty);
        }

        public static ParseFunction<T> Empty => new ParseFunction<T>(empty);
    }
}