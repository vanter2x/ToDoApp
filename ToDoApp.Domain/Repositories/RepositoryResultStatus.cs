using System.ComponentModel;

namespace ToDoApp.Domain.Repositories
{
    public enum RepositoryResultStatus
    {
        [Description("Błąd")]
        Error = 0,

        [Description("Sukces")]
        Success = 1,

        [Description("Ostrzeżenie")]
        Warning = 2,

        [Description("Informacja")]
        Information = 3,
    }
}