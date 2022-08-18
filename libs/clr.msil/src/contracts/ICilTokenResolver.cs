// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    public interface ICilTokenResolver
    {
        MethodBase AsMethod(int token);

        FieldInfo AsField(int token);

        Type AsType(int token);

        string AsString(int token);

        MemberInfo AsMember(int token);

        byte[] AsSignature(int token);
    }
}
