//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct JmpStub
    {
        readonly byte OpCode;

        readonly int DispData;

        readonly byte SizeData;

        public readonly MemoryAddress Source;

        public readonly MemoryAddress Target;

        public readonly AsmHexCode Encoding;

        [MethodImpl(Inline)]
        public JmpStub(byte opcode, int disp, byte size, MemoryAddress src, MemoryAddress dst, AsmHexCode encoding)
        {
            OpCode = opcode;
            DispData = disp;
            SizeData = size;
            Source = src;
            Target = dst;
            Encoding = encoding;
        }

        public Disp32 Disp
        {
            [MethodImpl(Inline)]
            get => DispData;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => SizeData;
        }
    }
}