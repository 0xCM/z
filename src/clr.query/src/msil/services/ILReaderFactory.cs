// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    using System.Reflection.Emit;

    public class ILReaderFactory
    {
        public static ILReader Create(object obj)
        {
            Type type = obj.GetType();

            if (type == s_dynamicMethodType || type == s_rtDynamicMethodType)
            {
                DynamicMethod dm;
                if (type == s_rtDynamicMethodType)
                {
                    //
                    // if the target is RTDynamicMethod, get the value of
                    // RTDynamicMethod.m_owner instead
                    //
                    dm = (DynamicMethod)s_fiOwner.GetValue(obj);
                }
                else
                {
                    dm = obj as DynamicMethod;
                }

                return new ILReader(new DynamicMethodILProvider(dm), new DynamicScopeTokenResolver(dm));
            }

            throw new NotSupportedException($"Reading IL from type '{type}' is currently not supported.");
        }

        static readonly Type s_dynamicMethodType = Type.GetType("System.Reflection.Emit.DynamicMethod", throwOnError: true);

        static readonly Type s_runtimeMethodInfoType = Type.GetType("System.Reflection.RuntimeMethodInfo", throwOnError: true);

        static readonly Type s_runtimeConstructorInfoType = Type.GetType("System.Reflection.RuntimeConstructorInfo", throwOnError: true);

        static readonly Type s_rtDynamicMethodType = Type.GetType("System.Reflection.Emit.DynamicMethod+RTDynamicMethod", throwOnError: true);

        static readonly FieldInfo s_fiOwner = s_rtDynamicMethodType.GetFieldAssert("m_owner");
    }
}