//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct JmpRel32 : IAsmRelInst<Disp32>
    {
        [MethodImpl(Inline), Op]
        public static bool test(ReadOnlySpan<byte> encoding)
            => encoding.Length >= InstSize && core.first(encoding) == OpCode;

        /// <summary>
        /// Jump near, relative
        /// </summary>
        /// <param name="w">The relative width selector</param>
        /// <param name="rip">The callsite, i.e. the location at which the jmp instruction begins</param>
        /// <param name="target">The target address</param>
        [MethodImpl(Inline), Op]
        public static void encode(Rip rip, MemoryAddress target, Span<byte> dst)
        {
            var i=0;
            seek(dst, i++) = JmpRel32.OpCode;
            var disp = AsmRel.disp32(rip,target);
            @as<Disp32>(slice(dst,1, 4)) = disp;
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode encode(Rip rip, MemoryAddress target)
        {
            var storage = ByteBlock16.Empty;
            var buffer = storage.Bytes;
            encode(rip,target, buffer);
            seek(buffer,15) = JmpRel32.InstSize;
            return @as<AsmHexCode>(buffer);
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode encode(JmpRel32 spec)
            => encode((spec.SourceAddress, JmpRel32.InstSize), spec.TargetAddress);

        public const byte OpCode = 0xE9;

        public const byte InstSize = 5;

        public readonly LocatedSymbol Source;

        public readonly LocatedSymbol Target;

        [MethodImpl(Inline)]
        public JmpRel32(LocatedSymbol src, LocatedSymbol dst)
        {
            Source = src;
            Target = dst;
        }

        [MethodImpl(Inline)]
        public JmpRel32(Rip src, LocatedSymbol dst)
        {
            Source = src.Address - (uint)InstSize;
            Target = dst;
        }

        public MemoryAddress SourceAddress
        {
            [MethodImpl(Inline)]
            get => Source.Location;
        }

        public MemoryAddress TargetAddress
        {
            [MethodImpl(Inline)]
            get => Target.Location;
        }

        public Disp32 Disp
        {
            [MethodImpl(Inline)]
            get => AsmRel.disp32(Rip, TargetAddress);
        }

        public Rip Rip
        {
            [MethodImpl(Inline)]
            get => (Source.Location, InstSize);
        }

        public AsmHexCode Encoding
        {
            [MethodImpl(Inline)]
            get => JmpRel32.encode(this);
        }

        public AsmMnemonic Mnemonic
        {
            [MethodImpl(Inline)]
            get => "jmp";
        }

        LocatedSymbol IAsmRelInst.Source
            => Source;

        LocatedSymbol IAsmRelInst.Target
            => Target;

        public string Format()
            => string.Format("jmp32:{0} [{1}] -> {2} -> {3}", Source, Disp, Target, Encoding);

        public override string ToString()
            => Format();
    }
}