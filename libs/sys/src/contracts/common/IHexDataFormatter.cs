//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IHexDataFormatter
    {
        void FormatLines(ReadOnlySpan<byte> data, Action<string> receiver);

        string FormatLine(ReadOnlySpan<byte> data, ulong offset, char delimiter);
    }
}