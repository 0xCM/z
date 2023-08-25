//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaReader
    {       
        public IEnumerable<TypeDefinition> GetEnumTypes()
        {
            var @base = GetSystemEnumToken();
            if(@base.IsNonEmpty)
            {
                foreach(var t in GetTypeDefs())
                {
                    if(t.BaseType == @base)
                        yield return t;
                }
            }
        }
    }
}