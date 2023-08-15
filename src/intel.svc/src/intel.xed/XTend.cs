//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

using static XedRules;
using static XedModels;

partial class XTend
{
    public static SortedLookup<XedInstClass,Index<XedInstForm>> ClassForms(this Index<InstPattern> src)
        => src.Storage.Where(x => x.InstForm.IsNonEmpty)
                .GroupBy(x => x.InstClass.Classifier)
                .Select(x => (x.Key.Classifier, x.Select(y => y.InstForm).ToIndex()))
                .ToSortedLookup();

    public static SortedLookup<XedInstClass,Index<InstPattern>> ClassPatterns(this Index<InstPattern> src)
        => src.Storage
                .GroupBy(x => x.InstClass)
                .Select(x => (x.Key, x.ToIndex()))
                .ToSortedLookup();

    public static SortedLookup<XedInstClass,Index<InstGroupMember>> ClassGroups(this Index<InstGroup> src)
        => src.SelectMany(x => x.Members).GroupBy(x => x.Class.Classifier).Select(x => (x.Key.Classifier,x.Index())).ToDictionary();
}
