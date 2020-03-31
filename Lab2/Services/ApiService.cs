namespace Lab2.Services
{
    using System.Threading.Tasks;
    using Models;
    using Plugin.Connectivity;

    public class ApiService
    {
        public async Task<Response> CheckConnection()
        {
            if(!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Please turn on your internet settings."
                };
            }

            var isReachable = await CrossConnectivity.Current.IsRemoteReachable(
                "google.com");
            if(!isReachable)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Check your internet connection."
                };
            }

            return new Response
            {
                IsSuccess = true,
                Message = "Ok"
            };
        }
    }
}
