using CMY8C0_HFT_2021222.Models;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CMY8C0_HFT_2021222.WpfClient.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        BrandWindow BrandWindow;
        EngineWindow EngineWindow;
        public ICommand GoToBandsCommand { get; set; }
        public ICommand GoToCarsCommand { get; set; }
        public ICommand GoToEnginesCommand { get; set; }
        public MainWindowViewModel()
        {
            BrandWindow = new BrandWindow();
            EngineWindow = new EngineWindow();

            GoToBandsCommand = new RelayCommand(() =>
            {
                BrandWindow.ShowDialog();
            });
            GoToCarsCommand = new RelayCommand(() =>
            {

            });
            GoToEnginesCommand = new RelayCommand(() =>
            {
                EngineWindow.ShowDialog();
            });
        }
    }
}
