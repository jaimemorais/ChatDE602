using Microsoft.AspNet.SignalR;
using System;
using System.IO;

namespace ChatDE602.Hubs
{
    public class ChatHub : Hub
    {

        public void EnviaMensagem(string usuario, string mensagem)
        {
            string dataHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            Clients.All.broadcastMessage(usuario, mensagem, dataHora);

            EscreveHistorico(usuario, mensagem, dataHora);
        }

        private void EscreveHistorico(string usuario, string mensagem, string dataHora)
        {
            string pathArquivoHistorico = Util.ObtemPathArquivoHistorico();

            if (File.Exists(pathArquivoHistorico))
            {
                using (StreamWriter arquivoHistorico = File.AppendText(pathArquivoHistorico))
                {
                    arquivoHistorico.WriteLine(usuario + "|" + dataHora + "|" + mensagem);
                }
            }
            else
            {
                if (!Directory.Exists(Path.GetDirectoryName(pathArquivoHistorico)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(pathArquivoHistorico));
                }
                using (StreamWriter arquivoHistorico = File.CreateText(pathArquivoHistorico))
                {
                    arquivoHistorico.WriteLine(usuario + "|" + dataHora + "|" + mensagem);
                }
            }            
        }

        public void ExibeHistoricoMensagens()
        {
            string pathArquivoHistorico = Util.ObtemPathArquivoHistorico();
            if (File.Exists(pathArquivoHistorico))
            {
                string[] conteudoHistorico = File.ReadAllLines(pathArquivoHistorico);

                foreach (string linha in conteudoHistorico)
                {
                    string[] info = linha.Split('|');
                    Clients.All.broadcastMessage(info[0], info[2], info[1]);
                }
            }
        }
    }
}
