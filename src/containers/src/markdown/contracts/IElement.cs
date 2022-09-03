//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Markdown
    {
        public interface IElement : ITextual
        {

        }

        public interface IElement<T> : IElement, IEquatable<T>
            where T : IElement<T>
        {


        }
    }
}