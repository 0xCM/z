//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Build
    {
        public record struct ShellSpec
        {
            public string ProjectName;

            public string AssemblyName;

            public ShellSpec(string proj, string ass)
            {
                ProjectName = proj;
                AssemblyName = ass;
            }
        }
    }
}