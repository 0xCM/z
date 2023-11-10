//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class XedRules
{
    public readonly struct RuleTableBlock : IComparable<RuleTableBlock>
    {
        public readonly RuleTableKind TableKind;

        public readonly string TableName;

        public readonly LineNumber Offset;

        public readonly Index<TextLine> Data;

        [MethodImpl(Inline)]
        public RuleTableBlock(RuleTableKind kind, string name, LineNumber offset, TextLine[] src)
        {
            TableKind = kind;
            TableName = name;
            Offset = offset;
            Data = src;
        }

        public void Render(uint seq, ITextEmitter dst)
        {
            dst.AppendLineFormat("{0:D5}: {1:D3} | {2,-3} | {3}", (uint)Offset, seq, TableKind, TableName);
            dst.AppendLine(RP.PageBreak120);
            var trimmed = text.trim(Data.Select(x => text.despace(x.Content.Replace("|", "=>").Replace("->", "=>")))).Index();
            var max = (uint)trimmed.Storage.Select(x => x.Length).Max();
            for(var j=0u; j<Data.Count; j++)
            {
                ref readonly var content = ref trimmed[j];
                var cols = text.join(" | ", text.pad(text.split(content,Chars.Space), 0, 22, Chars.Space, Chars.Space));
                var row = string.Format("{0:D5}: {1}", (uint)Data[j].LineNumber, cols);
                dst.AppendLine(row);
            }
        }

        public int CompareTo(RuleTableBlock src)
        {
            var result = Xed.cmp(TableKind,src.TableKind);
            if(result == 0)
                result = Offset.CompareTo(src.Offset);
            return result;
        }
    }
}
