//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    public readonly struct RegOpSeq : IIndex<RegOp>
    {
        Index<RegOp> Data {get;}

        [MethodImpl(Inline)]
        public RegOpSeq(RegOp[] src)
        {
            Data = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref RegOp this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref RegOp this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref RegOp this[RegIndexCode reg]
        {
            [MethodImpl(Inline)]
            get => ref Data[(byte)reg];
        }

        public RegOp[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<RegOp> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public RegOpSeq Concat(params RegOpSeq[] src)
        {
            var count = Count + gcalc.sum(src.Map(x => x.Count));
            var dst = alloc<RegOp>(count);
            var j=0;
            for(var i=0u; i<Count; i++)
                seek(dst,j++) = this[i];

            for(var k=0; k<src.Length; k++)
            {
                ref readonly var set = ref skip(src,k);
                var kset = set.Count;
                for(var m=0u; m<kset; m++)
                    seek(dst,j++) = set[m];
            }

            return dst;
        }

        [MethodImpl(Inline)]
        public RegOpSeq Replicate()
            => new RegOpSeq(Data);

        [MethodImpl(Inline)]
        public static implicit operator RegOpSeq(RegOp[] src)
            => new RegOpSeq(src);

        public static RegOpSeq Empty
            => new RegOpSeq(sys.empty<RegOp>());

        public string ToNameArray(string name)
        {
            const string Pattern = "string[] {0} = new string[]{1};";
            return string.Format(Pattern, name, text.embrace(View.Map(x => text.dquote(x.Name.Format().Trim())).Delimit(Chars.Comma).Format()));
        }
    }
}