using CurdTodoList.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CurdTodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ListController : ControllerBase
    {
     private readonly ListContext _dbContext;
        private object _logger;

        public ListController(ListContext dbContext)
        {
            _dbContext = dbContext;
        }
        // get api
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<List>>> GetLists() 

        { 
            if(_dbContext.Lists == null)
            {
                return NotFound();
            }
          

            return await _dbContext.Lists.ToListAsync();
        }

        // get api by id
        [Authorize]
        [HttpGet("{id}")]
      
        public async Task<ActionResult<List>> GetLists(int id)

        {
            if (_dbContext.Lists == null)
            {
                return NotFound();
            }
            var list = await _dbContext.Lists.FindAsync(id);
            if (list == null)
            {
                return NotFound();
            }

            return list;
        }
        // Post api
        [Authorize]
        [HttpPost]
        public async  Task<ActionResult<List>> PostBrand(List list)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            object value = _dbContext.Add(list);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLists), new {id = list.ID}, list);
        }

        // put api
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> PutResult (int id,[FromBody] List list)
        {
           
            if (id != list.ID)
            {

                return BadRequest();
            }
            _dbContext.Entry(list).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListAvailable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return Ok();
        }
        private bool ListAvailable(int id)
        {
            return (_dbContext.Lists?.Any(x => x. ID == id)).GetValueOrDefault();
        }

        // delete api
        [Authorize]
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteList (int id)
        {
            if(_dbContext.Lists == null)
            {
                return NotFound();
            }
            var list =await  _dbContext.Lists.FindAsync(id);
            if(list == null)
            {
                return NotFound();
            }
            _dbContext.Lists.Remove(list);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }

}
