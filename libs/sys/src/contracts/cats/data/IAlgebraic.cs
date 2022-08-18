//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    [Free]
    public interface IEquivalenceClass<T>
    {
        /// <summary>
        /// The class representative
        /// </summary>
        T Rep {get;}
    }

    /// <summary>
    /// Characterizes an equivalence class, i.e. a segment of a partition effected via
    /// an equivalence relation
    /// </summary>
    /// <typeparam name="T">The classified type</typeparam>
    [Free]
    public interface IEquivalenceClass<S,T> : ISemigroup<S,T>, IEquivalenceClass<T>//, INonEmpty<S>
        where S : IEquivalenceClass<S,T>, new()
    {

    }

    /// <summary>
    /// Characterizes a partition over a set effected via an equivalence relation.
    /// In this context, a partition is a collection of mutually disjoint subsets
    /// of a given set whose union recovers the original set
    /// </summary>
    /// <typeparam name="C">The equivalence class type</typeparam>
    /// <typeparam name="T">The set domain</typeparam>
    [Free]
    public interface IQuotientSet<C,T>
        where C : IEquivalenceClass<C,T>, new()
        where T : new()
    {
        /// <summary>
        /// Effects a partition via the equivalence
        /// </summary>
        C[] Partition();

        /// <summary>
        /// The canonical surjective projection from the underlying set to the equivalence
        /// partitions that maps a given element to the equivalence class in which it
        /// resides
        /// </summary>
        /// <param name="src">The source value</param>
        C Project(T src);
    }

    /// <summary>
    /// Characterizes a discrete partition over a discrete set and, consequently,
    /// is a constructive presentation of an equivalence relation. In this context, a partition
    /// is a collection of mutually disjoint subsets of a given set whose union
    /// is recovers the original set
    /// </summary>
    /// <typeparam name="T">The element type</typeparam>
    /// <remarks>See https://en.wikipedia.org/wiki/Setoid</remarks>
    [Free]
    public interface ISetoid<C,T> : IQuotientSet<C,T>
        where C : IEquivalenceClass<C,T>, new()
        where T : ISemigroup<T>, new()
    {

    }
}