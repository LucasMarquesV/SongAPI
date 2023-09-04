using Business.SongInterface;
using Data.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using Model.Musica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class SongRepository<TEntity> : ISong<TEntity>, IDisposable where TEntity : SongViewModel

    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public SongRepository()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task Add(TEntity entity)
        {
            using(var data = new ContextBase(_OptionsBuilder))
            {
                await data.Set<TEntity>().AddAsync(entity);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(TEntity entity)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<TEntity>().Remove(entity);
                await data.SaveChangesAsync();
            }
        }       
        public async Task<TEntity> GetEntityById(int Id)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<TEntity>().FindAsync(Id);
            }
        }

        public async Task<List<TEntity>> List()
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<TEntity>().ToListAsync();
            }
        }

        public async Task Update(TEntity entity)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<TEntity>().Update(entity);
                await data.SaveChangesAsync();
            }
        }
#region Disposed
        bool disposed = false;

        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
            }
            disposed = true;
        }
        #endregion
    }
}
