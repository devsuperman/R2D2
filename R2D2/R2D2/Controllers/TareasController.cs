using Microsoft.AspNetCore.Mvc;
using Dominio.Interfaces;
using Dominio.Models;

namespace R2D2.Controllers
{
    [ApiController]
    [Route("api/tareas")]
    public class TareasController : ControllerBase
    {
        private readonly ITareasRepository _repository;

        public TareasController(ITareasRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
                return NotFound();

            var model = await _repository.GetAsync(id.Value);

            if (model is null)
                return NotFound();

            return Ok(model);
        }


        [HttpPost]
        public async Task<IActionResult> Post(Tarea model)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(model);
                return Ok(model);
            }

            return Ok(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Tarea model)
        {
            if (model.Id == 0)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _repository.UpdateAsync(model);
                return Ok(model);
            }
            return Ok(ModelState);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _repository.GetAsync(id);
            
            await _repository.DeleteAsync(id);

            return Ok(model);
        }
    }
}
