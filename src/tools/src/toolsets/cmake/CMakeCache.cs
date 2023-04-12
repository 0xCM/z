//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    public class CMakeCache
    {
        public FilePath Path;

        public readonly ReadOnlySeq<IVarAssignment> Vars;

        public CMakeCache(FilePath path, params IVarAssignment[] vars)
        {
            Path = path;
            Vars = vars;
        }
    }
}