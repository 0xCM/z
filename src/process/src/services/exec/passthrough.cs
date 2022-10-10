//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProcExec
    {        
        public static Task<int> passthrough(FilePath target, WfEmit channel, params string[] args)
        {
            int run()
            {
                var result = 0;
                var process = new ChildProcess.PassThrough();
                try
                {
                    process = new(ProcExec.start(ProcessStartSpec.define(target, args)));
                    var id = process.Id;
                    var running = channel.Running($"{process.Id}:{target}");
                    process.WaitForExit();
                    result = process.ExitCode;
                    if(result >= 0)
                    {
                        channel.Ran(running, $"Process exited with code {result}");
                    }
                    else
                    {
                        channel.Error(running, $"Process exited with code {result}");
                    }
                    
                }
                catch(Exception e)
                {
                    result = -1;
                    channel.Error(e);
                }
                finally
                {
                    process.Dispose();
                }

                return result;
            }
            return sys.start(run);
        }
    }
}