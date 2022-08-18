//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct RenderCapable
    {
        [Op]
        public static string format(IRenderCapable src)
        {
            var dst = text.buffer();
            src.Render(dst);
            return dst.Emit();
        }

        public static string format<T>(T src)
            where T : IRenderCapable<T>
        {
            var dst = text.buffer();
            src.Render(dst);
            return dst.Emit();
        }
    }
}