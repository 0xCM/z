//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;

    class MachineHost : AppService<MachineHost>
    {
        // public static void Main(params string[] args)
        //     => run(args, PartId.Cpu, PartId.CalcShell);

        Machines TM;

        public void Run(string[] args)
        {
            var count = args.Length;
            for(var i=0; i<count; i++)
                Run(skip(args,i));
        }

        protected override void Disposing()
        {
            TM.Dispose();
        }

        void Run(N22 n)
        {
            TM = Machines.create(Wf);
            TM.Run();
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