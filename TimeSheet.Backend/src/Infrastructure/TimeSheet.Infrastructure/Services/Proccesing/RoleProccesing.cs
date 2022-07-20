using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Dto;
using TimeSheet.Application.Mapper;
using TimeSheet.Domain.Exceptions;
using TimeSheet.Infrastructure.Dal;
using static TimeSheet.Domain.Constants.ResponseMessage;

namespace TimeSheet.Infrastructure.Services.Proccesing
{
    public class RoleProccesing : IRoleProccesing
    {
        private readonly TimeSheetContext _timeSheetContext;
        public RoleProccesing(TimeSheetContext timeSheetContext)
        {
            _timeSheetContext = timeSheetContext;
        }

        public async Task<DataServiceMessage> CreateRoleAsync(CreateRoleDto createRoleDto)
        {
            var mapper = Mapping.CreateRoleDtoToRole(createRoleDto);

            await _timeSheetContext.Role.AddAsync(mapper);
            await _timeSheetContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.AddedSuccessfully, mapper);
            return data;
        }

        public async Task<DataServiceMessage> DeleteRoleAsync(DeleteRoleDto deleteRoleDto)
        {
            var role = await _timeSheetContext.Role.FirstOrDefaultAsync(x => x.Id == deleteRoleDto.Id);

            if (role == null)
                throw new InvalidRoleException(deleteRoleDto.Id);

            _timeSheetContext.Role.Remove(role);
            await _timeSheetContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.DeletedSuccessfully, role);
            return data;
        }

        public async Task<DataServiceMessage> UpdateRoleAsync(UpdateRoleDto updateRoleDto)
        {
            var role = await _timeSheetContext.Role.AsNoTracking().FirstOrDefaultAsync(x => x.Id == updateRoleDto.Id);

            if (role == null)
                throw new InvalidRoleException(updateRoleDto.Id);

            var mapper = Mapping.UpdateRoleDtoToRole(updateRoleDto);

            _timeSheetContext.Role.Update(mapper);
            await _timeSheetContext.SaveChangesAsync();


            var data = new DataServiceMessage(true, GoodResponse.UpdatedSuccessfully, mapper);
            return data;
        }
    }
}
