using ChatDE602.Hubs;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace ChatDE602.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        // GET: Chat
        [HttpPost]
        public ActionResult Login(string nomeUsuario)
        {
            Session["NomeUsuario"] = nomeUsuario;
            return RedirectToAction("Chat");
        }

        // GET: Chat
        public ActionResult Chat()
        {
            if (Session["NomeUsuario"] == null || string.IsNullOrEmpty(Session["NomeUsuario"].ToString()))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Config
        public ActionResult Config()
        {
            ViewBag.PathHist = Util.ObtemPathArquivoHistorico();
            return View();
        }


        // GET: Arquivos
        public ActionResult Arquivos()
        {
            string pathArquivos = Util.ObtemPathArquivosUpload();

            ViewBag.ArquivosServidor = Directory.GetFiles(pathArquivos);

            return View();
        }


        [HttpPost]
        public ActionResult UploadArquivo()
        {
            if (Request.Files.Count > 0)
            {
                var arqUpload = Request.Files[0];

                byte[] dadosArquivoUpload;
                using (Stream inputStream = arqUpload.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }

                    dadosArquivoUpload = memoryStream.ToArray();
                }

                if (!Directory.Exists(Util.ObtemPathArquivosUpload()))
                {
                    Directory.CreateDirectory(Util.ObtemPathArquivosUpload());
                }

                System.IO.File.WriteAllBytes(Util.ObtemPathArquivosUpload() + "\\" + arqUpload.FileName, dadosArquivoUpload);
            }

            return RedirectToAction("Arquivos");
        }



        public ActionResult DownloadArquivo(string paramPath)
        {
            byte[] dados = System.IO.File.ReadAllBytes(paramPath);

            return this.File(dados, System.Net.Mime.MediaTypeNames.Application.Octet, Path.GetFileName(paramPath));
        }

    }



}