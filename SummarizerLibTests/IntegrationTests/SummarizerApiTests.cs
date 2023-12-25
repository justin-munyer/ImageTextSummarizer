using Xunit;
using SummarizerLib.Summarization;
using FluentAssertions;

namespace SummaryLibTests.IntegrationTests
{
    public class SummarizerApiTests
    {
        [Fact]
        public void SummarizerApi_WhenCalled_RetrievesSuccessfulResult()
        {
            string text = "UK retail sales fell in December,\r\nfailing to meet expectations and making it by some counts the worst\r\nChristmas since 1981.\r\n\r\nRetail sales dropped by 1% on the month in\r\nDecember, after a 0.6% rise in November, the Office for National\r\nStatistics (ONS) said.  The ONS revised the annual 2004 rate of growth\r\ndown from the 5.9% estimated in November to 3.2%. A number of\r\nretailers have already reported poor figures for December.  Clothing\r\nretailers and non-specialist stores were the worst hit with only\r\ninternet retailers showing any significant growth, according to the\r\nONS.\r\n\r\nThe last time retailers endured a tougher Christmas was 23 years\r\npreviously, when sales plunged 1.7%.\r\n\r\nThe ONS echoed an earlier\r\ncaution from Bank of England governor Mervyn King not to read too much\r\ninto the poor December figures.  Some analysts put a positive gloss on\r\nthe figures, pointing out that the non-seasonally-adjusted figures\r\nshowed a performance comparable with 2003. The November-December jump\r\nlast year was roughly comparable with recent averages, although some\r\nway below the serious booms seen in the 1990s.  And figures for retail\r\nvolume outperformed measures of actual spending, an indication that\r\nconsumers are looking for bargains, and retailers are cutting their\r\nprices.\r\n\r\nHowever, reports from some High Street retailers highlight\r\nthe weakness of the sector.  Morrisons, Woolworths, House of Fraser,\r\nMarks & Spencer and Big Food all said that the festive period was\r\ndisappointing.\r\n\r\nAnd a British Retail Consortium survey found that\r\nChristmas 2004 was the worst for 10 years.  Yet, other retailers -\r\nincluding HMV, Monsoon, Jessops, Body Shop and Tesco - reported that\r\nfestive sales were well up on last year.  Investec chief economist\r\nPhilip Shaw said he did not expect the poor retail figures to have any\r\nimmediate effect on interest rates.  \"The retail sales figures are\r\nvery weak, but as Bank of England governor Mervyn King indicated last\r\nnight, you don't really get an accurate impression of Christmas\r\ntrading until about Easter,\" said Mr Shaw.  \"Our view is the Bank of\r\nEngland will keep its powder dry and wait to see the big picture.\"";

            // TODO set key from settings file below. 
            string apiKey = "TODO SET HUGGINGFACE API KEY";
            var summarizer = new SummarizerApi(apiKey);

            Task<string?> resultTask = summarizer.SummarizeAsync(text);
            string? result = Task.Run(() => resultTask).Result;

            result.Should().NotBeNullOrEmpty();
        }
    }
}