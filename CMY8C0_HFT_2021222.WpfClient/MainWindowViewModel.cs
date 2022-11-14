using CMY8C0_HFT_2021222.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMY8C0_HFT_2021222.WpfClient
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
