//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class DevCmd : AppCmdService<DevCmd>
    {
        public static FolderPath cd()
            => new(Environment.CurrentDirectory);

        public static FolderPath cd(CmdArgs args)
        {
            if(args.Length == 1)
                Environment.CurrentDirectory = args.First.Value;
            return cd();
        }

        [CmdOp("sln/root")]
        void SlnRoot()
        {

        }


        [CmdOp("cd")]
        void Cd(CmdArgs args)
        {
            if(args.Length == 1)
                Environment.CurrentDirectory = args.First.Value;
            Write(Environment.CurrentDirectory);
        }

    }
}