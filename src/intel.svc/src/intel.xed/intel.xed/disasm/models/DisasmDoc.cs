//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasmModels
    {
        public class DisasmDoc
        {
            public readonly DisasmSummary Summary;

            public readonly DisasmDetail Detail;

            [MethodImpl(Inline)]
            public DisasmDoc(DisasmSummary summary, DisasmDetail detail)
            {
                Summary = summary;
                Detail = detail;
            }

            public ref readonly FileRef Origin
            {
                [MethodImpl(Inline)]
                get => ref Detail.Origin;
            }

            public ref readonly Index<DisasmDetailBlock> DetailBlocks
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
            public void Deconstruct(out DisasmSummary s, out DisasmDetail d)
            {
                s = Summary;
                d = Detail;
            }

            [MethodImpl(Inline)]
            public static implicit operator DisasmDoc((DisasmSummary s, DisasmDetail d) src)
                => new DisasmDoc(src.s,src.d);
        }
    }
}