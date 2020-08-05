using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Globalization;
using Web.Domain.Interfaces;

namespace Web.Service.Utils
{
    public class ListasGenericasService : IListasGenericasService
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public ListasGenericasService(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public partial class ListaGenerica
        {

            [JsonProperty("SiyNo")]
            public List<ValoresLista> SiyNo { get; set; }

            [JsonProperty("ActivoInactivo")]
            public List<ValoresLista> ActivoInactivo { get; set; }

            [JsonProperty("ExampleEstado")]
            public List<ValoresLista> ExampleEstado { get; set; }


        }

        public partial class ValoresLista
        {
            [JsonProperty("Value")]
            public long Value { get; set; }

            [JsonProperty("Text")]
            public string Text { get; set; }
        }

        public partial class ListaGenerica
        {

            public static ListaGenerica FromJson(string json) => JsonConvert.DeserializeObject<ListaGenerica>(json, Converter.Settings);
        }


        public string GetListaJson()
        {

            try
            {
                var ruta = hostingEnvironment.ContentRootPath + "\\ListasPredefinidas.json";
                string jsonString = System.IO.File.ReadAllText(ruta);
                var objeto = JsonConvert.DeserializeObject(jsonString);
                return objeto.ToString();
            }
            catch (System.Exception ex)
            {
                return "";

            }

        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }

    }
}
