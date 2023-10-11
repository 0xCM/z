//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    public readonly struct OpDetails : IIndex<OpDetail>
    {
        readonly Index<OpDetail> Data;

        [MethodImpl(Inline)]
        public OpDetails(OpDetail[] src)
        {
            Data = src;
        }

        public OpDetail[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public ref OpDetail this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref OpDetail this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public bool Search(WidthCode match, byte offset, out OpDetail dst)
        {
            var result = false;
            dst = default;
            for(var i=offset; i<Count; i++)
            {
                ref readonly var op = ref Data[i];
                if(op.OpWidth.Code == match)
                {
                    dst = op;
                    result = true;
                    break;
                }
            }
            return result;
        }

        public bool Search(WidthCode match, out OpDetail dst)
            => Search(match,0,out dst);
        public string Format()
            => XedRender.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator OpDetail[](OpDetails src)
            => src.Storage;

        public static OpDetails Empty => new OpDetails(sys.empty<OpDetail>());
    }
}
