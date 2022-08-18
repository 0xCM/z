//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ApiSigs
    {
        public static string format(ApiTypeSig src)
        {
            var dst = text.buffer();
            render(src, dst);
            return dst.Emit();
        }

        public static string format(ApiOperationSig src)
        {
            var dst = text.buffer();
            render(src, dst);
            return dst.Emit();
        }

        public static string format(in ApiSig src)
        {
            var dst = text.buffer();
            render(src, dst);
            return dst.Emit();
        }
    }
}