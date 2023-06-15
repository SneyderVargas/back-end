namespace login.Dtos.Infrastructure
{
    public class ApiSingleResponseDto
    {
        public string Message { get; set; }

        public ApiSingleResponseDto(string message)
        {
            Message = message;
        }
    }
}
