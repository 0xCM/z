//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial class IntelSdm
    {
        public void ExportSplitDefs()
        {
            var specs = LoadSplitDefs(SdmPaths.SplitConfig());
            var buffer = new PllBag<LineRange>();
            iter(specs, spec => Split(spec, buffer));
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

        void CombineDocs(ReadOnlySpan<FilePath> src, FilePath dst, Pair<TextEncodingKind> encoding)
        {
            var count = src.Length;
            var result = Outcome.Success;
            var flow = Channel.EmittingFile(dst);
            var counter = 0u;
            using var writer = dst.Writer(encoding.Right);
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(src,i);
                if(input.IsEmpty)
                {
                    result = (false,string.Format("A supplied source path at index {0} is empty", i));
                    Channel.Error(result.Message);
                }
                if(!input.Exists)
                {
                    result = (false,FS.Msg.DoesNotExist.Format(input));
                    Channel.Error(result.Message);
                }

                var processing = Channel.Running(string.Format("Appending {0} to {1}", input.ToUri(), dst.ToUri()));
                using var reader = input.Reader(encoding.Left);
                var line = reader.ReadLine();
                while(line != null)
                {
                    writer.WriteLine(line);
                    counter++;
                    line = reader.ReadLine();
                }
                Channel.Ran(processing);
            }
            Channel.EmittedFile(flow,counter);
        }

        public Outcome<uint> CreateLinedDoc(FilePath src, FilePath dst, Pair<TextEncodingKind> encoding)
        {
            var flow = Channel.Running(string.Format("{0} => {1}", src.ToUri(), dst.ToUri()));
            var outcome = Lines.copy(src,dst,encoding);
            if(outcome)
                Channel.Ran(flow, string.Format("Emitted {0} lines", outcome.Data));
            else
                Channel.Error(outcome.Message);
            return outcome;
        }

        void Split(in DocSplitSpec spec, IReceiver<LineRange> dst)
        {
            var src = SdmPaths.Sources().Path(FS.file(spec.DocId, FS.Txt));
            if(!src.Exists)
            {
                Channel.Error(FS.missing(src));
                return;
            }

            var range = TextDocs.split(src, TextEncodingKind.Unicode, spec, dst);
            Emit(range, SdmPaths.Targets().Path(FS.file(string.Format("{0}-{1}", spec.DocId, spec.Unit), FS.Txt)));
            dst.Deposit(range);
        }

        void Emit(in LineRange src, FilePath dst)
        {
            var emitting = Channel.EmittingFile(dst);
            using var writer = dst.Writer(TextEncodingKind.Unicode);
            var data = src.View;
            var count = data.Length;
            for(var i=0; i<count; i++)
                writer.WriteLine(skip(data,i));
            Channel.EmittedFile(emitting, count);
        }
    }
}