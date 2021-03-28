using System.IO;
using System.Threading.Tasks;
using Discord.Webhook;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace BlobFunction
{
    public static class BlobFunction
    {
        [FunctionName("BlobFunction")]
        public static async Task Run([BlobTrigger("{container_name}/{name}")]Stream myBlob, string name, ILogger log)
        {
            ulong webhookId = ulong.MinValue;
            using (var client = new DiscordWebhookClient(webhookId, "{discord_key}"))
            {
                await client.SendFileAsync(myBlob, name, "Novo PDF Criado");
            }
        }
    }
}
