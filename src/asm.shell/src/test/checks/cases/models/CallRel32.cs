//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCases
    {
        [ApiHost("cases.callrel32")]
        public struct CallRel32
        {
            [Op]
            public static ulong f(int i, byte a, ushort b, uint c, ulong d)
                => (ulong)f0(a) & f1(b) | f2(c) ^ f3(c);

            [MethodImpl(NotInline), Op]
            public static byte f0(byte a)
                => (byte)(a & 0xF0);

            [MethodImpl(NotInline), Op]
            public static ushort f1(ushort b)
                => (ushort)(b & 0xF0F0);

            [MethodImpl(NotInline), Op]
            public static uint f2(uint c)
                => (uint)(c & 0xF0F0F0F0);

            [MethodImpl(NotInline), Op]
            public static ulong f3(ulong d)
                => (ulong)(d & 0xF0F0F0F0F0F0F0F0);

            public static string format(in CallRel32 src)
            {
                const string RenderPattern = "{0,-12}: {1}";
                var dst = text.buffer();
                dst.AppendLineFormat(RenderPattern, nameof(src.Asm), src.Asm);
                dst.AppendLineFormat(RenderPattern, nameof(src.Block), src.Block);
                dst.AppendLineFormat(RenderPattern, nameof(src.Target), src.Target);
                dst.AppendLineFormat(RenderPattern, nameof(src.Encoding), src.Encoding);
                dst.AppendLineFormat(RenderPattern, nameof(src.IP), src.IP);
                dst.AppendLineFormat(RenderPattern, nameof(src.RIP), src.RIP);
                dst.AppendLineFormat(RenderPattern, nameof(src.Disp), src.Disp);
                return dst.Emit();
            }

            public @string Asm;

            public LocatedSymbol Block;

            public MemoryAddress Target;

            public Disp32 Disp;

            public MemoryAddress IP;

            public MemoryAddress RIP;

            public AsmHexCode Encoding;

            public ByteSize IpDelta
                => (ByteSize)(RIP - IP);

            public string Format()
                => format(this);

            public override string ToString()
                => Format();
        }
    }
}