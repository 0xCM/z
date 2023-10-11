//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    public readonly struct PatternOps
    {
        readonly Seq<PatternOp> Data;

        [MethodImpl(Inline)]
        public PatternOps(PatternOp[] src)
        {
            Data = src;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref PatternOp this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref PatternOp this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public Index<OpName> Names
            => Data.Select(x => x.Name);

        public string Format()
        {
            var dst = text.emitter();
            dst.Append(Chars.LParen);
            for(var i=0; i<Count; i++)
            {
                if(i != 0)
                    dst.Append(", ");
                
                dst.Append(this[i]);
            }
            dst.Append(Chars.RParen);
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator PatternOp[](PatternOps src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator Index<PatternOp>(PatternOps src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator PatternOps(PatternOp[] src)
            => new(src);

        public static PatternOps Empty => new(sys.empty<PatternOp>());
    }
}
