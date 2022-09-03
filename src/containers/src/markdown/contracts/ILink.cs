//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public interface ILink : ILabeled
        {
            ILinkTarget Target {get;}
        }

        public interface ILink<T> : ILink
            where T : ILinkTarget
        {
            new T Target {get;}

            ILinkTarget ILink.Target
                => Target;
        }

        public interface ILink<E,T> : ILink<T>, IElement<E>
            where T : ILinkTarget
            where E : IElement<E>
        {

        }
    }
}