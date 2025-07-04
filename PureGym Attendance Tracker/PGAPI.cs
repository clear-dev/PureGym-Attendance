using PureGym_Attendance_Tracker.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace PureGym_Attendance_Tracker
{
    public class PGAPI
    {
        private readonly HttpClient httpClient = new();
        private string? _email;
        private string? _pin;
        private bool _authed = false;

        public PGAPI()
        {
            _authed = false;
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("PureGym/1523 CFNetwork/1312 Darwin/21.0.0");
        }

        private record LoginResponse(string access_token);
        public async Task<bool> Login(string email, string pin)
        {
            _email = email;
            _pin = pin;

            var data = new Dictionary<string, string>
            {
                {"grant_type", "password"},
                {"username", email},
                {"password", pin},
                {"scope", "pgcapi"},
                {"client_id", "ro.client"}
            };
            FormUrlEncodedContent content = new(data);
            HttpResponseMessage response = await httpClient.PostAsync("https://auth.puregym.com/connect/token", content);
            if (response.IsSuccessStatusCode)
            {
                var responseData = JsonSerializer.Deserialize<LoginResponse>(response.Content.ReadAsStream())!;
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", responseData.access_token);
                _authed = true;
                return true;
            }
            return false;
        }

        private record HomeGymResponse(int homeGymId, string homeGymName);
        public async Task<Gym?> GetHomeGym()
        {
            if (!_authed)
                return null;
            HttpResponseMessage response = await httpClient.GetAsync("https://capi.puregym.com/api/v1/member");
            if (response.IsSuccessStatusCode)
            {
                var responseData = JsonSerializer.Deserialize<HomeGymResponse>(response.Content.ReadAsStream())!;
                return new Gym(responseData.homeGymName, responseData.homeGymId);
            }
            return null;
        }

        private record GymListResponse(string name, int id);
        public async Task<List<Gym>?> GetGymList()
        {
            if (!_authed)
                return null;
            HttpResponseMessage response = await httpClient.GetAsync("https://capi.puregym.com/api/v1/gyms");
            if (response.IsSuccessStatusCode)
            {
                var responseData = JsonSerializer.Deserialize<List<GymListResponse>>(response.Content.ReadAsStream())!;
                return responseData.Select(obj => new Gym(obj.name, obj.id)).ToList();
            }
            return null;
        }

        private record GymAttendeesResponse(int totalPeopleInGym);
        public async Task<int?> GymAttendance(Gym gym)
        {
            if (!_authed)
                return null;
            HttpResponseMessage response = await httpClient.GetAsync($"https://capi.puregym.com/api/v1/gyms/{gym.ID}/attendance");
            if (response.IsSuccessStatusCode)
            {
                var responseData = JsonSerializer.Deserialize<GymAttendeesResponse>(response.Content.ReadAsStream())!;
                return responseData.totalPeopleInGym;
            }
            return null;
        }
    }
}
