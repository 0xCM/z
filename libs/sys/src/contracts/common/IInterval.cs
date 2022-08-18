//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IInterval : IExpr
    {
        /// <summary>
        ///  Specifies whether the interval contains its left endpoint
        /// </summary>
        bool LeftClosed {get;}

        /// <summary>
        ///  Specifies whether the interval contains its right endpoint
        /// </summary>
        bool RightClosed {get;}

        /// <summary>
        /// The interval classification
        /// </summary>
        IntervalKind Kind {get;}

        /// <summary>
        /// The interval width
        /// </summary>
        ulong Width {get;}

        bool IsDegenerate
            => Width == 0;

        bool IsNonDegenerate
            => Width != 0;

        bool INullity.IsEmpty
            => IsDegenerate;

        bool INullity.IsNonEmpty
            => IsNonDegenerate;

        /// <summary>
        ///  Specifies whether the interval is closed
        /// </summary>
        bool Closed
        {
            [MethodImpl(Inline)]
            get => Kind == IntervalKind.Closed;
        }

        /// <summary>
        ///  Specifies whether the interval is open
        /// </summary>
        bool Open
        {
            [MethodImpl(Inline)]
            get => Kind == IntervalKind.Open;
        }

        /// <summary>
        /// Specifies whether the interval is open on the right and closed on the left, denoted by [Left,Right)
        /// </summary>
        bool RightOpen
        {
            [MethodImpl(Inline)]
            get => Kind == IntervalKind.RightOpen;
        }

        /// <summary>
        /// Specifies whether the interval is open on the left and closed on the right, denoted by (Left,Right]
        /// </summary>
        bool LeftOpen
        {
            [MethodImpl(Inline)]
            get => Kind == IntervalKind.LeftOpen;
        }
    }

    /// <summary>
    /// Characterizes a contiguous segment of homogenous values that lie within left and right boundaries
    /// </summary>
    /// <remarks>
    /// Note that extended real numbers may also serve as endpoints,enabling representations such as (-∞,3] and (-3, ∞).
    /// </remarks>
    [Free]
    public interface IInterval<T> : IInterval, IRange<T>
        where T : unmanaged
    {

    }

    [Free]
    public interface IRange<T>
        where T : unmanaged
    {
        /// <summary>
        /// The least value
        /// </summary>
        T Min {get;}

        /// <summary>
        /// The greatest value
        /// </summary>
        T Max {get;}
    }
}