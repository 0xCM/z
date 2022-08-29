//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    using System.Text;
    public readonly struct CliSigFormat
    {
        public static string format(byte[] sig)
        {
            var sb = new StringBuilder();
            int length = sig.Length;
            for (int i = 0; i < length; i++)
            {
                if (i == 0) sb.AppendFormat("SIG [");
                else sb.AppendFormat(" ");
                sb.Append(Int8ToHex(sig[i]));
            }
            sb.AppendFormat("]");
            return sb.ToString();
        }

        static string Int8ToHex(int int8)
            => int8.ToString("X2");
    }
}