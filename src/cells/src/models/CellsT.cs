//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Cells<T> : Seq<Cells<T>,T>
    {
        public Cells()
        {

        }
        [MethodImpl(Inline)]
        public Cells(T[] src)
            : base(src)
        {

        }

        [MethodImpl(Inline)]
        public static implicit operator Cells<T>(T[] src)
            => new Cells<T>(src);    
    }
}