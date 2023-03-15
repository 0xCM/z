//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class ScriptVar : ScriptVar<@string>
    {
        [MethodImpl(Inline)]
        public ScriptVar(string name, AsciSymbol prefix, AsciFence fence, @string value = default)
            : base(name, prefix, fence, value)
        {

        }

        public override string ToString()
            => Format();
    }    
}