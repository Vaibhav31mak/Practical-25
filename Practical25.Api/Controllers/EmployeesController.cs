namespace Practical25.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Creates a new employee record.
    /// </summary>
    /// <param name="command">The command containing employee details.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The result of the create operation.</returns>
    [HttpPost]
    public async Task<IActionResult> Create
        (CreateEmployeeCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves all employee records.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>Returns all employee records.</returns>
    //[HttpGet]
    //public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    //{
    //    var result = await mediator.Send(new GetAllEmployeesQuery(), cancellationToken);
    //    return Ok(result);
    //}

    /// <summary>
    /// Retrieves the employee with the specified identifier.
    /// </summary>
    /// <param name="id">The Id of the employee to retrieve.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>Returns the employee if found, otherwise returns NotFound.</returns>
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int? id, CancellationToken cancellationToken)
    {
        if(id == null)
        {
            var result = await mediator.Send(new GetAllEmployeesQuery(), cancellationToken);
            return Ok(result);
        }
        var GetByIdResult = await mediator.Send(new GetEmployeeByIdQuery(id.Value), cancellationToken);
        if (GetByIdResult == null)
        {
            return NotFound();
        }
        return Ok(GetByIdResult);
    }

    /// <summary>
    /// Deletes the employee with the specified id.
    /// </summary>
    /// <param name="id">The id of the employee to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>Returns Notfound if employee with specific id doesn't exist otherwise returns not found.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send
            (new DeleteEmployeeCommand(id), cancellationToken);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }

    /// <summary>
    /// Updates the employee with the specified id using the provided details in the request body.
    /// </summary>
    /// <param name="id">The id of the employee to update.</param>
    /// <param name="command">The command containing updated employee details.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>Returns NotFound if the employee with the specified id doesn't exist, otherwise returns the updated employee.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateEmployeeCommand command, CancellationToken cancellationToken)
    {
        if (id != command.Id)
        {
            return BadRequest("Id not matching Id in request body.");
        }
        var result = await mediator.Send(command, cancellationToken);
        if (result == 0)    
        {
            return NotFound();
        }
        return Ok(result);
    }
}
