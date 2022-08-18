//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed partial class CliEmitter : WfSvc<CliEmitter>
    {
        ApiMd ApiMd => Wf.ApiMd();

        Cli Cli => Wf.Cli();

        public void Emit(CliEmissionSettings options, IApiPack dst)
        {
            if(options.EmitAssemblyRefs)
                EmitAssemblyRefs(dst);

            if(options.EmitFieldMetadata)
                EmitFieldMetadata(dst);

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
                EmitMethodDefs(ApiMd.Assemblies, dst);

            if(options.EmitCliRowStats)
                EmitRowStats(dst);
        }
    }
}