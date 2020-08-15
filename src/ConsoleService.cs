using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Endomondo.Export
{
    public class ConsoleService : IHostedService
    {
        private readonly ILogger<ConsoleService> _logger;
        private readonly Options _options;
        private readonly IGpxParser _parser;
        private readonly IFileService _fileService;
        private readonly IEndomondoClient _client;

        public ConsoleService(ILogger<ConsoleService> logger, Options options, IGpxParser parser, IFileService fileService, EndomondoClient client)
        {
            _client = client;
            _logger = logger;
            _options = options;
            _parser = parser;
            _fileService = fileService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var authResult = _client.Authenticate(_options.Email, _options.Password).GetAwaiter().GetResult();
            Console.WriteLine($"Getting all {_options.Limit} workouts...");
            var workoutList = _client.GetWorkoutsList(_options.Limit, authResult.AuthToken).GetAwaiter().GetResult();

            foreach (var singleWorkout in workoutList.data)
            {
                Console.WriteLine($"Downloading... {singleWorkout.id}");
                var workout = _client.GetWorkout(singleWorkout.id, authResult.AuthToken).GetAwaiter().GetResult();
                var gpx = _parser.Parse(workout, singleWorkout.id);

                _fileService.Save(gpx);
            }
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
