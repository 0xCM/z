//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EcmaTables;

    partial class EcmaReader
    {
        [MethodImpl(Inline), Op]
        public BinaryCode ReadSigData(FieldDefinition src)
            => ReadBlobData(src.Signature);

        [MethodImpl(Inline), Op]
        public BinaryCode ReadSigData(MethodDefinition src)
            => ReadBlobData(src.Signature);
    }
}