// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    public sealed class ModuleScopeTokenResolver : ICilTokenResolver
    {
        readonly Module _module;

        readonly MethodBase _enclosingMethod;

        readonly Type[] _methodContext;

        readonly Type[] _typeContext;

        public ModuleScopeTokenResolver(MethodBase method)
        {
            _enclosingMethod = method;
            _module = method.Module;
            _methodContext = (method is ConstructorInfo) ? null : method.GetGenericArguments();
            _typeContext = (method.DeclaringType == null) ? null : method.DeclaringType.GetGenericArguments();
        }

        public MethodBase AsMethod(int token)
            => _module.ResolveMethod(token, _typeContext, _methodContext);

        public FieldInfo AsField(int token)
            => _module.ResolveField(token, _typeContext, _methodContext);

        public Type AsType(int token)
            => _module.ResolveType(token, _typeContext, _methodContext);

        public MemberInfo AsMember(int token)
            => _module.ResolveMember(token, _typeContext, _methodContext);

        public string AsString(int token)
            => _module.ResolveString(token);

        public byte[] AsSignature(int token)
            => _module.ResolveSignature(token);
    }
}
