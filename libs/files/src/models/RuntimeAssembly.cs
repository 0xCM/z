//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = RuntimeArchive;

    public readonly struct RuntimeAssembly : IFsEntry<RuntimeAssembly>
    {
        public readonly Assembly Component;

        public readonly FilePath Path;

        [MethodImpl(Inline)]
        public RuntimeAssembly(Assembly src, FilePath path)
        {
            Component = Require.notnull(src);
            Path = path;
        }

        PathPart IFsEntry.Name
        {
            [MethodImpl(Inline)]
            get => Path.Name;
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Assembly(RuntimeAssembly src)
            => src.Component;

        [MethodImpl(Inline)]
        public static implicit operator RuntimeAssembly(Assembly src)
            => api.assembly(src);
    }
}