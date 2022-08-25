//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static CsPatterns;

    public class SymbolFactories : WfSvc<SymbolFactories>
    {
        public void Emit(string ns, string name, ReadOnlySpan<Type> enums, FilePath dst)
        {
            var flow = EmittingFile(dst);
            var buffer = text.buffer();
            var margin = 0u;
            buffer.IndentLine(margin, CsPatterns.NamespaceDecl(ns));
            buffer.IndentLine(margin, Open());
            var count = Emit(margin + 4, name, enums, buffer);
            buffer.IndentLine(margin, Close());
            using var writer = dst.Writer();
            writer.WriteLine(buffer.Emit());
            EmittedFile(flow,count);
        }

        public uint Emit(uint margin, string name, ReadOnlySpan<Type> enums, ITextBuffer dst)
        {
            dst.IndentLine(margin, PublicReadonlyStruct(name));
            dst.IndentLine(margin, Open());
            margin +=4;
            var counter = 0u;
            for(var i=0; i<enums.Length; i++)
            {
                ref readonly var type = ref skip(enums,i);
                var adapted = ClrEnumAdapter.adapt(type);
                counter += Emit(margin, adapted, dst);
            }
            margin -=4;
            dst.IndentLine(margin, Close());
            return counter;
        }

        public uint Emit(uint margin, ClrEnumAdapter src, ITextBuffer dst)
        {
            var counter = 0u;
            var members = src.Members;
            for(var j=0; j<members.Length; j++)
            {
                ref readonly var member = ref skip(members,j);
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