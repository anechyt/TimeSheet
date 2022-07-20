using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Dto;

namespace TimeSheet.Application.Queries.Project.GetById
{
    public class GetProjectsById : IQuery<DataServiceMessage>
    {
        public int Id { get; set; }
    }
}
