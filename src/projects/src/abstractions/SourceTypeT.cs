//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectModels
    {
        public abstract record class SourceType<T>
            where T : SourceType<T>, new()
        {

        }
    }
}