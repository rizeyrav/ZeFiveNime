using System.Collections.Generic;
using ZeFiveNime.Models;

namespace ZeFiveNime.Repositories
{
    public interface IAnimationRepository {
        //Menampilkan seluruh data Animation
        IEnumerable<ZeFiveNime.Models.Animation> GetAll();
        // Menampilkan Animation Berdasarkan Id
        ZeFiveNime.Models.Animation GetById(int id);
        // Menambahkan Animasi Baru
        void Add(ZeFiveNime.Models.Animation animation);
        // Memperbarui Animasi
        void Update(ZeFiveNime.Models.Animation animation);
        // Menghapus Animasi berdasarkan Id
        void Delete(int id);
    }
}