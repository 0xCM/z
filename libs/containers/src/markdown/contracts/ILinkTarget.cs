//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public interface ILinkTarget : IElement
        {

        }

        public interface ILinkTarget<E,T> : ILinkTarget, IElement<E>
            where E : ILinkTarget<E,T>
        {
            T Destination {get;}
        }
    }
}