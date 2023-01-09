//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record struct ApiWorkflowSettings : ISettings<ApiWorkflowSettings>
    {
        public bool CollectApiDocs;

        public bool EmitImageContent;

        public bool EmitSectionHeaders;

        public bool EmitMsilMetadata;

        public bool EmitCliStrings;

        public bool EmitCliBlobs;

        public bool EmitAssemblyRefs;

        public bool EmitCliConstants;

        public bool EmitApiMetadump;

        public bool EmitFieldMetadata;

        public bool EmitApiClasses;

        public bool EmitSymbolicLiterals;

        public bool EmitXedCatalogs;

        public bool EmitAsmRows;

        public bool EmitResBytes;

        public bool EmitAsmStatements;

        public bool CorrelateMembers;

        public bool EmitAssetContent;

        public bool EmitApiBitMasks;

        public bool EmitHexIndex;

        public bool EmitCallData;

        public bool EmitJmpData;

        public bool EmitHexPack;

        public bool ProcessCultFiles;
        
        public static ApiWorkflowSettings @default()
        {
            var dst = new ApiWorkflowSettings();
            dst.CollectApiDocs = true;
            dst.EmitImageContent = true;
            dst.EmitSectionHeaders = true;
            dst.EmitMsilMetadata = true;
            dst.EmitCliStrings = true;
            dst.EmitCliBlobs = true;
            dst.EmitCliConstants = true;
            dst.EmitFieldMetadata = true;
            dst.EmitXedCatalogs = true;
            dst.EmitAsmRows = true;
            dst.EmitResBytes = true;
            dst.EmitAsmStatements = true;
            dst.EmitApiMetadump = true;
            dst.CorrelateMembers = true;
            dst.EmitAssetContent = false;
            dst.EmitSymbolicLiterals = true;
            dst.EmitApiBitMasks = true;
            dst.EmitHexIndex = true;
            dst.EmitCallData = false;
            dst.EmitJmpData = false;
            dst.EmitHexPack = true;
            dst.ProcessCultFiles = false;
            dst.EmitAssemblyRefs = true;
            dst.EmitApiClasses = true;
            return dst;
        }

        public string Format()
            =>(this as ISettings).Format();

        public override string ToString()
            => Format();
    }
}