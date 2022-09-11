//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        // [MethodImpl(Inline), Op]
        // public static CliSig sig(MethodInfo src)
        // {
        //     sig(src, out var dst);
        //     return dst;
        // }

        [MethodImpl(Inline), Op]
        public static CliSig sig(MemberInfo src)
        {
            sig(src, out CliSig dst);
            return dst;
        }

        public static bool sig(MemberInfo src, out CliSig dst)
        {
            try
            {
                dst = src.Module.ResolveSignature(src.MetadataToken);
                return true;
            }
            catch
            {
                dst = CliSig.Empty;
                return false;
            }
        }
    }
}