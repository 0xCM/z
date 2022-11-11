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
            if(options.EmitAssemblyRefs)
                EmitAssemblyRefs(src.Assemblies, dst);

            if(options.EmitFieldMetadata)
                EmitFieldMetadata(src.Assemblies, dst);

            if(options.EmitApiMetadump)
                EmitApiMetadump(dst);

            if(options.EmitSectionHeaders)
                EmitSectionHeaders(dst);

            if(options.EmitMsilMetadata)
                EmitIlDat(dst);

            if(options.EmitMsilCode)
                Cli.EmitIl(dst);

            if(options.EmitCliStrings)
            {
                EmitUserStrings(dst);
                EmitSystemStrings(dst);
            }

            if(options.EmitMetadataHex)
                EmitLocatedMetadata(dst);

            if(options.EmitCliConstants)
                EmitConstFields(dst);

            if(options.EmitCliBlobs)
                EmitBlobs(dst);

            if(options.EmitMethodDefs)
                EmitMethodDefs(ApiMd.Parts, dst);

            if(options.EmitCliRowStats)
                EmitRowStats(dst);
        }
    }
}