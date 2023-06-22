//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class AsmDisamSvc : WfSvc<AsmDisamSvc>
    {
        readonly AsmDisasm _D = new();

        public AsmDisamSvc()
        {
        }


        public Outcome ParseRawData(FilePath src)
        {
            const string Marker = "RAW DATA #";
            var result = Outcome.Success;
            var block = 0u;
            var offset = Hex32.Zero;
            var data = BinaryCode.Empty;
            var parsing = false;
            var records = list<HexCsvRow>();
            var formatter = CsvTables.formatter<HexCsvRow>(16);
            using var reader = src.LineReader(TextEncodingKind.Asci);
            while(reader.Next(out var line))
            {
                var content = line.Content;
                if(parsing)
                {
                    if(line.IsEmpty)
                    {
                        if(records.Count != 0)
                        {
                            iter(records, r => Write(formatter.Format(r)));
                            records.Clear();
                        }
                        parsing = false;
                    }
                    else
                    {
                        var i = text.index(content, Chars.Colon);
                        if(i<0)
                            return (false, "Unexpected content");

                        result = HexParser.parse(text.left(content,i), out offset);
                        if(result.Fail)
                            return (false, "Unable to parse offset");

                        result = DataParser.parse(text.right(content,i), out data);
                        if(result.Fail)
                            return result;
                    }
                }
                else
                {
                    var i = text.index(content,Marker);
                    if(i>0)
                    {
                        result = DataParser.parse(text.right(content,i), out block);
                        if(result.Fail)
                            return (false, "Unable to parse block number");
                        parsing = true;
                    }
                }
            }
            return result;
        }

        // public void ParseDisassembly(FilePath src, FilePath dst)
        // {
        //     using var map = MemoryFiles.map(src);
        //     var flow = EmittingFile(dst);
        //     var outcome = TransformData(map.View<byte>(), dst);
        //     EmittedFile(flow, 0);
        // }

        // Outcome TransformData(ReadOnlySpan<byte> src, FilePath dst)
        // {
        //     var lines = LineCount(src);
        //     var size = (ByteSize)src.Length;
        //     var max = MaxLineLength(src);
        //     using var writer = dst.Writer(Encoding.ASCII);
        //     Span<char> buffer = alloc<char>(max);
        //     var pos = 0u;
        //     var length = 0u;
        //     var offset = 0u;
        //     var number = 0u;
        //     while(pos++ < size -1)
        //     {
        //         ref readonly var a0 = ref skip(src, pos);
        //         ref readonly var a1 = ref skip(src, pos + 1);
        //         if(SQ.eol(a0,a1))
        //         {
        //             var line = AsciLines.asci(src, offset, length + 1);
        //             number++;
        //             if(!SQ.contains(line.Codes, C.Colon) || number < 4)
        //             {
        //                 pos++;
        //                 length = 0;
        //                 offset = pos;
        //                 continue;
        //             }

        //             var outcome = _D.ProcessLine(ref line, out var content);
        //             if(outcome.Fail)
        //             {
        //                 Wf.Error(string.Format("Error processing line {0}:{1} - {2}", number, line.Format(), outcome.Message));
        //                 break;
        //             }
        //             buffer.Clear();
        //             writer.WriteLine(AsmDisasm.format(content,buffer));
        //             pos++;
        //             length = 0;
        //             offset = pos;
        //         }
        //         else
        //             length++;
        //     }

        //     return true;
        // }
    }
}