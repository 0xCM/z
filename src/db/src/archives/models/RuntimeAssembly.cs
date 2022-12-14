//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = RuntimeArchive;

    public readonly struct RuntimeAssembly
    {
        public readonly Assembly Component;

        public readonly FileUri Uri;

        [MethodImpl(Inline)]
        public RuntimeAssembly(Assembly src, FileUri path)
        {
            Component = Require.notnull(src);
            Uri = path;
        }

        public string Format()
            => string.Format("{0}:{1}", Component.GetSimpleName(), Uri);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Assembly(RuntimeAssembly src)
            => src.Component;

        [MethodImpl(Inline)]
        public static implicit operator RuntimeAssembly(Assembly src)
            => new RuntimeAssembly(src, new FileUri(src.Location));   
    }
}