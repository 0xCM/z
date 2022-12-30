//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class VarExpr : VarExpr<@string>
    {
        [MethodImpl(Inline)]
        public VarExpr(AsciSymbol prefix, @string? value = null)
            : base(prefix, value ?? @string.Empty)
        {
        }

        [MethodImpl(Inline)]
        public VarExpr(AsciFence fence, @string? value = null)
            : base(fence, value ?? @string.Empty)
        {

        }

        [MethodImpl(Inline)]
        public VarExpr(AsciSymbol prefix, AsciFence fence, @string? value = null)
            : base(prefix,fence, value ?? @string.Empty)
        {

        }

        [MethodImpl(Inline)]
        public VarExpr(string name, AsciSymbol prefix, @string? value = null)
            : base(name, prefix, value ?? @string.Empty)
        {

        }

        [MethodImpl(Inline)]
        public VarExpr(string name, AsciFence fence, @string? value = null)
            : base(name, fence, value ?? @string.Empty)
        {
        }

        [MethodImpl(Inline)]
        public VarExpr(string name, AsciSymbol prefix, AsciFence fence, @string? value = null)
            : base(name,prefix,fence, value ?? @string.Empty)
        {

        }

        [MethodImpl(Inline)]
        public static implicit operator VarExpr(string name)
            => new VarExpr(name);
    }    
}