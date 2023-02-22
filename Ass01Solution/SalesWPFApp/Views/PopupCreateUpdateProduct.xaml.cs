using DataAccess.DTOs;
using DataAccess.Models;
using SalesWPFApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SalesWPFApp.Views
{
    /// <summary>
    /// Interaction logic for PopupCreateUpdateProduct.xaml
    /// </summary>
    public partial class PopupCreateUpdateProduct : Window
    {
        public PopupCreateUpdateProduct(ProductDTO  product)
        {
            InitializeComponent();
            DataContext = new PopupCreateUpdateProductViewModel(product);
        }
    }
}
