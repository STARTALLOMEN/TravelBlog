using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Models;

namespace API.Services
{
    public interface IQuestionService
    {
        List<Question>? GetAllQuestion();
        QuestionDto? GetQuestionById(int id);
        List<Question>? GetQuestionsByName(string name);
        Question? GetQuestionByName(string name);
        List<QuestionDto>? GetQuestionByDesId(int desId);
        //List<Question>? GetQuestionsOfProvice(int provinceId);
        void CreateQuestion(QuestionAdd Question, string username);
    }
}