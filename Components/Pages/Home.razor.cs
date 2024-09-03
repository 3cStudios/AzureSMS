using Microsoft.AspNetCore.Components;
using Azure;
using Azure.Communication.Sms;


namespace SmsPoc.Components.Pages
{
    public partial class Home : ComponentBase
    {
        public class SmsModel
        {
            public string ToPhoneNumber { get; set; }
            public string Message { get; set; }
        }

        private SmsModel ExampleSmsModel = new SmsModel();

        private const string FromPhoneNumber = "YOUR AZURE COMMUNUICATION SERVICES ASSIGNED SMS PHONE NUMBER";
        private const string ConnectionString = "YOUR AZURE COMMUNUICATION SERVICES CONNECTION STRING";


        private void SendSms()
        {
            var smsClient = new SmsClient(ConnectionString);
            try
            {
                smsClient.Send(
                    from: FromPhoneNumber,
                    to: ExampleSmsModel.ToPhoneNumber,
                    message: ExampleSmsModel.Message
                );
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }


    }
}
