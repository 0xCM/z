//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class ScriptVar : ScriptVar<@string>
    {
        [MethodImpl(Inline)]
        public ScriptVar(AsciSymbol prefix, @string? value = null)
            : base(prefix, value ?? @string.Empty)
        {
        }

        [MethodImpl(Inline)]
        public ScriptVar(AsciFence fence, @string? value = null)
            : base(fence, value ?? @string.Empty)
        {

        }

        [MethodImpl(Inline)]
        public ScriptVar(AsciSymbol prefix, AsciFence fence, @string? value = null)
            : base(prefix,fence, value ?? @string.Empty)
        {

        }

        [MethodImpl(Inline)]
        public ScriptVar(string name, AsciSymbol prefix, @string? value = null)
            : base(name, prefix, value ?? @string.Empty)
        {

        }

        [MethodImpl(Inline)]
        public ScriptVar(string name, AsciFence fence, @string? value = null)
            : base(name, fence, value ?? @string.Empty)
        {
        }

        [MethodImpl(Inline)]
        public ScriptVar(string name, AsciSymbol prefix, AsciFence fence, @string? value = null)
            : base(name,prefix,fence, value ?? @string.Empty)
        {

        }

        [MethodImpl(Inline)]
        public static implicit operator ScriptVar(string name)
            => new ScriptVar(name);
    }    
}