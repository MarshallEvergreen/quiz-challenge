using System;
using FluentAssertions;
using Library.Core;
using NUnit.Framework;
using QuizEnginePackage;

namespace CoreTests
{
	[TestFixture]
	public class SingleQuizTests
	{
		[SetUp]
		public void Setup()
		{
			_quizEngine = new QuizEngineCore();
			_quizEngine.AddUser(UserEmail);

			_multipleChoiceQuestion.Question = "Who are the best heavy metal band?";

			_multipleChoiceQuestion.Options.Add("Black Sabbath");
			_multipleChoiceQuestion.Options.Add("Judas Priest");
			_multipleChoiceQuestion.Options.Add("Metallica");
			_multipleChoiceQuestion.Options.Add("Iron Maiden");

			_multipleChoiceQuestion.CorrectAnswer = "Iron Maiden";

			var quiz = new Quiz {Uuid = new UUID {Value = _quizUuid.ToString()}};
			quiz.Questions.Add(_multipleChoiceQuestion);

			_quizEngine.AddQuiz(quiz);
		}

		private QuizEngineCore _quizEngine;
		private readonly Guid _quizUuid = Guid.NewGuid();
		private const string UserEmail = "quizEnthusiast@quizzy.com";
		private readonly MultipleChoiceQuestion _multipleChoiceQuestion = new();

		[Test]
		public void SingleQuiz_AvailableToUser_IfTheyHaveNotTakenIt()
		{
			_quizEngine.AvailableQuizzesForUser(UserEmail)
				.Should()
				.HaveCount(1)
				.And.Contain(_quizUuid.ToString());
		}

		[Test]
		public void SingleQuiz_NotAvailableToUser_IfTheyHaveTakenIt()
		{
			var completedQuiz = CompletedQuizWithAnswer("Metallica");

			_quizEngine.SubmitQuizAnswers(UserEmail, completedQuiz);

			_quizEngine.AvailableQuizzesForUser(UserEmail)
				.Should()
				.HaveCount(0);
		}

		[Test]
		public void SingleQuiz_UserIsScoredCorrectly_AllAnsweredCorrectly()
		{
			var completedQuiz = CompletedQuizWithAnswer("Iron Maiden");

			_quizEngine.SubmitQuizAnswers(UserEmail, completedQuiz);

			var scoredQuiz = completedQuiz.Clone();
			scoredQuiz.CorrectAnswers = 1;

			_quizEngine.UserQuizResults(UserEmail)
				.Should()
				.HaveCount(1)
				.And.Contain(scoredQuiz);
		}

		[Test]
		public void SingleQuiz_UserIsScoredCorrectly_AllAnsweredIncorrectly()
		{
			var completedQuiz = CompletedQuizWithAnswer("Metallica");

			_quizEngine.SubmitQuizAnswers(UserEmail, completedQuiz);

			var scoredQuiz = completedQuiz.Clone();
			scoredQuiz.CorrectAnswers = 0;

			_quizEngine.UserQuizResults(UserEmail)
				.Should()
				.HaveCount(1)
				.And.Contain(scoredQuiz);
		}

		private CompletedQuiz CompletedQuizWithAnswer(string answer)
		{
			var submittedAnswer = new SubmittedAnswer
			{
				Question = _multipleChoiceQuestion,
				Answer = answer
			};

			var completedQuiz = new CompletedQuiz {Uuid = new UUID {Value = _quizUuid.ToString()}};
			completedQuiz.SubmittedAnswers.Add(submittedAnswer);
			return completedQuiz;
		}
	}
}