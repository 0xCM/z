//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct PeStream : IDisposable
    {
        readonly PEReader PEReader;

        readonly FileStream Stream;

        public readonly MetadataReader Reader;

        public PeStream(FileStream stream, PEReader peReader)
        {
            Stream = stream;
            PEReader = peReader;
            Reader = peReader.GetMetadataReader();
        }

        public void Dispose()
        {
            PEReader?.Dispose();
            Stream?.Dispose();
        }
    }
}