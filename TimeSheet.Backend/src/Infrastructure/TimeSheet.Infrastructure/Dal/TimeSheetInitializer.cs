namespace TimeSheet.Infrastructure.Dal
{
    public class TimeSheetInitializer
    {
        public static void Initializer(TimeSheetContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
