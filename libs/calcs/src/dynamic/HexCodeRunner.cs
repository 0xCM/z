//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public unsafe class HexCodeRunner : IDisposable
    {
        public static unsafe void slots(WfEmit channel)
        {
            var slots = ClrDynamic.slots(typeof(SlotBox64));
            var box = new SlotBox64();
            var code = GetArg;
            for(byte i=0; i<slots.Length; i++)
            {
                ref readonly var slot = ref slots[i];
                var pDst = slot.Address.Pointer<byte>();
                var length = code.Length;
                for(var j=0; j<length; j++)
                    seek(pDst,j) = skip(code,j);

                ulong Dispatch(byte index, ulong a)
                    => index switch
                    {
                        0 => box.f0(a*2),
                        1 => box.f1(a*3),
                        2 => box.f2(a*4),
                        3 => box.f3(a*5),
                        _ => 0
                    };

                var @return = Dispatch(i,i);
                channel.Row(string.Format("{0}: {1}", i, @return));
            }
        }

        readonly NativeBuffer CodeBuffer;

        readonly WfEmit Channel;

        public HexCodeRunner(IWfRuntime wf, WfEmit channel)
        {
            CodeBuffer = memory.native(Pow2.T10);
            Channel = channel;
        }

        public void RunAlgs()
        {
            AlgDynamic.runA(result => Channel.Row(result));
            AlgDynamic.runB(result => Channel.Row(result));
            AlgDynamic.runC(result => Channel.Row(result));
            ExecDemo();
        }

        public void Dispose()
        {
            CodeBuffer.Dispose();
        }

        uint LoadBuffer(uint offset, ReadOnlySpan<byte> src)
        {
            var i0 = offset;
            var dst = CodeBuffer.Edit;
            var j=offset;
            for(var i=0; i<src.Length; i++)
                seek(dst, offset++) = skip(src,i);
            return offset - i0;
        }

        public void ExecDemo()
        {
            LoadBuffer(0,min64u_64u_64u);
            var pCode = CodeBuffer.BaseAddress.Pointer<byte>();
            var name = "min64u";
            var f = BinaryOpDynamics.create<ulong>(name, pCode);
            var a = 4ul;
            var b = 12ul;
            var c = f(a,b);
            Channel.Row(string.Format("{0}({1},{2})={3}", name, a, b, c));
        }

        readonly struct SlotBox64
        {
            readonly ulong A;

            [MethodImpl(NotInline)]
            public ulong f0(ulong a)
                => ulong.MaxValue;

            [MethodImpl(NotInline)]
            public ulong f1(ulong a0)
                => ulong.MaxValue;

            [MethodImpl(NotInline)]
            public ulong f2(ulong a0)
                => ulong.MaxValue;

            [MethodImpl(NotInline)]
            public ulong f3(ulong a0)
                => ulong.MaxValue;
        }

        // mov rax,rcx -> ret
        static ReadOnlySpan<byte> GetThis => new byte[]{0x48, 0x8b, 0xc1, 0xc3};

        // mov rax,rdx -> ret
        static ReadOnlySpan<byte> GetArg => new byte[]{0x48, 0x8b, 0xc2, 0xc3};

        static ReadOnlySpan<byte> JmpRdx => new byte[]{0xff, 0xe2};

        static ReadOnlySpan<byte> min64u_64u_64u
            => new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x3b,0xca,0x72,0x04,0x48,0x8b,0xc2,0xc3,0x48,0x8b,0xc1,0xc3};
    }
}