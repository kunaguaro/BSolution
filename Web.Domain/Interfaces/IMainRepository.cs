using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Domain.Views.Album;
using Web.Domain.Views.Comment;
using Web.Domain.Views.Photo;

namespace Web.Domain.Interfaces
{
    public interface IMainRepository
    {
        Task<List<AlbumListView>> ListadoAlbumAsync();
        Task<List<PhotoListView>> ListadoPhotosAsync(int albumIdfilter);
        Task<List<CommentListView>> ListadoCommentAsync(int photoIdfilter);
    }
}