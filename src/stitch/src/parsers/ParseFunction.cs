//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public delegate Outcome ParserDelegate(string src, out dynamic dst);

    public readonly struct ParseFunction : IParser
    {
        public Type TargetType {get;}

        readonly ParserDelegate F;

        [MethodImpl(Inline)]
        public ParseFunction(Type target, ParserDelegate f)
        {
            TargetType = target;
            F = f;
        }

        [MethodImpl(Inline)]
        public Outcome Parse(string src, out dynamic dst)
            => F(src, out dst);
    }
}