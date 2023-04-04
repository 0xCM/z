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
            => new CaptureWfRunner(wf, settings, dst, transport);

        public static ReadOnlySeq<ApiEncoded> run(IWfRuntime wf, CmdArgs args)
        {
            var collected = ReadOnlySeq<ApiEncoded>.Empty;
            var channel = wf.Channel;
            var catalog = default(IApiCatalog);
            var settings = new CaptureWfSettings();
            var assemblies = list<Assembly>();
            var parts = hashset<PartName>();
            if(args.Count != 0)
            {
                iter(args, arg => {
                    if(PartNames.parse(arg.Value, out var name))
                        parts.Add(name);
                    else
                        channel.Warn($"{arg.Value} is not a part");
                });

                settings.Parts = parts.ToSeq();
                catalog = ApiCatalog.catalog();
            }
            else
            {
                foreach(var a in ApiCatalog.components())
                {
                    if(ApiCatalog.part(a, out IPart part))
                    {
                        parts.Add(part.Name);
                        assemblies.Add(a);
                    }
                }
                settings.Parts = parts.ToSeq();
                catalog = ApiCatalog.catalog(assemblies.ToArray());
            }

            using var transport = new CaptureTransport(Dispense.composite(), wf.Channel);
            channel.Row((settings as ISettings).Format());
            var ts = sys.timestamp();
            var exec = runner(wf, settings, ApiPacks.create(ts), transport);
            collected = exec.Run(catalog);
            return collected;
        }
    }
}