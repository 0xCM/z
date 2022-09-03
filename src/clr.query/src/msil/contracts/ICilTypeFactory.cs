// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    using System;

    public interface ICilTypeFactory
    {
        Type FromHandle(IntPtr handle);
        
        Type MakeArrayType(Type type);
        
        Type MakeArrayType(Type type, int rank);
        
        Type MakeByRefType(Type type);
        
        Type MakePointerType(Type type);
        
        Type MakeGenericType(Type definition, Type[] arguments);
    }
}

