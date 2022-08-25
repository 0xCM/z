//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Tools
    {
        partial class Sqlite
        {
            public static SqlCmd import(FilePath src)
                => string.Format(".import {0} {1}", src.Format(PathSeparator.FS), identifier(null, src.FileName));

            public static Index<SqlCmd> import(FS.Files src)
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

            static Identifier identifier(Identifier? id, FS.FileName file)
                => id != null ? id.Value.Format() : file.WithoutExtension.Format();
        }
    }
}