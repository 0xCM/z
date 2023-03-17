//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public record class FileFilter : IExpr
    {
        public Seq<FileExt> Extensions;

        public Seq<FileKind> FileKinds;

        public Seq<SearchPattern> Inclusions;

        public Seq<SearchPattern> Exclusions;

        public FileFilter()
        {
            Extensions = sys.empty<FileExt>();
            FileKinds = sys.empty<FileKind>();
            Inclusions = sys.empty<SearchPattern>();
            Exclusions = sys.empty<SearchPattern>();
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Extensions.IsEmpty && FileKinds.IsEmpty && Inclusions.IsEmpty && Exclusions.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public string Format()
        {
            var dst = text.emitter();
            if(Extensions.IsNonEmpty)
                dst.AppendLineFormat("{0,-12} {1)", nameof(Extensions), Extensions.Map(t => t.Format()).Concat(RP.Pipe));
            if(FileKinds.IsNonEmpty)
                dst.AppendLineFormat("{0,-12} {1)", nameof(FileKinds), FileKinds.Map(t => t.Format()).Concat(RP.Pipe));
            if(Inclusions.IsNonEmpty)
                dst.AppendLineFormat("{0,-12} {1)", nameof(Inclusions), Inclusions.Map(t => t.Format()).Concat(RP.Pipe));
            if(Exclusions.IsNonEmpty)
                dst.AppendLineFormat("{0,-12} {1)", nameof(Exclusions), Exclusions.Map(t => t.Format()).Concat(RP.Pipe));
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        public static FileFilter Empty => new();
    }
}