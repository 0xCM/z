//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct RpOps
    {
        public static string[] slots(byte i0, byte count, short pad)
        {
            var dst = alloc<string>(count);
            var j=i0;
            for(byte i=0; i<count; i++,j++)
                seek(dst,i) = slot(j,pad);
            return dst;
        }

        public static string[] slots(byte i0, short[] pad)
        {
            var count = pad.Length;
            var j=i0;
            var dst = alloc<string>(count);
            for(byte i=0; i<count; i++, j++)
                seek(dst,i) = slot(j,skip(pad,i));
            return dst;
        }

        public static string slots(string sep, params short[] pad)
        {
            var dst = text.buffer();
            var count = pad.Length;
            for(byte i=0; i<count; i++)
            {
                dst.Append(slot(i, pad[i]));
                if(i != count - 1)
                    dst.Append(sep);
            }
            return dst.Emit();
        }

        public static string slots(char sep, params short[] pad)
        {
            var dst = text.buffer();
            var count = pad.Length;
            for(byte i=0; i<count; i++)
            {
                dst.Append(slot(i, pad[i]));
                if(i != count - 1)
                    dst.Append(sep);
            }
            return dst.Emit();
        }
    }
}