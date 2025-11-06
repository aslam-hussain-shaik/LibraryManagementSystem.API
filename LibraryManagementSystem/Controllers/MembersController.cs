using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;
        public MembersController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _memberRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
           return (await _memberRepository.GetByIdAsync(id)) is Member m ? Ok(m) : NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Member member)
        {
            return Created(string.Empty, await _memberRepository.AddAsync(member));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Member member)
        {
            if (id != member.Id) return BadRequest();
            await _memberRepository.UpdateAsync(member);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _memberRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
