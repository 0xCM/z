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
                            iter(records, r => Channel.Write(formatter.Format(r)));
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


    }
}