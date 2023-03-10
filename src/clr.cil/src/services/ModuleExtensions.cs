// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    using System.Linq;

    public static class ModuleExtensions
    {
        static readonly MethodInfo s_resolveMethod = GetMethodInfo(nameof(ResolveMethod));

        static readonly MethodInfo s_resolveField = GetMethodInfo(nameof(ResolveField));

        static readonly MethodInfo s_resolveType = GetMethodInfo(nameof(ResolveType));

        static readonly MethodInfo s_resolveMember = GetMethodInfo(nameof(ResolveMember));

        static readonly MethodInfo s_resolveString = GetMethodInfo(nameof(ResolveString));

        static readonly MethodInfo s_resolveSignature = GetMethodInfo(nameof(ResolveSignature));

        public static MethodBase ResolveMethod(this Module module, int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
            => Invoke<MethodBase>(s_resolveMethod, module, metadataToken, genericTypeArguments, genericMethodArguments);

        public static FieldInfo ResolveField(this Module module, int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
            => Invoke<FieldInfo>(s_resolveField, module, metadataToken, genericTypeArguments, genericMethodArguments);

        public static Type ResolveType(this Module module, int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
            => Invoke<Type>(s_resolveType, module, metadataToken, genericTypeArguments, genericMethodArguments);

        public static MemberInfo ResolveMember(this Module module, int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
            => Invoke<MemberInfo>(s_resolveMember, module, metadataToken, genericTypeArguments, genericMethodArguments);

        public static byte[] ResolveSignature(this Module module, int metadataToken)
            => Invoke<byte[]>(s_resolveSignature, module, metadataToken);

        public static string ResolveString(this Module module, int metadataToken)
            => Invoke<string>(s_resolveString, module, metadataToken);

        static MethodInfo GetMethodInfo(string name)
        {
            Type[] parameterTypes = typeof(ModuleExtensions).GetMethod(name).GetParameters().Skip(1).Select(p => p.ParameterType).ToArray();
            return typeof(Module).GetMethod(name, parameterTypes);
        }

        static T Invoke<T>(MethodInfo method, Module module, params object[] args)
            => (T)method.Invoke(module, args);
    }
}
