//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IToolCmdArg : IExpr
    {
        /// <summary>
        /// The argument name, if any
        /// </summary>
        string Name {get;}

        /// <summary>
        /// The (required) argument value
        /// </summary>
        string Value {get;}

        /// <summary>
        /// Specifies whether the argument is a flag and thus the name is the value and conversely
        /// </summary>
        bool IsFlag => false;

        bool INullity.IsEmpty
            => sys.empty(Value);

        bool INullity.IsNonEmpty
            => sys.nonempty(Value);

        string IExpr.Format()
            => Settings.format(Name, Value);
    }

    [Free]
    public interface IToolCmdArg<T> : IToolCmdArg
    {
        new T Value {get;}

        string  IToolCmdArg.Value
            => Value.ToString();
    }
}