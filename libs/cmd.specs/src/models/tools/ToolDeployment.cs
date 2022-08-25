//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ToolDeployment
    {
        public readonly ToolIdOld Id;

        public readonly FilePath Path;

        [MethodImpl(Inline)]
        public ToolDeployment(ToolIdOld id, FilePath path)
        {
            Id = id;
            Path = path;
        }

        public string Format()
            => string.Format("{0}:{1}", Id.Format(), Path.ToUri());

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ToolDeployment((ToolIdOld id, FilePath path) src)
            => new ToolDeployment(src.id, src.path);
    }
}