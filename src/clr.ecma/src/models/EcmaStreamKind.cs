//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = EcmaConstants;

    public enum EcmaStreamKind : byte
    {
        [Symbol("")]
        None,

        [Symbol(K.StringStreamName)]
        String,

        [Symbol(K.BlobStreamName)]
        Blob,

        [Symbol(K.GUIDStreamName)]
        Guid,

        [Symbol(K.UserStringStreamName)]
        UserString,

        [Symbol(K.CompressedMetadataTableStreamName)]
        CompressedTable,

        [Symbol(K.UncompressedMetadataTableStreamName)]
        UncompressedTable,

        [Symbol(K.MinimalDeltaMetadataTableStreamName)]
        MinimalDeltaTable,

        [Symbol(K.StandalonePdbStreamName)]
        StandalonePdb,
    }
}