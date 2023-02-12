//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasmModels
    {
        public class DisasmDetail : IComparable<DisasmDetail>
        {
            public readonly DisasmDataFile DataFile;

            public readonly Index<DisasmDetailBlock> Blocks;

            [MethodImpl(Inline)]
            public DisasmDetail(in DisasmDataFile file, DisasmDetailBlock[] data)
            {
                DataFile = file;
                Blocks = data;
            }

            public ref readonly FileRef Origin
            {
                [MethodImpl(Inline)]
                get => ref DataFile.Origin;
            }

            public ref readonly FileRef Source
            {
                [MethodImpl(Inline)]
                get => ref DataFile.Source;
            }

            public uint Seq
            {
                [MethodImpl(Inline)]
                get => DataFile.Source.Seq;
            }

            public ref DisasmDetailBlock this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Blocks[i];
            }

            public ref DisasmDetailBlock this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Blocks[i];
            }

            public FilePath Path
            {
                [MethodImpl(Inline)]
                get => DataFile.Source.Path;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Blocks.Count;
            }

            public int CompareTo(DisasmDetail src)
                => Seq.CompareTo(src.Seq);

            public static DisasmDetail Empty => new DisasmDetail(DisasmDataFile.Empty, sys.empty<DisasmDetailBlock>());
        }
    }
}