//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public interface ISection : INamed
        {
            uint Index {get;}

            ISectionHeader Header {get;}

            @string INamed.Name
                => Header.Name;
        }

        public interface ISection<T> : ISection, IContented<T>
        {

        }


        public interface ISection<E,T> : ISection<T>, IElement<E>
            where E : IElement<E>
        {

        }

        public interface ISection<E,H,T> : ISection<T>, IElement<E>
            where E : IElement<E>
            where H : ISectionHeader
        {
            new H Header {get;}

            ISectionHeader ISection.Header
                => Header;
        }
    }
}