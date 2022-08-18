// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    using System;

    public sealed class ExceptionHandlerInfo
    {
        public ExceptionHandlerInfo(int startAddress, int endAddress, Type type, int kind)
        {
            StartAddress = startAddress;
            EndAddress = endAddress;
            Type = type;
            Kind = (ExceptionHandlerKind)kind;
        }

        public int StartAddress {get;}
        
        public int EndAddress {get;}
        
        public Type Type {get;}
        
        public ExceptionHandlerKind Kind {get;}
    }
}
