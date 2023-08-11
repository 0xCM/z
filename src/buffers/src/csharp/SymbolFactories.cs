//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static CsPatterns;

    public class SymbolFactories : Channeled<SymbolFactories>
    {
        public Index<Type> LoadTypes(FilePath src)
        {
            var running = Channel.Running(string.Format("Loading enum types from {0}", src.ToUri()));
            var buffer = list<Type>();
            using var reader = src.Utf8LineReader();
            while(reader.Next(out var line))
            {
                if(line.IsEmpty)
                    continue;

                var name = line.Content.Trim();
                var type = Type.GetType(name);
                if(type != null)
                    buffer.Add(type);
                else
                    Channel.Warn(string.Format("Unable to load {0}", name));
            }

            var dst = buffer.ToArray();
            Channel.Ran(running, string.Format("Loaded {0} enum types from {1}", dst.Length, src.ToUri()));
            return dst;
        }

        public void Emit(string ns, string name, ReadOnlySpan<Type> enums, FilePath dst)
        {
            var flow = Channel.EmittingFile(dst);
            var buffer = text.buffer();
            var margin = 0u;
            buffer.IndentLine(margin, CsPatterns.NamespaceDecl(ns));
            buffer.IndentLine(margin, Open());
            var count = Emit(margin + 4, name, enums, buffer);
            buffer.IndentLine(margin, Close());
            using var writer = dst.Writer();
            writer.WriteLine(buffer.Emit());
            Channel.EmittedFile(flow,count);
        }

        public static uint Emit(uint margin, string name, ReadOnlySpan<Type> enums, ITextBuffer dst)
        {
            dst.IndentLine(margin, PublicReadonlyStruct(name));
            dst.IndentLine(margin, Open());
            margin +=4;
            var counter = 0u;
            for(var i=0; i<enums.Length; i++)
                counter += Emit(margin, ClrEnumType.from(skip(enums,i)), dst);
            margin -=4;
            dst.IndentLine(margin, Close());
            return counter;
        }

        public static uint Emit(uint margin, ClrEnumType src, ITextBuffer dst)
        {
            var counter = 0u;
            var members = src.Members;
            for(var j=0; j<members.Length; j++)
            {
                ref readonly var member = ref members[j];
                var name = member.Name;
                var tag = member.Definition.Tag<SymbolAttribute>();
                var symbol = text.ifempty(tag.MapValueOrDefault(t => t.Symbol, name),name);
                var func = PublicOneLineFunc("string", name, Empty(), text.dquote(symbol));
                dst.IndentLine(margin, func);
                dst.AppendLine();
                counter++;
            }
            return counter;
        }
    }
}