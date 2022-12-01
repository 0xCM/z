//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text.Json;
    using System.Globalization;
    using System.Linq;

    partial struct JsonData
    {
        /// <summary>
        /// Adapted from https://github.com/dotnet/runtime/blob/36697a52c89caedd014b255695eae2058a9b0546/src/libraries/System.Private.DataContractSerialization/src/System/Runtime/Serialization/Json/XmlJsonReader.cs
        /// </summary>
        /// <param name="src">The json input</param>
        /// <param name="dst">Receives the unescaped text, if successful</param>
        internal static Outcome unescape(string src, out string dst)
        {
            dst = EmptyString;
            var result = Outcome.Success;
            if(src == null)
                return Outcome.fail(RP.Null);

            var buffer = new StringBuilder();
            int startIndex = 0, count = 0;
            for (int i = 0; i < src.Length; i++)
            {
                if (src[i] == '\\')
                {
                    i++;

                    buffer.Append(src, startIndex, count);

                    if (i >= src.Length)
                    {
                        result = Outcome.fail(string.Format("{0}>={1}", i, src.Length));
                        break;
                    }

                    switch (src[i])
                    {
                        case '"':
                        case '\'':
                        case '/':
                        case '\\':
                            buffer.Append(src[i]);
                            break;
                        case 'b':
                            buffer.Append('\b');
                            break;
                        case 'f':
                            buffer.Append('\f');
                            break;
                        case 'n':
                            buffer.Append('\n');
                            break;
                        case 'r':
                            buffer.Append('\r');
                            break;
                        case 't':
                            buffer.Append('\t');
                            break;
                        case 'u':
                            if ((i + 3) >= src.Length)
                            {
                                result = Outcome.fail(string.Format("{0} + 3 >={1}", i, src.Length));
                                break;
                            }

                            result = parse(src.Substring(i + 1, 4), NumberStyles.HexNumber, out char c);
                            if(result)
                                buffer.Append(c);
                            else
                                break;
                            i += 4;
                            break;
                    }
                    startIndex = i + 1;
                    count = 0;
                }
                else
                    count++;
            }

            if(count > 0)
                buffer.Append(src, startIndex, count);

            dst = buffer.ToString();
            return result;
        }


        /// <summary>
        /// Adapted from https://github.com/dotnet/runtime/blob/36697a52c89caedd014b255695eae2058a9b0546/src/libraries/System.Private.DataContractSerialization/src/System/Runtime/Serialization/Json/XmlJsonReader.cs
        /// </summary>
        static bool parse(string src, NumberStyles style, out char dst)
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
        static bool parse(string value, NumberStyles style, out int dst)
            => int.TryParse(value, style, NumberFormatInfo.InvariantInfo, out dst);

    }
}