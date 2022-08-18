//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static ITextEmitter Emitter(this FS.FilePath dst, bool append = false)
            => dst.Writer(append).Emitter();

        public static ITextEmitter Emitter(this FS.FilePath dst, TextEncodingKind encoding, bool append = false)
            => dst.Writer(encoding, append).Emitter();

        public static ITextEmitter Emitter(this FS.FilePath dst, Encoding encoding, bool append = false)
            => dst.Writer(encoding, append).Emitter();

        public static ITextEmitter AsciEmitter(this FS.FilePath dst, bool append = false)
            => dst.AsciWriter(append).Emitter();

        public static ITextEmitter UnicodeEmitter(this FS.FilePath dst, bool append = false)
            => dst.UnicodeWriter(append).Emitter();

        public static ITextEmitter Utf8Emitter(this FS.FilePath dst, bool append = false)
            => dst.Utf8Writer(append).Emitter();
    }
}