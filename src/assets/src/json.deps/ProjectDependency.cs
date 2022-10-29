//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct JsonDepsModel
    {
        public record struct ProjectDependency
        {
            public string AssemblyName;

            public string AssemblyVersion;
        }
    }
}