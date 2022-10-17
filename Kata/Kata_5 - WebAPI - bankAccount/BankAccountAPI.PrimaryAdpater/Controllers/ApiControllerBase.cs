using Microsoft.AspNetCore.Mvc;


namespace BankAccountAPI.PrimaryAdpater.Controllers
{
public class ApiControllerBase: ControllerBase{
        protected async Task<ActionResult<T>> ExecuteGet<T>(Func<Task<T>> action, string customErrorMessage)
        {
            try
            {
                return Ok(await action());
            }
            catch (Exception ex)
            {
                return StatusCode( 500, new { errorMessage = ex.Message });
            }
        }
        protected async Task<ActionResult> ExecutePost(Func<Task> action, string customErrorMessage)
        {
            try
            {
                await action();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errorMessage = ex.Message });
            }
        }

        protected async Task<ActionResult> ExecutePost<T>(Func<Task<T>> action, string customErrorMessage)
        {
            try
            {
                return Ok(await action());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errorMessage = ex.Message });
            }
        }
    }
}