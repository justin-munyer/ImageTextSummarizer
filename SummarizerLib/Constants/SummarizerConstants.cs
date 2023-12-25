using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummarizerLib.Summarization;

/// <summary>
/// Contains constants for the summarizer API.
/// </summary>
public static class SummarizerConstants
{
    #region Public Constants

    public const string SummarizerUri = "https://api-inference.huggingface.co/models/facebook/bart-large-cnn";
    public const string SummarizeJsonTag = "summary_text";

    #endregion
}
