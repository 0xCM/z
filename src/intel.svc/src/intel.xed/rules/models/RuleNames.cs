//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using Bv128 = BitVector128<ulong>;
    using Bv256 = BitVector256<ulong>;
    using static XedModels;
    
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct RuleNames
        {
            [MethodImpl(Inline), Op]
            public static RuleNames create()
                => Empty;

            [MethodImpl(Inline)]
            public static RuleNames all()
                => new RuleNames(Bv256.Ones, Bv128.Ones);

            [MethodImpl(Inline), Op]
            public static RuleNames init(params NonterminalKind[] src)
                => init(@readonly(src));

            [MethodImpl(Inline), Op]
            public static RuleNames init(ReadOnlySpan<NonterminalKind> src)
            {
                var dst = Empty;
                for(var i=0; i<src.Length; i++)
                    dst.Include(skip(src,i));
                return dst;
            }

            public const NonterminalKind FirstName = NonterminalKind.None;

            public const NonterminalKind LastName = NonterminalKind.ZMM_R3_64;

            public const uint MaxCount = (uint)(LastName - FirstName) + 1;

            public static ReadOnlySpan<NonterminalKind> View
            {
                [MethodImpl(Inline), Op]
                get => recover<NonterminalKind>(slice(Bytes.B512x16u, 0, MaxCount));
            }

            [MethodImpl(Inline)]
            RuleNames(Bv256 a, Bv128 b)
            {
                SegA = a;
                SegB = b;
            }

            Bv256 SegA;

            Bv128 SegB;

            [MethodImpl(Inline)]
            public bit Contains(NonterminalKind src)
                => (IsSegA(src) && SegA.Test(SegAPos(src))) || (IsSegB(src) && SegB.Test(SegBPos(src)));

            [MethodImpl(Inline)]
            public bool Include(NonterminalKind src)
            {
                var result = false;
                if(IsSegA(src))
                {
                    SegA.Enable(SegAPos(src));
                    result = true;
                }
                else if(IsSegB(src))
                {
                    SegB.Enable(SegBPos(src));
                    result = true;
                }
                return result;
            }

            [MethodImpl(Inline)]
            public RuleNames Include(params NonterminalKind[] src)
            {
                for(var i=0; i<src.Length; i++)
                    Include(skip(src,i));
                return this;
            }

            [MethodImpl(Inline)]
            public RuleNames Include(ReadOnlySpan<NonterminalKind> src)
            {
                for(var i=0; i<src.Length; i++)
                    Include(skip(src,i));
                return this;
            }

            [MethodImpl(Inline)]
            public uint Members(Span<NonterminalKind> dst)
            {
                var counter = 0u;
                for(var i=0; i<MaxCount; i++)
                {
                    if(Contains(ToName(i)))
                        seek(dst,counter++) = (NonterminalKind)i;
                }
                return counter;
            }

            [MethodImpl(Inline)]
            public uint Members(Action<NonterminalKind> f)
            {
                var counter = 0u;
                for(var i=0; i<MaxCount; i++)
                {
                    var kind = ToName(i);
                    if(Contains(kind))
                        f(kind);
                }
                return counter;
            }

            [MethodImpl(Inline)]
            public uint Count()
            {
                var counter = 0u;
                for(var i=0; i<MaxCount; i++)
                {
                    if(Contains(ToName(i)))
                        counter++;
                }
                return counter;
            }

            [MethodImpl(Inline)]
            public RuleNames Clear()
            {
                SegA = Bv256.Zero;
                SegB = Bv128.Zero;
                return this;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => alg.hash.combine(SegA.GetHashCode(), SegB.GetHashCode());
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Count() == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Count() != 0;
            }

            public string Format()
                => XedRender.format(this);

            public string Format(char sep)
                => XedRender.format(this, sep);

            public override string ToString()
                => Format();

            public override int GetHashCode()
                => Hash;

            [MethodImpl(Inline)]
            public bool Equals(RuleNames src)
                => SegA == src.SegA && SegB == src.SegB;

            public override bool Equals(object src)
                => src is RuleNames x && Equals(x);

            [MethodImpl(Inline)]
            public static bool operator==(RuleNames a, RuleNames b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator!=(RuleNames a, RuleNames b)
                => !a.Equals(b);

            [MethodImpl(Inline)]
            static byte SegAPos(NonterminalKind src)
                => (byte)src;

            [MethodImpl(Inline)]
            static byte SegBPos(NonterminalKind src)
                => (byte)((short)src - (short)SegBFirstName);

            public static RuleNames Empty => default;

            [MethodImpl(Inline)]
            static bit IsSegA(NonterminalKind src)
                => src <= SegALastName;

            [MethodImpl(Inline)]
            static bit IsSegB(NonterminalKind src)
                => src >= SegBFirstName && src <= SegBLastName;

            [MethodImpl(Inline)]
            static NonterminalKind ToName(int index)
                => (NonterminalKind)index;

            const NonterminalKind SegALastName = NonterminalKind.VEX_REG_ENC;

            const NonterminalKind SegBFirstName = NonterminalKind.VEX_REXR_ENC;

            const NonterminalKind SegBLastName = LastName;
        }
    }
}