using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.DTOs;
using WebApplication3.Entities;
using WebApplication3.Exceptions;

namespace WebApplication3.Services;

public class DbService : IDbService
{
    private readonly AppDbContext _dbcontext;

    public DbService(AppDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    public async Task<PCWithComponentsDto> GetPCById(int id)
    {
        var res = await _dbcontext.Pcs
            .Where(x => x.Id == id)
            .Select(x => new PCWithComponentsDto
            {
                Id = x.Id,
                Name = x.Name,
                Weight = x.Weight,
                Warranty = x.Warranty,
                CreatedAt = x.CreatedAt,
                Stock = x.Stock,
                Components = x.PcComponents.Select(pcc => new GetAllComponentsDto
                {
                    Amount = pcc.Amount, 
                    getComponentDto = new GetComponentDto
                    {
                        Code = pcc.Component.Code,
                        Name = pcc.Component.Description,
                        GetComponentManufacturerDto = new GetComponentManufacturerDto
                        {
                            Id = pcc.Component.ComponentManufacturer.Id,
                            Abbreviation = pcc.Component.ComponentManufacturer.Abbreviation,
                            FullName = pcc.Component.ComponentManufacturer.FullName,
                            FoundationDate = pcc.Component.ComponentManufacturer.FoundationDate
                        },
                        GetComponentTypeDto = new GetComponentTypeDto
                        {
                            Id = pcc.Component.ComponentType.Id,
                            Abbreviation = pcc.Component.ComponentType.Abbreviation,
                            Name = pcc.Component.ComponentType.Name
                        }
                    }
                }).ToList()
            })
            .FirstOrDefaultAsync();
        if (res == null)
        {
            throw new NotFoundException();
        }

        return res;
    }


    public async Task UpdatePCAsync(int id, UpdatePCDto pcDto)
    {
        var pc = await _dbcontext.Pcs.FirstOrDefaultAsync(p => p.Id == id);
        if (pc == null)
        {
            throw new NotFoundException();
        }

        pc.Name = pcDto.Name;
        pc.Weight = pcDto.Weight;
        pc.Warranty = pcDto.Warranty;
        pc.CreatedAt = pcDto.CreatedAt;
        pc.Stock = pcDto.Stock;

        await _dbcontext.SaveChangesAsync();
    }

    public async Task DeletePCAsync(int id)
    {
        var pc = await _dbcontext.Pcs.FirstOrDefaultAsync(p => p.Id == id);
        if (pc == null)
        {
            throw new NotFoundException();
        }

        _dbcontext.Pcs.Remove(pc);
        await _dbcontext.SaveChangesAsync();
        return;
    }

    public async Task<GetPCDto> AddPCAsync(AddPCDto pcDto)
    {
        var pc = new PC()
        {
            Name = pcDto.Name,
            Weight = pcDto.Weight,
            Warranty = pcDto.Warranty,
            CreatedAt = DateTime.Now,
            Stock = pcDto.Stock
        };
        await _dbcontext.AddAsync(pc);
        await _dbcontext.SaveChangesAsync();
        return new GetPCDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }
    
    public async Task<IEnumerable<GetAllPCsDto>> GetAllPCsAsync()
    {
        return await _dbcontext.Pcs.Select(p => new GetAllPCsDto
        {
            Id = p.Id,
            Name = p.Name,
            Weight = p.Weight,
            Warranty = p.Warranty,
            CreatedAt = p.CreatedAt,
            Stock = p.Stock
        }
        ).ToListAsync();
    }
    
}