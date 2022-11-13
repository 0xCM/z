// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Z0
{
    partial class ClrQuery
    {
        public static string GetILSig(this MethodBase method)
        {
            try
            {
                if (method == null)
                    return "";

                string res = "";

                if (!method.IsStatic)
                    res = "instance ";

                var mtd = method as MethodInfo;
                Type ret = mtd?.ReturnType ?? typeof(void);

                res += ret.GetILSig() + " ";
                res += method.DeclaringType.GetILSig();
                res += "::";
                res += method.Name;

                if (method.IsGenericMethod)
                    res += "<" + string.Join(",", method.GetGenericArguments().Select(GetILSig)) + ">";

                res += "(" + string.Join(",", method.GetParameters().Select(p => GetILSig(p.ParameterType))) + ")";

                return res;
            }
            catch(Exception e)
            {
                return e.ToString();
            }
        }
    }
}