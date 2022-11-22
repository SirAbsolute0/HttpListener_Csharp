using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading;
namespace Test
{
    class http_listener
    {
        public static void SimpleListenerExample()
        {
            string prefixes = "http://localhost:1209/";

            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }
            // URI prefixes are required,
            // for example "http://contoso.com:8080/index/".
            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");

            // Create a listener.
            HttpListener listener = new HttpListener();
            // Add the prefixes.
            /*foreach (string s in prefixes)
            {
                listener.Prefixes.Add(s);
            }*/
            listener.Prefixes.Add(prefixes);
            listener.Start();
            Console.WriteLine("Listening...");
            // Note: The GetContext method blocks while waiting for a request.
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            // Obtain a response object.
            HttpListenerResponse response = context.Response;
            // Construct a response.
            string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // You must close the output stream.
            output.Close();
            listener.Stop();
        }

        public static void Tester()
        {
            for (int i = 0; i < 3999; i++)
            {
                Console.WriteLine("Working thread...");
                Thread.Sleep(1000);
            }
        }
        public static void TestResponse()
        {
            WebClient client = new WebClient();

            string response = client.DownloadString("http://localhost:1234/");
            //Assert.IsNotNull(response);
        }
    }
}
