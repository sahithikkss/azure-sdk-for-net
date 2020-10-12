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
                HttpMockServer.Initialize(this.GetType(), "QnAMakerRuntimeGenerateAnswerTest");

                var client = GetQnAMakerClient(HttpMockServer.CreateInstance());
                var queryDTO = new QueryDTO();
                queryDTO.Question = "greetings";
                queryDTO.Top = 3;
                queryDTO.ScoreThreshold = 60.0;
                queryDTO.StrictFiltersCompoundOperationType = StrictFiltersCompoundOperationType.OR;
                queryDTO.StrictFilters = new List<MetadataDTO>();
                queryDTO.StrictFilters.Add(new MetadataDTO("question", "good afternoon"));
                queryDTO.StrictFilters.Add(new MetadataDTO("question", "good morning"));
                queryDTO.AnswerSpanRequest = new QueryDTOAnswerSpanRequest
                {
                    Enable = true,
                    ScoreThreshold = 50.0,
                    TopAnswersWithSpan = 3
                };

                var answer = client.Knowledgebase.GenerateAnswerAsync("9e65acc2-ce5e-4530-8ce1-abb19b9f66bd", queryDTO).Result;
                Assert.Equal(1, answer.Answers.Count);
                Assert.Equal(100, answer.Answers[0].Score);
            }
        }
    }
}
