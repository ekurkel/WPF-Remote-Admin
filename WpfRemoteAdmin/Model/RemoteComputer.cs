using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;
using System.Threading;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace WpfRemoteAdmin.Model
{
     public class RemoteComputer
    {
        public string ComputerName { get; private set; }
        public BitmapImage ComputerScreen { get; private set; }
        private Socket clientSocket;

      //  public delegate void RemoteComputerScreenChanged();
       // public event RemoteComputerScreenChanged RemoteComputerScreenHasChanged;

        public RemoteComputer(string _computerName, Socket _clientSocket)
        {
            ComputerName = _computerName;
            clientSocket = _clientSocket;

            Thread ReciveScreenImageThread = new Thread(ReciveScreenImage);
            ReciveScreenImageThread.IsBackground = true;
            ReciveScreenImageThread.Start(); //запускаем поток
        }

        public void ReciveScreenImage()
        {
            byte[] bytes = new byte[1050000];

            while (true)
            {
             try
                {
                    int bytesRec = clientSocket.Receive(bytes);

                    using (MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length))
                    {
                        ms.Write(bytes, 0, bytes.Length);
                        ms.Seek(0, SeekOrigin.Begin);
                        ComputerScreen = new BitmapImage();
                        ComputerScreen.BeginInit();
                        ComputerScreen.StreamSource = ms;
                        ComputerScreen.CacheOption = BitmapCacheOption.OnLoad;
                        ComputerScreen.EndInit();
                        ComputerScreen.Freeze();
                    }
                   // RemoteComputerScreenHasChanged();
                }
              catch {  }

                
            }
        }

    }
}
