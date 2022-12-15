//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed partial class EcmaEmitter : WfSvc<EcmaEmitter>
    {
        Ecma Cli => Wf.Ecma();
                
        public void Emit(Assembly[] src, EcmaEmissionSettings options, IDbArchive dst)
        {
            if(options.EmitAssemblyRefs)
                EmitAssemblyRefs(src, dst);

            if(options.EmitFieldMetadata)
                EmitFieldMetadata(src, dst);

            if(options.EmitApiMetadump)
                EmitMetadumps(Channel, src,dst);

            if(options.EmitSectionHeaders)
                EmitSectionHeaders(sys.controller().RuntimeArchive(), dst);

            if(options.EmitMsilMetadata)
                EmitMsilMetadata(src, dst);

            if(options.EmitMsilCode)
                Cli.EmitMsil(dst);

            if(options.EmitCliStrings)
            {
                EmitUserStrings(src, dst);
                EmitSystemStrings(src, dst);
            }

            if(options.EmitMetadataHex)
                EmitLocatedMetadata(src, dst);

            if(options.EmitCliConstants)
                EmitConstFields(src, dst);

            if(options.EmitCliBlobs)
                EmitBlobs(src, dst);

            if(options.EmitMethodDefs)
                EmitMethodDefs(src, dst);

            if(options.EmitCliRowStats)
                EmitRowStats(src, dst);
        }
    }
}