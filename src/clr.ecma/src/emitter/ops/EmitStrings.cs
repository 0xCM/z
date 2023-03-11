//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaTables;

    partial class EcmaEmitter
    {
        public void EmitStrings(ReadOnlySeq<Assembly> src, IDbArchive dst)
        {
            exec(PllExec,
                () => EmitSystemStrings(src,dst),
                () => EmitUserStrings(src,dst)
            );
        }
    }
}