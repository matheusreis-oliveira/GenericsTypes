using Microsoft.AspNetCore.Mvc;
using TaskSystem.Repository.Interfaces;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity> : ControllerBase where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        protected BaseController(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TEntity>>> GetAll()
        {
            List<TEntity> entities = await _repository.GetAll();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> GetById(Guid id)
        {
            TEntity entity = await _repository.GetById(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<TEntity>> Create([FromBody] TEntity entity)
        {
            TEntity createdEntity = await _repository.Create(entity);
            return Ok(createdEntity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TEntity>> Update([FromBody] TEntity entity, Guid id)
        {
            TEntity updatedEntity = await _repository.Update(entity, id);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _repository.Delete(id);
            return Ok();
        }
    }
}
