//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public ref struct TextGrid<B>
        where B : unmanaged, IStorageBlock<B>
    {
        readonly ReadOnlySpan<B> Data;

        public readonly uint RowWidth;

        public readonly uint RowCount;

        public TextGrid(uint width, ReadOnlySpan<B> data)
        {
            Data = data;
            RowWidth = width;
            Require.invariant(data.Length % width == 0);
            RowCount = (uint)data.Length % width;
        }

        [MethodImpl(Inline)]
        public ref readonly B Row(uint index)
            => ref skip(Data,index);

        public B this[int index]
        {
            [MethodImpl(Inline)]
            get => Row((uint)index);
        }

        public B this[uint index]
        {
            [MethodImpl(Inline)]
            get => Row(index);
        }

        public void Render(ITextEmitter dst)
        {
            for(var i=0u; i<RowCount; i++)
                dst.AppendLine(Row(i));
        }

        public string Format()
        {
            var dst = text.emitter();
            Render(dst);
            return dst.Emit();
        }
    }
}