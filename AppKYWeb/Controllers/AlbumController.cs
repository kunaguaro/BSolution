using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Domain.Interfaces;
using Web.Domain.Views.Album;
using Web.Domain.Views.Photo;

namespace AppKYWeb.Controllers
{
    public class AlbumController : Controller
    {
        readonly IMainServices mainServices;

        public AlbumController(IMainServices mainServices)
        {
           this.mainServices=  mainServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ListadoPhotosAsync(int criteria )
        {
            List<Web.Domain.Views.Photo.PhotoListView> lista = new List<Web.Domain.Views.Photo.PhotoListView>();
            lista = await mainServices.GetPhotosByAlbum(criteria);
          
            return PartialView("_ListadoAlbum", lista);
        }


        [HttpPost]
        public async Task<IActionResult> ListadoCommmentAsync(int criteria )
        {
            List<Web.Domain.Views.Comment.CommentListView> lista = new List<Web.Domain.Views.Comment.CommentListView>();
            lista = await mainServices.GetCommentByIdPhoto(criteria);
          
            return PartialView("_ListadoComments", lista);
        }

        

        [HttpGet]
        public async Task<JsonResult> GetAlbumListaAsync()
        {
            try
            {
                List<AlbumListView> lista = new List<AlbumListView>();
                lista = await mainServices.GetAllAlbumAsync();
                return Json(new { success = "ok", listaObj = lista });
            }
            catch (Exception ex)
            {
                return Json(new { success = "error", message = ex.Message.ToString() });
            }
        }




        }
}
