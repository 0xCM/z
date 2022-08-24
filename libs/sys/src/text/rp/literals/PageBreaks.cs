//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        [RenderLiteral(PageBreak4)]
        public const string PageBreak2 = Dash2;

        [RenderLiteral(PageBreak4)]
        public const string PageBreak4 = Dash4;

        [RenderLiteral(PageBreak5)]
        public const string PageBreak5 = Dash5;

        [RenderLiteral(PageBreak6)]
        public const string PageBreak6 = PageBreak4 + PageBreak2;

        [RenderLiteral(PageBreak10)]
        public const string PageBreak10 = PageBreak5 + PageBreak5;

        [RenderLiteral(PageBreak10)]
        public const string PageBreak12 = PageBreak6 + PageBreak6;

        [RenderLiteral(PageBreak14)]
        public const string PageBreak14 = PageBreak12 + PageBreak2;

        [RenderLiteral(PageBreak16)]
        public const string PageBreak16 = PageBreak14 + PageBreak2;

        [RenderLiteral(PageBreak20)]
        public const string PageBreak20 = PageBreak10 + PageBreak10;

        [RenderLiteral(PageBreak24)]
        public const string PageBreak24 = PageBreak20 + PageBreak4;

        [RenderLiteral(PageBreak30)]
        public const string PageBreak30 = PageBreak24 + PageBreak6;

        [RenderLiteral(PageBreak32)]
        public const string PageBreak32 = PageBreak30 + PageBreak2;

        [RenderLiteral(PageBreak34)]
        public const string PageBreak34 = PageBreak32 + PageBreak2;

        [RenderLiteral(PageBreak36, 36)]
        public const string PageBreak36 = PageBreak34 + PageBreak2;

        [RenderLiteral(PageBreak40, 40)]
        public const string PageBreak40 = PageBreak20 + PageBreak20;

        [RenderLiteral(PageBreak40)]
        public const string PageBreak50 = PageBreak40 + PageBreak10;

        [RenderLiteral(PageBreak60)]
        public const string PageBreak60 = PageBreak40 + PageBreak20;

        [RenderLiteral(PageBreak70)]
        public const string PageBreak70 = PageBreak60 + PageBreak10;

        [RenderLiteral(PageBreak80)]
        public const string PageBreak80 = PageBreak40 + PageBreak40;

        [RenderLiteral(PageBreak120)]
        public const string PageBreak100 = PageBreak80 + PageBreak20;

        [RenderLiteral(PageBreak120, 120)]
        public const string PageBreak120 = PageBreak80 + PageBreak40;

        [RenderLiteral(PageBreak160, 160)]
        public const string PageBreak160 = PageBreak80 + PageBreak80;

        [RenderLiteral(PageBreak180, 180)]
        public const string PageBreak180 = PageBreak160 + PageBreak20;

        [RenderLiteral(PageBreak200, 200)]
        public const string PageBreak200 = PageBreak180 + PageBreak20;

        [RenderLiteral(PageBreak210, 210)]
        public const string PageBreak210 = PageBreak200 + PageBreak10;

        [RenderLiteral(PageBreak220, 220)]
        public const string PageBreak220 = PageBreak200 + PageBreak20;

        [RenderLiteral(PageBreak240, 240)]
        public const string PageBreak240 = PageBreak120 + PageBreak120;

        [RenderLiteral(PageBreak260, 260)]
        public const string PageBreak260 = PageBreak240 + PageBreak20;

        [RenderLiteral(PageBreak500, 500)]
        public const string PageBreak500 = PageBreak100 + PageBreak100 + PageBreak100 + PageBreak100 + PageBreak100;

        [RenderLiteral(PageBreak512, 512)]
        public const string PageBreak512 = PageBreak500 + PageBreak12;

        [RenderLiteral(PageBreak580, 580)]
        public const string PageBreak580 = PageBreak240 + PageBreak240;

        [RenderLiteral(PageBreak600, 600)]
        public const string PageBreak600 = PageBreak500 + PageBreak100;

        [RenderLiteral(PageBreak680, 680)]
        public const string PageBreak680 = PageBreak580 + PageBreak100;

        [RenderLiteral(PageBreak1024, 1024)]
        public const string PageBreak1024 = PageBreak512 + PageBreak512;
    }
}