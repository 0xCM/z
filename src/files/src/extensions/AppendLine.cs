//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using static sys;

    partial class XTend
    {
        [Op]
        public static bool ReadLine(this StringReader src, uint number, out TextLine dst)
        {
            var data = src.ReadLine();
            if(data == null)
            {
                dst = TextLine.Empty;
                return false;
            }
            else
            {
                dst = new TextLine(number, data);
                return true;
            }
        }

        [MethodImpl(Inline)]
        public static void AppendLineFormat(this StreamWriter dst, string pattern, params object[] args)
            => dst.WriteLine(string.Format(pattern,args));

        [MethodImpl(Inline)]
        public static void AppendFormat(this StreamWriter dst, string pattern, params object[] args)
            => dst.Write(string.Format(pattern,args));

        [MethodImpl(Inline)]
        public static void AppendLine(this StreamWriter dst)
            => dst.WriteLine();

        [MethodImpl(Inline)]
        public static void AppendLine(this StreamWriter dst, object src)
            => dst.WriteLine(src);

        [MethodImpl(Inline)]
        public static void Append(this StreamWriter dst, object src)
        {
            if(src != null)
                dst.Write(src);
        }

        public static void AddRange<T>(this HashSet<T> dst, HashSet<T> src)
        {
            foreach(var item in src)
                dst.Add(item);
        }

        public static void AddRange<T>(this ConcurrentBag<T> dst, HashSet<T> src)
        {
            foreach(var item in src)
                dst.Add(item);
        }

        public static string Delimit<T>(this ReadOnlySpan<T> src, string sep, short pad = 0)
        {
            var dst = text.buffer();
            var slot = RP.slot(0,pad);
            for(var i=0; i<src.Length; i++)
            {
                if(i != 0)
                    dst.Append(sep);

                dst.AppendFormat(slot, skip(src,i));
            }
            return dst.Emit();
        }

        public static string Delimit<T>(this Span<T> src, string sep, short pad = 0)
            => (@readonly(src)).Delimit(sep,pad);


        public static string Delimit<T>(this Index<T> src, string sep, short pad = 0)
            => (src.View).Delimit(sep,pad);

        public static void AppendLines<T>(this ITextEmitter dst, ReadOnlySpan<T> src)
        {
            for(var i=0; i<src.Length; i++)
                dst.AppendLine(skip(src,i));
        }

        public static void AppendLines<T>(this ITextEmitter dst, Span<T> src)
        {
            for(var i=0; i<src.Length; i++)
                dst.AppendLine(skip(src,i));
        }

        public static void Indent<T>(this StreamWriter dst, uint margin, T src)
            => dst.Append(string.Format("{0}{1}", new string(Chars.Space, (int)margin), src));

        public static void IndentFormat<T>(this StreamWriter dst, uint margin, string format, T src)
            => dst.Indent(margin, string.Format(format,src));

        public static void IndentLine<T>(this StreamWriter dst, uint margin, T src)
            => dst.AppendLine(string.Format("{0}{1}", new string(Chars.Space, (int)margin), src));

        public static void IndentLineFormat(this StreamWriter dst, uint margin, string pattern, params object[] args)
            => dst.IndentLine(margin, string.Format(pattern, args));

        public static void Emit(this ITextBuffer src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            using var writer = dst.Writer(encoding);
            writer.Write(src.Emit());
        }

        public static void Pipe<T>(this FolderPath Db, ReadOnlySpan<T> src, string channel = null)
            where T : ITextual
        {
            var count = src.Length;
            if(count != 0)
            {
                var dst = Db + FS.file(string.Format("{0}.{1}", Timestamp.now(), channel ?? typeof(T).Name));
                using var writer = dst.AsciWriter();
                for(var i=0; i<count; i++)
                    writer.WriteLine(skip(src,i).Format());
            }
        }

        public static void Pipe<S,T>(this FolderPath root, ReadOnlySpan<S> src, Func<S,T> converter, string channel = null)
            where T : ITextual
        {
            var count = src.Length;
            if(count != 0)
            {
                var dst = root + FS.file(string.Format("{0}.{1}",Timestamp.now(), channel ?? typeof(T).Name));
                using var writer = dst.AsciWriter();
                for(var i=0; i<count; i++)
                    writer.WriteLine((converter(skip(src,i)).Format()));
            }
        }
    }
}