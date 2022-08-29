//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines statistical distribution classifiers
    /// </summary>
    public enum DistributionKind : uint
    {        
        /// <summary>
        /// Identifies a uniform distribution
        /// </summary>
        Uniform = Pow2.T01,

        /// <summary>
        /// Identifies a uniform distribution bound to a particular range
        /// </summary>
        UniformRange = Pow2.T02,

        /// <summary>
        /// Identifies a bitwise uniform distribution
        /// </summary>
        UniformBits = Pow2.T03,

        /// <summary>
        /// Identifies a Bernoulli distribution
        /// </summary>
        Bernoulli  = Pow2.T04,

        /// <summary>
        /// Identifies a Beta distribution
        /// </summary>
        Beta = Pow2.T05,

        /// <summary>
        /// Identifies a Binomial distribution
        /// </summary>
        Binomial = Pow2.T06,

        /// <summary>
        /// Identifies a Cauchy distribution
        /// </summary>
        Cauchy  = Pow2.T07,

        Chi2  = Pow2.T08,

        Exponential  = Pow2.T09,

        Gamma  = Pow2.T10,

        Gaussian = Pow2.T11,

        Geometric = Pow2.T12,

        Laplace = Pow2.T13,

        Poisson = Pow2.T14,

        Rayleigh = Pow2.T15,

        Weibull = Pow2.T16,

        Lognormal = Pow2.T17,
    }
}