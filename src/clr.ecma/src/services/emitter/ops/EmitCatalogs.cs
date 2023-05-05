//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaEmitter
    {
        // public void EmitCatalogs(ReadOnlySeq<Assembly> src, IDbArchive dst)
        // {
        //     sys.exec(true,
        //         () => EmitLocatedMetadata(src, dst.Scoped("ecma/hex").Delete(), 64),
        //         () => EmitAssemblyRefs(src, dst.Scoped("ecma").Delete()),
        //         () => EmitStrings(src, dst.Scoped("ecma/strings").Delete()),
        //         () => EmitMsilMetadata(src, dst.Scoped("ecma/msil.dat").Delete()),
        //         () => EmitBlobs(src, dst.Scoped("ecma/blobs").Delete()),
        //         () => EmitDump(Channel, src, dst.Scoped("ecma/dumps").Delete()),
        //         () => EmitMemberRefs(src, dst.Scoped("ecma/members.refs").Delete()),
        //         () => EmitMethodDefs(src, dst.Scoped("ecma/methods.defs").Delete()),
        //         () => {}
        //     );
        // }
    }
}