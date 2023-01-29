//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct RuntimeAssembly
    {
        public readonly Assembly Component;

        public readonly FilePath Location;

        [MethodImpl(Inline)]
        public RuntimeAssembly(Assembly src, FilePath path)
        {
            Component = Require.notnull(src);
            Location = path;
        }

        public string Format()
            => string.Format("{0}:{1}", Component.GetSimpleName(), Location);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Assembly(RuntimeAssembly src)
            => src.Component;

        [MethodImpl(Inline)]
        public static implicit operator RuntimeAssembly(Assembly src)
            => new RuntimeAssembly(src, new FilePath(src.Location));   
    }
}