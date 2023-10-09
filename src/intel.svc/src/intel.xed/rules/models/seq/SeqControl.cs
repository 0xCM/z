//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    public readonly struct SeqControl
    {
        public readonly asci32 SeqName;

        public readonly Index<SeqDef> Defs;

        [MethodImpl(Inline)]
        public SeqControl(asci32 name, SeqDef[] defs)
        {
            SeqName = name;
            Defs = defs;
        }

        public string Format()
        {
            var dst = text.buffer();
            var count = Defs.Count;
            dst.AppendLineFormat("{0}(){{", SeqName);
            for(var i=0; i<count; i++)
                dst.IndentLineFormat(4, "{0}", Defs[i].SeqName);
            dst.AppendLine("}");
            return dst.Emit();
        }

        public override string ToString()
            => Format();

    }
}
