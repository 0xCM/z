//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct WinSdkInfo
    {
        public string Version;

        public IncludePath IncPaths;

        public IncludePath LibPaths;

        public string Format()
        {
            var dst = text.buffer();
            dst.AppendLineFormat("SdkVer:{0}", Version);
            dst.AppendLineFormat("/I{0}", IncPaths.Format());
            dst.AppendLineFormat("/LIBPATH {0}", LibPaths.Format());
            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
}