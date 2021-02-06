using System.Collections.Generic;
using System.Linq;
using QuizEnginePackage;

namespace Library.Core
{
	public class QuizEngineCore
	{
		private readonly Dictionary<string, Quiz> _quizzes = new();
		private readonly Dictionary<string, User> _users = new();

		public void AddQuiz(Quiz quiz)
		{
			_quizzes.Add(quiz.Uuid.Value, quiz);
		}

		public void AddUser(string email)
		{
			_users.Add(email, new User());
		}

		public IEnumerable<string> AvailableQuizzesForUser(string email)
		{
			var availableQuizzes = new List<string>();
			foreach (var (uuid, quiz) in _quizzes)
			{
				if (!_users[email].CompletedQuizUuids.Contains(quiz.Uuid))
				{
					availableQuizzes.Add(uuid);
				}
			}

			return availableQuizzes;
		}

		public void SubmitQuizAnswers(string email, CompletedQuiz completedQuiz)
		{
			_users[email].CompletedQuizUuids.Add(completedQuiz.Uuid);
			CalculateScore(completedQuiz);
			_users[email].CompletedQuizzes.Add(completedQuiz);
		}

		private void CalculateScore(CompletedQuiz completedQuiz)
		{
			var numberCorrect =
				completedQuiz.SubmittedAnswers.Count(
					submittedAnswer => submittedAnswer.Answer == submittedAnswer.Question.CorrectAnswer);

			completedQuiz.CorrectAnswers = (uint) numberCorrect;
		}

		public IEnumerable<CompletedQuiz> UserQuizResults(string user)
		{
			return _users[user].CompletedQuizzes;
		}
	}
}