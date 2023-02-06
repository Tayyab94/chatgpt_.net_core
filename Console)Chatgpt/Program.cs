using Newtonsoft.Json;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var apiKey = "API_KEY";

        // Build the API request URL
        var requestUrl = "https://api.openai.com/v1/engines/text-davinci-002/completions";

        Console.WriteLine("Write your question? ");

        string query = Console.ReadLine();
        // Build the request body
        var requestBody = new
        {
            prompt = query,
            max_tokens = 100,
            n = 1,
            temperature = 0,
        };

        // Serialize the request body to a JSON string
        var requestJson = JsonConvert.SerializeObject(requestBody);

        // Create a new HTTP client
        var client = new HttpClient();

        // Add the API key to the request headers
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        // Create the request message
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
        requestMessage.Content = new StringContent(requestJson, Encoding.UTF8, "application/json");

        // Send the request and retrieve the response
        var response = client.SendAsync(requestMessage).Result;

        // Read the response content
        var responseContent = response.Content.ReadAsStringAsync().Result;

        // Deserialize the response content to a dynamic object
        dynamic responseJson = JsonConvert.DeserializeObject(responseContent);

        // Extract the completion text from the response
        var completion = responseJson.choices[0].text;

        // Print the completion text
        Console.WriteLine(completion);


        //// Serialize the request body to a JSON string
        //var requestJson = JsonConvert.SerializeObject(requestBody);

        //// Create a new HTTP client
        //var client = new HttpClient();

        //// Add the API key to the request headers
        //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        //// Create the request message
        //var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
        //requestMessage.Content = new StringContent(requestJson, Encoding.UTF8, "application/json");

        //// Send the request and retrieve the response
        //var response = client.SendAsync(requestMessage).Result;

        //// Read the response content
        //var responseContent = response.Content.ReadAsStringAsync().Result;

        //// Deserialize the response content to a dynamic object
        //dynamic responseJson = JsonConvert.DeserializeObject(responseContent);

        //// Extract the completion text and detail from the response
        //var completion = responseJson.choices[0].text;
        //var detail = responseJson.choices[0].detail;

        //// Print the completion text and detail
        //Console.WriteLine(completion);
        //Console.WriteLine(detail);
    }
}