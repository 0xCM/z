//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EventLevel : ITextual
    {
        readonly LogLevel LogLevel;

        [MethodImpl(Inline)]
        internal EventLevel(FlairKind src)
            => LogLevel = (LogLevel)src;

        [MethodImpl(Inline)]
        internal EventLevel(LogLevel src)
            => LogLevel = src;

        public string Format()
            => LogLevel.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator EventLevel(FlairKind src)
            => new EventLevel(src);

        [MethodImpl(Inline)]
        public static implicit operator EventLevel(LogLevel src)
            => new EventLevel(src);
    }
}