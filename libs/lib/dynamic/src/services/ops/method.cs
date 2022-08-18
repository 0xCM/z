//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Reflection.Emit;

    partial class Dynop
    {
        [Op]
        internal static DynamicMethod method(string name, Type owner, Type @return, params Type[] args)
            => new DynamicMethod(name: name,
                attributes: MethodAttributes.Public | MethodAttributes.Static,
                callingConvention: CallingConventions.Standard,
                returnType: @return,
                parameterTypes: args,
                owner: owner,
                skipVisibility: false);
    }
}