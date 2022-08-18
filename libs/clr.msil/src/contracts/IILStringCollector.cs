// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    public interface IILStringCollector
    {
        void Process(ILInlineInstruction ilInstruction, string operandString);
    }
}
