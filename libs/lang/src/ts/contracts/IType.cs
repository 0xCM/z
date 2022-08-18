//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    partial class TS
    {
        public interface IType
        {
            TypeKind Kind {get;}
        }
                
        public interface IType<T> : IType
            where T : IType<T>, new()
        {


        }
    }
}