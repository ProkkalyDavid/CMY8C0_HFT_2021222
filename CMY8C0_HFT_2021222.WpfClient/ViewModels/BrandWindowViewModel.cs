using CMY8C0_HFT_2021222.Models;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json.Linq;

namespace CMY8C0_HFT_2021222.WpfClient.ViewModels
{
    public class BrandWindowViewModel : ObservableRecipient
    {
        public RestCollection<Brand> Brands { get; set; }

        private Brand selectedBrand;
        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                if (value != null)
                {
                    selectedBrand = new Brand()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Country = value.Country,
                        Cars = value.Cars
                    };
                }
                OnPropertyChanged();
                (DeleteBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateBrandCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand CreateBrandCommand { get; set; }
        public ICommand DeleteBrandCommand { get; set; }
        public ICommand UpdateBrandCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public BrandWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Brands = new RestCollection<Brand>("http://localhost:43002/", "brand", "hub");
                CreateBrandCommand = new RelayCommand(() =>
                {
                    Brands.Add(new Brand()
                    {
                        Id = Brands.Count() + 1,
                        Name = SelectedBrand.Name
                    });
                });
                DeleteBrandCommand = new RelayCommand(
                    () => Brands.Delete(SelectedBrand.Id),
                    () => SelectedBrand != null
                    );
                UpdateBrandCommand = new RelayCommand(
                    () => Brands.Update(SelectedBrand),
                    () => SelectedBrand != null
                    );
                SelectedBrand = new Brand()
                {
                    Name = "Brand's name"
                };
            }
        }
    }
}