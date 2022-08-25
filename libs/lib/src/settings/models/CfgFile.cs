//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public record struct CfgEntry
    {
        public readonly ReadOnlySeq<char> Name;

        public readonly ReadOnlySeq<char> Value;

        [MethodImpl(Inline)]
        public CfgEntry(string name, string value)
        {
            Name = name.Array();
            Value = value.Array();
        }
    }

    //public class CfgSet : Seq<CfgSet,
}
