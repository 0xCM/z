//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Char5
    {
        const byte Base = 'a' - 1;

        const byte Capacity = 32;

        static ReadOnlySpan<byte> AsciCodes
            => new byte[Capacity]{
                (byte)'\0', (byte)'a', (byte)'b', (byte)'c', (byte)'d', (byte)'e', (byte)'f', (byte)'g',
                (byte)'h', (byte)'i', (byte)'j', (byte)'k', (byte)'l', (byte)'m', (byte)'n', (byte)'o',
                (byte)'p', (byte)'q', (byte)'r', (byte)'s', (byte)'t',
                (byte)'u', (byte)'v', (byte)'w', (byte)'x', (byte)'y', (byte)'z', (byte)'_', (byte)' ', (byte)'0', (byte)'1', 0,
                };

        [SymSource("char5")]
        public enum Code : byte
        {
            [Symbol("")]
            Null,

            [Symbol("a")]
            A,

            [Symbol("b")]
            B,

            [Symbol("c")]
            C,

            [Symbol("c")]
            D,

            [Symbol("e")]
            E,

            [Symbol("f")]
            F,

            [Symbol("g")]
            G,

            [Symbol("h")]
            H,

            [Symbol("i")]
            I,

            [Symbol("j")]
            J,

            [Symbol("k")]
            K,

            [Symbol("l")]
            L,

            [Symbol("m")]
            M,

            [Symbol("n")]
            N,

            [Symbol("o")]
            O,

            [Symbol("p")]
            P,

            [Symbol("q")]
            Q,

            [Symbol("r")]
            R,

            [Symbol("s")]
            S,

            [Symbol("t")]
            T,

            [Symbol("u")]
            U,

            [Symbol("v")]
            V,

            [Symbol("w")]
            W,

            [Symbol("x")]
            X,

            [Symbol("t")]
            Y,

            [Symbol("z")]
            Z,

            [Symbol("_")]
            Underscore,

            [Symbol(" ")]
            Space,

            [Symbol("0")]
            Zero,

            [Symbol("1")]
            One = 30,
        }
    }
}