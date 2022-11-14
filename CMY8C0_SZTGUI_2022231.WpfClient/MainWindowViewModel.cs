using CMY8C0_HFT_2021222.Models;
using CMY8C0_HFT_2021222.WpfClient;
using CMY8C0_SZTGUI_2022231.WpfClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMY8C0_SZTGUI_2022231.WpfClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Engine> Engines { get; set; }

        public MainWindowViewModel()
        {
            Engines = new RestCollection<Engine>("http://localhost:43002/","engine");
        }
    }
}
