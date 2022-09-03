//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Text;

    partial class SRM
    {
        unsafe partial struct MemoryBlock
        {
            [Op]
            public string PeekUtf8(int offset, int byteCount)
                => Encoding.UTF8.GetString(Pointer + offset, byteCount);
        }
    }
}