//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiParser : IComparable<ApiParser>
    {
        public readonly string TargetName;

        public readonly Type TargetType;

        public readonly Type Host;

        public readonly ParserContracts.IParser Service;

        public readonly Type ResultType;

        [MethodImpl(Inline)]
        public ApiParser(MethodInfo method, ParserContracts.IParser service)
        {
            TargetName = service.TargetType.DisplayName();
            TargetType = service.TargetType;
            Host = method.DeclaringType;
            Service = service;
            ResultType = method.ReturnType;
        }

        public int CompareTo(ApiParser src)
        {
            var result = TargetName.CompareTo(src.TargetName);
            if(result == 0)
                result = TargetType.AssemblyQualifiedName.CompareTo(src.TargetType.AssemblyQualifiedName);
            return result;
        }
    }
}