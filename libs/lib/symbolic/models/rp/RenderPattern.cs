//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a pattern to service as a projection domain for render patterns
    /// </summary>
    /// <remarks>
    /// The template may include any character sequence that may be tokenzied by fence-matching on '{' and '}' with corresponding escape-matching when needed
    /// </remarns>
    public readonly struct RenderTemplate : IRenderTemplate
    {
        public string Content {get;}

        [MethodImpl(Inline)]
        public RenderTemplate(string src)
            => Content = src;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => string.IsNullOrEmpty(Content);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public override string ToString()
            => Content;

        public static implicit operator RenderTemplate(string src)
            => new RenderTemplate(src);

        public static implicit operator string(RenderTemplate src)
            => src.Content;
    }
}