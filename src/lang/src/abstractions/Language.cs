//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    // [Language]
    // public abstract class Language : ILanguage
    // {
    //     public LanguageCode Name {get;}

    //     protected Language()
    //     {
    //         Name = 0;
    //     }

    //     protected Language(LanguageCode name)
    //     {
    //         Name = name;
    //     }
    // }     
    public abstract class Language : ILanguage
    {
        protected Language(string id, string name)
        {   
            LanguageCode = id;
            LanguageName = name;
        }

        public readonly @string LanguageCode;

        public readonly string LanguageName;

        @string ILanguage.LanguageCode 
            => LanguageCode;

        string ILanguage.LanguageName 
            => LanguageName;
    }
}