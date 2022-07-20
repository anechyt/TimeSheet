namespace TimeSheet.Application.Dto
{
    public class CreateActivityDto
    {
        public int ProjectId { get; set; }
        public int RoleId { get; set; }
        public int ActivityTypeId { get; set; }
        public int EmployeeId { get; set; }
    }
}
