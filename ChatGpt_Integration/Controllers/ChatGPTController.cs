using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace ChatGpt_Integration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGPTController : ControllerBase
    {
        [HttpGet]
        [Route("UseChatGpt")]
        public async Task<IActionResult> UseChatGpt(string query)
        {
            string OutputMsg = string.Empty;
            var openAi = new OpenAIAPI("API_KEy");
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = query;
            completionRequest.Model= OpenAI_API.Models.Model.DavinciText;

            var completion = openAi.Completions.CreateCompletionAsync(completionRequest);

            foreach (var comp in completion.Result.Completions)
            {
                OutputMsg += comp.Text;
            }
            return Ok(OutputMsg);
        }
    }
}
