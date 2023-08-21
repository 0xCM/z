//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using dsl.intel;
    using dsl.intel.intrinsics;
    using static NativeSigs;

    using static sys;

    using K = dsl.intel.IntrinsicName;

    [ApiHost]
    public sealed class IntrinsicsChecks : PageBank16x4x4<IntrinsicsChecks>
    {
        public static IntrinsicsChecks create(IWfChannel channel)
        {
            var dst = new IntrinsicsChecks();
            dst.Channel = channel;
            dst.Random = Rng.@default();
            return dst;
        }

        const NumericKind Closure = UnsignedInts;

        IWfChannel Channel;

        IPolySource Random;

        public IntrinsicsChecks()
        {

        }

        void Compute(IntrinsicName name)
        {
            switch(name)
            {
                case K._mm256_cvtepi16_epi8:
                break;

                case K.mm256_min_epu8:
                {
                    var block0 = Cells<byte>(n0);
                    Random.Fill(block0);
                    var block1 = Cells<byte>(n1);
                    Random.Fill(block1);
                    var left = recover<__m256i<byte>>(block0);
                    var right = recover<__m256i<byte>>(block1);
                    var count = left.Length;
                    for(var i=0; i<count; i++)
                    {
                        var input = new mm256_min_epu8(skip(left,i), skip(right,i));
                        var output = Specs.calc(input);
                        var expr = string.Format("{0}(\r\n  {1}, \r\n  {2}) -> \r\n  {3}", input.Kind, input.A, input.B, output);
                        Channel.Write(expr);
                    }
                }
                break;

                case K.mm_packus_epi16:
                {
                    var block0 = Cells<short>(n0);
                    Random.Fill(block0);
                    var block1 = Cells<short>(n1);
                    Random.Fill(block1);
                    var left = recover<__m128i<short>>(block0);
                    var right = recover<__m128i<short>>(block1);
                    var count = left.Length;
                    for(var i=0; i<count; i++)
                    {
                        var input = new mm_packus_epi16(skip(left,i), skip(right,i));
                        var output = Specs.calc(input);
                        var expr = string.Format("{0}(\r\n  {1}, \r\n  {2}) -> \r\n  {3}", input.Kind, input.A, input.B, output);
                        var y = intel.eq(vpack.vpackus(input.A, input.B), output).Format();
                        Channel.Write(y);
                    }
                }
                break;

                case K.mm_min_epi8:
                {
                    var block0 = Cells<sbyte>(n0);
                    Random.Fill(block0);
                    var block1 = Cells<sbyte>(n1);
                    Random.Fill(block1);
                    var left = recover<__m128i<sbyte>>(block0);
                    var right = recover<__m128i<sbyte>>(block1);
                    var count = left.Length;
                    for(var i=0; i<count; i++)
                    {
                        var input = new mm_min_epi8(skip(left,i), skip(right,i));
                        var output = Specs.calc(input);
                        var expr = string.Format("{0}(\r\n  {1}, \r\n  {2}) -> \r\n  {3}", input.Kind, input.A, input.B, output);
                        Channel.Write(expr);
                    }
                }
                break;

                default:
                break;
            }
        }

        public ref readonly PageBankInfo BufferInfo
            => ref Describe();

        [MethodImpl(Inline), Op, Closures(Closure)]
        Span<T> Cells<T>(N0 n)
            where T : unmanaged
                => Block(n).Cells<T>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        Span<T> Cells<T>(N1 n)
            where T : unmanaged
                => Block(n).Cells<T>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        Span<T> Cells<T>(N2 n)
            where T : unmanaged
                => Block(n).Cells<T>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        Span<__m128i<T>> Vecs<T>(N0 n, W128 w)
            where T : unmanaged
                => Block(n).Cells<__m128i<T>>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        Span<__m256i<T>> Vecs<T>(N0 n, W256 w)
            where T : unmanaged
                => Block(n).Cells<__m256i<T>>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        Span<__m512i<T>> Vecs<T>(N0 n, W512 w)
            where T : unmanaged
                => Block(n).Cells<__m512i<T>>();

        [MethodImpl(Inline)]
        Span<__m128i<T>> Vecs<T>(N1 n, W128 w)
            where T : unmanaged
                => Block(n).Cells<__m128i<T>>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        Span<__m256i<T>> Vecs<T>(N1 n, W256 w)
            where T : unmanaged
                => Block(n).Cells<__m256i<T>>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        Span<__m512i<T>> Vecs<T>(N1 n, W512 w)
            where T : unmanaged
                => Block(n).Cells<__m512i<T>>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        Span<__m128i<T>> Vecs<T>(N2 n, W128 w)
            where T : unmanaged
                => Block(n).Cells<__m128i<T>>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        Span<__m256i<T>> Vecs<T>(N2 n, W256 w)
            where T : unmanaged
                => Block(n).Cells<__m256i<T>>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        Span<__m512i<T>> Vecs<T>(N2 n, W512 w)
            where T : unmanaged
                => Block(n).Cells<__m512i<T>>();

        public void CheckSigs()
        {
            var specs = new Operand[3];
            using var alloc = Alloc.create();

            var intrinsics = new Sigs();
            var f0 = intrinsics._mm_add_epi8();
            Channel.Write(f0.Format(SigFormatStyle.C));

            var f0x = alloc.Sig(f0);
            Channel.Write(f0x.Format(SigFormatStyle.C));

            var f1 = intrinsics._mm_add_epi16();
            Channel.Write(f1.Format(SigFormatStyle.C));

            var f1x = alloc.Sig(f1);
            Channel.Write(f1x.Format(SigFormatStyle.C));

            var f2 = intrinsics._mm_add_epi32();
            Channel.Write(f2.Format(SigFormatStyle.C));

            var f2x = alloc.Sig(f2);
            Channel.Write(f2x.Format(SigFormatStyle.C));

            var f3 = intrinsics._mm_add_epi64();
            Channel.Write(f3.Format(SigFormatStyle.C));

            var f3x = alloc.Sig(f3);
            Channel.Write(f3x.Format(SigFormatStyle.C));

            seek(specs,0) = NativeSigs.op("op0", NativeSigs.u8());
            seek(specs,1) = NativeSigs.op("op1", NativeSigs.i16());
            seek(specs,2) = NativeSigs.op("op2", NativeSigs.u32());
        }

        void Segments()
        {
            var src = Vecs<byte>(n0,w128);
            src.Clear();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref var vec = ref seek(src,i);
                var bits = vec.Width;
                for(byte j=0; j<bits; j+=8)
                    vec[j+7,j] = (byte)(j/8);
                Channel.Write(string.Format("{0:D5}:{1}", i, vec.Format()));
            }
        }

        void Compute()
        {
            var block0 = Cells<ushort>(n0);
            var block1 = Cells<byte>(n1);
            var block2 = Cells<int>(n2);
            Random.Fill(block0);
            block1.Clear();
            var src = recover<__m256i<ushort>>(block0);
            var dst = recover<__m128i<byte>>(block1);
            var count = Specs._mm256_cvtepi16_epi8_seq(src,dst);
            var op = nameof(Specs._mm256_cvtepi16_epi8_seq);
            for(var i=0; i<count; i++)
                Channel.Write(string.Format("{0}:{1} -> {2}", op, skip(src,i), skip(dst,i)));
        }

        public void Execute(IEventTarget log)
        {
            Compute(IntrinsicName.mm256_min_epu8);
            Compute(IntrinsicName.mm_packus_epi16);
            Compute(IntrinsicName.mm_min_epi8);
        }
    }    
}
