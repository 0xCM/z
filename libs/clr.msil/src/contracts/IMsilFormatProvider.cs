// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    public interface IMsilFormatProvider
    {
        string Int32ToHex(int int32);

        string Int16ToHex(int int16);

        string Int8ToHex(int int8);

        string Argument(int ordinal);

        string EscapedString(string str);

        string Label(int offset);

        string MultipleLabels(int[] offsets);

        string SigByteArrayToString(byte[] sig);
    }
}
