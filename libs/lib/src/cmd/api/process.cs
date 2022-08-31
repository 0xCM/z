//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Cmd
    {
        // static void include(CmdVars? src, CmdProcessOptions dst)
        // {
        //     if(src != null)
        //     {
        //         var count = src.Count;
        //         for(var i=0; i<count; i++)
        //         {
        //             ref readonly var v = ref src[i];
        //             if(v.IsNonEmpty && v.Name.IsNonEmpty)
        //                 dst.AddEnvironmentVariable(v.Name,v.Value);
        //         }
        //     }
        // }


        // [Op]
        // public static CmdProcess process(CmdLine cmd, CmdVars? vars)
        // {
        //     var options = new CmdProcessOptions();
        //     include(vars, options);
        //     return new CmdProcess(cmd, options);
        // }


        // [Op]
        // public static CmdProcess process(CmdLine cmd, Receiver<string> status, Receiver<string> error)
        // {
        //     var options = new CmdProcessOptions();
        //     options.WithReceivers(status, error);
        //     return new CmdProcess(cmd, options);
        // }

    }
}