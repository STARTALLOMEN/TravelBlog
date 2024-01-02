using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace API.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DataContext _context;
        public QuestionRepository(DataContext context)
        {
            _context = context;
        }
        public List<Question>? GetAllQuestion()
        {
            return _context.Questions.Include(p => p.QuestionDestinations).ThenInclude(w => w.Destination)
                                    .Include(p => p.ImageQuestions)
                                    .ToList();
        }

        public Question? GetQuestionById(int id)
        {
            return _context.Questions.FirstOrDefault(u => u.Id == id);
        }

        public List<Question>? GetQuestionsByName(string name)
        {
            return _context.Questions.Where(u => u.Title == name).ToList();
        }
        public Question? GetQuestionByName(string name)
        {
            var query = _context.Questions.Include(p => p.QuestionDestinations).ThenInclude(w => w.Destination)
                                            .Include(p => p.ImageQuestions)
                                            .FirstOrDefault(u => u.Title == name);
            if (query == null)
            {
                query = _context.Questions.FirstOrDefault(delegate (Question c)
                {
                    if (ConvertToUnSign(c.Title).IndexOf(name, StringComparison.CurrentCultureIgnoreCase) >= 0)
                        return true;
                    else
                        return false;
                });

            }
            return query;
        }

        public List<Question>? GetQuestionsOfProvice(int provinceId)
        {
            throw new NotImplementedException();
        }

        public static string RemoveDiacritics(string text)
        {
            string normalizedString = text.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < normalizedString.Length; i++)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(normalizedString[i]);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(normalizedString[i]);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
        private string ConvertToUnSign(string input)
        {
            input = input.Trim();
            for (int i = 0x20; i < 0x30; i++)
            {
                input = input.Replace(((char)i).ToString(), " ");
            }
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string str = input.Normalize(NormalizationForm.FormD);
            string str2 = regex.Replace(str, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
            while (str2.IndexOf("?") >= 0)
            {
                str2 = str2.Remove(str2.IndexOf("?"), 1);
            }
            return str2;
        }

        // public List<Question>? GetQuestionPopular()
        // {
        //    var top10Questions = _context.Questions
        //     .OrderByDescending(t => t.ReviewQuestions.Count())    
        //     .Take(10)
        //     .ToList();

        // return top10Questions;
        // }

        public async Task<bool> CreateQuestion(Question Question)
        {
            _context.Questions.Add(Question);
            return SaveChanges();
            ;
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public Question? GetLastQuestionByUserId(int userId)
        {
            var lastAddedQues = _context.Questions
                                        .Where(q => q.UserId == userId)
                                        .OrderByDescending(q => q.CreatedAt)
                                        .FirstOrDefault();
            return lastAddedQues;
        }

        public void CreateImageQuestion(ImageQuestion imageQuestion)
        {
            _context.ImageQuestions.Add(imageQuestion);
            SaveChanges();
        }

        public List<Question>? GetQuestionByDesId(int desId)
        {
            var questions = _context.Destinations
                                    .Where(d => d.Id == desId)
                                    .SelectMany(d => d.QuestionDestinations)
                                    .Include(qd => qd.Question.ImageQuestions)
                                    .Include(qd => qd.Question.User)
                                    .Include(qd => qd.Question.QuestionDestinations).ThenInclude(m => m.Destination)
                                    .Select(qd => qd.Question)
                                    .ToList();
            return questions;
        }

        public void CreateQuestionDestination(int quesId, List<int> desId)
        {
            foreach(int id in desId){
                _context.QuestionDestinations.Add(new QuestionDestination {
                    QuestionId = quesId,
                    DestinationId = id
                });
                SaveChanges();
            }
        }
    }
}