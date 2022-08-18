//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    partial class text
    {
        [Op]
        public static ITextBuffer buffer()
            => new TextBuffer(new StringBuilder());

        [Op]
        public static ITextBuffer buffer(StringBuilder src)
            => new TextBuffer(src);

        [Op]
        public static ITextBuffer buffer(uint capacity)
            => new TextBuffer(capacity);

        public static ITextEmitter emitter()
            => TextFormat.emitter();
    }
}