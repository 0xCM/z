//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ProjectModels;

    partial class ProjectServices
    {
        public static void kind(string src, out ProjectKind dst)
        {
            dst = ProjectKind.None;
            switch(src.ToLower())
            {
                case "binary":
                    dst = ProjectKind.Binary;
                break;
            }
        }
    }
}