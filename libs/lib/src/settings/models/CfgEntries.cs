//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class CfgEntries : Seq<CfgEntries,CfgEntry>
    {
        public CfgEntries()
        {

        }

        public CfgEntries(CfgEntry[] src) 
            : base(src)
        {

        }

        public override string Format()
        {
            var dst = text.emitter();
            for(var i=0; i<Count; i++)
                dst.AppendLine(this[i]);
            return dst.Emit();
        }
    }
}