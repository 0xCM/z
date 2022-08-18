//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITerminal
    {
        void SetTerminationHandler(Action handler);

        void WriteLine();

        void WriteLine(object src);

        void WriteLine(string src, FlairKind kind);

        void WriteChar(char c, FlairKind? color = null);

        void WriteMessage(IAppMsg msg, FlairKind? color = null);

        void WriteLine<F>(F src, FlairKind color)
            where F : ITextual;

        string ReadLine(IAppMsg msg = null);

        char ReadKey(IAppMsg msg = null);
    }
}