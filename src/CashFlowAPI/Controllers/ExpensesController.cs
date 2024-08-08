using CashFlow.Application.UseCase.Expenses.Register;
using CashFlow.Communication.Request;
using CashFlow.Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowAPI.Controllers
{
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {

        [HttpPost]
        public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
        {
            try
            {

                var useCase = new RegisterExpenseUseCase();

                var response = useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch (ArgumentException ex)
            {
                var errorResponse = new ResponseErrorJson(ex.Message)
                {
                    ErrorMessage = ex.Message
                };

                return BadRequest(errorResponse);
            }
            
            catch
            {

                var errorResponse = new ResponseErrorJson("unknown error");
                

                return StatusCode(StatusCodes.Status500InternalServerError, "unknown error");
            }

        }
    }
}
