using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Dto;
using TimeSheet.Application.Mapper;
using TimeSheet.Domain.Exceptions;
using TimeSheet.Infrastructure.Dal;
using static TimeSheet.Domain.Constants.ResponseMessage;

namespace TimeSheet.Infrastructure.Services.Proccesing
{
    public class EmployeeProccesing : IEmployeeProccesing
    {
        private readonly TimeSheetContext _timeSheetContext;
        public EmployeeProccesing(TimeSheetContext timeSheetContext)
        {
            _timeSheetContext = timeSheetContext;
        }

        public async Task<DataServiceMessage> CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto)
        {
            var mapper = Mapping.CreateEmployeeDtoToEmployee(createEmployeeDto);

            await _timeSheetContext.Employee.AddAsync(mapper);
            await _timeSheetContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.AddedSuccessfully, mapper);
            return data;
        }

        public async Task<DataServiceMessage> DeleteEmployeeAsync(DeleteEmployeeDto deleteEmployeeDto)
        {
            var employee = await _timeSheetContext.Employee.FirstOrDefaultAsync(x => x.Id == deleteEmployeeDto.Id);

            if (employee == null)
                throw new InvalidEmployeeException(deleteEmployeeDto.Id);

            _timeSheetContext.Employee.Remove(employee);
            await _timeSheetContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.DeletedSuccessfully, employee);
            return data;
        }

        public async Task<DataServiceMessage> UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = await _timeSheetContext.Employee.AsNoTracking().FirstOrDefaultAsync(x => x.Id == updateEmployeeDto.Id);

            if (employee == null)
                throw new InvalidEmployeeException(updateEmployeeDto.Id);

            var mapper = Mapping.UpdateEmployeeDtoToEmployee(updateEmployeeDto);

            _timeSheetContext.Employee.Update(mapper);
            await _timeSheetContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.UpdatedSuccessfully, mapper);
            return data;
        }
    }
}
