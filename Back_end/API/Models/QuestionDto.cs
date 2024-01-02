namespace API.Models
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public List<ImageQuestionDto> ImageQuestionsDto { get; set; }
        public List<DestinationDto> DesDto { get; set; }
        
    }
}