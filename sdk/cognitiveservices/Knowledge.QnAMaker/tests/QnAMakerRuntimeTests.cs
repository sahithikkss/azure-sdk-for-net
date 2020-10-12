using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker;
using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace QnAMaker.Tests
{
    public class QnAMakerRuntimeTests: BaseTests
    {
        [Fact]
        public void QnAMakerRuntimeGenerateAnswerTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "QnAMakerRuntimeGenerateAnswerTest", HttpRecorderMode.Record);

                var client = GetQnAMakerClient(HttpMockServer.CreateInstance());
                var queryDTO = new QueryDTO();
                queryDTO.Question = "tell me";
                queryDTO.IsTest = true;
                queryDTO.Top = 3;
                queryDTO.ScoreThreshold = 60.0;
                queryDTO.StrictFiltersCompoundOperationType = StrictFiltersCompoundOperationType.OR;
                queryDTO.StrictFilters = new List<MetadataDTO>();
                queryDTO.StrictFilters.Add(new MetadataDTO("timeoftheday", "morning"));
                queryDTO.StrictFilters.Add(new MetadataDTO("timeoftheday", "forenoon"));
                queryDTO.AnswerSpanRequest = new QueryDTOAnswerSpanRequest
                {
                    Enable = true,
                    ScoreThreshold = 50.0,
                    TopAnswersWithSpan = 3
                };

                queryDTO.Context = new QueryDTOContext
                {
                    PreviousQnaId = -1,
                    PreviousUserQuery = ""
                };

                var answer = client.Knowledgebase.GenerateAnswerAsync("c2d2d1f5-1e94-4394-b235-d0f37c7090b0", queryDTO).Result;
                Assert.Equal(2, answer.Answers.Count);
                Assert.True(answer.Answers[0].Score > 95);
            }
        }
    }
}
