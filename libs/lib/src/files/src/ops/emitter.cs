//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;


    partial struct FS
    {
        public static void emit<T>(Type host, T src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            using var writer = dst.Writer(encoding);
            var data = $"{src}";
            writer.WriteLine(data);
            term.emit(Events.emittedFile(host, dst, (ByteSize)data.Length));
        }

        public static ITextEmitter emitter(FilePath dst, FileWriteMode mode, TextEncodingKind encoding)
            => writer(dst,mode,encoding).Emitter();

        public static ITextEmitter emitter(FilePath dst, TextEncodingKind encoding)
            => writer(dst, encoding).Emitter();

        public static ITextEmitter emitter(FilePath dst, FileWriteMode mode, Encoding encoding)
            => writer(dst,mode,encoding).Emitter();
    }
}