//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct VersionExpr
    {
        public string Value {get;}

        [MethodImpl(Inline)]
        public VersionExpr(string src)
        {
            Value = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator VersionExpr(string src)
            => new VersionExpr(src);
    }
}