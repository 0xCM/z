//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class XedZ
{
    public record FormRules
    {

        public readonly List<FormRule> Rules;

        public FormRules()
        {
            Rules = new();
        }
    }
}
