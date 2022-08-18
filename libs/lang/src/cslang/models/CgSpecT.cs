//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CgSpec<T>
    {
        public readonly @string TargetNs;

        public readonly Index<string> Usings;

        public readonly T Content;

        public CgSpec(@string ns, string[] usings, T content)
        {
            TargetNs = ns;
            Usings = usings;
            Content = content;
        }
    }
}