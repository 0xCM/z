//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;

    using Microsoft.Diagnostics.Runtime;

    public class DumpAdapter : IDisposable
    {
        public static DumpAdapter create(FS.FilePath src)
            => new DumpAdapter(src);

        public FS.FilePath DumpPath {get;}

        DataTarget Target;

        ClrRuntime Runtime;

        DumpAdapter(FS.FilePath src)
        {
            DumpPath = src;
            Target = DataTarget.LoadDump(src.Name);
            Runtime = Target.ClrVersions.Single().CreateRuntime();
        }

        public void Dispose()
        {
            Runtime.Dispose();
            Target.Dispose();
        }

        public Outcome FindMethod(MemoryAddress ip, out ClrMethod dst)
        {
            var method = Runtime.GetMethodByInstructionPointer(ip);
            if(method != null)
            {
                dst = method;
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }
    }
}