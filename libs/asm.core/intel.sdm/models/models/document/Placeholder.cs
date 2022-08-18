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
        /// <summary>
        /// Represents a sequence of placeholder markers, each of the form ' .'
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct Placeholder
        {
            public const char Space = ' ';

            public const char Dot = '.';

            public char A;

            public char B;

            public byte Count;

            [MethodImpl(Inline)]
            public Placeholder(char a, char b, byte count)
            {
                A = a;
                B = b;
                Count = count;
            }

            public byte Length
            {
                [MethodImpl(Inline)]
                get => (byte)(Count * 2);
            }

            public ByteSize Size
            {
                [MethodImpl(Inline)]
                get => Length;
            }
        }
    }
}