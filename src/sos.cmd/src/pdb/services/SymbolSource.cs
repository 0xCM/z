//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using System.IO;

    public ref struct PdbSymbolSource
    {
        public readonly bool IsPortable;

        public readonly FilePath PePath;

        readonly ReadOnlySpan<byte> PeData;

        readonly ReadOnlySpan<byte> PdbData;

        readonly PinnedPtr<byte> PePin;

        readonly PinnedPtr<byte> PdbPin;

        public readonly MemoryStream PeStream;

        public readonly FilePath PdbPath;

        public readonly MemoryStream PdbStream;

        public readonly PdbKind PdbKind;

        /// <summary>
        /// Specifies whether the pe image has been loaded by the runtime
        /// </summary>
        public readonly bool RuntimeLoaded;

        /// <summary>
        /// Specifies whether the pe and pdb streams are defined
        /// </summary>
        public readonly bool Streams;

        public PdbSymbolSource(ReadOnlySpan<byte> pe, ReadOnlySpan<byte> pdb)
        {
            RuntimeLoaded = true;
            Streams = false;
            PePath = FilePath.Empty;
            PdbPath = FilePath.Empty;
            PeData = pe;
            PdbData = pdb;
            PeStream = default;
            PdbStream = default;
            PePin = PinnedPtr<byte>.Empty;
            PdbPin = PinnedPtr<byte>.Empty;
            IsPortable = PdbQuery.portable(PdbData);
            PdbKind = PdbQuery.pdbkind(PdbData);
        }

        public PdbSymbolSource(FilePath pe, FilePath pdb)
        {
            RuntimeLoaded = false;
            Streams = true;
            PePath = pe;
            PdbPath = pdb;
            var peData = File.ReadAllBytes(PePath.Name);
            var pdbData = File.ReadAllBytes(PdbPath.Name);
            PePin = memory.pin<byte>(peData);
            PdbPin = memory.pin<byte>(pdbData);
            PeData = peData;
            PdbData = pdbData;
            PeStream = new MemoryStream(peData);
            PdbStream = new MemoryStream(pdbData);
            IsPortable = PdbQuery.portable(PdbData);
            PdbKind = PdbQuery.pdbkind(PdbData);
        }

        public void Dispose()
        {
            PeStream?.Dispose();
            PdbStream?.Dispose();
            PePin.Dispose();
            PdbPin.Dispose();
        }

        public unsafe SegRef PeSrc
        {
            [MethodImpl(Inline)]
            get => new SegRef(address(PeData), PeData.Length);
        }

        public unsafe SegRef PdbSrc
        {
            [MethodImpl(Inline)]
            get => new SegRef(address(PdbData), PdbData.Length);
        }

        public ByteSize PdbSize
        {
            [MethodImpl(Inline)]
            get => PdbData.Length;
        }

        public ByteSize PeSize
        {
            [MethodImpl(Inline)]
            get => PeData.Length;
        }

        public static PdbSymbolSource Empty
        {
            [MethodImpl(Inline)]
            get => new PdbSymbolSource(sys.empty<byte>().ToReadOnlySpan(), sys.empty<byte>().ToReadOnlySpan());
        }
    }
}