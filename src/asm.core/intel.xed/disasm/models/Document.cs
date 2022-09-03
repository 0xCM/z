//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasmModels
    {
        public class Document
        {
            public readonly XedDisasmSummary Summary;

            public readonly Detail Detail;

            [MethodImpl(Inline)]
            public Document(XedDisasmSummary summary, Detail detail)
            {
                Summary = summary;
                Detail = detail;
            }

            public ref readonly FileRef Origin
            {
                [MethodImpl(Inline)]
                get => ref Detail.Origin;
            }

            public ref readonly Index<DetailBlock> DetailBlocks
            {
                [MethodImpl(Inline)]
                get => ref Detail.Blocks;
            }

            public ref readonly FileRef DataSource
            {
                [MethodImpl(Inline)]
                get => ref Summary.DataFile.Source;
            }

            [MethodImpl(Inline)]
            public void Deconstruct(out XedDisasmSummary s, out Detail d)
            {
                s = Summary;
                d = Detail;
            }

            [MethodImpl(Inline)]
            public static implicit operator Document((XedDisasmSummary s, Detail d) src)
                => new Document(src.s,src.d);
        }
    }
}