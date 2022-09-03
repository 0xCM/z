//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1), Settings(Id)]
    public record struct CliEmissionSettings : IWfSettings<CliEmissionSettings>
    {
        const string Id = "cli.options";

        public bit EmitImageContent;

        public bit EmitSectionHeaders;

        public bit EmitMsilMetadata;

        public bit EmitMsilCode;

        public bit EmitCliStrings;

        public bit EmitCliBlobs;

        public bit EmitAssemblyRefs;

        public bit EmitCliConstants;

        public bit EmitApiMetadump;

        public bit EmitFieldMetadata;

        public bit EmitMethodDefs;

        public bit EmitCliRowStats;

        public bit EmitMetadataHex;

        public CliEmissionSettings()
        {
            EmitImageContent = true;
            EmitSectionHeaders = true;
            EmitMsilMetadata = true;
            EmitCliStrings = true;
            EmitCliBlobs = true;
            EmitCliConstants = true;
            EmitFieldMetadata = true;
            EmitApiMetadump = false;
            EmitAssemblyRefs = true;
            EmitMethodDefs = true;
            EmitCliRowStats = true;
            EmitMetadataHex = true;
            EmitMsilCode = true;
        }

        public static CliEmissionSettings Default
            => new();
    }
}