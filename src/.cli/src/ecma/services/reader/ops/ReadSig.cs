//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        [MethodImpl(Inline), Op]
        public BinaryCode ReadSig(FieldDefinition src)
            => ReadBlob(src.Signature);

        [MethodImpl(Inline), Op]
        public BinaryCode ReadSig(MethodDefinition src)
            => ReadBlob(src.Signature);
    }
}