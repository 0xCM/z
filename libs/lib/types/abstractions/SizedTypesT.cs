//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class SizedTypes<T>
        where T : ISizedType
    {
        readonly Index<T> Data;

        public virtual ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        protected SizedTypes()
        {
            Data = Index<T>.Empty;
        }
        protected SizedTypes(T[] data)
        {
            Data = data;
        }
    }
}