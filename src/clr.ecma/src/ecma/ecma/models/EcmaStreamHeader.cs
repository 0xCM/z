//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public record struct EcmaStreamHeader
    {
        public Hex32 Offset;

        public uint Size;

        public string Name;

        public EcmaStreamKind StreamKind;

        public string Format()
            => string.Format("{0}:{1,-8}", Offset, (ByteSize)Size);
        
        public override string ToString()
            => Format();
    }
}