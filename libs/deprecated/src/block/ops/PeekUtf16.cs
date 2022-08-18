//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    partial class SRM
    {
        unsafe partial struct MemoryBlock
        {
            [Op]
            public string PeekUtf16(int offset, int byteCount)
            {
                byte* ptr = Pointer + offset;
                if (BitConverter.IsLittleEndian)
                    return new string((char*)ptr, 0, byteCount / sizeof(char));
                else
                    return Encoding.Unicode.GetString(ptr, byteCount);
            }
        }
    }
}