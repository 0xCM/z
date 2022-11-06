//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaEmitter
    {
        public void EmitCatalogs(FolderPath src, FolderPath dst)
        {

        }

        public void EmitCatalogs(ReadOnlySeq<Assembly> src)
        {
            sys.exec(true,
                () => EmitLocatedMetadata(src, AppDb.ApiTargets("ecma/hex").Delete(), 64),
                () => EmitAssemblyRefs(src, AppDb.ApiTargets("ecma").Delete()),
                () => EmitStrings(src, AppDb.ApiTargets("ecma/strings").Delete()),
                () => EmitRowStats(src, AppDb.ApiTargets("ecma").Table<EcmaRowStats>()),
                () => EmitMsilMetadata(src, AppDb.ApiTargets("ecma/msil.dat").Delete()),
                () => EmitBlobs(src, AppDb.ApiTargets("ecma/blobs").Delete()),
                () => EmitMetadumps(Channel, src, AppDb.ApiTargets("ecma/dumps").Delete()),
                () => EmitMemberRefs(src, AppDb.ApiTargets("ecma/members.refs").Delete()),
                () => EmitMethodDefs(src, AppDb.ApiTargets("ecma/methods.defs").Delete()),
                () => {}
            );
        }
    }
}