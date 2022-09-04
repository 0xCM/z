//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ApiIdentity
    {
        /// <summary>
        /// Assigns host-independent api member identity to a nongeneric method
        /// </summary>
        /// <param name="src">The source method</param>
        public static _OpIdentity nongeneric(MethodInfo src)
        {
            if(src.IsGenericMethod || src.IsConstructedGenericMethod || src.IsGenericMethodDefinition)
                Throw.e(AppErrors.GenericMethod(src));

            var id = EmptyString;
            id += src.Name;
            id += IDI.PartSep;
            id += sequential(IDI.ArgsOpen, IDI.ArgsClose, IDI.ArgSep, ValueParamIdentities(src));
            return opid(id);
        }
    }
}