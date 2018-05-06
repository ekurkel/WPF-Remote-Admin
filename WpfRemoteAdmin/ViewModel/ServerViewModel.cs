using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfRemoteAdmin.Model;
using WpfRemoteAdmin.Helpers;

namespace WpfRemoteAdmin.ViewModel
{
    public class ServerViewModel : ObservableObject
    {
        public Server server { get; private set; }

        public ServerViewModel()
        {
            this.server = new Server();
            server.RemoteComputersListHasChanged += UpdateRemoteComputersList;
        }
        
        private void UpdateRemoteComputersList()
        {
            RaisePropertyChangedEvent("RemoteComputers");
        }
    }
}
