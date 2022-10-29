//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    class ProcessCmd : WfAppCmd<ProcessCmd>
    {
        [CmdOp("proc/memory")]
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
                    Write(string.Format("{0,-16}: {1}", address, hex));
                }

            }
            return result;
        }
        
        [CmdOp("procs/list")]
        void ProcessList()
        {
            const string Pattern = "{0,-24} | {1,-12}";
            var src = ProcessAdapter.proceses().Sort();
            var dst = text.emitter();
            dst.AppendLineFormat(Pattern,"Name", "PID");
            iter(src, p => dst.AppendLineFormat(Pattern, p.ProcessName, p.Id));
            var data = dst.Emit();
            Row(data);
            FileEmit(data, AppDb.AppData().Path("processes", FileKind.Csv));
            //Row(dst.Emit());
            //FileEmit()
        }

        [CmdOp("procs/context")]
        void ProcContext(CmdArgs args)
            => RuntimeContext.emit(args, Emitter, AppSettings.ProcDumps());

        [CmdOp("procs/map")]
        void ProcMap(CmdArgs args)
            => ImageMemory.map(args, Emitter, AppDb.AppData());

        [CmdOp("procs/modules")]
        void ProcModules(CmdArgs args)
            => ImageMemory.modules(args, Emitter, AppDb.AppData());
    }
}