namespace TimeSheet.Domain.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int RoleId { get; set; }
        public int ActivityTypeId { get; set; }
        public int EmployeeId { get; set; }


        public virtual Project Project { get; set; }
        public virtual Role Role { get; set; }
        public virtual ActivityType ActivityType { get; set; }
        public virtual Employee Employee { get; set; }

    }
}
//For example, 25.06.2022 as a "Software Engineer" [Role] I worked on the "Project_3" [Project] 8
//hours regular work [activity type] but 26.06.2022 as a "Software Architect"[Role] I worked on 
//the "Project_2" [Project] 2 hours overtimes[activity type] and 6 hours as a "team lead" [Role]
//on the "Project_1" [Project] regular work[activity type].