using BusinessAccessLayer.UserBusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusinessLayer _userBusinessLayer;
        public UserController(IUserBusinessLayer userBusinessLayer)
        {
            _userBusinessLayer = userBusinessLayer;
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {

            try
            {
                var result = await _userBusinessLayer.GetMethod();
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound("No products found.");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            try
            {
                var result = await _userBusinessLayer.GetByIdUser(id);

                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound($"User with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("AddNewUser")]
        public async Task<IActionResult> InsertProduct(UserDto userDto)
        {
            try
            {
                await _userBusinessLayer.InsertMethod(userDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateProduct(Guid Id, UserDto userDto)
        {
            try
            {
                await _userBusinessLayer.UpdateMethod(userDto, Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteProduct(Guid Id)
        {
            try
            {
                await _userBusinessLayer.DeleteMethod(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
