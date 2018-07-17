using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Brainence.Models;

namespace Brainence.Helpers
{
    public static class TextParserHelper
    {
        public static List<SentenceRecordModel> Parse(this string text, string word)
        {
            var result = new List<SentenceRecordModel>();

            var splitedSentences = text.Split(".", StringSplitOptions.RemoveEmptyEntries);

            foreach (var sentence in splitedSentences)
            {
                var count = Regex.Matches(sentence, word).Count;

                if (count > 0)
                {
                    var sentenceArray = sentence.ToCharArray();
                    Array.Reverse(sentenceArray);
                    result.Add(new SentenceRecordModel {Sentence = new string(sentenceArray), WordsCount = count});
                }
            }

            return result;
        }
    }
}