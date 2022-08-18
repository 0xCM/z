//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public interface ICellSeq : ICounted, ITextual
    {
        bool INullity.IsEmpty
            => Count == 0;

        bool INullity.IsNonEmpty
            => Count == 0;

        int Length
            => (int)Count;

        string Delimiter
            => ",";
    }

    public interface ICellSeq<T> : ICellSeq
    {
        ReadOnlySpan<T> View {get;}

        ref readonly T this[int index]
            => ref skip(View,index);

        ref readonly T this[uint index]
            => ref skip(View,index);

        ref readonly T First
            => ref first(View);

        string ITextual.Format()
        {
            var dst = text.buffer();
            for(var i=0; i<Count; i++)
            {
                if(i!=0)
                    dst.Append(Delimiter);
                dst.Append(this[i]);
            }
            return dst.Emit();
        }
    }
}