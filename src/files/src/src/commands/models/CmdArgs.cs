//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public sealed class CmdArgs : Seq<CmdArgs,CmdArg>
    {
        public CmdArgs()
        {

        }

        [MethodImpl(Inline)]
        public CmdArgs(CmdArg[] src)
            : base(src)
        {
            Data = src;
        }

        static CmdArg EmptyArg = CmdArg.Empty;

        public new CmdArg this[int i]
        {
            [MethodImpl(Inline)]
            get => i < Count ?  base[i] : EmptyArg;
            [MethodImpl(Inline)]
            set => base[i] = value;
        }

        [Op]
        public static CmdArg arg(CmdArgs src, int i)
            => src[i];

        public static CmdArgs args<T>(params T[] src)
            where T : IEquatable<T>, IComparable<T>
        {
            var dst = alloc<CmdArg>(src.Length);
            for(ushort i=0; i<src.Length; i++)
                seek(dst,i) = new CmdArg<T>(skip(src,i));
            return new (dst);
        }

        public CmdArgs Skip(uint count)
            => new CmdArgs(Data.Slice(count).ToArray());

        public ReadOnlySeq<string> Values()
            => Data.Map(x => x.Value);

        public CmdArgs Concat(CmdArgs src)
        {
            var count = Count + src.Count;
            var dst = new CmdArgs(alloc<CmdArg>(count));
            var i=0u;
            for(var j=0u; j<Count; j++)
                dst[i++] = this[i];
            for(var j=0; j< src.Count; j++)
                dst[i++] = src[i];
            return dst;
        }
        
        public override string Format()
            => text.join(Chars.Space,this);
        // {
        //     if(Count > 0)
        //     {
        //         var dst = text.emitter();
        //         for(var i=0; i<Count; i++)
        //         {
        //             dst.Append(this[i].Value);
        //             if(i != Count - 1)
        //                 dst.Append(Chars.Space);
        //         }
        //         return dst.Emit();
        //     }
        //     else
        //     {
        //         return EmptyString;
        //     }
        // }

        public static implicit operator CmdArgs(CmdArg[] src)
            => new CmdArgs(src);

        public static CmdArgs operator +(CmdArgs a, CmdArgs b)
            => a.Concat(b);
    }
}