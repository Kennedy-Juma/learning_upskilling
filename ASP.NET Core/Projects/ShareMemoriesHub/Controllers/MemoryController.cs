using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShareMemoriesHub.Interfaces;
using ShareMemoriesHub.Models;
using ShareMemoriesHub.Models.Memories;


namespace ShareMemoriesHub.Controllers
{
    [Route("api/memory")]
    [ApiController]
    public class MemoryController : ControllerBase
    {
        private IMemoryFactory memoryFactory;
        public MemoryController(IMemoryFactory _memoryFactory) 
        {
            memoryFactory = _memoryFactory;
        }
        [HttpPost("create", Name = "create")]
        public async Task<IActionResult> CreateMemory(Memory memory)
        {

           var response= await memoryFactory.CreateMemoryAsync(memory);
            if(response.Equals(false))
            {
             return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "There was an error creating your memory. Please try again" });
            }
            return Ok(memory);
            
        }
        [HttpPost("delete", Name = "delete")]
        public async Task<IActionResult> DeleteMemory(string Id)
        {

            var response = await memoryFactory.DeleteMemoryAsync(Id);
            if (response.Equals(false))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "There was an error deleting your memory. Please try again" });
            }
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Deleted Successfuls" });

        }
    }
}
