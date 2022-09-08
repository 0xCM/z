//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct JccInfo<K>
        where K : unmanaged
    {
        public readonly text7 Name;

        public readonly NativeSize Size;

        public readonly K Code;

        [MethodImpl(Inline)]
        public JccInfo(K code, text7 name, NativeSize size)
        {
            Name = name;
            Size = size;
            Code = code;
        }

        public byte Encoding
        {
            [MethodImpl(Inline)]
            get => u8(Code);
        }
    }
}