using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using API.Data.Entities;
using API.Models;
using API.Repositories;

namespace API.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUploadImgService _uploadImgService;
        public QuestionService(IQuestionRepository repository, IUserRepository userRepository, IMapper mapper, IUploadImgService uploadImgService)
        {
            _repository = repository;
            _userRepository = userRepository;
            _mapper = mapper;
            _uploadImgService = uploadImgService;
        }

        public void CreateQuestion(QuestionAdd questionadd, string username)
        {
            var user = _userRepository.GetUserByUsername(username);
            var Question = _mapper.Map<QuestionAdd, Question>(questionadd);
            Question.UserId = user.Id;
            Question.CreatedAt = DateTime.Now;
            Question.UpdateAt = DateTime.Now;
            _repository.CreateQuestion(Question);
            var lastQues = _repository.GetLastQuestionByUserId(user.Id);
            if (questionadd.ImageQuestionsFile != null)
            {
                
                foreach (var image in questionadd.ImageQuestionsFile)
                {
                    var linkImage = _uploadImgService.UploadImage("QuestionImage", username, image);
                    var imageQuestion = new ImageQuestion{
                        Images = linkImage.Result,
                        QuestionId = lastQues.Id
                    };
                    _repository.CreateImageQuestion(imageQuestion);
                }
            }
            if (questionadd.DesId != null)
            {
                _repository.CreateQuestionDestination(lastQues.Id, questionadd.DesId);
            }
        }

        public List<Question>? GetAllQuestion()
        {
            return _repository.GetAllQuestion();
        }

        public QuestionDto? GetQuestionById(int id)
        {
            return _mapper.Map<Question, QuestionDto>(_repository.GetQuestionById(id));
        }

        public Question? GetQuestionByName(string name)
        {
            return _repository.GetQuestionByName(name);
        }

        public List<QuestionDto>? GetQuestionByDesId(int desId)
        {
            // var listQuestion = _repository.GetAllQuestion();
            // var listQuestionDes = new List<QuestionDto>();
            // var listQuestionDes = _mapper.Map<List<Question>, List<QuestionDto>>(listQuestion);
            // List<QuestionDto> questionDtos = _mapper.ProjectTo<QuestionDto>(listQuestion).ToList();
            var listQuestion = _repository.GetQuestionByDesId(desId);
            List<QuestionDto> questionDtoss = listQuestion.Select(q => _mapper.Map<QuestionDto>(q)).ToList();
            // if (listQuestion != null)
            // {
            //     foreach (var question in listQuestion)
            //     {
            //         foreach (var questiondDes in question.QuestionDestinations)
            //         {
            //             if (questiondDes.DestinationId == desId)
            //             {
            //                 listQuestionDes.Add(_mapper.Map<Question, QuestionDto>(question));
            //             }
            //         }
            //     }
            // }
            // if (listQuestion != null)
            // {
            //     foreach (var question in listQuestion)
            //     {
            //         foreach (var questiondDes in question.QuestionDestinations)
            //         {
            //             if (questiondDes.DestinationId == desId)
            //             {
            //                 listQuestionDes.Add(_mapper.Map<Question, QuestionDto>(question));
            //             }
            //         }
            //     }
            // }

            return questionDtoss;
        }

        public List<Question>? GetQuestionsByName(string name)
        {
            return _repository.GetQuestionsByName(name);
        }

        // public List<Question>? GetQuestionsOfProvice(int provinceId)
        // {
        //     var listQuestion = _repository.GetAllQuestion();
        //     var QuestionsOfProvince = new List<Question>();
        //     if (listQuestion != null)
        //     {
        //         foreach (var Question in listQuestion)
        //         {
        //             if (Question.Ward.Dictrict.Province.Id == provinceId)
        //             {
        //                 QuestionsOfProvince.Add(Question);
        //             }
        //         }
        //     }
        //     return QuestionsOfProvince;
        // }
    }
}