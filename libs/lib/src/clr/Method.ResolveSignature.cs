//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System.Reflection;

    partial class XTend
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