//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class Sqlite
    {
        public readonly record struct SqlCmd
        {
            public readonly TextBlock Content;

            [MethodImpl(Inline)]
            public SqlCmd(string content)
            {
                Content = content;
            }

            [MethodImpl(Inline)]
            public static implicit operator SqlCmd(string src)
                => new SqlCmd(src);
        }

        [Cmd(CmdName)]
        public record struct ImportCmd : IApiCmd<ImportCmd>
        {
            const string CmdName=".import";

            public FilePath Source;

            public TableId Target;

            [MethodImpl(Inline)]
            public ImportCmd(FilePath src, TableId dst)
            {
                Source = src;
                Target = dst;
            }
        
            public string Format()
                => $"{CmdName} {Source.Format(PathSeparator.FS)} {Target}";

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator SqlCmd(ImportCmd src)
                => src.Format();
        }

        public static SqlCmd import(FilePath src)
            => string.Format(".import {0} {1}", src.Format(PathSeparator.FS), identifier(null, src.FileName));

        public static Index<SqlCmd> import(Files src)
        {
            var count = src.Length;
            var buffer = sys.alloc<SqlCmd>(count);
            if(count != 0)
            {
                ref var dst = ref first(buffer);
                var view = src.View;
                for(var i=0; i<count; i++)
                    seek(dst,i) = import(skip(view,i));
            }
            return buffer;
        }

        public static void render(SqlCmd src, ITextEmitter dst)
            => dst.AppendLine(src.Content);

        public static void render(ReadOnlySpan<SqlCmd> src, ITextEmitter dst)
            => iter(src, cmd => render(cmd,dst));

        static Identifier identifier(Identifier? id, FileName file)
            => id != null ? id.Value.Format() : file.WithoutExtension.Format();
    }
}