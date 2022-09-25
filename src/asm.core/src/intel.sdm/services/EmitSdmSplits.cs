//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial class IntelSdm
    {
        public Outcome EmitSdmSplits()
        {
            var specs = LoadSplitSpecs(SdmPaths.SplitConfig());
            var buffer = new PllBag<LineRange>();
            iter(specs, spec => Split(spec, buffer));
            return true;
        }

        public Outcome VerifyLinedDoc(FilePath src, TextEncodingKind encoding)
        {
            var outcome = Outcome.Success;
            using var reader = src.LineReader(encoding);
            var counter = 1u;
            while(reader.Next(out var line))
            {
                if(counter != line.LineNumber)
                {
                    outcome = (false, string.Format("{0} != {1}:{2}", counter, line.LineNumber, line.Content));
                    break;
                }
                counter++;
            }
            return outcome;
        }

        public ReadOnlySpan<DocSplitSpec> LoadSplitSpecs(FilePath src)
        {
            var outcome = DocSplits.load(src, out var specs);
            if(outcome.Fail)
                Wf.Error(outcome.Message);
            return specs;
        }

        public Outcome CombineDocs(ReadOnlySpan<FilePath> src, FilePath dst, Pair<TextEncodingKind> encoding)
        {
            var count = src.Length;
            var result = Outcome.Success;
            var flow = EmittingFile(dst);
            var counter = 0u;
            using var writer = dst.Writer(encoding.Right);
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(src,i);
                if(input.IsEmpty)
                {
                    result = (false,string.Format("A supplied source path at index {0} is empty", i));
                    Error(result.Message);
                    return result;
                }
                if(!input.Exists)
                {
                    result = (false,FS.Msg.DoesNotExist.Format(input));
                    Error(result.Message);
                    return result;
                }

                var processing = Running(string.Format("Appending {0} to {1}", input.ToUri(), dst.ToUri()));
                using var reader = input.Reader(encoding.Left);
                var line = reader.ReadLine();
                while(line != null)
                {
                    writer.WriteLine(line);
                    counter++;
                    line = reader.ReadLine();
                }
                Ran(processing);
            }
            EmittedFile(flow,counter);
            return result;
        }

        public Outcome<uint> CreateLinedDoc(FilePath src, FilePath dst, Pair<TextEncodingKind> encoding)
        {
            var flow = Wf.Running(string.Format("{0} => {1}", src.ToUri(), dst.ToUri()));
            var outcome = Lines.copy(src,dst,encoding);
            if(outcome)
                Wf.Ran(flow, string.Format("Emitted {0} lines", outcome.Data));
            else
                Error(outcome.Message);
            return outcome;
        }

        void Split(in DocSplitSpec spec, IReceiver<LineRange> dst)
        {
            var src = SdmPaths.Sources().Path(FS.file(spec.DocId, FS.Txt));
            if(!src.Exists)
            {
                Error(FS.missing(src));
                return;
            }

            var range = DocSplits.split(src, TextEncodingKind.Unicode, spec, dst);
            Emit(range, SdmPaths.Output().Path(FS.file(string.Format("{0}-{1}", spec.DocId, spec.Unit), FS.Txt)));
            dst.Deposit(range);
        }

        void Emit(in LineRange src, FilePath dst)
        {
            var emitting = Wf.EmittingFile(dst);
            using var writer = dst.Writer(TextEncodingKind.Unicode);
            var data = src.View;
            var count = data.Length;
            for(var i=0; i<count; i++)
                writer.WriteLine(skip(data,i));
            Wf.EmittedFile(emitting, count);
        }
    }
}