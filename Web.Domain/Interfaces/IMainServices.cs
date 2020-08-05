using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Domain.Pagination;
using Web.Domain.Views.Album;
using Web.Domain.Views.Comment;
using Web.Domain.Views.Photo;

namespace Web.Domain.Interfaces 
{ 
    public interface IMainServices
    {
        Task<List<AlbumListView>> GetAllAlbumAsync();
        Task<List<CommentListView>> GetCommentByIdPhoto(int filterId);
        Task<List<PhotoListView>> GetPhotosByAlbum(int filterId);
        Task<PagingList<PhotoListView>> GetPaginateResultOrdersListViewAsync(int orderId, int pageNo, bool firstLoad);
    }
}