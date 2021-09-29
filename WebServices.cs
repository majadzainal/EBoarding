using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EBoarding
{
    public class WebServices
    {
        private CancellationToken completionOption;

        public class CheckServices
        {
            public string error_code = string.Empty;
        }


        public async Task<HttpResponseMessage> CheckBookingCode(string base_url, string rqid, string book_code, string device_id)
        {
            try
            {
                System.Net.ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls12 |
                SecurityProtocolType.Tls11 |
                SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(600);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(base_url + "get_checkin_info_tes?rqid=" + rqid + "&book_code=" + book_code + "&device_id=" + device_id);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<HttpResponseMessage> GetCheckIn(string base_url, string ticket_no, string device_id)
        {
            try
            {
                System.Net.ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls12 |
                SecurityProtocolType.Tls11 |
                SecurityProtocolType.Tls;
                HttpClient client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(600);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(base_url + "get_checkin_tes?&ticket_no=" + ticket_no + "&device_id=" + device_id);
                //HttpResponseMessage response
                    

                //string result = response.Content.ReadAsStringAsync().Result;

                //JustValidateResponse(response, result);

                //ResponseUser userData = JsonConvert.DeserializeObject<ResponseUser>(result);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
