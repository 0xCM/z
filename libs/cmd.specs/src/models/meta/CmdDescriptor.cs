//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CmdDescriptor
    {
        public readonly @string Scope;

        public readonly @string Name;

        public CmdDescriptor(string scope, string name)
        {
            Scope = scope;
            Name = name;
        }

        public static implicit operator CmdDescriptor((string scope, string name) src)
            => new CmdDescriptor(src.scope, src.name);
    }
}