//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEcmaReader
    {
        string String(EcmaStringKey key);

        Guid Guid(EcmaGuidKey key);

        ReadOnlySpan<byte> Blob(EcmaBlobKey key);
    }
}