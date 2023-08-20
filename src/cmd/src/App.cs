//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using System.Linq;
    using static sys;

    [Free]
    sealed class App : ApiShell<App>
    {
        public static int Main(params string[] args)
        {
            var result = 0;
            var runtime = ApiServer.runtime();
            var spec = ApiServer.spec(args);
            using var shell = ApiServer.shell(runtime, args);
            try
            {
                if(args.Length == 0)
                    shell.Run();
                else
                    shell.Runner.RunCommand(spec);
            }
            catch(Exception e)
            {
                term.error(e);
                result = -1;
            }
            return result;
        }

        sealed class ShellCmd : WfAppCmd<ShellCmd>
        {
            [CmdOp("shell/*")]
            void RunShellCmd(CmdArgs args, string tag)
            {
                Channel.Row(tag);

                foreach(var arg in args)
                {
                    Channel.Row(arg);
                }
            }

        [CmdOp("asm/entries")]
        unsafe void FindEntries()
        {
                // Parts.Bit.Assembly,
                // Parts.SysApi.Assembly, 

            var decoder = Wf.AsmDecoder();
            var dst = text.emitter();
            var catalog = ApiCatalog.catalog(new Assembly[]{
                Parts.Asm.Assembly,
                Parts.Bits.Assembly, 
                Parts.Math.Assembly, 
                Parts.VCpu.Assembly, 
                });
            piter(ApiCode.entries(Channel,catalog), 
                entry => {
                    var @base = entry.Location;
                    var pCode = @base.Pointer<byte>();
                    var code = new ApiCodeBlock(@base, entry.Uri, cover(pCode, 10).ToArray());
                    decoder.Decode(code,out var decoded);
                    ref readonly var inst = ref decoded.First;
                    var size = (uint)inst.ByteLength;
                    var ip = @base;
                    var encoded = cover(pCode,size);
                    dst.AppendLine($"# {entry.Sig}\n{ip} {size} {inst.FormattedInstruction} # {encoded.FormatHex()}");
                });

            Channel.FileEmit(dst.Emit(), Env.cd() + FS.file("entries", FileKind.Asm));

            
        }
        
        [CmdOp("asm/find")]
        unsafe void Find()
        {
            
            var cols = new string[]{"Rip", "Instruction", "Encoding", "Disp", "Target"};
            const string RowPattern = "{0,-16} | {1,-32} | {2,-32} | {3,-16} | {4,-16}";
            var methods = from m in Parts.Math.Assembly.DeclaredStaticMethods().Concrete().NonGeneric()
                          let address = ClrJit.jit(m)
                          select (m,address);
            var decoder = Wf.AsmDecoder();
            var dst = text.emitter();
            foreach(var (m,a) in methods)
            {
                var pCode = a.Pointer<byte>();
                var @base = (MemoryAddress)pCode;
                var code = new ApiCodeBlock(@base, m.Uri(), cover(pCode, 10).ToArray());
                decoder.Decode(code,out var decoded);
                var count = decoded.Count;
                ref readonly var jump = ref decoded.First;
                var size = (uint)jump.ByteLength;
                var ip = @base;
                var encoded = cover(pCode,size);
                var offset = slice(encoded,2);
                var disp = asm.disp(offset,0,NativeSize.W32);
                var target = (MemoryAddress)(ip + disp);

                dst.AppendLine($"# {m.DisplaySig()}");
                dst.AppendLine($"{ip} {size} {jump.FormattedInstruction} # {encoded.FormatHex()}"); 
                dst.AppendLine($"# {ip} + {disp} -> {target}");

                pCode = target.Pointer<byte>();
                @base = pCode;
                code = new ApiCodeBlock(@base, m.Uri(), cover(pCode, 12).ToArray());
                decoded = AsmInstructionBlock.Empty;
                decoder.Decode(code,out decoded);
                count = decoded.Count;
                ip = @base;
                for(var i=0; i<count; i++)
                {
                    pCode = ip.Pointer<byte>();
                    ref readonly var inst = ref decoded[i];
                    size = (uint)inst.ByteLength;
                    encoded = cover(pCode,size);
                    dst.AppendLine($"{ip} {size} {inst.FormattedInstruction} # {encoded.FormatHex()}"); 
                    ip+=size;
                }
            }

            Channel.FileEmit(dst.Emit(), Env.cd() + FS.file("asm.find", FileKind.Asm));
        }
       
       
       unsafe void Jmp(AsmDecoder decoder, MethodInfo method, MemoryAddress dst)
       {
            var rip = dst;
            var pCode = dst.Pointer<byte>();
            var code = new ApiCodeBlock(dst, method.Uri(), cover(pCode,30).ToArray());
            decoder.Decode(code,out var block);
            for(var i=0; i<block.Length; i++)
            {
                ref readonly var inst = ref block[i];
                var size = (uint)inst.ByteLength;
                rip += size;
                var encoded = cover(pCode,size);
                Channel.Row($"JMP {rip} {inst.FormattedInstruction} # {encoded.FormatHex()}"); 
            }
            
       } 
       
       }

    }
}