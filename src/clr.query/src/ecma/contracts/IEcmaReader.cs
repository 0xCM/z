//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEcmaReader
    {
        string String(EcmaStringIndex key);

        Guid Guid(EcmaGuidIndex key);

        ReadOnlySpan<byte> Blob(EcmaBlobIndex key);
    }
}