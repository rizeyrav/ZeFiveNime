using Microsoft.AspNetCore.Mvc;
using ZeFiveNime.Models;
using ZeFiveNime.Repositories;
using System.Collections.Generic;

namespace ZeFiveNime.Controllers{
    [Route("api/Controller")]
    [ApiController]
    public class Animation : ControllerBase {
        private readonly IAnimationRepository _animationRepository;
        public Animation(IAnimationRepository animationRepository){
            _animationRepository = animationRepository;
        }
        // Menampilkan seluruh animasi
        [HttpGet]
        public ActionResult<IEnumerable<Animation>>GetAnimation(){
            var animations = _animationRepository.GetAll();
            return Ok(animations);
        }
        // Menampilkan Animasi berdasarkan Id
        [HttpGet("{id}")]
        public ActionResult<Animation> GetAnimation(int id){
            var animation = _animationRepository.GetById(id);
            if(animation == null){
                return NotFound();
            }
            return Ok(animation);
        }
        // Menambahkan Animasi baru
        [HttpPost]
        public ActionResult<Animation> CreateAnimation([FromBody] ZeFiveNime.Models.Animation animation){
            _animationRepository.Add(animation);
            return CreatedAtAction(nameof(GetAnimation),new {id = animation.Id},animation);
        }
        // Update Data Animasi
        [HttpPut("{id}")]
        public IActionResult UpdateAnimation(int id,[FromBody] ZeFiveNime.Models.Animation animation){
            if(id != animation.Id){
                return BadRequest();
            }
            var existAnimation = _animationRepository.GetById(id);
            if(existAnimation == null){
                return NotFound();
            }
            _animationRepository.Update(animation);
            return NoContent();
        }
        // Menghapus Data animasi
        [HttpDelete("{id}")]
        public IActionResult DeleteAnimation(int id){
            var existAnimation = _animationRepository.GetById(id);
            if(existAnimation == null){
                return NotFound();
            }
             _animationRepository.Delete(id);
             return NoContent();
        }
    }
}