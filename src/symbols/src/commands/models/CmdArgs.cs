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

        public CmdArgs Skip(uint count)
            => new CmdArgs(Data.Slice(count).ToArray());

        public ReadOnlySeq<@string> Values()
            => Data.Map(x => x.Value);

        public CmdArgs Concat(CmdArgs src)
        {
            var count = Count + src.Count;
            var dst = new CmdArgs(alloc<CmdArg>(count));
            var j=0u;
            for(var i=0u; i<Count; i++)
                dst[j++] = this[i];
            for(var i=0; i<src.Count; i++)
                dst[j++] = src[i];
            return dst;
        }

        public CmdArgs Replicate()
        {
            var dst = alloc<CmdArg>(Count);
            for(var i=0; i<Count; i++)
            {
                seek(dst,i) = this[i];
            }
            return dst;
        }

        public CmdArgs Prefixed(string prefix)
            => Storage.Where(x => text.begins(x.Name, prefix));

        public CmdArgs Prepend(params CmdArg[] src)
            => new CmdArgs(src).Concat(this);

        public CmdArgs Prepend(CmdArgs src)
            => src.Concat(this);
            
        public override string Format()
            => text.join(Chars.Space, Values());

        public static implicit operator CmdArgs(CmdArg[] src)
            => new CmdArgs(src);

        public static CmdArgs operator +(CmdArgs a, CmdArgs b)
            => a.Concat(b);                   

        static CmdArg EmptyArg = CmdArg.Empty;
    }
}