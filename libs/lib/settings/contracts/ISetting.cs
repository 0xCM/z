//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a nonparametric application setting
    /// </summary>
    public interface ISetting : INamed
    {
        /// <summary>
        /// The setting value
        /// </summary>
        string Value {get;}

        string Format(char sep)
            => $"{Name}{sep}{Value}";
    }

    public interface ISetting<T> : ISetting
    {
        new T Value {get;}

        string ISetting.Value
            => Value.ToString();
    }

    public interface ISetting<K,V> : ISetting<V>, INamed<K>
        where K : IExpr, IDataType
    {

    }
}