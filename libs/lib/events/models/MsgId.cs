//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct MsgId : ITextual
    {
        const string RenderPattern = "{0} | {1,-18}";

        public MsgLevel Level {get;}

        public Timestamp Ts {get;}

        [MethodImpl(Inline)]
        public MsgId(MsgLevel level, Timestamp ts)
        {
            Level = level;
            Ts = ts;
        }

        public string Format()
            => string.Format(RenderPattern, Ts, Level);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator MsgId((MsgLevel level, Timestamp ts) src)
            => new MsgId(src.level, src.ts);
    }
}