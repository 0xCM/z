//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedRules;
    using static XedDisasm;

    partial class XedDisasmModels
    {
        /// <summary>
        /// Represents the content of a verbose xed instruction disassembly
        /// </summary>
        public readonly struct DisasmBlock
        {
            public readonly Index<TextLine> Lines;

            [MethodImpl(Inline)]
            public DisasmBlock(TextLine[] src)
            {
                Lines = src;
            }

            public bool IsValid
            {
                [MethodImpl(Inline)]
                get => Lines.Count >= 3;
            }

            public bool IsEmtpy
            {
                [MethodImpl(Inline)]
                get => Lines.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Lines.IsEmpty;
            }

            public uint OpCount
            {
                [MethodImpl(Inline)]
                get => Lines.Count - 3;
            }

            public ref readonly TextLine Props
            {
                [MethodImpl(Inline)]
                get => ref Lines.First;
            }

            public ReadOnlySpan<TextLine> Ops
            {
                [MethodImpl(Inline)]
                get => slice(Lines.View,1,OpCount);
            }

            public ref readonly TextLine YDis
            {
                [MethodImpl(Inline)]
                get  => ref Lines[Lines.Count - 2];
            }

            public ref readonly TextLine XDis
            {
                [MethodImpl(Inline)]
                get  => ref Lines.Last;
            }

            public Index<OpSpec> ParseOps()
                => ops(this);

            public uint ParseOps(Span<OpSpec> dst)
                => ops(this, dst);

            public AsmInfo ParseAsm()
                => asminfo(this);

            public string Format()
                => DisasmRender.format(this);

            public override string ToString()
                => Format();

            public static DisasmBlock Empty => new DisasmBlock(sys.empty<TextLine>());
        }
    }
}