using System.Threading.Tasks;
using Grpc.Core;
using Library.Core;
using QuizEnginePackage;

namespace QuizEngineServer
{
	internal class QuizEngineService : QuizEnginePackage.QuizEngineService.QuizEngineServiceBase
	{
		private readonly QuizEngineCore _quizEngine;

		public QuizEngineService()
		{
			_quizEngine = new QuizEngineCore();
		}

		public override Task<AddUserReply> AddUser(AddUserRequest request, ServerCallContext context)
		{
			_quizEngine.AddUser(request.Email);
			return Task.FromResult(new AddUserReply());
		}

		public override Task<AvailableQuizzesReply> AvailableQuizzesForUser(AvailableQuizzesRequest request,
			ServerCallContext context)
		{
			var availableQuizzes = _quizEngine.AvailableQuizzesForUser(request.Email);
			var reply = new AvailableQuizzesReply();
			foreach (var quizUuid in availableQuizzes)
			{
				var uuid = new UUID {Value = quizUuid};
				reply.QuizUuids.Add(uuid);
			}

			return Task.FromResult(reply);
		}

		public override Task<SubmitQuizAnswersReply> SubmitQuizAnswers(SubmitQuizAnswersRequest request,
			ServerCallContext context)
		{
			_quizEngine.SubmitQuizAnswers(request.Email, request.CompletedQuiz);
			return Task.FromResult(new SubmitQuizAnswersReply());
		}

		public override Task<GetQuizResultsForUserReply> GetQuizResultsForUser(GetQuizResultsForUserRequest request,
			ServerCallContext context)
		{
			var quizResults = _quizEngine.UserQuizResults(request.Email);
			var reply = new GetQuizResultsForUserReply();
			foreach (var result in quizResults)
			{
				reply.CompletedQuizzes.Add(result);
			}

			return Task.FromResult(reply);
		}

		public override Task<AddQuizReply> AddQuiz(AddQuizRequest request, ServerCallContext context)
		{
			_quizEngine.AddQuiz(request.Quiz);
			return Task.FromResult(new AddQuizReply());
		}
	}
}