using System.Collections.Generic;
using System.Linq;
using ZeFiveNime.Models;

namespace ZeFiveNime.Repositories
{
    public class AnimationRepository : IAnimationRepository{
        // Menampung value sementara menggunakan list
        private readonly List<Animation> _animations = new List<Animation>();
        public IEnumerable<Animation> GetAll(){
            return _animations;
        }
        public Animation GetById(int id){
            // if(_sanimations == null){
            //     return NotFound();
            // }else{
                return _animations.FirstOrDefault(a => a.Id == id);
            // }
        }
        public void Add(Animation animation) => _animations.Add(animation);

        public void Update(ZeFiveNime.Models.Animation animation){
            var existAnimation = GetById(animation.Id);
            if(existAnimation != null){
                existAnimation.Judul = animation.Judul;
                existAnimation.Tahun = animation.Tahun;
                existAnimation.Sinopsis = animation.Sinopsis;
                
            }
        }
        public void Delete(int id){
            var animation = GetById(id);
            if(animation != null){
                _animations.Remove(animation);
            }
        }
    }
}