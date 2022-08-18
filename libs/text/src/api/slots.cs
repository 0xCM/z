//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        public static string[] slots(byte i0, byte count, short pad)
        {
            var dst = sys.alloc<string>(count);
            var j=i0;
            for(byte i=0; i<count; i++,j++)
                dst[i] = slot(j,pad);
            return dst;
        }

        public static string[] slots(byte i0, short[] pad)
        {
            var count = pad.Length;
            var j=i0;
            var dst = sys.alloc<string>(count);
            for(byte i=0; i<count; i++, j++)
                dst[i] = slot(j, pad[i]);
            return dst;
        }

        public static string slots(string sep, params short[] pad)
        {
            var dst = new StringBuilder();
            var count = pad.Length;
            for(byte i=0; i<count; i++)
            {
                dst.Append(slot(i, pad[i]));
                if(i != count - 1)
                    dst.Append(sep);
            }
            return dst.ToString();
        }

        public static string slots(char sep, params short[] pad)
        {
            var dst = new StringBuilder();
            var count = pad.Length;
            for(byte i=0; i<count; i++)
            {
                dst.Append(slot(i, pad[i]));
                if(i != count - 1)
                    dst.Append(sep);
            }
            return dst.ToString();
        }
    }
}