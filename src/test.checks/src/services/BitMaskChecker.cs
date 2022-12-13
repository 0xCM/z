//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static BitMasks;

    [ApiHost]
    public class BitMaskChecker : Checker<BitMaskChecker>
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Closures(Closure)]
        public static ref ulong eq<T>(T x, T y, ref byte index, ref ulong dst)
            where T : unmanaged
        {
            dst = (ulong)@byte(gmath.eq(x,y)) << index++;
            return ref dst;
        }

        [MethodImpl(Inline), Closures(Closure)]
        public static bit eq<T>(T x, T y)
            where T : unmanaged
                => gmath.eq(x,y);

        uint SuccessCount;

        uint FailureCount;

        public Pair<uint> Counts;

        Index<byte> Cases8;

        Index<byte> Cases16;

        Index<byte> Cases32;

        Index<byte> Cases64;

        BinaryLiterals<byte> Literals8;

        BinaryLiterals<ushort> Literals16;

        BinaryLiterals<uint> Literals32;

        BinaryLiterals<ulong> Literals64;

        HiMaskLogs<byte> HiMaskLog8;

        HiMaskLogs<ushort> HiMaskLog16;

        HiMaskLogs<uint> HiMaskLog32;

        HiMaskLogs<ulong> HiMaskLog64;

        public const uint Reps = Pow2.T08;

        protected override void Prepare()
        {
            Init();
        }

        [Op]
        void Exec()
        {
            var results = 0ul;
            var index = z8;
            Check(base2);
            CheckLoMasks(ref index, ref results);
            CheckHiMasks();
            Counts = (SuccessCount, FailureCount);
        }

        protected override void Execute(IEventTarget log)
        {
            Exec();
        }

        [Op]
        void Init()
        {
            Cases8 = Random.Fill(z8, width<byte>(w8), alloc<byte>(Reps));
            Cases16 = Random.Fill(z8, width<ushort>(w8), alloc<byte>(Reps));
            Cases32 = Random.Fill(z8, width<uint>(w8), alloc<byte>(Reps));
            Cases64 = Random.Fill(z8, width<uint>(w8), alloc<byte>(Reps));
            Literals8 = ClrLiterals.tagged<byte>(base2, typeof(BitMaskLiterals));
            Literals16 = ClrLiterals.tagged<ushort>(base2, typeof(BitMaskLiterals));
            Literals32 = ClrLiterals.tagged<uint>(base2, typeof(BitMaskLiterals));
            Literals64 = ClrLiterals.tagged<ulong>(base2, typeof(BitMaskLiterals));
            HiMaskLog8 = alloc<HiMaskLog<byte>>(Reps);
            HiMaskLog16 = alloc<HiMaskLog<ushort>>(Reps);
            HiMaskLog32 = alloc<HiMaskLog<uint>>(Reps);
            HiMaskLog64 = alloc<HiMaskLog<ulong>>(Reps);
        }

        [MethodImpl(Inline)]
        static CaseProvider<W> cases<W>(BitMaskChecker checker, W w = default)
            where W : unmanaged, ITypeWidth<W>
                => new CaseProvider<W>(checker);

        readonly struct CaseProvider<W>
            where W : unmanaged, ITypeWidth<W>
        {
            static W Width => default;

            readonly BitMaskChecker Checker;

            [MethodImpl(Inline)]
            public CaseProvider(BitMaskChecker checker)
            {
                Checker = checker;
            }

            public ReadOnlySpan<byte> Cases
            {
                [MethodImpl(Inline)]
                get => Checker.Cases(Width);
            }
        }

        [MethodImpl(Inline)]
        ReadOnlySpan<byte> Cases<W>(W w)
            where W : unmanaged, ITypeWidth<W>
        {
            if(typeof(W) == typeof(W8))
                return Cases8;
            else if(typeof(W) == typeof(W16))
                return Cases16;
            else if(typeof(W) == typeof(W32))
                return Cases32;
            else if(typeof(W) == typeof(W64))
                return Cases16;
            else
                throw no<W>();
        }

        [MethodImpl(Inline)]
        BinaryLiterals<T> Lit<T>(T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return @as<BinaryLiterals<byte>, BinaryLiterals<T>>(Literals8);
            else if(typeof(T) == typeof(ushort))
                return @as<BinaryLiterals<ushort>, BinaryLiterals<T>>(Literals16);
            else if(typeof(T) == typeof(uint))
                return @as<BinaryLiterals<uint>, BinaryLiterals<T>>(Literals32);
            else if(typeof(T) == typeof(ulong))
                return @as<BinaryLiterals<ulong>, BinaryLiterals<T>>(Literals64);
            else
                throw no<T>();
        }

        [Op]
        void CheckHiMasks()
        {
            CheckHimask(w8);
            CheckHimask(w16);
            CheckHimask(w32);
            CheckHimask(w64);
        }

        [Op]
        static void CheckLoMasks(ref byte index, ref ulong log)
        {
            CheckLoMask(n0, ref index, ref log);
            CheckLoMask(n1, ref index, ref log);
            CheckLoMask(n2, ref index, ref log);
        }

        [Op]
        static void CheckLoMask(N0 @case, ref byte index, ref ulong log)
        {
            eq((Pow2.pow(3) - 1)^Pow2.pow(3), lo64(3), ref index, ref log);
            eq((Pow2.pow(7) - 1)^Pow2.pow(7), lo64(7), ref index, ref log);
            eq((Pow2.pow(13) - 1)^Pow2.pow(13), lo64(13), ref index, ref log);
            eq((Pow2.pow(25) - 1)^Pow2.pow(25), lo64(25), ref index, ref log);
            eq((Pow2.pow(59) - 1)^Pow2.pow(59), lo64(59), ref index, ref log);
        }

        [Op]
        static void CheckLoMask(N1 @case, ref byte index, ref ulong log)
        {
            eq(4u, bits.pop(lo64(3)), ref index, ref log);
            eq(7u, bits.pop(lo64(6)), ref index, ref log);
            eq(13u, bits.pop(lo64(12)), ref index, ref log);
            eq(25u, bits.pop(lo64(24)), ref index, ref log);
            eq(59u, bits.pop(lo64(58)), ref index, ref log);
        }

        [Op]
        static void CheckLoMask(N2 @case, ref byte index, ref ulong log)
        {
            var lomask = BitMasks.lo<uint>(6);
            var himask = BitMasks.hi<uint>(8);
            var src = uint.MaxValue;
            var dst = gmath.xor(gmath.xor(src,lomask), himask);
            eq(7u, bits.ntz(dst), ref index, ref log);
            eq(8u, (uint)bits.nlz(dst), ref index, ref log);
            eq(7u, bits.pop(BitMasks.lo<uint>(6)), ref index, ref log);
            eq(12u, bits.pop(BitMasks.lo<uint>(11)), ref index, ref log);
        }

        [Op]
        void Check(Base2 @base)
        {
            Check<byte>(@base,Log);
            Check<ushort>(@base,Log);
            Check<uint>(@base,Log);
            Check<ulong>(@base,Log);
        }

        [MethodImpl(Inline), Op]
        void CheckHimask(W8 w)
            => CheckHiMask(cases(this,w), HiMaskLog8);

        [MethodImpl(Inline), Op]
        void CheckHimask(W16 w)
            => CheckHiMask(cases(this,w), HiMaskLog16);

        [MethodImpl(Inline), Op]
        void CheckHimask(W32 w)
            => CheckHiMask(cases(this,w), HiMaskLog32);

        [MethodImpl(Inline), Op]
        void CheckHimask(W64 w)
            => CheckHiMask(cases(this,w), HiMaskLog64);

        [MethodImpl(Inline)]
        void Check<T>(Base2 @base, Action<object> Log)
            where T : unmanaged
        {
            var literals = Lit<T>();
            foreach(var m in literals.Storage)
            {
                var bits = BitSpans32.parse(m.Text);
                var bitval = bits.Convert<T>();
                var ok = gmath.eq(bitval,m.Data);

                if(ok)
                    SuccessCount++;
                else
                    FailureCount++;

                var results = EvalResults.eq(bitval,m.Data,ok);
                var sym = ok ? "==" : "!=";
                var title = ok ? "Success" : "Failure";
                var normalized = BitStrings.normalize(m.Text);
                var bs = BitStrings.scalar(m.Data);
                var expr = RpOps.format("{0} {1} {2}", normalized, sym, bs);
                var description = RpOps.format("{0,-12} | {1,-14} | {2}", title, m.Name, expr);
                Log(description);
            }
        }

        [MethodImpl(Inline)]
        void CheckHiMask<W,T>(CaseProvider<W> src, HiMaskLogs<T> dst)
            where T : unmanaged
            where W : unmanaged, ITypeWidth<W>
        {
            var w = default(W);
            var mincount = (byte)1;
            var maxcount = (byte)width<T>();
            var cases = src.Cases;
            for(var i=0u; i<Reps; i++)
            {
                ref var log = ref dst[i];
                log.Check1 = true;
                log.Count = skip(cases, i);
                log.Mask = BitMasks.hi<T>(log.Count);
                log.PopCount = (byte)gbits.pop(log.Mask);
                log.Check1 = log.PopCount != log.Count;
                log.Check1 = eq(log.Count, gbits.pop(log.Mask));
                log.Lowered = gmath.srl(log.Mask, (byte)(width<T>() -  log.Count));
                log.PackedWidth = gbits.effwidth(log.Lowered);
                log.Check3 = log.Count == log.PackedWidth;
            }

            TableEmit(dst.View, AppDb.ApiTargets().Table<HiMaskLog<T>>());
        }
    }
}