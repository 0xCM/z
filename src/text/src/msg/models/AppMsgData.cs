//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    public readonly record struct AppMsgData
    {
        /// <summary>
        /// The message payload
        /// </summary>
        public readonly object Content;

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
        public readonly EventOrigin Source;

        [MethodImpl(Inline)]
        public AppMsgData(object content, string pattern, LogLevel kind, FlairKind color, EventOrigin origin)
        {
            Content = content;
            Pattern = pattern;
            Kind = kind;
            Flair = color;
            Source = origin;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(Pattern, Content);

        public override string ToString()
            => Format();
        public static AppMsgData Empty
            => new AppMsgData(EmptyString, "{0}", 0, 0, AppMsgSource.Empty);
    }
}