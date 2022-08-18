//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class ServiceAttribute : Attribute
    {

        public ServiceAttribute()
        {
            ContractType = typeof(void);
        }

        public ServiceAttribute(Type contract)
        {
            ContractType = contract;
        }

        public Type ContractType {get;}
    }

}