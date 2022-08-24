//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class CaptureWf : WfSvc<CaptureWf>
    {
        public class SettingsStore : Repository<FS.FilePath, CaptureWfSettings, FS.FilePath>
        {
            public override CaptureWfSettings Load(FS.FilePath key)
            {
                throw new NotImplementedException();
            }

            public override void Store(CaptureWfSettings src, FS.FilePath dst)
            {
                
            }
        }

        public void RunChecks(IApiPack src)
        {
            CaptureWfChecks.run(src, Emitter);            
        }

        static CaptureWfRunner runner(IWfRuntime wf, CaptureWfSettings settings, IApiPack dst, CaptureTransport transport)
            => new CaptureWfRunner(wf, settings, dst, transport);

        public static ReadOnlySeq<ApiEncoded> run(IWfRuntime wf, CmdArgs args)
        {
            var collected = ReadOnlySeq<ApiEncoded>.Empty;
            var channel = wf.Emitter;
            var catalog = default(IApiCatalog);
            var settings = new CaptureWfSettings();
            if(args.Count != 0)
            {
                var src = FS.path(ExecutingPart.Assembly.Location).FolderPath;
                var parts = hashset<PartId>();
                iter(args, arg => {
                    if(PartNames.parse(arg.Value, out var name))
                        parts.Add(name);
                    else
                        channel.Warn($"{arg.Value} is not a part");
                });

                settings.Parts = parts.ToSeq();
                catalog = ApiRuntime.catalog(ApiRuntime.colocated(ExecutingPart.Assembly));
            }
            else
            {
                catalog = ApiRuntime.catalog(ApiRuntime.colocated(ExecutingPart.Assembly));
            }

            using var transport = new CaptureTransport(Dispense.composite(), wf.Emitter);
            channel.Row((settings as ISettings).Format());
            var ts = sys.timestamp();
            var exec = runner(wf, settings, ApiPacks.create(ts), transport);
            collected = exec.Run(catalog);
            return collected;
        }

        public void Run(CmdArgs args)
        {
            run(Wf, args);
        }

        static SettingsStore Store = new();

        public static CaptureWfSettings settings()   
            => new();

        public static CaptureWfSettings settings(FS.FilePath src)   
            => Store.Load(src);

        public static void store(CaptureWfSettings src, FS.FilePath dst)
            => Store.Store(src,dst);
    }
}