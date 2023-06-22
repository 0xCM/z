//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasmModels
    {
        public class DisasmSummary
        {
            public readonly uint RowCount;

            public readonly DisasmDataFile DataFile;

            public readonly FileRef Origin;

            public readonly Index<XedDisasmRow> Rows;

            public readonly Index<DisasmLines> LineIndex;

            internal DisasmSummary(in DisasmDataFile src, in FileRef origin, Index<XedDisasmRow> rows, DisasmLines[] lines)
            {
                DataFile = src;
                Origin = origin;
                Rows = rows;
                LineIndex = lines;
                RowCount = Rows.Count;
            }

            public FileRef DataSource
            {
                [MethodImpl(Inline)]
                get => DataFile.Source;
            }

            public ref XedDisasmRow this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Rows[i];
            }

            public ref XedDisasmRow this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Rows[i];
            }

            public override int GetHashCode()
                => DataFile.Source.GetHashCode();

            public static DisasmSummary Empty
                => new DisasmSummary(DisasmDataFile.Empty, FileRef.Empty, sys.empty<XedDisasmRow>(),  sys.empty<DisasmLines>());
        }
    }
}