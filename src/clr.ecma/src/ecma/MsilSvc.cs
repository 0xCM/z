//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class MsilSvc : WfSvc<MsilSvc>
    {
        const string CommentToken = "// ";

        const string CilCodeHeader = CommentToken + "Id:{0,-12} Uri:{1}";

        const string CilSigHeader = CommentToken + "CliSig:[{0}] = [{1}]";

        const string CilEncodedHeader = CommentToken + "Encoded[{0}] = [{1}]";

        const string CilPageBreak = CommentToken + RpOps.PageBreak120;

        ILVisualizer IlViz;

        public MsilSvc()
        {
            IlViz = ILVisualizer.service();
        }

        public Index<MsilCapture> LoadCaptured(IApiPack src)
        {
            var input = src.Files(FileKind.Csv);
            var count = input.Length;
            var dst = Lists.list<MsilCapture>();
            var row = default(MsilCapture);
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref input[i];
                using var reader = path.Utf8Reader();
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if(parse(line, out row))
                    {
                        dst.Add(row);
                    }
                    else
                    {
                        Wf.Warn($"The content {line} could not be parsed");
                    }
                }
            }
            return dst.Emit();
        }

        public Files MetadataFiles(IApiPack src)
            => src.Metadata().Files(FileKind.MsilDat);

        public Index<MsilRow> LoadMetadata(FilePath src)
        {
            var flow = Wf.Running(src.ToUri());
            var dst = Lists.list<MsilRow>();
            using var reader = src.Utf8Reader();
            var fields = reader.ReadLine().SplitClean(Chars.Pipe);
            if(fields.Length != MsilRow.FieldCount)
            {
                Wf.Error(Tables.FieldCountMismatch.Format(MsilRow.FieldCount, fields.Length));
                return Index<MsilRow>.Empty;
            }

            var row = default(MsilRow);
            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var outcome = parse(line, out row);
                if(outcome)
                    dst.Add(row);
                else
                    Wf.Warn(line);
            }

            Wf.Ran(flow, dst.Count);
            return dst.Emit();
        }

        public void EmitCode(ReadOnlySpan<MsilRow> src, FilePath dst)
        {
            var count = src.Length;
            if(count == 0)
                return;

            var builder = text.build();
            var flow = Wf.EmittingFile(dst);
            using var writer = dst.Writer();
            for(var i=0; i<count; i++)
            {
                builder.Clear();
                ref readonly var row = ref skip(src,i);
                if(i != 0)
                    writer.WriteLine(CilPageBreak);

                writer.WriteLine("// Token:{0,-16} Rva:{1,-12} | Size:{2,-8} | Method:{3}:{4}", row.Token, row.MethodRva, row.BodySize, row.ImageName, row.MethodName);
                writer.WriteLine(CilPageBreak);
                IlViz.DumpMethod(row.MaxStack, row.Code.View, builder);
                writer.WriteLine(builder.ToString());
                writer.WriteLine();

            }

            Wf.EmittedFile(flow, count);
        }

        public void EmitCode(Index<MemberCodeBlock> src, FilePath path)
        {
            var count = src.Count;
            var builder = text.build();
            if(count != 0)
            {
                var flow = Wf.EmittingFile(path);
                var view = src.View;
                using var dst = path.Writer();
                for(var i=0u; i<count; i++)
                {
                    ref readonly var code = ref skip(view,i);
                    var member = code.Member;
                    var cil = member.Msil;
                    var sig = code.CliSig.Data;
                    var bytes = cil.CliCode;
                    var _sig = member.Method.DisplaySig();
                    dst.AppendLine(CilPageBreak);
                    dst.AppendLineFormat("// {0}", member.Method.DisplaySig());
                    dst.AppendLine(string.Format(CilCodeHeader, member.Token, member.OpUri));
                    dst.AppendLine(string.Format(CilSigHeader, sig.Length, sig.Format()));
                    dst.AppendLine(string.Format(CilEncodedHeader, bytes.Length, bytes.Format()));
                    dst.AppendLine(CommentToken + member.Metadata.DisplaySig);
                    builder.Clear();
                    IlViz.DumpILBlock(bytes, bytes.Length, builder);
                    dst.AppendLine("{");
                    dst.Write(builder.ToString());
                    dst.AppendLine("}");
                    dst.AppendLine();
                }

                Wf.EmittedFile(flow, count);
            }
        }

        public void RenderCode(ApiMsil src, ITextEmitter dst)
        {
            var bytes = src.CliCode;
            var sig = src.CliSig.Data;
            dst.AppendLine(CilPageBreak);
            dst.AppendLineFormat("// {0}", src.DisplaySig);
            dst.AppendLineFormat("// {0}", src.Uri);
            dst.AppendLineFormat("// {0}", src.Token);
            dst.AppendLine(string.Format(CilSigHeader, sig.Length, sig.Format()));
            dst.AppendLine(string.Format(CilEncodedHeader, bytes.Length, bytes.Format()));
            dst.AppendLine(CilPageBreak);
            dst.AppendLine("{");
            IlViz.DumpILBlock(bytes, bytes.Length, dst.ToStringBuilder());
            dst.AppendLine("}");
            dst.AppendLine();
        }

        public Index<MsilCapture> EmitData(Index<MemberCodeBlock> src, FilePath dst)
        {
            var count = src.Count;
            var buffer = alloc<MsilCapture>(count);
            if(count != 0)
            {
                ref var target = ref first(buffer);
                var flow = Wf.EmittingTable<MsilCapture>(dst);
                var view = src.View;
                var formatter = Tables.formatter<MsilCapture>();
                using var writer = dst.Writer();
                writer.WriteLine(formatter.FormatHeader());
                for(var i=0u; i<count; i++)
                {
                    ref var row = ref seek(target,i);
                    fill(skip(view,i).Member, ref row);
                    writer.WriteLine(formatter.Format(row));
                }

                Wf.EmittedTable(flow, count);
            }
            return buffer;
        }

        static ref MsilCapture fill(in ApiMember src, ref MsilCapture dst)
        {
            var cil = src.Msil;
            dst.BaseAddress = cil.BaseAddress;
            dst.Token = src.Token;
            dst.Uri = src.OpUri;
            dst.Encoded = cil.CliCode;
            return ref dst;
        }

        static bool parse(string src, out MsilCapture dst)
        {
            var parts = @readonly(src.SplitClean(Chars.Pipe));
            var count = parts.Length;
            if(count != MsilCapture.FieldCount)
            {
                dst = default;
                return false;
            }
            else
            {
                var i=0;
                Ecma.parse(skip(parts,i++), out dst.Token);
                DataParser.parse(skip(parts,i++), out dst.BaseAddress);
                ApiIdentity.parse(skip(parts,i++), out dst.Uri);
                DataParser.parse(skip(parts,i++), out dst.Encoded);
                return true;
            }
        }

        static Outcome parse(string src, out MsilRow dst)
        {
            dst = default;
            var parts = @readonly(src.Split(Chars.Pipe));
            var count = parts.Length;
            if(count != MsilRow.FieldCount)
                return (false, Tables.FieldCountMismatch.Format(MsilRow.FieldCount, count));
            else
            {
                var outcome = Outcome.Empty;
                var i=0;
                dst.ImageName = skip(parts,i++);

                outcome = Ecma.parse(skip(parts,i++), out dst.Token);
                if(!outcome)
                    return outcome;

                outcome = AddressParser.parse(skip(parts,i++), out dst.MethodRva);
                if(!outcome)
                    return outcome;

                outcome = DataParser.parse(skip(parts,i++), out dst.BodySize);
                if(!outcome)
                    return outcome;

                outcome = DataParser.parse(skip(parts,i++), out dst.MaxStack);
                if(!outcome)
                    return outcome;

                outcome = DataParser.parse(skip(parts,i++), out dst.LocalInit);
                if(!outcome)
                    return outcome;

                outcome = ClrMemberName.parse(skip(parts,i++), out dst.MethodName);
                if(!outcome)
                    return outcome;

                outcome = DataParser.parse(skip(parts,i++), out dst.Code);
                return outcome;
            }
        }
    }
}