using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Web.Domain.Interfaces;
using Web.Domain.Views.Album;
using Web.Domain.Views.Comment;
using Web.Domain.Views.Photo;

namespace Web.Infrastructure.Data.Repository
{
    public class MainRepository : IMainRepository
    {
        public async System.Threading.Tasks.Task<List<AlbumListView>> ListadoAlbumAsync()
        {
            List<AlbumListView> result = new List<AlbumListView>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/albums"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<AlbumListView>>(apiResponse);
                }
            }

            return result;
        }

        public async System.Threading.Tasks.Task<List<PhotoListView>> ListadoPhotosAsync(int albumIdfilter)
        {
            List<PhotoListView> result = new List<PhotoListView>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/photos"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<PhotoListView>>(apiResponse);
                }
            }

            return result.Where(x => x.albumId == albumIdfilter).ToList();
        }


        public async System.Threading.Tasks.Task<List<CommentListView>> ListadoCommentAsync(int photoIdfilter)
        {
            List<CommentListView> result = new List<CommentListView>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/comments"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<CommentListView>>(apiResponse);
                }
            }

            return result.Where(x => x.id == photoIdfilter).ToList();
        }
    }
}
