using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ChatDE602.Hubs
{
    public static class Util
    {
        public static string ObtemPathArquivoHistorico()
        {
            //return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "ArquivosDE602\\HistoricoChat.txt");
            return "C:\\ArquivosDE602\\Chat\\HistoricoChat.txt";
        }

        public static string ObtemPathArquivosUpload()
        {            
            return "C:\\ArquivosDE602\\Uploads";
        }

    }
}