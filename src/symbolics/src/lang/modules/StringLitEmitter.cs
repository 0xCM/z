//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static sys;

    public class StringLitEmitter : AppService<StringLitEmitter>
    {
        public void Emit(string name, ReadOnlySpan<char> src, FilePath dst)
        {
            var emitting = Channel.EmittingFile(dst);
            using var writer = dst.AsciWriter();
            writer.Write(fielddecl(name));
            begin(writer);
            write(writer,src);
            end(writer);

            Channel.EmittedFile(emitting, 1);
        }

        public void Emit(string name, ReadOnlySpan<char> src, StreamWriter dst)
        {
            dst.Write(fielddecl(name));
            begin(dst);
            write(dst,src);
            end(dst);
        }

        static void begin(StreamWriter writer)
            => writer.Write('\"');

        static void end(StreamWriter writer)
            => writer.WriteLine("\";");

        static string structdecl(string name)
            => string.Format("public readonly struct {0}", name);

        static string fielddecl(string name)
            => string.Format("    public const string {0} = ", name);

        static void write(StreamWriter writer, ReadOnlySpan<char> src)
        {
            var i=0;
            var count = src.Length;
            while(i++<count)
                write(writer,skip(src,i));
        }

        static void write(StreamWriter writer, char c)
        {
            if(c == 0)
            {
                writer.Write('\\');
                writer.Write('0');
            }
            else
                writer.Write((char)c);
        }

        public void Emit(string name, ReadOnlySpan<string> src, FilePath dst)
        {
            var emitting = Channel.EmittingFile(dst);
            using var writer = dst.AsciWriter();

            writer.WriteLine(structdecl(name));
            writer.WriteLine("{");

            writer.Write(fielddecl("Data"));
            var count = src.Length;
            begin(writer);
            for(var i=0; i<count; i++)
            {
                var s = span(skip(src,i));
                for(var j=0; j<s.Length; j++)
                    writer.Write(skip(s,j));
            }
            end(writer);

            writer.WriteLine("}");

            Channel.EmittedFile(emitting, count);
        }
    }
}