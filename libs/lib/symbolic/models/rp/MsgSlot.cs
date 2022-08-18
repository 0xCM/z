//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct MsgSlot : ITextual
    {
        [MethodImpl(Inline)]
        public static MsgSlot define(int index)
            => new MsgSlot((byte)index);

        public byte Index {get;}

        public char LeftFence {get;}

        public char RightFence {get;}

        [MethodImpl(Inline)]
        public MsgSlot(byte index)
        {
            Index = index;
            LeftFence = Chars.Lt;
            RightFence = Chars.Gt;
        }

        public string Format()
            => $"{LeftFence}" + "{" + $"{Index}" +  "}" + $"{RightFence}";

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator MsgSlot(int index)
            => new MsgSlot((byte)index);
    }
}