//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EcmaModels;

    partial class EcmaReader
    {
        [MethodImpl(Inline), Op]
        public BinaryCode ReadBlobData(BlobHandle src)
            => MD.GetBlobBytes(src);                    
    }
}