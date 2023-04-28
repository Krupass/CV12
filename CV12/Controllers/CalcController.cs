using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        [HttpPost(Name = "Calculate")]
        public decimal Post([FromBody] CalcDTO calcDTO)
        {
            decimal result = 0;
            switch (calcDTO.Operation) { 
                case("divide"):
                    if (calcDTO.Operand2 != 0)
                    {
                        result = decimal.Parse(calcDTO.Operand1.ToString()) / decimal.Parse(calcDTO.Operand2.ToString());
                    }
                    break;
                case ("times"):
                    result = decimal.Parse(calcDTO.Operand1.ToString()) * decimal.Parse(calcDTO.Operand2.ToString());
                    break;
                case ("plus"):
                    result = decimal.Parse(calcDTO.Operand1.ToString()) + decimal.Parse(calcDTO.Operand2.ToString());
                    break;
                case ("minus"):
                    result = decimal.Parse(calcDTO.Operand1.ToString()) - decimal.Parse(calcDTO.Operand2.ToString());
                    break;
            }

            return result;
        }

    }
}
