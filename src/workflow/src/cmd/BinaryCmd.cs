//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    using static sys;

    unsafe class BinaryCmd : WfAppCmd<BinaryCmd>
    {
		[DllImport(ImageNames.Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr GetCurrentProcess();

        [DllImport(ImageNames.PsApi, SetLastError = true), Free]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumProcesses([Out] ProcessId* lpidProcess, [In]uint cb, [Out] uint* lpcbNeeded);

        [DllImport(ImageNames.PsApi, SetLastError = true), Free]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumProcessModulesEx([In] Handle hProcess, [Out] void *lphModule, [In] uint cb, [Out] uint* lpcbNeeded, [In] uint dwFilterFlag);
        
        [CmdOp("procinfo")]
        unsafe void ProcInfo()
        {
            var process = GetCurrentProcess();
            var dst = default(PROCESS_BASIC_INFORMATION);
            NtDll.NtQueryInformationProcess(process, PROCESSINFOCLASS.ProcessBasicInformation, &dst, size<PROCESS_BASIC_INFORMATION>(), out var length);
            Require.equal(length, size<PROCESS_BASIC_INFORMATION>());
            Channel.Row(dst.ToString());
            Channel.Row($"Peb:{dst.PebBaseAddress}");

            //NtDll.NtQueryInformationProcess()

        }

        [CmdOp("projects/assemblies")]
        void IndexAssemblies(CmdArgs args)
        {
            const string RenderPattern ="{0,-64} | {1,-16} | {2,-16} | {3}";
            var locations = list<string>();
            var index = Ecma.index(Channel, FS.dir(args[0]));
            iter(index.Entries(), entry => {
                locations.Add(entry.Path.Format(PathSeparator.FS));
            });
            iter(index.Distinct(), entry => {
                Channel.Row(string.Format(RenderPattern, entry.Key.Name, entry.FileSize, entry.Key.Version, entry.Key.Mvid));
            });

            iter(index.Duplicates(), entry => {
                Channel.Row(string.Format(RenderPattern, entry.Key.Name, entry.FileSize, entry.Key.Version, entry.Key.Mvid), FlairKind.StatusData);
            });

            var buffer = sys.span<byte>(2024);
            foreach(var input in locations)
            {
                try
                {
                    buffer.Clear();
                    BinaryFormatters.verify(input,buffer);
                    Channel.Status($"Verified {input}");
                }
                catch(Exception e)
                {
                    Channel.Error(e.Message);
                }
            }
        }


        [CmdOp("procenum")]
        void ProcEnum()
        {
            var needed = 0u;
            var max = 2024u;
            var buffer = alloc<ProcessId>(max);
            fixed(ProcessId* pBuffer = &buffer[0])
            {
                var result = EnumProcesses(pBuffer, max*4, &needed);                
                if(result)
                {
                    var count = min(max,needed/4);
                    var values = slice(span(buffer), 0, count);
                    values.Sort();
                    for(var i=0; i<count; i++)
                    {
                        Channel.Row(string.Format("{0:D5} {1}", i, skip(buffer,i)));
                    }
                }
            }
        }

        [CmdOp("binary/test")]
        void RunTests()
        {
            var tests = BinaryTests.discover(typeof(BinaryTests).Assembly);
            iter(tests, test => test.Run(Channel));
        }

        [CmdOp("binary/align")]
        void Align()
        {
            var expressions = new Binary.IExpr[]{
                Binary.align(25, 24),
                Binary.align(29, 24),
                Binary.align(43, 24),
                Binary.align(48, 24),
                Binary.align(49, 24),
                Binary.align(3, 8),
                };

            iter(expressions, e => Channel.Row($"{e.Format()} = {e.Evaluate()}"));                        
        }

        [CmdOp("formatters/list")]
        void CheckBinaryFormatters()
        {
            var types = Assembly.GetExecutingAssembly().Types();
            iter(types, t => {
                if(t.Name == "StringFormatter")
                {
                    var attribs = t.GetCustomAttributes();
                    iter(attribs, a => {
                        if(a.GetType() == typeof(BinaryFormatterAttribute))
                            Channel.Row(t);
                    });
                }                
            });
        }
    }
}