//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ApiIdentity
    {
        public static OpIdentity conversion(MethodInfo src)
        {
            var input = src.Parameters();
            if(input.Length == 1)
            {
                const string FormatPattern = "op_{0}_{1}_{2}";
                var source = identify(input[0].ParameterType);
                var target = identify(src.ReturnType);

                if(src.IsImplicitConverter())
                    return opid(string.Format(FormatPattern, "implicit", source, target));
                else if(src.IsExplicitConverter())
                    return opid(string.Format(FormatPattern, "explicit", source, target));
            }
            return opid("!!Error!!");
        }
    }
}