using WebApplication3.DTOs;

namespace WebApplication3.Services;

public interface IDbService
{
    Task <GetPCDto> AddPCAsync(AddPCDto pc);
    Task<IEnumerable<GetAllPCsDto>> GetAllPCsAsync();
    Task<PCWithComponentsDto> GetPCById(int id);
    Task UpdatePCAsync(int id, UpdatePCDto pc);
    Task DeletePCAsync(int id);
}