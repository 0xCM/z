//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Language<L> : Language
        where L : Language<L>, new()
    {
        protected Language(LanguageCode name)
            : base(name)
        {

        }
    }
}