//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    /// <summary>
    /// Specifies application message origination details
    /// </summary>
    [ApiHost]
    public readonly struct AppMsgSource
    {
        [MethodImpl(Inline), Op]
        public static AppMsgSource define(string caller, string file, int? line)
            => new AppMsgSource(caller, file, line);

        /// <summary>
        /// The name of the member that originated the message
        /// </summary>
        public readonly string Caller;

        /// <summary>
        /// The path to the source file in which the message originated
        /// </summary>
        public readonly string File;

        /// <summary>
        /// The source file line number on which the message originated
        /// </summary>
        public readonly uint Line;

        [MethodImpl(Inline)]
        public AppMsgSource(string caller, string file, int? line)
        {
            Caller = caller;
            File = file ?? EmptyString;
            Line = (uint)(line ?? 0);
        }

        public string Format()
            => string.Format(RenderPattern, Path.GetFileName(File), Caller, Line, File);

        public override string ToString()
            => Format();

        public static AppMsgSource Empty
            => new AppMsgSource(EmptyString, EmptyString, 0);

        const string RenderPattern = "{0}/{1}?line = {2} | {3}";

        [MethodImpl(Inline)]
        public static implicit operator EventOrigin(AppMsgSource src)
            => new EventOrigin(src.Caller, src.File, src.Line);
    }
}