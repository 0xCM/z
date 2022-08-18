//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ApiIdentity
    {
        /// <summary>
        /// Assigns host-independent api member identity to a generic method; if the
        /// source method is nongeneric, returns <see cref='OpIdentityG.Empty' />
        /// </summary>
        /// <param name="src">The source method</param>
        public static OpIdentityG generic(MethodInfo src)
        {
            if(!src.IsGenericMethod)
                return OpIdentityG.Empty;

            var id = src.Name;
            id += IDI.PartSep;
            id += IDI.Generic;

            var args = src.GetParameters();
            var argtypes = src.ParameterTypes(true);
            var last = string.Empty;
            for(var i=0; i<argtypes.Length; i++)
            {
                var argtype = argtypes[i];
                if(i != 0 && last.IsNotBlank())
                    id += IDI.PartSep;

                last = EmptyString;

                if(args[i].IsParametric())
                    last = parameter(args[i]);
                else if(argtype.IsOpenGeneric())
                {
                    if(argtype.IsVector())
                        last = text.concat(IDI.Vector, width(argtype).FormatValue());
                    else if(argtype.IsSpanBlock())
                        last = text.concat(IDI.Block, width(argtype).FormatValue());
                    else if(SpanTypes.IsSystemSpan(argtype))
                        last = SpanTypes.kind(argtype).Format();
                }

                id += last;
            }

            return new OpIdentityG(id);
        }
    }
}