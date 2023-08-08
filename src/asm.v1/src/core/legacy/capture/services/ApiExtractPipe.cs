//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Globalization;

    using static sys;

    public class ApiExtractPipe : AppService<ApiExtractPipe>
    {
        static byte parse8u(string src)
        {
            if(byte.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null, out var b))
                return b;
            else
                return 0;
        }

        public static Outcome parse(string src, out ApiExtractBlock dst)
        {
            dst = ApiExtractBlock.Empty;
            try
            {
                var parts = src.SplitClean(FieldDelimiter);
                if(parts.Length != 3)
                    return (false, $"components = {parts.Length} != 3");

                var address = HexNumericParser.parse64u(parts[(byte)ApiExtractField.Base]).ValueOrDefault();
                var uri = ApiIdentity.parse(parts[(byte)ApiExtractField.Uri].Trim()).ValueOrDefault();
                var bytes = parts[(byte)ApiExtractField.Encoded].SplitClean(HexFormatSpecs.DataDelimiter).Select(parse8u);
                dst = new ApiExtractBlock(address, uri.Format(), bytes);
                return true;
            }
            catch(Exception e)
            {
                return e;
            }
        }

        public uint Load(FilePath src, List<ApiExtractBlock> dst)
        {
            var lines = src.ReadLines().View;
            var count = lines.Length;
            var flow = Channel.Running(string.Format("Reading extracts from {0}", src.ToUri()));
            var counter = 0u;
            var result = Outcome.Success;
            for(var i=1u; i<count; i++)
            {
                ref readonly var line = ref skip(lines,i);
                result = parse(line, out var block);
                if(result.Ok)
                {
                    dst.Add(block);
                    counter++;
                }
                else
                    Channel.Warn(result.Message);

            }
            Channel.Ran(flow, string.Format("Read {0} extract blocks from {1}", counter, src.ToUri()));
            return counter;
        }

        public ReadOnlySpan<ApiExtractBlock> Load(Files src)
        {
            var dst = list<ApiExtractBlock>();
            var counter = 0u;
            foreach(var file in src)
                counter += Load(file, dst);
            return dst.ViewDeposited();
        }
    }
}