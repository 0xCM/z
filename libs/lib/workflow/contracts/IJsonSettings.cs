//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes an app settings collection
    /// </summary>
    public interface IJsonSettings : IEnumerable<ISetting>, ITextual
    {
        FS.FilePath SourcePath {get;}

        Option<string> Setting(string name);

        string this[string name] {get;}

        IEnumerable<ISetting> All {get;}

        IEnumerator<ISetting> IEnumerable<ISetting>.GetEnumerator()
            => All.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => All.GetEnumerator();

    }
}