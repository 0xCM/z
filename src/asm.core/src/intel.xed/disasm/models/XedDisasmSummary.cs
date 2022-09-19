//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasmModels
    {
        public class XedDisasmSummary
        {
            public readonly uint RowCount;

            public readonly DataFile DataFile;

            public readonly FileRef Origin;

            public readonly Index<XedDisasmRow> Rows;

            public readonly Index<XedDisasmLines> LineIndex;

            internal XedDisasmSummary(in DataFile src, in FileRef origin, Index<XedDisasmRow> rows, XedDisasmLines[] lines)
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

            public static XedDisasmSummary Empty
                => new XedDisasmSummary(DataFile.Empty, FileRef.Empty, sys.empty<XedDisasmRow>(),  sys.empty<XedDisasmLines>());
        }
    }
}