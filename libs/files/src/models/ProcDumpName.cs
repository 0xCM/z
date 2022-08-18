//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics;

    public readonly struct ProcDumpName : IIdentified
    {
        public static ProcDumpName from(FS.FilePath src)
        {
            if(src.IsEmpty)
                return Empty;

            var identifier = src.FileName.WithoutExtension.Format();
            var name = identifier.LeftOfFirst(Chars.Dot);
            var result = Time.parse(identifier.RightOfFirst(Chars.Dot), out var ts);
            if(result)
                return create(name,ts);
            else
                return Empty;
        }

        [MethodImpl(Inline)]
        public static ProcDumpName create(Process process, Timestamp ts)
            => new ProcDumpName(process.ProcessName, ts);

        [MethodImpl(Inline)]
        public static ProcDumpName create(string name, Timestamp ts)
            => new ProcDumpName(name, ts);

        public string ProcessName {get;}

        public Timestamp CaptureTime {get;}

        [MethodImpl(Inline)]
        public ProcDumpName(string name, Timestamp ts)
        {
            ProcessName = name;
            CaptureTime = ts;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => sys.nonempty(ProcessName) && CaptureTime.IsNonZero;
        }

        public string IdentityText
            => string.Format("{0}.{1}", ProcessName, CaptureTime.Format());

        public Identifier Identifier
            => IdentityText;

        public string Format(bool ts)
            => ts ? Identifier : ProcessName;
        public string Format()
            => Identifier;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ProcDumpName((string name, Timestamp ts) src)
            => new ProcDumpName(src.name, src.ts);

        [MethodImpl(Inline)]
        public static implicit operator ProcDumpName((Process proc, Timestamp ts) src)
            => create(src.proc, src.ts);

        public static ProcDumpName Empty
        {
            [MethodImpl(Inline)]
            get => new ProcDumpName(EmptyString, Timestamp.Zero);
        }
    }
}