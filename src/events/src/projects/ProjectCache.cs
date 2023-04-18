//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class ProjectCache
    {
       static IProject Project;

        public static ref readonly IProject project()
        {
            if(Project == null)
                sys.@throw("Project is null");
            return ref Project;
        }

        [MethodImpl(Inline)]
        public static ref readonly IProject project(IProject src)
        {
            Project = src;
            return ref Project;
        }
        
    }
}