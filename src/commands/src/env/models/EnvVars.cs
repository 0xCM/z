//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class EnvVars : Seq<EnvVars,EnvVar>
    {
        public EnvVars()
        {

        }
        
        [MethodImpl(Inline)]
        public EnvVars(EnvVar[] src)
            : base(src)
        {
        }

        public override string Format()
        {
            var dst = text.emitter();
            var src = View;
            var count = src.Length;
            for(var i=0; i<count; i++)
                dst.AppendLine(skip(src,i));
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        public SortedLookup<string,EnvVar> ToLookup()
        {
            var dst = dict<string,EnvVar>(Count);
            for(var i=0; i<Count; i++)
            {
                ref readonly var v = ref this[i];
                dst.TryAdd(v.VarName,v);
            }

            return dst;
        }

        [MethodImpl(Inline)]
        public static implicit operator EnvVars(EnvVar[] src)
            => new EnvVars(src);

        [MethodImpl(Inline)]
        public static implicit operator EnvVars(List<EnvVar> src)
            => new EnvVars(src.ToArray());

        [MethodImpl(Inline)]
        public static implicit operator EnvVar[](EnvVars src)
            => src.Storage;
    }
}