//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedDisasm;

    partial class XedDisasmModels
    {
        public readonly record struct DataFile : IComparable<DataFile>
        {
            public readonly FileRef Origin;

            public readonly FileRef Source;

            public readonly Index<DisasmBlock> Blocks;

            [MethodImpl(Inline)]
            public DataFile(in FileRef origin, in FileRef src, DisasmBlock[] blocks)
            {
                Origin = origin;
                Source = src;
                Blocks = blocks;
            }

            public uint Seq
            {
                [MethodImpl(Inline)]
                get => Source.Seq;
            }

            public Hex32 DocId
            {
                [MethodImpl(Inline)]
                get => Source.DocId;
            }

            public uint LineCount
            {
                [MethodImpl(Inline)]
                get => Blocks.Count;
            }

            public ref readonly DisasmBlock this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Blocks[i];
            }

            public ref readonly DisasmBlock this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Blocks[i];
            }

            public OperandStates ParseStates()
                => states(this);

            public int CompareTo(DataFile src)
                => Seq.CompareTo(src.Seq);

            public static DataFile Empty => new DataFile(FileRef.Empty, FileRef.Empty, sys.empty<DisasmBlock>());
        }
    }
}