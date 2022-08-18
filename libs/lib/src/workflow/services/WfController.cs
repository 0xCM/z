//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct WfController
    {
        public Assembly Component {get;}

        [MethodImpl(Inline)]
        public WfController(Assembly src)
            => Component = src;

        public FS.FilePath ImagePath
            => FS.path(Component.Location);

        public FS.FolderPath ImageDir
            => ImagePath.FolderPath;

        public string Name
        {
            [MethodImpl(Inline)]
            get => Component.GetSimpleName();
        }

        public PartId Id
        {
            [MethodImpl(Inline)]
            get => Component.Id();
        }

        [MethodImpl(Inline)]
        public static implicit operator WfController(Assembly src)
            => new WfController(src);

        [MethodImpl(Inline)]
        public static implicit operator Assembly(WfController src)
            => src.Component;
    }
}