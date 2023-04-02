//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    class ProcessCmd : WfAppCmd<ProcessCmd>
    {        
        [CmdOp("process/memory")]
        Outcome ShowMemHex(CmdArgs args)
        {
            var address = MemoryAddress.Zero;
            var result = DataParser.parse(arg(args,0), out address);
            var size = 16u;
            if(result)
            {

                if(args.Count >= 2)
                    result = DataParser.parse(arg(args,1), out size);

                if(result)
                {
                    var data = sys.cover(address.Ref<byte>(), size);
                    var hex = data.FormatHex();
                    Channel.Write(string.Format("{0,-16}: {1}", address, hex));
                }

            }
            return result;
        }
        
        [CmdOp("process/list")]
        void ProcessList()
        {
            const string Pattern = "{0,-24} | {1,-12}";
            var src = ProcessAdapter.proceses().Sort();
            var dst = text.emitter();
            dst.AppendLineFormat(Pattern,"Name", "PID");
            iter(src, p => dst.AppendLineFormat(Pattern, p.ProcessName, p.Id));
            var data = dst.Emit();
            Channel.Row(data);
            Channel.FileEmit(data, Env.ShellData.Path("processes", FileKind.Csv));
        }

        [CmdOp("process/thread")]
        unsafe void ProcessThread()
        {
            var v0 = vcpu.vbroadcast(w128,0xFF);
            var v1 = vcpu.vbroadcast(w128,0xFF);
            var v2 = vcpu.vbroadcast(w128,0xFF);
            var v3 = vcpu.vbroadcast(w128,0xFF);
            var f0 = vcpu.vbroadcast(w128, (double)255.0);
            var result = ProcessControl.context(ProcessThreads.executing(), out var context);

            if(result)            
            {
                var fields = context.GetType().Fields();
                iter(fields, f => {
                    Channel.Row(string.Format("{0,-16} {1}", f.Name, f.GetValue(context)));
                });
            
            }
            else
                Channel.Error(result.Message);
        }

        [CmdOp("process/context")]
        void ProcContext(CmdArgs args)
            => ImageMemory.dump(Channel, args, AppSettings.ProcDumps());

        [CmdOp("process/map")]
        void ProcMap(CmdArgs args)
            => ImageMemory.map(Channel, args, Env.ShellData);

        [CmdOp("process/modules")]
        void ProcModules(CmdArgs args)
            => ImageMemory.modules(Channel, args, EnvDb.Scoped("context"));
    }
}