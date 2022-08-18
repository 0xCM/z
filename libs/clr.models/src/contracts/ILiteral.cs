//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a representation of a compile-time literal
    /// </summary>
    [Free]
    public interface ILiteral : INullity, ITextual
    {
        /// <summary>
        /// A locally-scoped identifier
        /// </summary>
        string Name {get;}

        /// <summary>
        /// The literal data
        /// </summary>
        object Data {get;}

        /// <summary>
        /// The literal's text representation
        /// </summary>
        string Text {get;}

        bool Polymorphic
             => false;

        Type SystemType
            => Data.GetType();

        TypeCode TypeCode
            => Type.GetTypeCode(SystemType);

        bool IsEnum
            => SystemType.IsEnum;

        string ITextual.Format()
            => Text;

        bool IsAnonymous
            => string.IsNullOrWhiteSpace(Name);
    }

    /// <summary>
    /// Characterizes compile-time literal representation
    /// </summary>
    [Free]
    public interface ILiteral<H> : ILiteral, INullary<H>, IEquatable<H>
        where H : struct, ILiteral<H>
    {

    }

    /// <summary>
    /// Characterizes compile-time literal representation
    /// </summary>
    [Free]
    public interface ILiteral<H,L> : ILiteral<H>
        where H : struct, ILiteral<H,L>
    {
        /// <summary>
        /// The literal data
        /// </summary>
        new L Data {get;}

        object ILiteral.Data
            => Data;
    }
}