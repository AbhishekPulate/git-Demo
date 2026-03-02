using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class CustomerController : ControllerBase
{
    ICustomerService customerService;
    public CustomerController(ICustomerService customerService)
    {
        this.customerService = customerService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(customerService.GetAllCustomers());
    }

    [HttpPost]
    public IActionResult Post(Customer customer)
    {
        return Ok(customer);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Customer customer)
    {
        return Ok(customer);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok();
    }
}