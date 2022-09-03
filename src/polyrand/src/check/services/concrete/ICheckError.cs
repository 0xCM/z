//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;

    public interface ICheckError
    {
        void Print(IAppMsg message)
            => Terminal.Get().WriteMessage(message);

        IAppMsg Describe(Exception e, string title, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        {
            var msg = new StringBuilder();
            msg.AppendLine($"{title}: Failure ocuurred at {caller} {file} {line}");
            msg.AppendLine(e?.ToString() ?? string.Empty);
            return AppMsg.define($"{msg.ToString()}", LogLevel.Error);
        }

        void Print(Exception e, string title, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Print(Describe(e, title, caller,file,line));
    }
}