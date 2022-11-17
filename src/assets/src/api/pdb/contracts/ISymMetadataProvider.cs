//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using Microsoft.DiaSymReader;

    public interface ISymMetadataProvider : ISymReaderMetadataProvider, ISymWriterMetadataProvider, IDisposable
    {

    }
}