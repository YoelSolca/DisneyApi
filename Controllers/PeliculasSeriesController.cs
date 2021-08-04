using AutoMapper;
using DisneyApi.Entities;
using DisneyApi.Models;
using DisneyApi.Models.PeliculaSerie;
using DisneyApi.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace DisneyApi.Controllers
{
    [Route("movies")]
    [ApiController]
    public class PeliculasSeriesController : ControllerBase
    {
        private IRepository<PeliculaSerie> _repository;
        private IMapper _mapper;
        public PeliculasSeriesController(IRepository<PeliculaSerie> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
       
        [HttpGet()]
        public ActionResult<IEnumerable<PeliculaSerie>> GetAllPeliculaSerie([FromQuery] PeliculaSerieFilters peliculaSerieFilters)
        {
            var peliculaSerie = _repository.GetListP(peliculaSerieFilters);

            var peliculaSerieResult = _mapper.Map<IEnumerable<PeliculaSerieDto>>(peliculaSerie);

            return Ok(peliculaSerieResult);
        }

        [HttpGet("{movieID}")]
        public ActionResult<PeliculaSerie> GetPeliculaSerie(int movieID)
        {
            var peliculaSerie = _repository.GetListId(movieID);

            if(peliculaSerie == null)
            {
                return NotFound();
            }

            var peliculaSerieResult = _mapper.Map<PeliculaSerieDetallesDto>(peliculaSerie);

             return Ok(peliculaSerieResult);
        }


        [HttpPost]
        public ActionResult<PeliculaSerieDto> CreateMovie(PeliculaSerieForCreationDto peliculaSerie)
        {
            var movie = _mapper.Map<PeliculaSerie>(peliculaSerie);

            _repository.Add(movie);

            _repository.save();

            return NoContent();

        }

        // PUT api/<PeliculasSeriesController>/5
        [HttpPatch("{movieID}")]
        public ActionResult UpdateMovie(int movieID, JsonPatchDocument<PeliculaSerieForCreationDto> patchDocument)
        {
            var movie = _repository.GetListId(movieID);

            if(movie == null)
            {
                return NotFound();
            }

            var movieToPatch = _mapper.Map<PeliculaSerieForCreationDto>(movie);

            patchDocument.ApplyTo(movieToPatch, ModelState);

            if (!TryValidateModel(movieToPatch))
            {
                return ValidationProblem(ModelState);
            }

            var movieToResult = _mapper.Map(movieToPatch, movie);

            _repository.Updater(movieToResult);

            _repository.save();

            return NoContent();
        }

        // DELETE api/<PeliculasSeriesController>/5
        [HttpDelete("{movieID}")]
        public ActionResult DeleteMovie(int movieID)
        {
            var movie = _repository.GetListId(movieID);

            if(movie == null)
            {
                return NotFound();
            }

            _repository.Delete(movie);

            _repository.save();

            return NoContent();
        }
    }
}
