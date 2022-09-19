//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        [ApiHost("sdm.patterns")]
        public readonly partial struct ContentPatterns
        {
            /// <summary>
            /// {Chapter}-{Page} Vol. {Vol}
            /// </summary>
            public const string PageNumber = "{0}-{1} Vol. {2}";

            /// <summary>
            /// {Mnemonic} — {Description}
            /// </summary>
            public const string MnemonicTitle = "{0} — {1}";

            /// <summary>
            /// {Mnemonic0}/{Mnemonic1}
            /// </summary>
            public const string MultiMnemonicTitle1 = "{0}/{1}";

            /// <summary>
            /// {Mnemonic0}/{Mnemonic1}/{Mnemonic2}
            /// </summary>
            public const string MultiMnemonicTitle2 = "{0}/{1}/{2}";

            /// <summary>
            /// {Mnemonic0}/{Mnemonic1}/{Mnemonic2}/{Mnemonic3}
            /// </summary>
            public const string MultiMnemonicTitle3 = "{0}/{1}/{2}/{3}";

            /// <summary>
            /// CHAPTER {Number}
            /// </summary>
            public const string ChapterNumber = "CHAPTER " + "{0}";

            /// <summary>
            /// Table {Number}
            /// </summary>
            public const string TableNumber = "Table " + "{0}";

            /// <summary>
            /// {Chapter}-{Page}
            /// </summary>
            public const string ChapterPage = "{0}-{1}";
        }
    }
}