//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        public static string CodeName(this Type src)
        {
            if(src.IsGenericMethodParameter || src.IsGenericParameter || src.IsGenericTypeParameter)
                return src.Name;

            if(src.IsEnum)
                return src.Name;

            if(src.IsPointer)
                return $"{src.GetElementType().CodeName()}*";

            if(src.IsSystemDefined())
            {
                var kw = CsData.keyword(src);
                return string.IsNullOrWhiteSpace(kw) ? src.Name : kw;
            }

            if(src.IsGenericType && !src.IsRef())
            {
                var name = src.Name;
                var args = src.GetGenericArguments();
                if(args.Length != 0)
                {
                    name = name.Replace($"`{args.Length}", string.Empty);
                    name += "<";
                    for(var i= 0; i<args.Length; i++)
                    {
                        name += args[i].CodeName();
                        if(i != args.Length - 1)
                            name += ",";
                    }
                    name += ">";
                }
                return name;
            }

            if(src.IsRef())
                return src.GetElementType().CodeName();

            return src.Name;
        }
    }
}