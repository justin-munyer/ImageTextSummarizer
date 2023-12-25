using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace SummarizerLib.Summarization;

/// <summary>
/// This class is a wrapper for the HuggingFace summarizer API.
/// </summary>
public class SummarizerApi
{
    #region Private Fields

    private readonly string m_authorizationToken;

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a <see cref="SummarizerApi"/>.
    /// </summary>
    /// <param name="authorizationToken">The authorization token used to access the HuggingFace API.</param>
    public SummarizerApi(string authorizationToken) 
    {
        m_authorizationToken = authorizationToken;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Summarizes input text.
    /// </summary>
    /// <param name="text">The text to summarize.</param>
    /// <returns>The summarized text. If the text could not be summarized, returns null or an empty string.</returns>
    public async Task<string?> SummarizeAsync(string text)
    {
        using HttpClient httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", m_authorizationToken);

        using StringContent jsonContent = new(
            JsonSerializer.Serialize(new
            {
                inputs = text
            }),
            Encoding.UTF8,
            "application/json");

        HttpResponseMessage result = await httpClient.PostAsync(SummarizerConstants.SummarizerUri, jsonContent);

        if (result.IsSuccessStatusCode == false)
        {
            return null;
        }

        string summarized = await result.Content.ReadAsStringAsync();

        string content;
        if (summarized.Contains(SummarizerConstants.SummarizeJsonTag))
        {
            // Remove extra json content from result.
            content = summarized.Split(":")[1];

            // Last 3 characters are not used.
            content = content.Substring(0, content.Length - 3);

            // First character is a quote.
            content = content.Substring(1);
        }
        else
        {
            return null;
        }

        return content;
    }

    #endregion
}
