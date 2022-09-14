//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes an app settings collection
    /// </summary>
    public interface IJsonSettings : IEnumerable<ISetting>, IExpr
    {
        Option<string> Setting(string name);

        string this[string name] {get;}

        ReadOnlySeq<ISetting> All {get;}

        IEnumerator<ISetting> IEnumerable<ISetting>.GetEnumerator()
            => (IEnumerator<ISetting>)All.Storage.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => All.Storage.GetEnumerator();            
    }
}