//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Language]
    public abstract class Language : ILanguage
    {
        public LanguageCode Name {get;}

        protected Language()
        {
            Name = 0;
        }

        protected Language(LanguageCode name)
        {
            Name = name;
        }
    } 
}