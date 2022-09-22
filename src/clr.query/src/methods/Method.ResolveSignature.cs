//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        public static CliSig ResolveSignature(this MethodInfo src)
        {
            try
            {
                return src.Module.ResolveSignature(src.MetadataToken);
            }
            catch
            {
                return CliSig.Empty;
            }
        }
    }
}