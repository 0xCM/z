//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IMsgChannel
    {
        void Babble<T>(T content);

        void Babble(string pattern, params object[] args);

        void Status<T>(T content, FlairKind flair = FlairKind.Status);

        void Warn<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null);

        void Error<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null);

        void Row<T>(T content);

        void Row<T>(T content, FlairKind flair);

        void Write<T>(T content);

        void Write<T>(T content, FlairKind flair);

        void Write(string content, FlairKind flair);

        void Write<T>(string name, T value);

        void RowFormat(string format, params object[] parameters)
            => Row(string.Format(format, parameters));
    }
}