// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    public class DefaultTypeFactory : ICilTypeFactory
    {
        public static readonly ICilTypeFactory Instance = new DefaultTypeFactory();

        protected DefaultTypeFactory() { }

        static readonly MethodInfo s_GetTypeFromHandleUnsafe = typeof(Type).RequireMethod("GetTypeFromHandleUnsafe");

        public virtual Type FromHandle(IntPtr handle)
            => (Type)s_GetTypeFromHandleUnsafe.Invoke(null, new object[] {handle});

        public Type MakeGenericType(Type definition, Type[] arguments)
            => definition.MakeGenericType(arguments);

        public Type MakeArrayType(Type type)
            => type.MakeArrayType();

        public Type MakeArrayType(Type type, int rank)
            => type.MakeArrayType(rank);

        public Type MakeByRefType(Type type)
            => type.MakeByRefType();

        public Type MakePointerType(Type type)
            => type.MakePointerType();
    }
}
