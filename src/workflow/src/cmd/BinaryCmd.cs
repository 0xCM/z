//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    unsafe class BinaryCmd : WfAppCmd<BinaryCmd>
    {
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
                Channel.Row(string.Format(RenderPattern, entry.Key.AssemblyName, entry.FileSize, entry.Key.Version, entry.Key.Mvid));
            });

            iter(index.Duplicates(), entry => {
                Channel.Row(string.Format(RenderPattern, entry.Key.AssemblyName, entry.FileSize, entry.Key.Version, entry.Key.Mvid), FlairKind.StatusData);
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