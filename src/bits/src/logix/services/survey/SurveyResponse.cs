//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Surveys;

    /// <summary>
    /// Defines a response to a survey
    /// </summary>
    /// <typeparam name="T">The primal survey representation type</typeparam>
    public readonly ref struct SurveyResponse<T>
        where T : unmanaged
    {
        /// <summary>
        /// The survey identifier
        /// </summary>
        public uint SurveyId {get;}

        /// <summary>
        /// The answered survey questions
        /// </summary>
        public Index<QuestionResponse<T>> Answered {get;}

        [MethodImpl(Inline)]
        public SurveyResponse(uint id, params QuestionResponse<T>[] answered)
        {
            SurveyId = id;
            Answered = answered;
        }

        public override string ToString()
            => api.format(this);
    }
}