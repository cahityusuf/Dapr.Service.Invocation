namespace Microservice.Abstraction.Application.Models
{
    /// <summary>
    /// Success result.
    /// </summary>
    public class SuccessResult<T> : Result<T>
    {
        private readonly T _data;
        public SuccessResult(T data) : base()
        {
            _data = data;
        }
        public override ResultType ResultType => ResultType.Ok;
        public override bool Success => true;
        public override List<string> Messages { get; set; }
        public override T Data => _data;
    }
}
