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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp9.ADO;

namespace WpfApp9
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			ProductList.ItemsSource = DbConectionClass.DataBase.Product.ToList();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Product product = new Product();
			product.Name = "TriCorochki";
			product.Price = 1000;
			string str = "";
			foreach (var i in DbConectionClass.DataBase.Product)
			{
				str += $"{i.Name}: {i.Price}\n";
			}
			MessageBox.Show(str);
			DbConectionClass.DataBase.Product.Add(product);
			DbConectionClass.DataBase.SaveChanges();
			string newStr = "";
			foreach (var i in DbConectionClass.DataBase.Product)
			{
				newStr += $"{i.Name}: {i.Price}\n";
			}
			MessageBox.Show(newStr);
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			Product product = ProductList.SelectedItem as Product;
			if (product != null)
			{
				DbConectionClass.DataBase.Product.Remove(product);
				DbConectionClass.DataBase.SaveChanges();
			}
			ProductList.ItemsSource = DbConectionClass.DataBase.Product.ToList();
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			
			Product product = ProductList.SelectedItem as Product;
			if (product != null)
			{
				if (ProductName.Text != "" && ProductPrice.Text != "")
				{
					int newPrice;
					if (Int32.TryParse(ProductPrice.Text, out newPrice))
					{
						product.Name= ProductName.Text;
						product.Price = newPrice;
					}
				}
				DbConectionClass.DataBase.SaveChanges();
			}
			ProductList.ItemsSource = DbConectionClass.DataBase.Product.ToList();
		}
	}
}
