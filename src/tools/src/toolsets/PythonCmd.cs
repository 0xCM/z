//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    class PythonCmd : WfAppCmd<PythonCmd>
    {        
        Python Python => Wf.Python();

        [CmdOp("python")]
        void RunCommand(CmdArgs args)        
        {
            if(args.IsEmpty)
                args = Cmd.args("--help");            
            Python.RunCommand(args);
        }

        [CmdOp("python/script")]
        void RunScript(CmdArgs args)
        {
            var path = FS.path(args[0]);
            if(!path.Exists)
                Channel.Error(FS.missing(path));
            else
            {
                if(args.Count > 1)
                {
                    Python.RunScript(path, args.Skip(1));
                }
                else
                {
                    Python.RunScript(path);
                }

            }
        }        
    }   
}