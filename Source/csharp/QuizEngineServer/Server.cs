using System;
using Grpc.Core;

namespace QuizEngineServer
{
	internal static class Server
	{
		private const int Port = 30051;

		public static void Main(string[] args)
		{
			var server = new Grpc.Core.Server
			{
				Services =
				{
					QuizEnginePackage.QuizEngineService
						.BindService(new QuizEngineService())
				},
				Ports = {new ServerPort("localhost", Port, ServerCredentials.Insecure)}
			};
			server.Start();

			Console.WriteLine("Quiz engine server listening on port " + Port);
			Console.WriteLine("Press any key to stop the server...");
			Console.ReadKey();

			server.ShutdownAsync().Wait();
		}
	}
}