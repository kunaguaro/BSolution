using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Domain.Interfaces;
using Web.Domain.Pagination;
using Web.Domain.Views.Album;
using Web.Domain.Views.Comment;
using Web.Domain.Views.Photo;

namespace Web.Service.Services
{
    public class MainServices : IMainServices
    {
        private readonly IMainRepository mainRepository;

        public MainServices(IMainRepository mainRepository)
        {
            this.mainRepository = mainRepository;
        }

        public async System.Threading.Tasks.Task<List<AlbumListView>> GetAllAlbumAsync()
        {
            try
            {
                List<AlbumListView> response = new List<AlbumListView>();
                response = await mainRepository.ListadoAlbumAsync();
                return response.OrderBy(x => x.title).ToList();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error: " + ex.Message);
            }

        }

        public async System.Threading.Tasks.Task<List<PhotoListView>> GetPhotosByAlbum(int filterId)
        {
            try
            {
                List<PhotoListView> response = new List<PhotoListView>();
                response = await mainRepository.ListadoPhotosAsync(filterId);
                return response.OrderBy(x => x.id).ToList();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error: " + ex.Message);
            }

        }

        public async System.Threading.Tasks.Task<List<CommentListView>> GetCommentByIdPhoto(int filterId)
        {
            try
            {
                List<CommentListView> response = new List<CommentListView>();
                response = await mainRepository.ListadoCommentAsync(filterId);
                return response.OrderBy(x => x.id).ToList();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error: " + ex.Message);
            }

        }


        public async System.Threading.Tasks.Task<PagingList<PhotoListView>> GetPaginateResultOrdersListViewAsync(int orderId, int pageNo, bool firstLoad)
        {
            List<PhotoListView> list = new List<PhotoListView>();
            list = await mainRepository.ListadoPhotosAsync(orderId);
            return PagingList<PhotoListView>.Create(list.AsQueryable(), pageNo);
        }


    }
}
