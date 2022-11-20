//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.Intrinsics;

    using static BitMaskLiterals;
    using static Root;
    using static core;

    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;

    public class t_vblendp : t_inx<t_vblendp>
    {
        public override bool Enabled => true;

        bool EmitInfo
            => false;

        public void vblendp_perm32_g128x8u()
            => vblendp_check(w128, n32, Msb16x16x1, z8);

        public void vblendp_perm16_g128x16u()
            => vblendp_check(w128, n16, Msb32x32x1, z16);

        public void vblendp_perm8_g128x32u()
            => vblendp_check(w128, n8, Msb64x64x1, z32);

        public void vblendp_perm64_g256x8u()
            => vblendp_check(w256, n64, Msb16x16x1, z8);

        public void vblendp_perm32_g256x16u()
            => vblendp_check(w256, n32, Msb32x32x1, z16);

        public void vblendp_perm16_g256x32u()
            => vblendp_check(w256, n16, Msb64x64x1, z32);

        /// <summary>
        /// Expands a bit-level S-pattern to a vector-level T-pattern
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The source pattern</param>
        /// <param name="enabled">The value to assign to a block when the corresponding index-identified bit is enabled</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target cell type</typeparam>
        public static Vector128<T> vbroadcast<S,T>(N128 w, S src, T enabled)
            where S : unmanaged
            where T : unmanaged
        {
            var count = cpu.vcount(w, enabled);
            var buffer = gcpu.vzero<T>(w);
            ref var dst = ref gcpu.vref(ref buffer);
            var length = min(count, width<S>());
            for(var i=0u; i<length; i++)
                seek(dst, i) = gbits.test(src,(byte)i) ? enabled : default;
            return buffer;
        }

        /// <summary>
        /// Expands a bit-level S-pattern to a vector-level T-pattern
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="src">The source pattern</param>
        /// <param name="enabled">The value to assign to a block when the corresponding index-identified bit is enabled</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target cell type</typeparam>
        public static Vector256<T> vbroadcast<S,T>(W256 w, S src, T enabled)
            where S : unmanaged
            where T : unmanaged
        {
            var count = cpu.vcount(w, enabled);
            var buffer = gcpu.vzero<T>(w);
            ref var dst = ref gcpu.vref(ref buffer);
            var length = min(count, width<S>());
            for(var i=0u; i<length; i++)
                seek(dst, i) = gbits.test(src,(byte)i) ? enabled : default;
            return buffer;
        }

        public static string format<F,D,T,S>(IMaskSpec<F,D,T> maskspec, S sample, Vector512<T> source, Vector512<T> target)
            where F : unmanaged, ITypeNat
            where D : unmanaged, ITypeNat
            where T : unmanaged
            where S : unmanaged
        {
            var description = text.build();
            var indent = "/// ";
            var bits = BitStrings.scalar(sample).Format(specifier:true);
            var header = $"{indent}512x{width<T>()}, {maskspec}, {bits}";
            var sep = Chars.Comma;
            var pad = 2;
            description.AppendLine(header);
            description.AppendLine($"{indent}source: {source.Format()}");
            description.AppendLine($"{indent}target: {target.Format()}");
            return description.ToString();
        }

        /// <summary>
        /// 512x64, msb, f:2, d:1, t:64u, 0b10101010
        /// source: [ 0,  1,  2,  3,  4,  5,  6,  7]
        /// target: [ 0,  5,  2,  7,  4,  1,  6,  3]
        /// </summary>
        public void vblendp_512x64_Msb2x1()
        {
            var w = w512;
            var t = z64;
            var maskspec = BitMasks.msbspec(n2,n1,t);

            var source = gcpu.vinc(w,t);
            var blendspec = vbroadcast(w256, BitMasks.create(maskspec), Limits.maxval<ulong>());
            var target = gcpu.vblendp(source, blendspec);
            var expect = cpu.vparts(w,0,5,2,7,4,1,6,3);
            Claim.require(gcpu.vsame(expect,target));

            var descrition = format(maskspec, BitMasks.create(maskspec.As(z8)), source,target);
            if(EmitInfo)
                Notify(descrition);
        }

        /// <summary>
        /// 512x64, msb, f:4, d:1, t:64u, 0b10001000
        /// source: [ 0,  1,  2,  3,  4,  5,  6,  7]
        /// target: [ 0,  1,  2,  7,  4,  5,  6,  3]
        /// </summary>
        public void vblendp_512x64_Msb4x1()
        {
            var w = w512;
            var t = z64;
            var maskspec = BitMasks.msbspec(n4,n1,t);
            var source = gcpu.vinc(w,t);
            var blendspec = vbroadcast(w256, BitMasks.create(maskspec), Limits.maxval(t));
            var target = gcpu.vblendp(source, blendspec);
            var expect = cpu.vparts(w,0,1,2,7,4,5,6,3);
            Claim.require(gcpu.vsame(expect, target));

            var descrition = format(maskspec, BitMasks.create(maskspec.As(z8)), source, target);
            if(EmitInfo)
                Notify(descrition);
        }

        /// <summary>
        /// 512x64, lsb, f:2, d:1, t:64u, 0b01010101
        /// source: [ 0,  1,  2,  3,  4,  5,  6,  7]
        /// target: [ 4,  1,  6,  3,  0,  5,  2,  7]
        /// </summary>
        public void vblendp_512x64_Lsb2x1()
        {
            var w = w512;
            var t = z64;
            var maskspec = BitMasks.lsbspec(n2,n1,t);

            var source = gcpu.vinc(w,t);
            var blendspec = vbroadcast(w256, BitMasks.create(maskspec), Limits.maxval(t));
            var target = gcpu.vblendp(source, blendspec);
            var expect = cpu.vparts(w,4,1,6,3,0,5,2,7);
            Claim.require(gcpu.vsame(expect,target));

            var descrition = format(maskspec, BitMasks.create(maskspec.As(z8)), source,target);
            if(EmitInfo)
                Notify(descrition);
        }

        /// <summary>
        /// 512x64, jsb, f:8, d:2, t:64u, 0b11000011
        /// source: [ 0,  1,  2,  3,  4,  5,  6,  7]
        /// target: [ 4,  5,  2,  3,  0,  1,  6,  7]
        /// </summary>
        public void vblendp_512x64_Jsb8x2()
        {
            var w = n512;
            var t = z64;
            var maskspec = BitMasks.jsbspec(n8,n2,t);

            var source = gcpu.vinc(w,t);
            var blendspec = vbroadcast(w256, BitMasks.create(maskspec), Limits.maxval(t));
            var target = gcpu.vblendp(source, blendspec);
            var expect = cpu.vparts(w,4,5,2,3,0,1,6,7);
            Claim.require(gcpu.vsame(expect,target));

            var descrition = format(maskspec, BitMasks.create(maskspec.As(z8)), source,target);
            if(EmitInfo)
                Notify(descrition);
        }

        /// <summary>
        /// 512x32, jsb, f:8, d:2, t:32u, 0b1100001111000011
        /// source: [ 0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15]
        /// target: [ 8,  9,  2,  3,  4,  5, 14, 15,  0,  1, 10, 11, 12, 13,  6,  7]
        /// </summary>
        public void vblendp_512x32_Jsb8x2()
        {
            var w = n512;
            var t = z32;
            var maskspec = BitMasks.jsbspec(n8,n2,t);
            var source = gcpu.vinc(w,t);
            var blendspec = vbroadcast(w256, BitMasks.create(maskspec), Limits.maxval(t));
            var target = gcpu.vblendp(source, blendspec);
            var expect = cpu.vparts(w,8,  9,  2,  3,  4,  5, 14, 15,  0,  1, 10, 11, 12, 13,  6,  7);
            Claim.require(gcpu.vsame(expect,target));

            var descrition = format(maskspec, BitMasks.create(maskspec.As(z16)), source,target);
            if(EmitInfo)
                Notify(descrition);
        }

        /// <summary>
        /// 512x16, jsb, f:8, d:2, t:16u, 0b11000011110000111100001111000011
        /// source: [ 0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31]
        /// target: [16, 17,  2,  3,  4,  5, 22, 23, 24, 25, 10, 11, 12, 13, 30, 31,  0,  1, 18, 19, 20, 21,  6,  7,  8,  9, 26, 27, 28, 29, 14, 15]
        /// </summary>
        public void vblendp_512x16_Jsb8x2()
        {
            var w = n512;
            var t = z16;
            var maskspec = BitMasks.jsbspec(n8,n2,t);

            var source = gcpu.vinc(w,t);
            var blendspec = vbroadcast(w256, BitMasks.create(maskspec), Limits.maxval(t));
            var target = gcpu.vblendp(source, blendspec);
            var expect = cpu.vparts(w,16, 17,  2,  3,  4,  5, 22, 23, 24, 25, 10, 11, 12, 13, 30, 31,  0,  1, 18, 19, 20, 21,  6,  7,  8,  9, 26, 27, 28, 29, 14, 15);
            Claim.eq(expect,target);

            var descrition = format(maskspec, BitMasks.create(maskspec.As(z32)), source,target);
            if(EmitInfo)
                Notify(descrition);
        }

        /// <summary>
        /// 512x8, jsb, f:8, d:2, t:8u, 0b1100001111000011110000111100001111000011110000111100001111000011
        /// source: [ 0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63]
        /// target: [32, 33,  2,  3,  4,  5, 38, 39,  8,  9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31,  0,  1, 34, 35, 36, 37,  6,  7, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63]
        /// </summary>
        public void vblendp_512x8_Jsb8x2_outline()
        {
            var w = n512;
            var t = z8;
            var maskspec = BitMasks.jsbspec(n8,n2,t);

            var source = gcpu.vinc(w,t);
            var blendspec = vbroadcast(w256, BitMasks.create(maskspec), Limits.maxval(t));
            var target = gcpu.vblendp(source, blendspec);

            var descrition = format(maskspec, BitMasks.create(maskspec.As(z64)), source,target);
            if(EmitInfo)
                Notify(descrition);
        }

        public void vblendp_512x8_Jsb8x2()
        {
            var w = w512;
            var t = z8;
            var maskspec = BitMasks.jsbspec(n8,n2,t);
            var blendspec = vbroadcast(w256, BitMasks.create(maskspec), Limits.maxval(t));
            var maskbits = BitMasks.create(maskspec.As(z64));

            for(var samples=0; samples< RepCount; samples++)
            {
                var source = Random.CpuVector(w,t);
                var target = gcpu.vblendp(source,blendspec);
            }
        }

        public void vblendp_perm64_256x8u()
        {
            var w = w256;
            var t = z8;
            var n = n64;
            var tf = 4;
            var pick = BitMasks.msb(n1,n1,t);
            var pattern = SpanBlocks.alloc<byte>(w, 1);
            for(var i=0; i< pattern.CellCount; i++)
                pattern[i] = (i % tf == 0) ? pick : t;

            var spec = pattern.LoadVector();
            var x = gcpu.vinc(w, t);
            var y = gcpu.vadd(x, gmath.add(x.LastCell(), one<byte>()));
            var z = gcpu.vblendp(x,y,spec);

            var dst = SpanBlocks.alloc<byte>(w,2);
            gcpu.vlo(z).StoreTo(dst,0);
            gcpu.vhi(z).StoreTo(dst,1);

            var perm = Z0.Perm.init(dst.Storage);
            for(var i=0; i< perm.Length; i++)
            {
                var identity = i == perm[i];
                if(!identity)
                {
                    var j = perm[i];
                    var k = perm[j];
                    Claim.eq(i,k);
                }
            }
        }

        static Vector128<T> swaps_pattern<T>(W128 w, int tf, T t = default)
            where T : unmanaged
        {
            var pick = BitMasks.msb(n1,n1,t);
            var pattern = SpanBlocks.alloc<T>(w, 1);
            for(var i=0; i< pattern.CellCount; i++)
                pattern[i] = (i % tf == 0) ? pick : t;
            return pattern.LoadVector();
        }

        static T enabled<T>(T t = default)
            where T : unmanaged
                => BitMasks.msb(n1,n1,t);

        static Vector128<T> rrll_pattern<T>(N128 w, T t = default)
            where T : unmanaged
                => Calcs.broadcast(BitMasks.even(n2,n2,z64), enabled(t), SpanBlocks.alloc<T>(w,1)).LoadVector();

        static Vector128<T> llrr_pattern<T>(N128 w, T t = default)
            where T : unmanaged
                => Calcs.broadcast(BitMasks.odd<ulong>(n2,n2), enabled(t), SpanBlocks.alloc<T>(w,1)).LoadVector();

        static Vector128<T> rl_pattern<T>(N128 w, T t = default)
            where T : unmanaged
                => Calcs.broadcast(BitMasks.lsb(n2,n1,z64), enabled(t), SpanBlocks.alloc<T>(w,1)).LoadVector();

        static Vector128<T> lr_pattern<T>(N128 w, T t = default)
            where T : unmanaged
                => Calcs.broadcast(BitMasks.msb(n2,n1,z64), enabled(t), SpanBlocks.alloc<T>(w,1)).LoadVector();

        static Vector256<T> rl_pattern<T>(N256 w, T t = default)
            where T : unmanaged
                => Calcs.broadcast(BitMasks.lsb(n2,n1,t), enabled(t), SpanBlocks.alloc<T>(w,1)).LoadVector();

        void vblendp_check<T>(Vector128<T> spec, [CallerName] string title = null)
            where T : unmanaged
        {
            var w = n128;
            var t = default(T);
            var pn = n32;

            Claim.eq(nat64u(pn), NatCalc.divT(w,t) * 2);

            var left = gcpu.vinc(w, t);
            var right = gcpu.vadd(left, gmath.add(left.LastCell(), one<T>()));
            var blend = gcpu.vblendp(left,right,spec);


            var dst = SpanBlocks.alloc<T>(w,2);
            gcpu.vlo(blend).StoreTo(dst,0);
            gcpu.vhi(blend).StoreTo(dst,1);

            var perm = Z0.Perm.init(dst.Storage);
            var tc = 0;
            for(var i=0; i<perm.Length; i++)
            {
                var ti = Numeric.force<T>(i);
                var identity = gmath.eq(ti ,perm[i]);
                if(!identity)
                {
                    var j = perm[i];
                    var k = perm[j];
                    Claim.eq(ti,k);
                    tc++;
                }
            }

            if(EmitInfo)
            {
                var sep = Chars.Comma;
                var pad = 2;
                Notify($"* {title}: vector width = {w}, swap count = {tc}, cell type = {typeof(T).DisplayName()}, perm length = {pn}");
                Notify($"left:  {left.Format()}");
                Notify($"right: {right.Format()}");
                Notify(perm.Format());
                Notify(string.Empty);
            }
        }


        public void vblendp_perm32_128x8u()
        {
            var w = n128;
            var t = z8;

            void swaps()
            {
                var title = nameof(swaps);
                vblendp_check(swaps_pattern(w, 1,t), title);
                vblendp_check(swaps_pattern(w, 2,t), title);
                vblendp_check(swaps_pattern(w, 3,t), title);
                vblendp_check(swaps_pattern(w, 4,t), title);
                vblendp_check(swaps_pattern(w, 5,t), title);
                vblendp_check(swaps_pattern(w, 6,t), title);
                vblendp_check(swaps_pattern(w, 7,t), title);
            }

            void lr()
                => vblendp_check(lr_pattern(n128,z8), nameof(lr));

            void rl()
                => vblendp_check(rl_pattern(n128,z8), nameof(rl));

            void llrr()
                => vblendp_check(llrr_pattern(n128,z8), nameof(llrr));

            void rrll()
                => vblendp_check(rrll_pattern(n128,z8), nameof(rrll));

            lr();
            rl();
            llrr();
            rrll();

            /*

            * lr: vector width = 128, swap count = 16, cell type = byte, perm length = 32
            left:  [ 0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15]
            right: [16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31]
            |  0  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 |
            |  0 17  2 19  4 21  6 23  8 25 10 27 12 29 14 31 16  1 18  3 20  5 22  7 24  9 26 11 28 13 30 15 |

            * rl: vector width = 128, swap count = 16, cell type = byte, perm length = 32
            left:  [ 0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15]
            right: [16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31]
            |  0  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 |
            | 16  1 18  3 20  5 22  7 24  9 26 11 28 13 30 15  0 17  2 19  4 21  6 23  8 25 10 27 12 29 14 31 |

            * llrr: vector width = 128, swap count = 16, cell type = byte, perm length = 32
            left:  [ 0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15]
            right: [16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31]
            |  0  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 |
            |  0  1 18 19  4  5 22 23  8  9 26 27 12 13 30 31 16 17  2  3 20 21  6  7 24 25 10 11 28 29 14 15 |

            * rrll: vector width = 128, swap count = 16, cell type = byte, perm length = 32
            left:  [ 0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15]
            right: [16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31]
            |  0  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 |
            | 16 17  2  3 20 21  6  7 24 25 10 11 28 29 14 15  0  1 18 19  4  5 22 23  8  9 26 27 12 13 30 31 |

            */
        }

        protected void vblendp_check<P,S,T>(N128 w, P np, S pattern, T t = default)
            where T : unmanaged
            where S : unmanaged
            where P : unmanaged, ITypeNat
        {
            var spec = cpu.@as(gcpu.vbroadcast(w, pattern), t);
            var a = gcpu.vinc(w, t);
            var b = gcpu.vadd(a, gmath.add(a.LastCell(), one<T>()));
            var c = gcpu.vblendp(a,b,spec);

            var dst = SpanBlocks.alloc<T>(w,2);
            gcpu.vlo(c).StoreTo(dst,0);
            gcpu.vhi(c).StoreTo(dst,1);

            var perm = Z0.Perm.init(dst.Storage);
            for(var i=0; i<perm.Length; i++)
            {
                var identity = gmath.eq(Numeric.force<T>(i), perm[i]);
                if(!identity)
                {
                    var j = perm[i];
                    var k = perm[j];

                    Claim.require(gmath.eq(Numeric.force<T>(i),k));
                }
            }
        }

        protected void vblendp_check<P,S,T>(N256 w, P np, S pattern, T t = default)
            where T : unmanaged
            where S : unmanaged
            where P : unmanaged, ITypeNat
        {
            var spec = cpu.@as(gcpu.vbroadcast(w, pattern),t);
            var a = gcpu.vinc(w, t);
            var b = gcpu.vadd(a, gmath.add(a.LastCell(), one<T>()));
            var c = gcpu.vblendp(a,b,spec);

            var dst = SpanBlocks.alloc<T>(w,2);
            c.Lo.StoreTo(dst,0);
            c.Hi.StoreTo(dst,1);

            var perm = Z0.Perm.init(dst.Storage);
            for(var i=0; i< perm.Length; i++)
            {
                var identity = gmath.eq(Numeric.force<T>(i), perm[i]);
                if(!identity)
                {
                    var j = perm[i];
                    var k = perm[j];

                    Claim.require(gmath.eq(Numeric.force<T>(i),k));
                }
            }
        }
    }
}