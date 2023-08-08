//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    class MachineHost : AppService<MachineHost>
    {
        Machines M;

        public MachineHost()
        {
            Disposing += HandleDispose;
        }
        public void Run(string[] args)
        {
            var count = args.Length;
            for(var i=0; i<count; i++)
                Run(skip(args,i));
        }

        void HandleDispose()
        {
            M.Dispose();
        }

        void Run(N22 n)
        {
            M = Machines.create(Wf);
            M.Loop();
        }

        void Run(string spec)
        {
            if(uint.TryParse(spec, out var n))
            {
                switch(n)
                {
                    case 22:
                        Run(n22);
                    break;
                }
            }
        }
    }
}