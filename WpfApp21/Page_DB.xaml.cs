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

namespace WpfApp21
{
    /// <summary>
    /// Логика взаимодействия для Page_DB.xaml
    /// </summary>
    public partial class Page_DB : Page
    {
        public Page_DB()
        {
            App_Context file_db = new App_Context(); // ссылка на класс App_Context

            InitializeComponent();

            List<Image> images = file_db.Images.ToList();
            string print_db = " ";
            foreach (Image image in images)
            {
                print_db += "\n" + image.id_images + " Имя картинки\n" + image.name_images + " Ссылка на картинку\n" + image.images_link; // вывод таблицы images базы данных
            }
            table_db.Text = print_db;
        }
    }
}
