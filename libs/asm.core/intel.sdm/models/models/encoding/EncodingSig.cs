//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    partial struct SdmModels
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public readonly struct EncodingSig
        {
            public EncodingClass Class {get;}

            public byte Kind {get;}

            [MethodImpl(Inline)]
            public EncodingSig(EncodingClass @class, byte kind)
            {
                Class = @class;
                Kind = kind;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Class == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Class != 0;
            }

            public static EncodingSig Empty => default;
        }
    }
}