//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System.Reflection;

    using Z0;

    /// <summary>
    /// Represents a member selection
    /// </summary>
    public class SelectedMember
    {
        public SelectedMember(MemberInfo Member, int Order, string Alias = null)
        {
            this.Member = Member;
            this.Order = Order;
            this.Alias = Alias;
        }

        public MemberInfo Member { get; }

        public int Order { get; }

        public Option<string> Alias { get; }


        public override string ToString()
            => Alias.Map(
                a => $"{Order} {Member.Name} as {a}",
                () => $"{Order} {Member.Name}");
    }

}