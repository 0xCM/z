//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;
    using static ByteBlocks;

    [ApiHost("asm.protos.deposits")]
    public readonly struct AsmDeposits
    {
        [Op]
        public void deposit(Span<byte> dst, byte a0, byte a1)
        {
            seek(dst,0) = a0;
            seek(dst,1) = a1;
        }

        [Op]
        public void deposit(Span<Cell128> dst, Cell128 a0, Cell128 a1)
        {
            seek(dst,0) = a0;
            seek(dst,1) = a1;

        }

        [Op]
        public void deposit(Span<Cell256> dst, Cell256 a0, Cell256 a1)
        {
            seek(dst,0) = a0;
            seek(dst,1) = a1;
        }

        [Op]
        public void deposit(Span<Cell512> dst, Cell512 a0, Cell512 a1)
        {
            seek(dst,0) = a0;
            seek(dst,1) = a1;
        }

        [Op]
        public void deposit(Span<Cell512> dst, Cell512 a0, Cell512 a1, Cell512 a2)
        {
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
        }

        [Op]
        public void deposit(Span<Cell512> dst, Cell512 a0, Cell512 a1, Cell512 a2, Cell512 a3)
        {
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            seek(dst,3) = a3;
        }

        [Op]
        public void deposit(Span<Cell512> dst, Cell512 a0, Cell512 a1, Cell512 a2, Cell512 a3, Cell512 a4)
        {
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            seek(dst,3) = a3;
            seek(dst,4) = a4;
        }

        [Op]
        public void deposit_runtime(Span<Cell256> dst, Cell256 a0, Cell256 a1, Cell256 a2, Cell256 a3, Cell256 a4)
        {
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            seek(dst,3) = a3;
            seek(dst,4) = a4;
        }

        [Op]
        public unsafe void deposit_intrinsic(Span<Cell256> dst, Cell256 a0, Cell256 a1, Cell256 a2, Cell256 a3, Cell256 a4)
        {
            vcpu.vstore(vcpu.vload(w256, first(bytes(a0))), ref first(bytes(seek(dst,0))));
            vcpu.vstore(vcpu.vload(w256, first(bytes(a1))), ref first(bytes(seek(dst,1))));
            vcpu.vstore(vcpu.vload(w256, first(bytes(a2))), ref first(bytes(seek(dst,2))));
            vcpu.vstore(vcpu.vload(w256, first(bytes(a3))), ref first(bytes(seek(dst,3))));
            vcpu.vstore(vcpu.vload(w256, first(bytes(a4))), ref first(bytes(seek(dst,4))));
        }

        [Op]
        public void deposit(Span<ByteBlock64> dst, ByteBlock64 a0, ByteBlock64 a1)
        {
            seek(dst,0) = a0;
            seek(dst,1) = a1;
        }

        [Op]
        public void deposit(Span<ByteBlock128> dst, ByteBlock128 a0, ByteBlock128 a1)
        {
            seek(dst,0) = a0;
            seek(dst,1) = a1;
        }

        [Op]
        public void deposit(Span<byte> dst, in byte a0, in byte a1)
        {
            seek(dst,0) = a0;
            seek(dst,1) = a1;
        }

        [Op]
        public void deposit(Span<byte> dst, byte a0, byte a1, byte a2)
        {
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
        }

        [Op]
        public void deposit(Span<byte> dst, in byte a0, in byte a1, in byte a2)
        {
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
        }

        [Op]
        public void deposit(Span<byte> dst, byte a0, byte a1, byte a2, byte a3)
        {
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            seek(dst,3) = a3;
        }


        [Op]
        public void deposit(Span<byte> dst, byte a0, byte a1, byte a2, byte a3, byte a4)
        {
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            seek(dst,3) = a3;
            seek(dst,4) = a4;
        }


        [Op]
        public void deposit(Span<ushort> dst, ushort a0, ushort a1, ushort a2, ushort a3, ushort a4, ushort a5, ushort a6)
        {
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            seek(dst,3) = a3;
            seek(dst,4) = a4;
            seek(dst,5) = a5;
            seek(dst,6) = a6;
        }

        [Op]
        public void deposit(ushort a0, ushort a1, ushort a2, ushort a3, ushort a4, ushort a5, ushort a6, Span<ushort> dst)
        {
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            seek(dst,3) = a3;
            seek(dst,4) = a4;
            seek(dst,5) = a5;
            seek(dst,6) = a6;
        }

        [Op]
        public void deposit(Span<ulong> dst, ulong a0, ulong a1, ulong a2)
        {
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
        }

        [Op]
        public void deposit(Span<ulong> dst, ulong a0, ulong a1, ulong a2, ulong a3, ulong a4)
        {
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            seek(dst,3) = a3;
            seek(dst,4) = a4;
        }

        [Op]
        public void deposit(Span<ulong> dst, ulong a0, ulong a1, ulong a2, ulong a3, ulong a4, ulong a5, ulong a6)
        {
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            seek(dst,3) = a3;
            seek(dst,4) = a4;
            seek(dst,5) = a5;
            seek(dst,6) = a6;
        }

        [Op]
        public void deposit(Span<ulong> dst, in ulong a0, in ulong a1, in ulong a2, in ulong a3, in ulong a4, in ulong a5, in ulong a6)
        {
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            seek(dst,3) = a3;
            seek(dst,4) = a4;
            seek(dst,5) = a5;
            seek(dst,6) = a6;
        }

        [Op]
        public void deposit(ref ulong dst, in ulong a0, in ulong a1, in ulong a2, in ulong a3, in ulong a4, in ulong a5, in ulong a6)
        {
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            seek(dst,3) = a3;
            seek(dst,4) = a4;
            seek(dst,5) = a5;
            seek(dst,6) = a6;
        }

        [Op]
        public void io(in ulong a0, out ulong b0, in ulong a1, out ulong b1, in ulong a2, out ulong b2, in ulong a3, out ulong b3)
        {
            b0 = a0;
            b1 = a1;
            b2 = a2;
            b3 = a3;
        }
    }    
}