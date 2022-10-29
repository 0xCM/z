// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Z0
{
    public class EcmaConstants
    {
        public const int SizeOfCorHeader = 72;
        public const uint COR20MetadataSignature = 0x424A5342;
        public const int MinimumSizeofMetadataHeader = 16;
        public const int SizeofStorageHeader = 4;
        public const int MinimumSizeofStreamHeader = 8;
        public const string StringStreamName = "#Strings";
        public const string BlobStreamName = "#Blob";
        public const string GUIDStreamName = "#GUID";
        public const string UserStringStreamName = "#US";
        public const string CompressedMetadataTableStreamName = "#~";
        public const string UncompressedMetadataTableStreamName = "#-";
        public const string MinimalDeltaMetadataTableStreamName = "#JTD";
        public const string StandalonePdbStreamName = "#Pdb";
        public const int LargeStreamHeapSize = 0x0001000;
    }
}