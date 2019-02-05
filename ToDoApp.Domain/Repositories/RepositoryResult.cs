namespace ToDoApp.Domain.Repositories
{
    public class RepositoryResult
    {
        public RepositoryResultStatus RepositoryStatus { get; set; }
        public string Message { get; set; }

        public RepositoryResult()
        {
            RepositoryStatus = RepositoryResultStatus.Success;
        }

        public RepositoryResult(string message): base()
        {
            Message = message;
        }
    }
}