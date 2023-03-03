//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaModels;

    partial class EcmaEmitter
    {
        // public void EmitStrings(IApiPack dst)
        // {
        //     exec(PllExec,
        //     () => EmitSystemStrings(dst),
        //     () => EmitUserStrings(dst)
        //     );
        // }

        public void EmitStrings(ReadOnlySeq<Assembly> src, IDbArchive dst)
        {
            exec(PllExec,
                () => EmitSystemStrings(src,dst),
                () => EmitUserStrings(src,dst)
            );
        }
    }
}