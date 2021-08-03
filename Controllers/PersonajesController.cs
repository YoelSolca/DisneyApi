using AutoMapper;
using DisneyApi.Entities;
using DisneyApi.Models;
using DisneyApi.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DisneyApi.Controllers
{
    [Route("characters")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private IRepository<Personaje> _repository;
        private IMapper _mapper;
        public PersonajesController(IRepository<Personaje> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<PersonajeDto>> GetAuthors([FromQuery] PersonajesFilters personajesFilters)

        {
            var personajes = _repository.GetList(personajesFilters);

            var personajeResult = _mapper.Map<IEnumerable<PersonajeDto>>(personajes);

            return Ok(personajeResult);
        }

        [HttpGet("{personajeID}")]
        public ActionResult<Personaje> GetAllPersonajes(int personajeID)
        {
            var personajes = _repository.GetListId(personajeID);


            if(personajes == null){

                return NotFound();
            }

            var personajeResult = _mapper.Map<PersonajeDetalleDto>(personajes);
            return Ok(personajeResult);
        }

        [HttpPost]

        public ActionResult<PersonajeDto> CreatePersonaje(PersonajeForCreationDto personaje)
        {
            var character = _mapper.Map<Personaje>(personaje);

            _repository.Add(character);

            _repository.save();

            return NoContent();
        }

        [HttpPatch("{personajeID}")]
        public ActionResult UpdatePartialPersonaje(int personajeID, JsonPatchDocument<PersonajeForUpdateDto> patchDocument)
        {
            var character = _repository.GetListDetalle(personajeID);

            if (character == null)
            {
                return NotFound();
            }

            var characterToPatch = _mapper.Map<PersonajeForUpdateDto>(character);

            patchDocument.ApplyTo(characterToPatch, ModelState);

            if (!TryValidateModel(characterToPatch))
            {
                return ValidationProblem(ModelState);
            }

            var characterToResult = _mapper.Map(characterToPatch, character);

            _repository.Updater(characterToResult);
            _repository.save();

            return NoContent();
        }



        [HttpDelete("{personajeID}")]
        public ActionResult DeletePersonaje(int personajeID)
        {
            var character = _repository.GetListId(personajeID);

            if(character == null)
            {
                return NotFound();
            }

            _repository.Delete(character);

            _repository.save();

            return NoContent();
        }
         
    }
}
