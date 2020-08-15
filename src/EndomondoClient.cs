using Endomondo.Export.Models.Endomondo;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Endomondo.Export
{
    public class AuthResponse
    {
        public string AuthToken { get; set; }
        public string DisplayName { get; set; }
        public string UserId { get; set; }
    }

    public class EndomondoClient : IEndomondoClient
    {
        private readonly HttpClient _client;

        public EndomondoClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<AuthResponse> Authenticate(string email, string password)
        {
            var authUrl = $"mobile/auth?deviceId=dummy&email={email}&password={password}&country=US&action=PAIR";

            var result = new AuthResponse();

            var response = await MakeGetRequest(authUrl);

            string[] lines = response.Split('\n');
            foreach (string line in lines)
            {
                string[] values = line.Split('=');
                if (values.Length == 2)
                {
                    switch (values[0])
                    {
                        case "authToken":
                            result.AuthToken = values[1];
                            break;
                        case "displayName":
                            result.DisplayName = values[1];
                            break;
                        case "userId":
                            result.UserId = values[1];
                            break;
                        default:
                            break;
                    }
                }
            }

            return result;
        }

        public async Task<WorkoutList> GetWorkoutsList(int maxResults, string authToken)
        {
            var url = $"mobile/api/workout/list?authToken={authToken}&maxResults={maxResults}";
            var response = await MakeGetRequest(url);

            return JsonConvert.DeserializeObject<WorkoutList>(response);
        }

        public async Task<string> GetWorkout(string workoutId, string authToken)
        {
            var url = $"mobile/readTrack?authToken={authToken}&trackId={workoutId}";
            var response = await MakeGetRequest(url);

            return response;
        }

        private async Task<string> MakeGetRequest(string url)
        {
            _client.DefaultRequestHeaders.Clear();

            var result = await _client.GetAsync(url);

            string resultContent = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                return resultContent;
            }

            return null;
        }
    }

    public interface IEndomondoClient
    {
        Task<AuthResponse> Authenticate(string email, string password);
        Task<WorkoutList> GetWorkoutsList(int maxResults, string authToken);
        Task<string> GetWorkout(string workoutId, string authToken);
    }
}
