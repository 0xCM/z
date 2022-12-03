//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public partial class ApiTools 
    {
        static ApiTools Instance;

        public static ref readonly ApiTools Service => ref Instance;

        public ReadOnlySpan<Key> Known => Lookup.Keys;

        static bool tool(Key key, out ApiTool tool)
            => Lookup.Find(key, out tool);

        static SortedLookup<Key,ApiTool> Lookup;

        public static Key key(uint seq, FileName name)
            => new (seq,name);
                
        static SortedLookup<Key,ApiTool> discover()
        {
            var paths = Env.paths(EnvTokens.PATH, EnvVarKind.Process).Delimit(Chars.NL);
            var dst = dict<Key,ApiTool>();
            var seq = 0u;
            for(var i=0u; i<paths.Count; i++)
            {
                ref readonly var dir = ref paths[i];
                iter(DbArchive.enumerate(dir, false, FileKind.Exe, FileKind.Cmd, FileKind.Bat), path => {
                    var k = key(seq++,path.FileName());
                    dst.TryAdd(k, new (seq++, k, path));
                });
            }
            return dst;
        }

        public static void emit(IWfChannel channel, ReadOnlySpan<Key> src, IDbArchive dst)
        {
            var emitter = text.emitter();
            foreach(var key in src)
            {               
                if(tool(key, out var t))
                {
                    var info = string.Format("{0:D5} | {1,-48} | {2}", t.Seq, t.Name, t.Path); 
                    emitter.AppendLine(info);
                    channel.Row(info);
                }
            }

            channel.FileEmit(emitter.Emit(), dst.Path(FS.file("tools", FileKind.Csv)));
        }

        static ApiTools()
        {
            Lookup = discover();
            Instance = new();
        }
    }
}