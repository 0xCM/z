//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class CfgBlock : Seq<CfgBlock,CfgEntry>
    {
        public CfgBlock()
        {
            Name = EmptyString;
        }

        public string Name {get;}

        public CfgBlock(string name, CfgEntry[] src) 
            : base(src)
        {
            Name = name;
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