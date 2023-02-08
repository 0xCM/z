//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class ScriptVar : ScriptVar<@string>
    {
        [MethodImpl(Inline)]
        public ScriptVar(string name, AsciSymbol prefix)
            : base(name, prefix)
        {

        }

        [MethodImpl(Inline)]
        public ScriptVar(string name, AsciFence fence)
            : base(name, fence)
        {
        }

        [MethodImpl(Inline)]
        public ScriptVar(string name, AsciSymbol prefix, AsciFence fence)
            : base(name,prefix,fence)
        {

        }

        public override string ToString()
            => Format();
    }    
}