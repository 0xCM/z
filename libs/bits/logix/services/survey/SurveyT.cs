//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Surveys;

    /// <summary>
    /// Defines a survey predicated on primal type evaluation
    /// </summary>
    /// <typeparam name="T">The primal survey representation type</typeparam>
    public readonly struct Survey<T>
        where T : unmanaged
    {
        public uint SurveyId {get;}

        public string Name {get;}

        public Index<Question<T>> Questions {get;}

        [MethodImpl(Inline)]
        public Survey(uint id, string name, params Question<T>[] questions)
        {
            SurveyId = id;
            Name = name;
            Questions = questions;
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();
    }
}