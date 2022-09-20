//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct EventLevel
    {
        readonly LogLevel LogLevel;

        [MethodImpl(Inline)]
        public EventLevel(FlairKind src)
            => LogLevel = (LogLevel)src;

        [MethodImpl(Inline)]
        public EventLevel(LogLevel src)
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