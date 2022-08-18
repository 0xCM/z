//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes a group action on a set
        /// </summary>
        /// <typeparam name="G">The type of the acting group</typeparam>
        /// <typeparam name="R">The type of the target set</typeparam>
        /// <remarks>
        /// For an instance to be law-abiding, the act function must satisfy g(act(h,t)) = act(hg,t) and
        /// act(1,t) = t for all g,h in G and t in T
        /// Also, see https://en.wikipedia.org/wiki/Group_with_operators
        /// </remarks>
        public interface IGroupAction<G,R>
            where G : unmanaged, IGroup<G>

        {
            /// <summary>
            /// Applies a G-element to a T-element
            /// </summary>
            /// <param name="g">The group element</param>
            /// <param name="t">The target element</param>
            R Act(G g, R t);
        }
    }
}