//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class CmdResults
    {
        public static string format<T>(ICmd<T> src)
            where T : struct, ICmd<T>
        {
            var buffer = text.buffer();
            buffer.AppendFormat("{0}{1}", src.CmdId, Chars.LParen);

            var fields = ClrFields.instance(typeof(T));
            if(fields.Length != 0)
                render(__makeref(src), fields, buffer);

            buffer.Append(Chars.RParen);
            return buffer.Emit();
        }

        static void render(TypedReference src, ReadOnlySpan<ClrFieldAdapter> fields, ITextBuffer dst)
        {
            var count = fields.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                dst.AppendFormat(RpOps.Assign, field.Name, field.GetValueDirect(src));
                if(i != count - 1)
                    dst.Append(", ");
            }
        }

        /// <summary>
        /// Defines a <see cref='CmdResult{C,P}'/>
        /// </summary>
        /// <param name="cmd">The completed command</param>
        /// <param name="payload"></param>
        /// <param name="ok">Whether the command succeeded</param>
        /// <typeparam name="C">The command type</typeparam>
        /// <typeparam name="P">The payload type</typeparam>
        [MethodImpl(Inline), Op]
        public static CmdResult<C,P> define<C,P>(C cmd, bool ok, P payload, string msg = EmptyString)
            where C : struct, ICmd<C>
                => new CmdResult<C,P>(cmd, ok, payload, msg);

        /// <summary>
        /// Defines a <see cref='CmdResult'/>
        /// </summary>
        /// <param name="cmd">The completed command</param>
        /// <param name="ok">Whether the command succeeded</param>
        [MethodImpl(Inline), Op]
        public static CmdResult define(ICmd cmd, bool ok)
            => new CmdResult(cmd.CmdId, ok);

        /// <summary>
        /// Defines a <see cref='CmdResult'/>
        /// </summary>
        /// <param name="cmd">The completed command</param>
        /// <param name="ok">Whether the command succeeded</param>
        [MethodImpl(Inline), Op]
        public static CmdResult define(ICmd cmd, bool ok, dynamic payload)
            => new CmdResult(cmd.CmdId, ok, payload);

        /// <summary>
        /// Defines a <see cref='CmdResult{C}'/>
        /// </summary>
        /// <param name="cmd">The completed command</param>
        /// <param name="ok">Whether the command succeeded</param>
        /// <typeparam name="C">The command type</typeparam>
        [MethodImpl(Inline), Op]
        public static CmdResult<C> define<C>(C cmd, bool ok)
            where C : struct, ICmd<C>
                => new CmdResult<C>(cmd, ok);

        /// <summary>
        /// Defines a <see cref='CmdResult{C}'/>
        /// </summary>
        /// <param name="cmd">The completed command</param>
        /// <param name="ok">Whether the command succeeded</param>
        /// <typeparam name="C">The command type</typeparam>
        [MethodImpl(Inline), Op]
        public static CmdResult<C> define<C>(C cmd, bool ok, dynamic payload)
            where C : struct, ICmd<C>
                => new CmdResult<C>(cmd, ok, payload);


        [MethodImpl(Inline)]
        public static CmdResult<C> ok<C>(C spec)
            where C : struct, ICmd
                => new CmdResult<C>(spec, true);

        [MethodImpl(Inline)]
        public static CmdResult<C> ok<C>(C spec, string msg)
            where C : struct, ICmd
                => new CmdResult<C>(spec, true, msg);

        [MethodImpl(Inline)]
        public static CmdResult<C,P> ok<C,P>(C spec, P payload, string msg = EmptyString)
            where C : struct, ICmd
                => new CmdResult<C,P>(spec, true, payload, msg);

        [MethodImpl(Inline), Op]
        public static CmdResult fail(ICmd cmd)
            => new CmdResult(cmd.CmdId, false);

        [MethodImpl(Inline), Op]
        public static CmdResult fail(ICmd cmd, Exception e)
            => new CmdResult(cmd.CmdId, e);

        public static CmdResult<C> fail<C>(C cmd)
            where C : struct, ICmd
                => new CmdResult<C>(cmd, false);

        public static CmdResult<C> fail<C>(C cmd, Exception e)
            where C : struct, ICmd
                => new CmdResult<C>(cmd, e);

        public static CmdResult<C> fail<C>(C cmd, string message)
            where C : struct, ICmd
                => new CmdResult<C>(cmd, false, message);
    }
}