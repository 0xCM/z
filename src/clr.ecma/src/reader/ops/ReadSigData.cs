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
        public BinaryCode ReadSigData(FieldDefinition src)
            => Blob(src.Signature);

        [MethodImpl(Inline), Op]
        public BinaryCode ReadSigData(MethodDefinition src)
            => Blob(src.Signature);
    }
}