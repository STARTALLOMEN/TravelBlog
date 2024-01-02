using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;

namespace API.Repositories
{
    public interface IQuestionRepository
    {
        List<Question>? GetAllQuestion();
        Question? GetQuestionById(int id);
        List<Question>? GetQuestionsByName(string name);
        Question? GetQuestionByName(string name);
        List<Question>? GetQuestionsOfProvice(int provinceId);
        // List<Question>? GetQuestionPopular();
        Task<bool> CreateQuestion(Question Question);
        bool SaveChanges();
        Question? GetLastQuestionByUserId(int userId);
        void CreateImageQuestion(ImageQuestion imageQuestion);
        List<Question>? GetQuestionByDesId(int desId);
        void CreateQuestionDestination(int quesId, List<int> desId);

    }
}