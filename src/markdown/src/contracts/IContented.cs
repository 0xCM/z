//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public interface IContented : IElement
        {
            dynamic Content {get;}
        }

        public interface IContented<T> : IContented
        {
            new T Content {get;}

            dynamic IContented.Content
                => Content;
        }

        public interface IContented<E,T> : IContented<T>, IElement<E>
            where E : IElement<E>
        {

        }
    }
}