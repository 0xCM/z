//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static RuntimeModeKind;
    using static OpszKind;

    using SZ = AsmPrefixCodes.SizeOverrideCode;

    [ApiHost]
    public readonly struct AsmPrefixTests
    {
        const byte MinRexCode = 0x40;

        const byte MaxRexCode = 0x4F;

        public static ReadOnlySpan<ProcessAsmRecord> vex(ProcessAsmBuffers src)
        {
            var counter = 0u;
            var records = src.Records();
            var buffer = src.Selected();
            buffer.Clear();
            var i = 0u;
            var count = vex(records, ref i, buffer);
            return slice(buffer,0,count);
        }

        [MethodImpl(Inline), Op]
        public static bit rex(in AsmOpCodeString src)
            => src.Data.Contains("REX", StringComparison.InvariantCultureIgnoreCase);

        [MethodImpl(Inline), Op]
        public static bit rex(byte src)
            => math.between(src, MinRexCode, MaxRexCode);

        [MethodImpl(Inline), Op]
        public static bit vex(byte src)
            => src == 0xC4 || src == 0xC5;

        [MethodImpl(Inline), Op]
        public static bit vex(uint src)
            => (byte)src == 0xC4 || (byte)src == 0xC5;

        [MethodImpl(Inline), Op]
        public static bit rex(in AsmHexCode src)
            => rex(skip(src.Bytes,0));

        [MethodImpl(Inline), Op]
        public static bit vex(in AsmHexCode src)
            => vex(skip(src.Bytes,0));

        [MethodImpl(Inline), Op]
        public static bit evex(uint src)
            => (byte)src == 0x62;

        [MethodImpl(Inline), Op]
        public static uint rex<T>(ReadOnlySpan<T> src, ref uint i, Span<T> dst)
            where T : struct, IAsmHexProvider
        {
            var i0 = i;
            var count = src.Length;
            for(var j = 0; j<count; j++)
            {
                ref readonly var provider = ref skip(src,j);
                if(rex(provider.AsmHex(out _)))
                    seek(dst, i++) = provider;
            }
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint vex<T>(ReadOnlySpan<T> src, ref uint i, Span<T> dst)
            where T : struct, IAsmHexProvider
        {
            var i0 = i;
            var count = src.Length;
            for(var j = 0; j<count; j++)
            {
                ref readonly var provider = ref skip(src,j);
                if(vex(provider.AsmHex(out _)))
                    seek(dst, i++) = provider;
            }
            return i - i0;
        }

        /// <summary>
        /// Tests whether a specified byte represents the operand size override prefix, selecting an instruction's non-default operand size
        /// </summary>
        /// <param name="src">The byte to test</param>
        [MethodImpl(Inline), Op]
        public static bit opsz(byte src)
            => (SZ)src == SZ.OPSZ;

        /// <summary>
        /// Tests whether a specified byte represents the address size override prefix selecting an instruction's non-default address size
        /// </summary>
        /// <param name="src">The byte to test</param>
        [MethodImpl(Inline), Op]
        public static bit adsz(byte src)
            => (SZ)src == SZ.ADSZ;

        /// <summary>
        /// Determines whether a 66h prefix is required to indicate an operand-size override
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="default"></param>
        /// <param name="effective"></param>
        [Op]
        public static bit opsz(RuntimeModeKind mode, OpszKind @default, OpszKind effective)
            => mode switch{
                IA32e => effective switch {
                    W16 => 1,
                    W32 => 0,
                    W64 => 0,
                    _ => 0,
                },

                Compatibilty => effective switch {
                    W16 => @default switch{
                        W16 => 1,
                        W32 => 0,
                        _ => 0,
                    },

                    W32 => @default switch{
                        W16 => 0,
                        W32 => 1,
                        _ => 0,
                    },

                    _ => 0
                },

                Protected => effective switch {
                    W16 => @default switch {
                        W16 => 1,
                        W32 => 0,
                        _ => 0,
                    },
                    W32 => @default switch {
                        W16 => 0,
                        W32 => 1,
                        _ => 0,
                    },
                    _ => 0
                },

                Virtual8086 => effective switch {
                    W16 => @default switch {
                        W16 => 1,
                        W32 => 0,
                        _ => 0,
                    },
                    W32 => @default switch {
                        W16 => 0,
                        W32 => 1,
                        _ => 0,
                    },
                    _ => 0
                },

                Real => effective switch {
                    W16 => @default switch {
                        W16 => 1,
                        W32 => 0,
                        _ => 0,
                    },
                    W32 => @default switch {
                        W16 => 0,
                        W32 => 1,
                        _ => 0,
                    },
                    _ => 0
                },
              _ => 0
            };
    }
}