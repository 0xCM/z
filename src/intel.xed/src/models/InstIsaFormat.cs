//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    public readonly struct InstIsaFormat : IComparable<InstIsaFormat>
    {
        public readonly InstIsa Isa;

        public readonly Index<InstPattern> Patterns;

        public readonly TextBlock Content;

        public readonly uint LineCount;

        [MethodImpl(Inline)]
        public InstIsaFormat(InstIsa isa, InstPattern[] patterns, string content, uint lines)
        {
            Isa = isa;
            Patterns = patterns;
            Content = content;
            LineCount = lines;
        }

        public int CompareTo(InstIsaFormat src)
            => Isa.CompareTo(src.Isa);

        public string Format()
            => Content;

        public override string ToString()
            => Format();
    }
}
