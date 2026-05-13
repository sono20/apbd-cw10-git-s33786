using Microsoft.AspNetCore.Mvc;
using WebApplication3.DTOs;
using WebApplication3.Exceptions;
using WebApplication3.Services;

namespace WebApplication3.Controllers;
[Route("api/[controller]")]
[ApiController]

public class PCsController : ControllerBase
{
    private readonly IDbService _dbService;

    public PCsController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [Route("api/[controller]")]
    [HttpGet]
    public async Task<IActionResult> GetAllPCs()
    {
            var res = await _dbService.GetAllPCsAsync();
            return Ok(res);
            
    }

    [Route("{id}/components")]
    [HttpGet]
    public async Task<IActionResult> GetPcById(int id)
    {
        try
        {
            var res = await _dbService.GetPCById(id);
            return Ok(res);
        }
        catch (NotFoundException)
        {
            return NotFound($"Komputer o ID {id} nie istnieje.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddPC (AddPCDto pcDto)
    {
        var result = await _dbService.AddPCAsync(pcDto);
        return CreatedAtAction(nameof(GetPcById), new { id = result.Id }, result);
    }
    
    [Route("{id}")]
    [HttpPut]
    public async Task<IActionResult> UpdatePc(int id, UpdatePCDto pc)
    {
        try
        {
            await _dbService.UpdatePCAsync(id, pc);
            return Ok("Dane zostały zaktualizowane");
        }
        catch (NotFoundException e)
        {
            return NotFound($"Nie znaleziono komputera o ID {id} do aktualizacji");
        }
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeletePc(int id)
    {
        try
        {
            await _dbService.DeletePCAsync(id);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound($"Nie znaleziono komputera o ID {id} do usunięcia.");
        }
    }

}   