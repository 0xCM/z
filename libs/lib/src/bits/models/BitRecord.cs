//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a record backed by an array of bytes
    /// </summary>
    public struct BitRecord
    {
        readonly Index<byte> Data;

        [MethodImpl(Inline)]
        public BitRecord(byte[] data)
        {
            Data = data;
        }

        public Span<byte> Storage
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }
    }
}