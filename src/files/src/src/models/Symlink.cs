//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    public record struct Symlink : IExpr, IFsEntry<Symlink>
    {
        public readonly SymLinkKind Kind;

        public readonly FsEntry Source;

        public readonly FsEntry Target;

        public Symlink()
        {
            Source = FsEntry.Empty;
            Target = FsEntry.Empty;
            Kind = 0;
        }

        public Symlink(SymLinkKind kind, FsEntry src, FsEntry dst)
        {
            Source = src;
            Target = dst;
            Kind = kind;
        }

        public bool IsEmpty 
        {
            [MethodImpl(Inline)]
            get => Source.IsEmpty || Target.IsEmpty;
        }

        public bool IsNonEmpty 
        {
            [MethodImpl(Inline)]
            get => Source.IsEmpty && Target.IsEmpty;
        }

        public string Format()
            => $"{Source} -> {Target}";

        public override string ToString()
            => Format();

        public static Symlink Empty => new ();

        public PathPart Name => $"{Source} -> ${Target}";
    }
}