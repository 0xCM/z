//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class CaptureWf : WfSvc<CaptureWf>
    {
        public void RunChecks(IApiPack src)
        {
            CaptureWfChecks.run(src, Channel);            
        }

        static CaptureWfRunner runner(IWfRuntime wf, CaptureWfSettings settings, IApiPack dst, CaptureTransport transport)
            => new (wf, settings, dst, transport);

        public static ReadOnlySeq<ApiEncoded> run(IWfRuntime wf, CmdArgs args)
        {
            var collected = ReadOnlySeq<ApiEncoded>.Empty;
            var catalog = ApiCode.catalog(args);
            var settings = new CaptureWfSettings{
                Parts = catalog.Parts.Map(x => x.Name)
            };
            using var transport = new CaptureTransport(Dispense.composite(), wf.Channel);
            wf.Channel.Row((settings as ISettings).Format());
            var ts = sys.timestamp();
            var exec = runner(wf, settings, ApiPacks.create(ts), transport);
            collected = exec.Run(catalog);
            return collected;
        }
    }
}