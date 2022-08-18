//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct JccInfo
    {
        public readonly JccKind Kind;

        public readonly text7 Name;

        public readonly NativeSize Size;

        public readonly byte Code;

        [MethodImpl(Inline)]
        public JccInfo(Jcc8Code code, text7 name)
        {
            Code = (byte)code;
            Name = name;
            Kind = JccKind.Jcc8;
            Size = NativeSizeCode.W8;
        }

        [MethodImpl(Inline)]
        public JccInfo(Jcc8AltCode code, text7 name)
        {
            Code = (byte)code;
            Name = name;
            Kind = JccKind.Jcc8Alt;
            Size = NativeSizeCode.W8;
        }

        [MethodImpl(Inline)]
        public JccInfo(Jcc32Code code, text7 name)
        {
            Code = (byte)code;
            Name = name;
            Kind = JccKind.Jcc32;
            Size = NativeSizeCode.W32;
        }

        [MethodImpl(Inline)]
        public JccInfo(Jcc32AltCode code, text7 name)
        {
            Code = (byte)code;
            Name = name;
            Kind = JccKind.Jcc32Alt;
            Size = NativeSizeCode.W32;
        }
    }
}