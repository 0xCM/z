//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    public abstract class Language : ILanguage
    {
        protected Language(string id, string name)
        {   
            LanguageCode = id;
            LanguageName = name;
        }

        public readonly asci8 LanguageCode;

        public readonly string LanguageName;

        asci8 ILanguage.LanguageCode 
            => LanguageCode;

        string ILanguage.LanguageName 
            => LanguageName;
    }
}