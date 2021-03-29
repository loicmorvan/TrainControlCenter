using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation
{
    public static class HttpClientEx
    {
        public static async Task PatchAsync<T>(this HttpClient @this, string requestUri, T content)
        {
            var response = await @this.PatchAsync(requestUri, JsonContent.Create(content));

            response.EnsureSuccessStatusCode();
        }

        public static async Task<T> PostAsync<T>(this HttpClient @this, string requestUri)
        {
            var resultTask = @this.PostAsync(requestUri, new StringContent(string.Empty));
            return await GetFromJsonAsyncCore<T>(resultTask);
        }

        private static async Task<T> GetFromJsonAsyncCore<T>(Task<HttpResponseMessage> taskResponse,
            JsonSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            using HttpResponseMessage response = await taskResponse.ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            // Nullable forgiving reason:
            // GetAsync will usually return Content as not-null.
            // If Content happens to be null, the extension will throw.
            return await response.Content!.ReadFromJsonAsync<T>(options, cancellationToken).ConfigureAwait(false)
                   ?? throw new NullReferenceException();
        }
    }
}