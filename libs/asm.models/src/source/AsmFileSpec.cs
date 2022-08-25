//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AsmFileSpec
    {
        [MethodImpl(Inline), Op]
        public static AsmFileSpec define(Identifier name, params IAsmSourcePart[] parts)
            => new AsmFileSpec(name, parts);

        public static string format(in AsmFileSpec src)
        {
            var dst = text.buffer();
            var parts = src.Parts;
            var count = parts.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var part = ref parts[i];
                dst.AppendLine(part.Format());
                switch(part.PartKind)
                {
                    case AsmCellKind.Block:
                        dst.AppendLine();
                    break;
                }

            }
            return dst.Emit();
        }

        public readonly Identifier Name;

        public readonly Index<IAsmSourcePart> Parts;

        [MethodImpl(Inline)]
        public AsmFileSpec(Identifier name, IAsmSourcePart[] parts)
        {
            Name = name;
            Parts = parts;
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        public FilePath Path(FolderPath dst)
            => dst + FS.file(Name.Format(), FS.Asm);

        public FilePath Save(FolderPath dst)
        {
            var path = Path(dst);
            Save(path);
            return path;
        }

        public uint Save(FilePath dst)
        {
            using var writer = dst.AsciWriter();
            writer.WriteLine(Format());
            return Parts.Count;
        }
    }
}