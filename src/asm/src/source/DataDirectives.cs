//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[ApiHost]
public readonly struct DataDirectives
{
    public struct Shape
    {
        public int N1;

        public int N2;

        public int N4;

        public int N8;

        public string Format()
        {
            var dst = text.buffer();
            var segs = 0;
            if(N1 != 0)
            {
                dst.AppendFormat("{0}:{1}", nameof(N1), N1);
                segs++;
            }

            if(N2 != 0)
            {
                if(segs != 0)
                    dst.Append(", ");

                dst.AppendFormat("{0}:{1}", nameof(N2), N2);
                segs++;
            }

            if(N4 != 0)
            {
                if(segs != 0)
                    dst.Append(", ");
                dst.AppendFormat("{0}:{1}", nameof(N4), N4);
                segs++;
            }

            if(N8 != 0)
            {
                if(segs != 0)
                    dst.Append(", ");
                dst.AppendFormat("{0}:{1}", nameof(N8), N8);
                segs++;
            }

            return dst.Emit();
        }

        public override string ToString()
            => Format();

    }

    [MethodImpl(Inline), Op]
    public static Shape shape(int n1 = 0, int n2 = 0, int n4 = 0, int n8 = 0)
    {
        var dst = new Shape();
        dst.N1 = n1;
        dst.N2 = n2;
        dst.N4 = n4;
        dst.N8 = n8;
        return dst;
    }

    [Op]
    public static Shape shape(ReadOnlySpan<byte> src)
    {
        var dst = default(Shape);
        return shape(src,ref dst);
    }

    [Op]
    static ref Shape shape(ReadOnlySpan<byte> src, ref Shape dst)
    {
        const byte N8 = 8;
        const byte N4 = 4;
        const byte N2 = 2;
        const byte N1 = 1;

        var count = src.Length;
        if(count == 0)
            return ref dst;

        var mod = -1;
        var div = 0;
        while(mod != 0 && count != 0)
        {
            if(count >= N8)
            {
                div = count/N8;
                dst.N8 = div;
                mod = count/N8;
                count -= div*N8;
            }
            else if(count >= N4)
            {
                div = count/N4;
                dst.N4 = div;
                mod = count/N4;
                count -= div*N4;
            }
            else if(count >= N2)
            {
                div = count/N2;
                dst.N2 = div;
                mod = count/N2;
                count -= div*N2;
            }
            else if(count == 1)
            {
                div = 1;
                dst.N1 = div;
                mod = 0;
                count -= div*N1;
            }
        }

        return ref dst;
    }
}
