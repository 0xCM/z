//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly struct Surveys
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Creates a bitvector representation of a question
        /// </summary>
        /// <param name="src">The question upon which the bitvector will be predicated</param>
        /// <typeparam name="T">The primal data type used for survey aspect representation</typeparam>
        [Op, Closures(Closure)]
        public static ScalarBits<T> vector<T>(in Question<T> src)
            where T : unmanaged
        {
            var data = default(T);
            foreach(var choice in src.Choices)
                data = gmath.or(data, choice.ChoiceId);
            return data;
        }

        /// <summary>
        /// Creates a bitvector representation of a question response
        /// </summary>
        /// <param name="src">The response upon which the bitvector will be predicated</param>
        /// <typeparam name="T">The primal data type used for survey aspect representation</typeparam>
        [Op, Closures(Closure)]
        public static ScalarBits<T> vector<T>(in QuestionResponse<T> src)
            where T : unmanaged
        {
            var data = default(T);
            foreach(var choice in src.Chosen)
                data = gmath.or(data, choice.ChoiceId);
            return data;
        }

        /// <summary>
        /// Creates a bitmatrix representation of a survey response
        /// </summary>
        /// <param name="src">The survey upon which the matrix will be predicated</param>
        /// <typeparam name="T">The primal data type used for survey aspect representation</typeparam>
        [Op, Closures(Closure)]
        public static BitMatrix<T> matrix<T>(in SurveyResponse<T> src)
            where T : unmanaged
        {
            var rowcount = src.Answered.Length;
            var maxrows = width<T>();
            if(rowcount > maxrows)
                throw new Exception($"Too many rows for a primal bitmatrix");

            var dst = BitMatrix.alloc<T>();
            for(var i=0; i< rowcount; i++)
                dst[i] = vector(src.Answered[i]);
            return dst;
        }

        /// <summary>
        /// Creates a bitmatrix representation of a survey
        /// </summary>
        /// <param name="src">The survey upon which the matrix will be predicated</param>
        /// <typeparam name="T">The primal data type used for survey aspect representation</typeparam>
        [Op, Closures(Closure)]
        public static BitMatrix<T> matrix<T>(in Survey<T> src)
            where T : unmanaged
        {
            var rowcount = src.Questions.Length;
            var maxrows = width<T>();
            if(rowcount > maxrows)
                throw new Exception($"Too many rows for a primal bitmatrix");

            var dst = BitMatrix.alloc<T>();
            for(var i=0; i<rowcount; i++)
                dst[i] = vector(src.Questions[i]);
            return dst;
        }

        [Op, Closures(Closure)]
        public static RowBits<T> rows<T>(in Survey<T> src)
            where T : unmanaged
        {
            var rowcount = src.Questions.Length;
            var dst = RowBits.alloc<T>(rowcount);
            for(var i=0; i< rowcount; i++)
                dst[i] = vector(src.Questions[i]);
            return dst;
        }

        [Op, Closures(Closure)]
        public static RowBits<T> rows<T>(in SurveyResponse<T> src)
            where T : unmanaged
        {
            var rowcount = src.Answered.Length;
            var dst = RowBits.alloc<T>(rowcount);
            for(var i=0; i<rowcount; i++)
                dst[i] = vector(src.Answered[i]);
            return dst;
        }

        public static QuestionResponse<T> response<T>(in Question<T> question, IBoundSource random)
            where T : unmanaged
        {
            var count = question.Choices.Length;
            var index = random.Next(0,count);
            var chosen = question.Choices[index];
            return response(question.QuestionId, chosen);
        }

        public static SurveyResponse<T> response<T>(in Survey<T> survey, IBoundSource random)
            where T : unmanaged
        {
            var answered = new QuestionResponse<T>[survey.Questions.Length];
            for(var i=0; i<answered.Length; i++)
                answered[i] = response(survey.Questions[i], random);
            return new SurveyResponse<T>(survey.SurveyId, answered);
        }

        [Op, Closures(Closure)]
        public static string format<T>(in SurveyResponse<T> src)
            where T : unmanaged
        {
            var dst = text.build();

            for(var i=0; i<src.Answered.Length; i++)
            {
                dst.Append(src.Answered[i].QuestionId);
                dst.Append(Chars.Colon);
                dst.Append(Chars.Space);
                dst.Append(src.Answered[i].Format());
                dst.AppendLine();
            }

            return dst.ToString();
        }

        [Op, Closures(Closure)]
        public static string format<T>(in Question<T> src)
            where T : unmanaged
        {
            var dst = text.build();
            dst.Append(src.Label.PadRight(12));
            dst.Append(Chars.Colon);
            dst.Append(Chars.Space);
            dst.Append(Chars.LBracket);
            dst.Append(string.Join(src.MultipleChoice ? Chars.Pipe : Chars.Caret, src.Choices.Select(c => c.Format())));
            dst.Append(Chars.RBracket);
            return dst.ToString();
        }

        [Op, Closures(Closure)]
        public static string format<T>(in Survey<T> src)
            where T : unmanaged
        {
            var dst = text.buffer();
            dst.AppendLine(src.Name);
            dst.AppendLine(RP.PageBreak80);
            for(var i=0; i<src.Questions.Length; i++)
                dst.AppendLine(format(src.Questions[i]));
                    return dst.ToString();
        }

        [Op, Closures(Closure)]
        public static string format<T>(in QuestionChoice<T> src)
            where T : unmanaged
                => text.parenthetical(src.Title);

        [Op, Closures(Closure)]
        public static string title<T>(T id, string label)
            where T : unmanaged
        {
            const string Pattern = "{0}: {1}";
            return string.Format(Pattern, gmath.log2(id), label);
        }

        [Op]
        public static string label(uint index)
        {
            var q = (int)(index / 26);
            var r = (int)(index % 26);
            var code = Convert.ToChar(ChoiceCodes[r]);
            var label = ChoiceCodes[r].ToString();
            if(q != 0)
                label = new string(code,q);
            else
                label = code.ToString();
            return label;
        }

        /// <summary>
        /// The numeric codes for the asci characters 'A' .. 'Z'
        /// </summary>
        static ReadOnlySpan<byte> ChoiceCodes
            => new byte[26]{65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90};

        /// <summary>
        /// Creates a stock survey that contains no meaningful content
        /// </summary>
        /// <param name="id">The survey id</param>
        /// <param name="name">The survey name</param>
        /// <param name="length">The number of questions in the survey</param>
        /// <param name="width">The (uniform) number of choices in each question</param>
        /// <typeparam name="T">The primal data type used for survey aspect representation</typeparam>
        [Op, Closures(Closure)]
        public static Survey<T> template<T>(uint id, string name, int length, int width)
            where T : unmanaged
        {
            var questions = new Question<T>[length];

            for(uint i=0u, questionId = 1; i<length; i++, questionId++)
            {
                var choices = new QuestionChoice<T>[width];
                var choiceId = core.one<T>();
                for(var j = 0u; j< width; j++)
                {
                    choices[j] = choice(choiceId, label(j));
                    choiceId = gmath.sll(choiceId, (byte)1);
                }
                questions[i] = question(questionId, $"Question {questionId}", 1, choices);
            }
            return define(id,name,questions);
        }

        /// <summary>
        /// Creates a stock survey with the maximum number of questions/choices supported by the primal type
        /// </summary>
        /// <param name="id">The survey id</param>
        /// <param name="name">The survey name</param>
        /// <typeparam name="T">The primal data type used for survey aspect representation</typeparam>
        [Op, Closures(Closure)]
        public static Survey<T> template<T>(uint id, string name)
            where T : unmanaged
                => template<T>(id,name, (int)width<T>(), (int)width<T>());

        /// <summary>
        /// Creates a stock survey with a specified number of questions, each of which has the maximum number
        /// of choices supported by the primal type
        /// </summary>
        /// <param name="id">The survey id</param>
        /// <param name="name">The survey name</param>
        /// <param name="length">The number of questions in the survey</param>
        /// <typeparam name="T">The primal data type used for survey aspect representation</typeparam>
        [Op, Closures(Closure)]
        public static Survey<T> template<T>(uint id, string name, int length)
            where T : unmanaged
                => template<T>(id,name, length, (int)width<T>());

        /// <summary>
        /// Creates a choice for a survey question
        /// </summary>
        /// <param name="id">The question-relative choice identifier</param>
        /// <param name="label">The choice name</param>
        /// <typeparam name="T">The primal data type used for survey aspect representation</typeparam>
        [Op, Closures(Closure)]
        public static QuestionChoice<T> choice<T>(T id, string label)
            where T : unmanaged
                => new QuestionChoice<T>(id,label);

        /// <summary>
        /// Creates a question for a survey
        /// </summary>
        /// <param name="id">The survey-relative question identifier</param>
        /// <param name="statement">The question statement</param>
        /// <typeparam name="T">The primal data type used for survey aspect representation</typeparam>
        [Op, Closures(Closure)]
        public static Question<T> question<T>(uint id, string statement, int maxselect,  params QuestionChoice<T>[] choices)
            where T : unmanaged
                => new Question<T>(id, statement, maxselect, choices);

        /// <summary>
        /// Creates a response to a survey question
        /// </summary>
        /// <param name="questionId">The id of the question to which a response is given</param>
        /// <param name="chosen">The selected choices</param>
        /// <typeparam name="T">The primal data type used for survey aspect representation</typeparam>
        [Op, Closures(Closure)]
        public static QuestionResponse<T> response<T>(uint questionId, params QuestionChoice<T>[] chosen)
            where T : unmanaged
                => new QuestionResponse<T>(questionId, chosen);

        /// <summary>
        /// Creates a response to a survey
        /// </summary>
        /// <param name="surveyId">The id of the question to which a response is given</param>
        /// <param name="answered">The selected choices</param>
        /// <typeparam name="T">The primal data type used for survey aspect representation</typeparam>
        [Op, Closures(Closure)]
        public static SurveyResponse<T> response<T>(uint surveyId, params QuestionResponse<T>[] answered)
            where T : unmanaged
                => new SurveyResponse<T>(surveyId, answered);

        /// <summary>
        /// Creates a survey
        /// </summary>
        /// <param name="id">The survey identifier, unique within some external scope</param>
        /// <param name="name">The name of the survey, unique within some external scope</param>
        /// <param name="questions"></param>
        /// <typeparam name="T">The primal data type used for survey aspect representation</typeparam>
        [Op, Closures(Closure)]
        public static Survey<T> define<T>(uint id, string name, params Question<T>[] questions)
            where T : unmanaged
                => new Survey<T>(id,name, questions);

        public static string format<T>(in QuestionResponse<T> src, bool bracket = false, char sep = Chars.Comma)
            where T : unmanaged
        {
            var dst = text.buffer();
            if(bracket)
                dst.Append(Chars.LBracket);

            for(var i=0; i<src.Chosen.Length; i++)
            {
                var chosen = src.Chosen[i];
                dst.Append($"({chosen.ChoiceId}) {chosen.Label}");
                if(i != src.Chosen.Length - 1)
                {
                    dst.Append(sep);
                    dst.Append(Chars.Space);
                }
            }

            if(bracket)
                dst.Append(Chars.RBracket);
            return dst.Emit();
        }
    }
}