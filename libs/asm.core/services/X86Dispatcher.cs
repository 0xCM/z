//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static AsmPrefixCodes;

    using Operands;

    [Free]
    public class X86Dispatcher
    {
        Index<MemoryRange> Trampolines;

        Index<Cell128> Payloads;

        Index<MemoryAddress> Receivers;

        public X86Dispatcher(uint slots)
        {
            Trampolines = alloc<MemoryRange>(slots);
            Payloads = alloc<Cell128>(slots);
            Receivers = alloc<MemoryAddress>(slots);
            Receivers.First = ClrJit.jit(GetType().Method(nameof(Receive64u)));
        }

        public ref readonly MemoryAddress DefaultReceiver
        {
            [MethodImpl(Inline)]
            get => ref Receivers.First;
        }
        public bool Create<T>(byte slot)
            where T : unmanaged
        {
             var stub = new JmpStub<T>();
            Trampolines[slot] = stub.Init();
            return Trampolines[slot].IsNonEmpty;
        }

        static void Receive64u(ulong a0)
            => term.print($"Received {a0}");

        // REX.W + B8+ rd io | MOV r64, imm64           | OI    | Valid       | N.E.            | Move imm64 to r64.                                             |
        [MethodImpl(Inline), Op]
        static byte mov(r64 r, Imm64 imm, Span<byte> dst)
            => AsmBytes.encode(RexW, (Hex8)(0xb8 + (byte)r.Index), imm, dst);

        [Op]
        public ref readonly Cell128 Encode(byte slot, MemoryAddress target)
        {
            var address = Trampolines[slot];
            ref var payload = ref Payloads[slot];
            var storage = Cell128.Empty;
            var buffer = storage.Bytes;
            var size = mov(AsmRegOps.rcx, target, buffer);
            var dst = payload.Bytes;
            var j=0;
            for(var i=0; i<size; i++)
                seek(dst,j++) = skip(buffer,i);
            return ref payload;
        }

        [Op]
        public ref readonly Cell128 Encode(byte slot)
            => ref Encode(slot, Receivers[slot]);
    }
}