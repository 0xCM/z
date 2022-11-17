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
        static MsgPattern EmptyArgList => "No arguments specified";

        static MsgPattern ArgSpecError => "Argument specification error";

        [Op]
        public static CmdArg arg(CmdArgs src, int index)
        {
            if(src.IsEmpty)
                @throw(EmptyArgList.Format());

            var count = src.Count;
            if(count < index - 1)
                @throw(ArgSpecError.Format());
            return src[(ushort)index];
        }

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

        public CmdArgs()
        {

        }

        public ReadOnlySeq<string> Values()
            => Data.Map(x => x.Value);

        [MethodImpl(Inline)]
        public CmdArgs(CmdArg[] src)
            : base(src)
        {
            Data = src;
        }

        public override string Format()
        {
            if(Count > 0)
            {
                var dst = text.emitter();
                for(var i=0; i<Count; i++)
                {
                    dst.Append(this[i].Value);
                    if(i != Count - 1)
                        dst.Append(Chars.Space);
                }
                return dst.Emit();
            }
            else
            {
                return EmptyString;
            }
        }

        public string Join()
            => Format();
    }
}