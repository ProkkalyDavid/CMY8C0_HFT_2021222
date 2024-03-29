﻿using CMY8C0_HFT_2021222.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CMY8C0_HFT_2021222.WpfClient.ViewModels
{
    public class CarWindowViewModel : ObservableRecipient
    {
        public RestCollection<Car> Cars { get; set; }

        private Car selectedCar;

        public Car SelectedCar
        {
            get { return selectedCar; }
            set 
            {
                if (value != null)
                {
                    selectedCar = new Car()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Year = value.Year,
                        Km = value.Km
                    };
                }
                OnPropertyChanged();
                (DeleteCarCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateCarCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public ICommand CreateCarCommand { get; set; }
        public ICommand DeleteCarCommand { get; set; }
        public ICommand UpdateCarCommand { get; set; }

        public CarWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Cars = new RestCollection<Car>("http://localhost:43002/", "car", "hub");
                CreateCarCommand = new RelayCommand(() =>
                {
                    Cars.Add(new Car()
                    {
                        Id = Cars.Count() + 1,
                        Name = SelectedCar.Name,
                        Year = SelectedCar.Year,
                        Km = SelectedCar.Km
                    });
                });
                DeleteCarCommand = new RelayCommand(
                    () => Cars.Delete(SelectedCar.Id),
                    () => SelectedCar != null
                    );
                UpdateCarCommand = new RelayCommand(
                    () => Cars.Update(SelectedCar),
                    () => SelectedCar != null
                    );
                SelectedCar = new Car()
                {
                    Name = "Cars's name",
                    Km = 10
                };
            }
        }
    }
}
