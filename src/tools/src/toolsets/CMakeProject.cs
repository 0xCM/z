//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CMakeProject : Project<CMakeProject>
    {
        public CMakeProject()
            : base(sys.alloc<IDbArchive>(3))
        {

        }

        CMakeProject(IDbArchive[] src)
            : base(src)
        {
            
        }

        public ref readonly IDbArchive Source => ref Root(0);

        public ref readonly IDbArchive Build => ref Root(1);

        public ref readonly IDbArchive Install => ref Root(2);
    }   
}