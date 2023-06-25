//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XFs
    {
        public static FilePath ToFilePath(this FileUri src)
            => new FilePath(src.LocalPath);
        
        public static FileName FileName(this FileUri src)
            => src.ToFilePath().FileName;
        
        public static FolderPath FolderPath(this FileUri src)
            => src.ToFilePath().FolderPath;

        public static FolderName FolderName(this FileUri src)
            => src.ToFilePath().FolderName;

        public static FileExt Extension(this FileUri src)
            => src.ToFilePath().Ext;

        public static FileKind FileKind(this FileUri src)
            => src.ToFilePath().FileKind();

        public static ITextEmitter Emitter(this FileUri dst, TextEncodingKind encoding, bool append = false)
            => dst.Writer(encoding, append).Emitter();

        public static ITextEmitter Emitter(this FileUri dst, Encoding encoding, bool append = false)
            => dst.Writer(encoding, append).Emitter();

        public static ITextEmitter AsciEmitter(this FileUri dst, bool append = false)
            => dst.AsciWriter(append).Emitter();

        public static ITextEmitter Utf8Emitter(this FileUri dst, bool append = false)
            => dst.Utf8Writer(append).Emitter();

        public static FileInfo FileInfo(this FileUri src)
            => FS.info(src);

        // public static Index<string> ReadLines(this FileUri src, bool skipBlank = false)
        //     => FS.readtext(src, TextEncodingKind.Utf8, skipBlank);

        // [Op]
        // public static Index<string> ReadLines(this FileUri src, TextEncodingKind encoding, bool skipBlank = false)
        //     => FS.readtext(src, encoding, skipBlank);

        // public static void ReadLines(this FileUri src, Func<TextLine,bool> dst, TextEncodingKind encoding = TextEncodingKind.Utf8, bool skipBlank = true)
        //     => FS.readlines(src, dst, encoding, skipBlank);

        [Op]
        public static Index<TextLine> ReadNumberedLines(this FileUri src, bool skipBlank = false)
            => FS.readlines(src, skipBlank);

        public static Index<TextLine> ReadNumberedLines(this FileUri src, TextEncodingKind encoding, bool skipBlank = false)
            => FS.readlines(src,encoding, skipBlank);
    }
}