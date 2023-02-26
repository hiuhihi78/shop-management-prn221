using SalesWPFApp.Views;
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
using SalesWPFApp.Navigation;
using System.Windows.Shapes;
using DataAccess.Repository;
using SalesWPFApp.Common;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IMemberRepository _memberRepository;
        IOrderRepository _orderRepository;
        IProductRepository _productRepository;
        public MainWindow(IMemberRepository memberRepository, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            InitializeComponent();

            _memberRepository = memberRepository;
            Common.DataContext.memberRepository = _memberRepository;
            _orderRepository = orderRepository;
            Common.DataContext.orderRepository = _orderRepository;
            _productRepository = productRepository;
            Common.DataContext.productRepository = _productRepository;

            NavigationService.Initialize(MainFrame);
            NavigationService.NavigateTo(new Login());
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
