using Human.Resources.API.Domain.Entities;
using Human.Resources.API.Domain.Interfaces;
using Human.Resources.API.DTOs;
using Human.Resources.API.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace Human.Resources.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkerController : Controller
    {
        private readonly IWorkerServices _workerServices;
        public WorkerController(IWorkerServices workerServices)
        {
            _workerServices = workerServices;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var worker = await _workerServices.GetById(id);

                if (worker != null)
                {
                    WorkerDTO workerData = WorkerMapper.MapWorkerEntityToDTO(worker);
                    return new OkObjectResult(workerData);
                }
                else
                {
                    return new NoContentResult();
                }
            }
            catch (Exception ex)
            {
                return ErrorResponse(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var worker = await _workerServices.GetAll();

                if (worker != null)
                {
                    var workers = WorkerMapper.MapWorkerEntityToDTO(worker);
                    return new OkObjectResult(workers);
                }
                else
                {
                    return new NoContentResult();
                }
            }
            catch (Exception ex)
            {
                return ErrorResponse(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("Active")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetActives()
        {
            try
            {
                var worker = await _workerServices.GetActives();

                if (worker != null)
                {
                    var workers = WorkerMapper.MapWorkerEntityToDTO(worker);
                    return new OkObjectResult(workers);
                }
                else
                {
                    return new NoContentResult();
                }
            }
            catch (Exception ex)
            {
                return ErrorResponse(500, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Insert(WorkerDTO workerDTO)
        {
            try
            {
                WorkerEntity worker = await _workerServices.Income(WorkerMapper.MapWorkerDtoToEntity(workerDTO));
                
                if (worker != null)
                {
                    WorkerDTO workerData = WorkerMapper.MapWorkerEntityToDTO(worker);
                    return new OkObjectResult(workerData);
                }
                else
                {
                    return new NoContentResult();
                }
            }
            catch (Exception ex)
            {
                return ErrorResponse(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id, WorkerFiredDTO workerFiredDTO)
        {
            try
            {
                await _workerServices.Fired(id, WorkerMapper.workerFiredDTOToEntity(workerFiredDTO));

                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return ErrorResponse(500, ex.Message);
            }
        }

        private IActionResult ErrorResponse(int codeError, string message)
        {
            ErrorMessageEntity errorMessage = new ErrorMessageEntity();
            errorMessage.CodeError = codeError;
            errorMessage.Message = message;

            return new BadRequestObjectResult(errorMessage);
        }


    }
}
