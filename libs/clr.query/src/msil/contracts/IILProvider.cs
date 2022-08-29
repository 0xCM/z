// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    public interface IILProvider
    {
        byte[] GetByteArray();

        ExceptionInfo[] GetExceptionInfos();

        byte[] GetLocalSignature();

        int MaxStackSize {get;}
    }
}