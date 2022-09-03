//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public interface ISectionHeader : INamed, ILeveled
        {

        }

        public interface ISectionHeader<E> : ISectionHeader, IElement<E>
            where E :IElement<E>
        {

        }
    }
}