//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = Surveys;

    /// <summary>
    /// Defines a question in the context of a survey
    /// </summary>
    /// <typeparam name="T">The primal survey representation type</typeparam>
    public readonly struct Question<T> : ITextual
        where T : unmanaged
    {
        /// <summary>
        /// Uniquely identifies a question relative to a survey
        /// </summary>
        public uint QuestionId {get;}

        /// <summary>
        /// The question statement
        /// </summary>
        public string Label {get;}

        /// <summary>
        /// The maximum number of choices allowed for a response, between 0 and the number of available choices
        /// </summary>
        public int MaxSelect {get;}

        /// <summary>
        /// The potential choices/answers
        /// </summary>
        public Index<QuestionChoice<T>> Choices {get;}

        [MethodImpl(Inline)]
        public Question(uint id, string statement, int? select, QuestionChoice<T>[] choices)
        {
            QuestionId = id;
            Label = statement;
            MaxSelect = select ?? choices.Length;
            Choices = choices;
        }

        public bool MultipleChoice
            => MaxSelect > 1;

        public string Title
            => $"{QuestionId} - {Label}";

        public string Format()
            => api.format(this);

        public override string ToString()
            => Title;
    }
}