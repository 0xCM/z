//-----------------------------------------------------------------------------
// Copyright   : (c) Chris Moore, 2020
// License     : MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct CmdJob
    {
        public readonly string Name;

        public readonly TextBlock Spec;

        [MethodImpl(Inline)]
        public CmdJob(string name, TextBlock spec)
        {
            Name = name;
            Spec = spec;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Spec;

        public override string ToString()
            => Format();
    }
}