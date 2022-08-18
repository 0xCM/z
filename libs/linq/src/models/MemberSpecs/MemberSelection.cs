//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class MemberSelection : IEnumerable<SelectedMember>
    {

        public MemberSelection(IEnumerable<SelectedMember> selections)
        {
            Selections = selections.OrderBy(item => item.Order).ToList();
        }

        IReadOnlyList<SelectedMember> Selections { get; }

        IEnumerator<SelectedMember> IEnumerable<SelectedMember>.GetEnumerator()
            =>Selections.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => Selections.GetEnumerator();

    }
}