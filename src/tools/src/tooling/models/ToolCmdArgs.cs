//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using api = Tooling;

    [ApiHost]
    public sealed class ToolCmdArgs : Seq<ToolCmdArgs,ToolCmdArg>
    {
        public ToolCmdArgs()
        {

        }

        [MethodImpl(Inline)]
        public ToolCmdArgs(ToolCmdArg[] src)
            : base(src)
        {
            Data = src;
        }

        static ToolCmdArg EmptyArg = ToolCmdArg.Empty;

        public new ToolCmdArg this[int i]
        {
            [MethodImpl(Inline)]
            get => i < Count ?  base[i] : EmptyArg;
            [MethodImpl(Inline)]
            set => base[i] = value;
        }

        public ToolCmdArgs Skip(uint count)
            => new ToolCmdArgs(Data.Slice(count).ToArray());

        public ToolCmdArgs Concat(ToolCmdArgs src)
        {
            var count = Count + src.Count;
            var dst = new ToolCmdArgs(alloc<ToolCmdArg>(count));
            var j=0u;
            for(var i=0u; i<Count; i++)
                dst[j++] = this[i];
            for(var i=0; i<src.Count; i++)
                dst[j++] = src[i];
            return dst;
        }

        public ToolCmdArgs Replicate()
        {
            var dst = alloc<ToolCmdArg>(Count);
            for(var i=0; i<Count; i++)
            {
                seek(dst,i) = this[i];
            }
            return dst;
        }

        public ToolCmdArgs Prepend(params ToolCmdArg[] src)
            => new ToolCmdArgs(src).Concat(this);

        public ToolCmdArgs Prepend(ToolCmdArgs src)
            => src.Concat(this);
            
        public override string Format()
        {
            var dst = text.emitter();
            api.render(this, dst);
            return dst.Emit();
        }

        public static implicit operator ToolCmdArgs(ToolCmdArg[] src)
            => new ToolCmdArgs(src);

        public static ToolCmdArgs operator +(ToolCmdArgs a, ToolCmdArgs b)
            => a.Concat(b);
    }
}