//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed partial class EcmaEmitter : WfSvc<EcmaEmitter>
    {
        ApiMd ApiMd => Wf.ApiMd();

        Ecma Cli => Wf.Ecma();
                
        public void Emit(IApiCatalog src, EcmaEmissionSettings options, IApiPack dst)
        {
            var parts = ApiAssemblies.Parts;
            if(options.EmitAssemblyRefs)
                EmitAssemblyRefs(parts, dst);

            if(options.EmitFieldMetadata)
                EmitFieldMetadata(parts, dst);

            if(options.EmitApiMetadump)
                EmitMetadumps(Channel, parts,dst);

            if(options.EmitSectionHeaders)
                EmitSectionHeaders(sys.controller().RuntimeArchive(), dst);

            if(options.EmitMsilMetadata)
                EmitMsilMetadata(parts, dst);

            if(options.EmitMsilCode)
                Cli.EmitIl(dst);

            if(options.EmitCliStrings)
            {
                EmitUserStrings(parts, dst);
                EmitSystemStrings(parts, dst);
            }

            if(options.EmitMetadataHex)
                EmitLocatedMetadata(parts, dst);

            if(options.EmitCliConstants)
                EmitConstFields(parts, dst);

            if(options.EmitCliBlobs)
                EmitBlobs(parts, dst);

            if(options.EmitMethodDefs)
                EmitMethodDefs(parts, dst);

            if(options.EmitCliRowStats)
                EmitRowStats(parts, dst);
        }
    }
}