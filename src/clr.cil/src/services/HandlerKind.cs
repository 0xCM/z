// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    public enum ExceptionHandlerKind
    {
        None,
        
        Filter,
        
        Finally,
        
        Fault,
        
        PreserveStack
    }
}
