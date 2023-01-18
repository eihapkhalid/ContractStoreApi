using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContractStoreApi.Models;
using ContractStoreApi.Services;

namespace ContractStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractsController : ControllerBase
    {
         private readonly ContractsService _contractsService;

    public ContractsController(ContractsService contractsService) =>
        _contractsService = contractsService;

    [HttpGet]
    public async Task<List<Contracts>> Get() =>
        await _contractsService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Contracts>> Get(string id)
    {
        var book = await _contractsService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Contracts newContract)
    {
        await _contractsService.CreateAsync(newContract);

        return CreatedAtAction(nameof(Get), new { id = newContract.Id }, newContract);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Contracts updatedBook)
    {
        var contract = await _contractsService.GetAsync(id);

        if (contract is null)
        {
            return NotFound();
        }

        updatedBook.Id = contract.Id;

        await _contractsService.UpdateAsync(id, updatedBook);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _contractsService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _contractsService.RemoveAsync(id);

        return NoContent();
    }
    }
}