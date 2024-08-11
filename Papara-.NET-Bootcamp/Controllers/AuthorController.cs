using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Papara.NET.Bootcamp.Models;
using Papara.NET.Bootcamp.Models.DTOs;
using Papara.NET.Bootcamp.Models.Entities;
using Papara.NET.Bootcamp.Services;

namespace Papara.NET.Bootcamp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AuthorCreateDto> _createValidator;
        private readonly IValidator<AuthorUpdateDto> _updateValidator;

        public AuthorController(IMapper mapper, IUnitOfWork unitOfWork,
                                IValidator<AuthorCreateDto> createValidator,
                                IValidator<AuthorUpdateDto> updateValidator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorCreateDto authorCreateDto)
        {
            var validationResult = await _createValidator.ValidateAsync(authorCreateDto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var author = _mapper.Map<Author>(authorCreateDto);
            _unitOfWork.AuthorRepository.Add(author);
            await _unitOfWork.CompleteAsync();

            var authorReadDto = _mapper.Map<AuthorReadDto>(author);
            return CreatedAtAction(nameof(GetAuthorById), new { id = authorReadDto.Id }, authorReadDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorUpdateDto authorUpdateDto)
        {
            var validationResult = await _updateValidator.ValidateAsync(authorUpdateDto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var author = await _unitOfWork.AuthorRepository.GetByIdAsync(id);
            if (author == null)
                return NotFound();

            _mapper.Map(authorUpdateDto, author);
            _unitOfWork.AuthorRepository.Update(author);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _unitOfWork.AuthorRepository.GetByIdAsync(id);
            if (author == null)
                return NotFound();

            if (author.Books.Any())
                return BadRequest("Kitabı yayında olan bir yazar silinemez. Önce kitabı silin.");

            _unitOfWork.AuthorRepository.Remove(author);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _unitOfWork.AuthorRepository.GetAllAsync();
            var authorReadDtos = _mapper.Map<IEnumerable<AuthorReadDto>>(authors);
            return Ok(authorReadDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _unitOfWork.AuthorRepository.GetByIdAsync(id);
            if (author == null)
                return NotFound();

            var authorReadDto = _mapper.Map<AuthorReadDto>(author);
            return Ok(authorReadDto);
        }
    }
}
