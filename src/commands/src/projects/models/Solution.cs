//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Solution : Project, ISolution
    {
        public ReadOnlySeq<IProject> Projects {get;}

        public Solution()
        {
            Projects = sys.empty<IProject>();
        }

        public Solution(string name, IDbArchive root, ReadOnlySeq<IProject> src)
            : base(name, root)
        {
            Projects = src;
        }
    }
}