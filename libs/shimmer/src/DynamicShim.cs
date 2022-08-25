//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class DynamicShim : Shim<DynamicShim>
    {    
        static FilePath path()
        {
            var dst = FilePath.Empty;
            var args = Environment.GetCommandLineArgs();
            if (args.Length != 0)
                dst = FS.path(first(args));
            return dst;                
        }

        public static ReadOnlySeq<string> args()
        {
            var dst = ReadOnlySeq<string>.Empty;
            var src = Environment.GetCommandLineArgs();
            if(src.Length > 1)
                dst = slice(span(src), 1).ToArray();
            return dst;
        }

        public DynamicShim()
            : base(path(), args())
        {


        }

        public override Task<int> Start()
        {
            return sys.start(() => 0);
        }
    }    
}