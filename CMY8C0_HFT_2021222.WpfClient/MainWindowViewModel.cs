using CMY8C0_HFT_2021222.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
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

namespace CMY8C0_HFT_2021222.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Engine> Engines { get; set; }

        private Engine selectedEngine;
        public Engine SelectedEngine
        {
            get { return selectedEngine; }
            set
            {
                //SetProperty(ref selectedEngine, value);
                if (value != null)
                {
                    selectedEngine = new Engine()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Hp = value.Hp,
                        Cylinders = value.Cylinders,
                        Torqe = value.Torqe,
                        Cars = value.Cars
                    };
                }
                OnPropertyChanged();
                (DeleteEngineCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateEngineCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand CreateEngineCommand { get; set; }
        public ICommand DeleteEngineCommand { get; set; }
        public ICommand UpdateEngineCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Engines = new RestCollection<Engine>("http://localhost:43002/", "engine","hub");
                CreateEngineCommand = new RelayCommand(() =>
                {
                    Engines.Add(new Engine()
                    {
                        Name = SelectedEngine.Name,
                        Hp = SelectedEngine.Hp
                    });
                });
                DeleteEngineCommand = new RelayCommand(
                    () => Engines.Delete(SelectedEngine.Id),
                    () => SelectedEngine != null
                    );
                UpdateEngineCommand = new RelayCommand(
                    () => Engines.Update(SelectedEngine),
                    () => SelectedEngine != null
                    );
                SelectedEngine = new Engine()
                {
                    Hp = 10,
                    Name = "Motor neve"
                };
            }
        }
    }
}
