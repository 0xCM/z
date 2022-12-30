//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Globalization;

    partial class Json
    {
        /// <summary>
        /// Adapted from https://github.com/dotnet/runtime/blob/36697a52c89caedd014b255695eae2058a9b0546/src/libraries/System.Private.DataContractSerialization/src/System/Runtime/Serialization/Json/XmlJsonReader.cs
        /// </summary>
        public static bool parse(string src, NumberStyles style, out char dst)
        {
            var result = parse(src, style, out int value);
            try
            {
                dst = Convert.ToChar(value);
            }
            catch(Exception)
            {
                dst = default;
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Adapted from https://github.com/dotnet/runtime/blob/36697a52c89caedd014b255695eae2058a9b0546/src/libraries/System.Private.DataContractSerialization/src/System/Runtime/Serialization/Json/XmlJsonReader.cs
        /// </summary>
        public static bool parse(string value, NumberStyles style, out int dst)
            => int.TryParse(value, style, NumberFormatInfo.InvariantInfo, out dst);
    }
}
