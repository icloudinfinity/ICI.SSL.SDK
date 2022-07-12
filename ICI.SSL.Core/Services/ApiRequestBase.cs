# nullable disable

using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace ICI.SSL.Core
{
    public abstract class ApiRequestBase
    {
        private readonly IOptions<ApiOptions> _options;
        private static readonly HttpClient _client;

        static ApiRequestBase()
        {
            _client = new HttpClient();
        }

        public ApiRequestBase(IOptions<ApiOptions> options)
        {
            _options = options;
        }

        public async Task<TResult> GetAsync<TResult>(string uri)
            where TResult : new()
        {
            try
            {
                SetRequestHeaders();

                var response = await _client.GetAsync($"{_options.Value.ApiEndpoint}/{uri}");
                string content = ResolveContent(await response.Content.ReadAsStringAsync());

                if (response.IsSuccessStatusCode)
                {
                    TResult obj = JsonSerializer.Deserialize<TResult>(content);
                    return obj;
                }
                else
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return new TResult();
                    }
                    else
                    {
                        throw new Exception($"{response.StatusCode} : {content}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TResult>> GetListResultAsync<TResult>(string uri)
            where TResult : class
        {
            try
            {
                SetRequestHeaders();

                var response = await _client.GetAsync($"{_options.Value.ApiEndpoint}/{uri}");
                string content = ResolveContent(await response.Content.ReadAsStringAsync());

                if (response.IsSuccessStatusCode)
                {
                    List<TResult> list = JsonSerializer.Deserialize<List<TResult>>(content);
                    return list;
                }
                else
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return new List<TResult>();
                    }
                    else
                    {
                        throw new Exception($"{response.StatusCode} : {content}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task PostAsync<T>(string uri, T payload)
            where T : class
        {
            try
            {
                SetRequestHeaders();

                var response = await _client.PostAsync($"{_options.Value.ApiEndpoint}/{uri}",
                     new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json"));

                string content = ResolveContent(await response.Content.ReadAsStringAsync());

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"{response.StatusCode} : {content}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TResult> PostAsync<T, TResult>(string uri, T payload)
            where TResult : new()
            where T : class
        {
            try
            {
                SetRequestHeaders();

                var response = await _client.PostAsync($"{_options.Value.ApiEndpoint}/{uri}",
                     new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json"));

                string content = ResolveContent(await response.Content.ReadAsStringAsync());

                if (response.IsSuccessStatusCode)
                {
                    TResult obj = JsonSerializer.Deserialize<TResult>(content);
                    return obj;
                }
                else
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return new TResult();
                    }
                    else
                    {
                        throw new Exception($"{response.StatusCode} : {content}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TResult> PutAsync<T, TResult>(string uri, T payload)
           where TResult : new()
           where T : class
        {
            try
            {
                SetRequestHeaders();

                var response = await _client.PutAsync($"{_options.Value.ApiEndpoint}/{uri}",
                     new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json"));

                string content = ResolveContent(await response.Content.ReadAsStringAsync());

                if (response.IsSuccessStatusCode)
                {
                    TResult obj = JsonSerializer.Deserialize<TResult>(content);
                    return obj;
                }
                else
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return new TResult();
                    }
                    else
                    {
                        throw new Exception($"{response.StatusCode} : {content}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TResult>> PostListResultAsync<T, TResult>(string uri, T payload)
          where TResult : class
          where T : class
        {
            try
            {
                SetRequestHeaders();

                var response = await _client.PostAsync($"{_options.Value.ApiEndpoint}/{uri}",
                     new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json"));

                string content = ResolveContent(await response.Content.ReadAsStringAsync());

                if (response.IsSuccessStatusCode)
                {
                    List<TResult> list = JsonSerializer.Deserialize<List<TResult>>(content);
                    return list;
                }
                else
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return new List<TResult>();
                    }
                    else
                    {
                        throw new Exception($"{response.StatusCode} : {content}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync(string uri)
        {
            try
            {
                SetRequestHeaders();

                var response = await _client.DeleteAsync($"{_options.Value.ApiEndpoint}/{uri}");

                string content = ResolveContent(await response.Content.ReadAsStringAsync());

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"{response.StatusCode} : {content}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void SetRequestHeaders()
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Ocp-Apim-Subscription-Key", _options.Value.SubscriptionKey);
        }

        private string ResolveContent(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return string.Empty;
            }
            else
            {
                if (content.ToLower().Contains("!doctype html"))
                {
                    return string.Empty;
                }
                else
                {
                    return content;
                }
            }
        }
    }
}
