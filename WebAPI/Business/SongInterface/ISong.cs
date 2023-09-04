using Model.Musica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.SongInterface
{
    public interface ISong<SongViewModel> 
    {
        Task Add(SongViewModel entity);
        Task Update(SongViewModel entity);
        Task Delete(SongViewModel entity);
        Task<SongViewModel> GetEntityById(int Id);
        Task<List<SongViewModel>> List();
    }
}
