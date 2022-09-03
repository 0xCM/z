//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// A <see cref='IByteSequence'/> with mutable cells
    /// </summary>
    [Free]
    public interface IMutableBytes : IByteSeq
    {
        Span<byte> Edit {get;}

        new ref byte this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref sys.seek(Edit,i);
        }

        new ref byte this[int i]
        {
            [MethodImpl(Inline)]
            get => ref sys.seek(Edit,i);
        }
    }
}