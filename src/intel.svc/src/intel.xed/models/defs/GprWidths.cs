//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static XedModels.RuleName;
    using static sys;

    using I = XedModels.GprWidthIndex;

    partial class XedModels
    {
        public readonly struct GprWidth
        {
            public static ReadOnlySpan<GprWidth> All
            {
                [MethodImpl(Inline)]
                get => recover<GprWidth>(Data);
            }

            [MethodImpl(Inline)]
            static GprWidth define(byte o16, byte o32, byte o64)
                => new GprWidth(o16, o32, o64);

            [MethodImpl(Inline)]
            public static ref readonly GprWidth widths(GprWidthIndex index)
                => ref skip(All, (byte)index);

            public static bool widths(Nonterminal src, out GprWidth dst)
            {
                dst = GprWidth.Empty;
                var result = true;
                switch(src.Name)
                {
                    case GPR16_B:
                        dst = widths(I.GPR16_B);
                        break;
                    case GPR16_R:
                        dst = widths(I.GPR16_R);
                        break;
                    case GPR32_B:
                        dst = widths(I.GPR32_B);
                        break;
                    case GPR32_R:
                        dst = widths(I.GPR32_R);
                        break;
                    case GPR64_B:
                        dst = widths(I.GPR64_B);
                        break;
                    case GPR64_R:
                        dst = widths(I.GPR64_R);
                        break;
                    case GPR8_B:
                        dst = widths(I.GPR8_B);
                        break;
                    case GPR8_R:
                        dst = widths(I.GPR8_R);
                    break;
                    case GPR8_SB:
                        dst = widths(I.GPR8_SB);
                    break;
                    case GPRv_B:
                        dst = widths(I.GPRv_B);
                    break;
                    case GPRv_R:
                        dst = widths(I.GPRv_R);
                    break;
                    case GPRv_SB:
                        dst = widths(I.GPRv_SB);
                    break;
                    case GPRy_B:
                        dst = widths(I.GPRy_B);
                    break;
                    case GPRy_R:
                        dst = widths(I.GPRy_R);
                        break;
                    case GPRz_B:
                        dst = widths(I.GPRz_B);
                        break;
                    case GPRz_R:
                        dst = widths(I.GPRz_R);
                        break;
                    case VGPR32_B:
                        dst = widths(I.VGPR32_B);
                        break;
                    case VGPR32_N:
                        dst = widths(I.VGPR32_N);
                        break;
                    case VGPR32_R:
                        dst = widths(I.VGPR32_R);
                        break;
                    case VGPR64_B:
                        dst = widths(I.VGPR64_B);
                        break;
                    case VGPR64_N:
                        dst = widths(I.VGPR64_N);
                    break;
                    case VGPR64_R:
                        dst = widths(I.VGPR64_R);
                    break;
                    case VGPRy_N:
                        dst = widths(I.VGPRy_N);
                    break;
                    case OeAX:
                        dst = widths(I.OeAX);
                    break;
                    case OrAX:
                        dst = widths(I.OrAX);
                    break;
                    case OrBP:
                        dst = widths(I.OrBP);
                    break;
                    case OrDX:
                        dst = widths(I.OrDX);
                    break;
                    case OrSP:
                        dst = widths(I.OrSP);
                    break;

                    default:
                        result = false;
                    break;
                }
                return result;
            }

            readonly uint6 Value;

            [MethodImpl(Inline)]
            GprWidth(uint6 value)
            {
                Value = value;
            }

            [MethodImpl(Inline)]
            public GprWidth(byte o16, byte o32, byte o64)
                : this(Sized.native(o16), Sized.native(o32), Sized.native(o64))
            {

            }

            [MethodImpl(Inline)]
            public GprWidth(NativeSize o16, NativeSize o32, NativeSize o64)
            {
                Value = BitNumbers.join((uint2)(byte)o16.Code, (uint2)(byte)o32.Code, (uint2)(byte)o64.Code);
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Value == uint6.MaxValue;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Value != uint6.MaxValue;
            }

            public NativeSize this[W16 w]
            {
                [MethodImpl(Inline)]
                get => (NativeSizeCode)((byte)(Value & uint2.Max));
            }

            public NativeSize this[W32 w]
            {
                [MethodImpl(Inline)]
                get => (NativeSizeCode)((byte)((Value >> 2) & uint2.Max));
            }

            public NativeSize this[W64 w]
            {
                [MethodImpl(Inline)]
                get => (NativeSizeCode)((byte)((Value >> 4) & uint2.Max));
            }

            public bool IsInvariant
            {
                [MethodImpl(Inline)]
                get => this[w16].Width == this[w32].Width && this[w32].Width == this[w64].Width;
            }

            public bool IsScalable
            {
                [MethodImpl(Inline)]
                get => IsNonEmpty && !IsInvariant;
            }

            public NativeSize InvariantWidth
            {
                [MethodImpl(Inline)]
                get => this[w16];
            }

            public byte Count
            {
                [MethodImpl(Inline)]
                get => (byte)(IsEmpty ? 0 : IsInvariant ? 1 : 3);
            }

            public string Format()
                => IsEmpty ? EmptyString:
                   IsInvariant  ? this[w32].Width.ToString()
                    : string.Format("{0}/{1}/{2}",
                        this[w16].Width,
                        this[w32].Width,
                        this[w64].Width
                    );

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator byte(GprWidth src)
                => (byte)src.Value;

            public static GprWidth Empty => new GprWidth(uint6.Max);

            const byte EntryCount = 28;

            static ReadOnlySpan<byte> Data => new byte[EntryCount]{
                define(16,16,16), // GPR16_B,
                define(16,16,16), // GPR16_R,

                define(32,32,32), // GPR32_B,
                define(32,32,32), // GPR32_R,

                define(64,64,64), // GPR64_B,
                define(64,64,64), // GPR64_R,

                define(8,8,8),    // GPR8_B,
                define(8,8,8),    // GPR8_R,
                define(8,8,8),    // GPR8_SB,

                define(16,32,64), // GPRv_B,
                define(16,32,64), // GPRv_R,
                define(16,32,64), // GPRv_SB

                define(32,32,64), // GPRy_B,
                define(32,32,64), // GPRy_R,

                define(16,32,32), // GPRz_B,
                define(16,32,32), // GPRz_R,

                define(32,32,32), // VGPR32_B,
                define(32,32,32), // VGPR32_N,
                define(32,32,32), // VGPR32_R,

                define(64,64,64), // VGPR64_B,
                define(64,64,64), // VGPR64_N,
                define(64,64,64), // VGPR64_R,

                define(32,32,64), // VGPRy_N,

                define(16,32,64), // OeAX,
                define(16,32,64), // OrAX,
                define(16,32,64), // OrBP,
                define(16,32,64), // OrDX,
                define(16,32,64), // OrSP,
                };
            }
        }
}