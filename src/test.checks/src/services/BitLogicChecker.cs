//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static cpu;

    using K = ApiClasses;

    [ApiHost]
    public sealed class BitLogicChecker : ApiValidator<BitLogicChecker>
    {
        const NumericKind Closure = UnsignedInts;

        public override void Validate()
        {
            Check128();
            Check256();
        }

        [CmdOp("check/bitlogic")]

        void Check()
        {
            Check128();
            Check256();
        }

        void Check128()
        {
            var lhs = Source.Cells<Cell128>(SampleCount);
            var rhs = Source.Cells<Cell128>(SampleCount);
            Check(lhs,rhs);
        }

        void Check256()
        {
            var lhs = Source.Cells<Cell256>(SampleCount);
            var rhs = Source.Cells<Cell256>(SampleCount);
            Check(lhs, rhs);
        }

        [Op]
        void Check(Index<Cell128> a, Index<Cell128> b)
        {
            CheckAnd(a,b);
            CheckOr(a,b);
            CheckXor(a,b);
        }

        [Op]
        void CheckAnd(Index<Cell128> a, Index<Cell128> b)
        {
            var f = K.and();
            var name = ApiClasses.format(f);
            var msg = string.Format("Validating {0} over {1} samples", name, SampleCount);
            var running = Wf.Running(msg);
            var success = 0u;
            for(var i=0; i<SampleCount; i++)
            {
                ref readonly var x = ref a[i];
                ref readonly var y = ref b[i];
                success += (uint)Check128x8u(x, y, f);
                success += (uint)Check128x8i(x, y, f);
                success += (uint)Check128x16u(x, y, f);
                success += (uint)Check128x16i(x, y, f);
                success += (uint)Check128x32u(x, y, f);
                success += (uint)Check128x32i(x, y, f);
                success += (uint)Check128x64u(x, y, f);
                success += (uint)Check128x64i(x, y, f);
            }

            Wf.Ran(running, string.Format("{0} validation steps succeeded", success));
        }

        [Op]
        void CheckOr(Index<Cell128> a, Index<Cell128> b)
        {
            var f = K.or();
            for(var i=0; i<SampleCount; i++)
            {
                ref readonly var x = ref a[i];
                ref readonly var y = ref b[i];
                Check128x8u(x, y, f);
                Check128x8i(x, y, f);
                Check128x16u(x, y, f);
                Check128x16i(x, y, f);
                Check128x32u(x, y, f);
                Check128x32i(x, y, f);
                Check128x64u(x, y, f);
                Check128x64i(x, y, f);
            }
        }

        [Op]
        void CheckXor(Index<Cell128> a, Index<Cell128> b)
        {
            var f = K.xor();
            for(var i=0; i<SampleCount; i++)
            {
                ref readonly var x = ref a[i];
                ref readonly var y = ref b[i];
                Check128x8u(x, y, f);
                Check128x8i(x, y, f);
                Check128x16u(x, y, f);
                Check128x16i(x, y, f);
                Check128x32u(x, y, f);
                Check128x32i(x, y, f);
                Check128x64u(x, y, f);
                Check128x64i(x, y, f);
            }
        }

        [Op]
        void Check(Index<Cell256> a, Index<Cell256> b)
        {
            for(var i=0; i<SampleCount; i++)
            {
                ref readonly var lhs = ref a[i];
                ref readonly var rhs = ref b[i];
                Check256x8u(lhs, rhs, K.and());
                Check256x8i(lhs, rhs, K.and());
                Check256x16u(lhs, rhs, K.and());
                Check256x16i(lhs, rhs, K.and());
                Check256x32u(lhs, rhs, K.and());
                Check256x32i(lhs, rhs, K.and());
                Check256x64u(lhs, rhs, K.and());
                Check256x64i(lhs, rhs, K.and());
                Check256x8u(lhs, rhs, K.or());
                Check256x8i(lhs, rhs, K.or());
                Check256x16u(lhs, rhs, K.or());
                Check256x16i(lhs, rhs, K.or());
                Check256x32u(lhs, rhs, K.or());
                Check256x32i(lhs, rhs, K.or());
                Check256x64u(lhs, rhs, K.or());
                Check256x64i(lhs, rhs, K.or());
            }
        }

        [MethodImpl(Inline)]
        bit Check128x8u<K>(Vector128<byte> a, Vector128<byte> b, K f)
            where K : unmanaged, IApiBitLogicClass
                => CheckMatch(a,b,f);

        [MethodImpl(Inline)]
        bit Check128x8i<K>(Vector128<sbyte> a, Vector128<sbyte> b, K f)
            where K : unmanaged, IApiBitLogicClass
                => CheckMatch(a,b,f);

        [MethodImpl(Inline)]
        bit Check128x16u<K>(Vector128<ushort> a, Vector128<ushort> b, K f)
            where K : unmanaged, IApiBitLogicClass
                => CheckMatch(a,b,f);

        [MethodImpl(Inline)]
        bit Check128x16i<K>(Vector128<short> a, Vector128<short> b, K f)
            where K : unmanaged, IApiBitLogicClass
                => CheckMatch(a,b,f);

        [MethodImpl(Inline)]
        bit Check128x32u<K>(Vector128<uint> a, Vector128<uint> b, K f)
            where K : unmanaged, IApiBitLogicClass
                => CheckMatch(a,b,f);

        [MethodImpl(Inline)]
        bit Check128x32i<K>(Vector128<int> a, Vector128<int> b, K f)
            where K : unmanaged, IApiBitLogicClass
                => CheckMatch(a,b,f);

        [MethodImpl(Inline)]
        bit Check128x64u<K>(Vector128<ulong> a, Vector128<ulong> b, K f)
            where K : unmanaged, IApiBitLogicClass
                => CheckMatch(a,b,f);

        [MethodImpl(Inline)]
        bit Check128x64i<K>(Vector128<long> a, Vector128<long> b, K f)
            where K : unmanaged, IApiBitLogicClass
                => CheckMatch(a,b,f);

        [MethodImpl(Inline)]
        bit Check256x8u<K>(Vector256<byte> a, Vector256<byte> b, K f)
            where K : unmanaged, IApiBitLogicClass
                => CheckMatch(a,b,f);

        [MethodImpl(Inline)]
        bit Check256x8i<K>(Vector256<sbyte> a, Vector256<sbyte> b, K f)
            where K : unmanaged, IApiBitLogicClass
                => CheckMatch(a,b,f);

        [MethodImpl(Inline)]
        bit Check256x16u<K>(Vector256<ushort> a, Vector256<ushort> b, K f)
            where K : unmanaged, IApiBitLogicClass
                => CheckMatch(a,b,f);

        [MethodImpl(Inline)]
        bit Check256x16i<K>(Vector256<short> a, Vector256<short> b, K f)
            where K : unmanaged, IApiBitLogicClass
                => CheckMatch(a,b,f);

        [MethodImpl(Inline)]
        bit Check256x32u<K>(Vector256<uint> a, Vector256<uint> b, K f)
            where K : unmanaged, IApiBitLogicClass
                => CheckMatch(a,b,f);

        [MethodImpl(Inline)]
        bit Check256x32i<K>(Vector256<int> a, Vector256<int> b, K f)
            where K : unmanaged, IApiBitLogicClass
                => CheckMatch(a,b,f);

        [MethodImpl(Inline)]
        bit Check256x64u<K>(Vector256<ulong> a, Vector256<ulong> b, K f)
            where K : unmanaged, IApiBitLogicClass
                => CheckMatch(a,b,f);

        [MethodImpl(Inline)]
        bit Check256x64i<K>(Vector256<long> a, Vector256<long> b, K f)
            where K : unmanaged, IApiBitLogicClass
                => CheckMatch(a,b,f);

        [MethodImpl(Inline)]
        bit CheckMatch<K,T>(Vector128<T> a, Vector128<T> b, K f = default)
            where K : unmanaged, IApiBitLogicClass
            where T : unmanaged
        {
            var w = w128;
            var mSvc = Calcs.bitlogic<T>();
            var vSvc = Calcs.vbitlogic<T>(w);
            var buffer = Cells.alloc(w);
            ref var dst = ref Cells.to<T>(buffer);
            var cells = cpu.vcount<T>(w);
            for(byte i=0; i<cells; i++)
                seek(dst, i) = mSvc.eval(vcell(a,i), vcell(b,i), f);
            var v1 = gcpu.vload(w, dst);
            var v2 = vSvc.eval(a,b,f);
            return gcpu.vsame(v2,v1);
        }

        [MethodImpl(Inline)]
        bit CheckMatch<K,T>(Vector256<T> a, Vector256<T> b, K f)
            where K : unmanaged, IApiBitLogicClass
            where T : unmanaged
        {
            var w = w256;
            var mSvc = Calcs.bitlogic<T>();
            var vSvc = Calcs.vbitlogic<T>(w);
            var buffer = Cells.alloc(w);
            ref var dst = ref Cells.to<T>(buffer);
            var cells = vcpu.vcount<T>(w);
            for(byte i=0; i<cells; i++)
                seek(dst, i) = mSvc.eval(vcell(a,i), vcell(b,i), f);
            var v1 = gcpu.vload(w, dst);
            var v2 = vSvc.eval(a,b,f);
            return gcpu.vsame(v2,v1);
        }
    }
}