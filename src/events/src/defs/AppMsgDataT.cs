//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct AppMsgData<T> : IExpr
    {
        /// <summary>
        /// The message payload
        /// </summary>
        public readonly T Content;

        /// <summary>
        /// Defines a content render pattern, if applicable
        /// </summary>
        public readonly string Pattern;

        /// <summary>
        /// The message classification
        /// </summary>
        public readonly LogLevel Kind;

        /// <summary>
        /// The message foreground color when rendered for display
        /// </summary>
        public readonly FlairKind Flair;

        /// <summary>
        /// Specifies the emitting executable part
        /// </summary>
        public readonly EventOrigin Origin;

        [MethodImpl(Inline)]
        public AppMsgData(T content, string pattern, LogLevel kind, FlairKind flair, EventOrigin origin)
        {
            Content = content;
            Pattern = pattern;
            Kind = kind;
            Flair = flair;
            Origin = origin;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => sys.empty($"{Content}");
        }

        public AppMsgData Untyped
        {
            [MethodImpl(Inline)]
            get => new AppMsgData(Content, Pattern, Kind, Flair, Origin);
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(Pattern, Content);

        [MethodImpl(Inline)]
        public static implicit operator AppMsgData(AppMsgData<T> src)
            => src.Untyped;
    }
}