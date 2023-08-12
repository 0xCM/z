//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ApiCode
    {
        const byte ZeroLimit = 10;

        static ConcurrentDictionary<ApiToken,ApiEncoded> parse(Dictionary<ApiHostUri,CollectedCodeExtracts> src, IWfChannel log)
        {
            var flow = log.Running(Msg.ParsingHosts.Format(src.Count));
            var buffer = sys.alloc<byte>(Pow2.T14);
            var parser = ApiCode.parser(buffer);
            var dst = new ConcurrentDictionary<ApiToken,ApiEncoded>();
            var counter = 0u;
            foreach(var host in src.Keys)
            {
                var running = log.Running(Msg.ParsingHostMembers.Format(host));
                var extracts = src[host];
                foreach(var extract in extracts)
                {
                    parser.Parse(extract.TargetExtract);
                    if(!dst.TryAdd(extract.Token,new ApiEncoded(extract.Token, parser.Parsed)))
                        log.Warn($"Duplicate:{extract.Token}");
                    else
                        counter++;
                }
                log.Ran(running, Msg.ParsedHostMembers.Format(extracts.Count, host));
            }

            log.Ran(flow, Msg.ParsedHosts.Format(counter, src.Keys.Count));
            return dst;
        }
    }
}