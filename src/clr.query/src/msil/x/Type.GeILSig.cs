// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Z0
{
    using System.Linq;

    partial class ClrQuery
    {
        public static string GetILSig(this Type type)
            => GetILSig(type?.GetTypeInfo());

        public static string GetILSig(this TypeInfo type)
        {
            if (type == null)
            {
                return "";
            }

            if (type.IsArray)
            {
                if (type.GetElementType().MakeArrayType().GetTypeInfo() == type)
                {
                    return GetILSig(type.GetElementType()) + "[]";
                }
                else
                {
                    string bounds = string.Join(",", Enumerable.Repeat("...", type.GetArrayRank()));
                    return GetILSig(type.GetElementType()) + "[" + bounds + "]";
                }
            }
            else if (type.IsGenericType && !type.IsGenericTypeDefinition && !type.IsGenericParameter /* TODO */)
            {
                string args = string.Join(",", type.GetGenericArguments().Select(GetILSig));
                string def = GetILSig(type.GetGenericTypeDefinition());
                return def + "<" + args + ">";
            }
            else if (type.IsByRef)
            {
                return GetILSig(type.GetElementType()) + "&";
            }
            else if (type.IsPointer)
            {
                return GetILSig(type.GetElementType()) + "*";
            }
            else
            {
                var res = default(string);
                if (!s_primitives.TryGetValue(type, out res))
                {
                    res = "[" + type.Assembly.GetName().Name + "]" + type.FullName;

                    if (type.IsValueType)
                    {
                        res = "valuetype " + res;
                    }
                    else
                    {
                        res = "class " + res;
                    }
                }

                return res;
            }
        }

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

        static readonly Dictionary<TypeInfo, string> s_primitives = new Dictionary<Type,string>
        {
            { typeof(object), "object" },
            { typeof(void), "void" },
            { typeof(IntPtr), "native int" },
            { typeof(UIntPtr), "native uint" },
            { typeof(char), "char" },
            { typeof(string), "string" },
            { typeof(bool), "bool" },
            { typeof(float), "float32" },
            { typeof(double), "float64" },
            { typeof(sbyte), "int8" },
            { typeof(short), "int16" },
            { typeof(int), "int32" },
            { typeof(long), "int64" },
            { typeof(byte), "uint8" },
            { typeof(ushort), "uint16" },
            { typeof(uint), "uint32" },
            { typeof(ulong), "uint64" },
        }.ToDictionary(kv => kv.Key.GetTypeInfo(), kv => kv.Value);
    }
}