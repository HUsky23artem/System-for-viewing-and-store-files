using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp21
{
    public partial class MainWindow : Window
    {

        App_Context file_db = new App_Context(); // ссылка на класс App_Context

        public string Pdf_File_Path = @"C:\Users\Пользователь\source\repos\WpfApp21\WpfApp21\PDF_Files";
        public string Image_File_Path = @"C:\Users\Пользователь\source\repos\WpfApp21\WpfApp21\Image_Files";
        public MainWindow()
        {
            InitializeComponent();
            new_file();
        }


        private void new_file()
        {
            try
            {
                // Проверяем существование папки
                if (!Directory.Exists(Pdf_File_Path))
                {
                    // Создаем каталог для папки
                    Directory.CreateDirectory(Pdf_File_Path);
                }
                if (!Directory.Exists(Image_File_Path))
                {
                    // Создаем каталог для папки
                    Directory.CreateDirectory(Image_File_Path);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании каталога: " + ex.Message);
            }
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            FileSystemWatcher watcher = new FileSystemWatcher(); // Создаем экземпляр FileSystemWatcher для отслеживания пути файла
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                string fileExtension = System.IO.Path.GetExtension(files[0]).ToLower();
                if (fileExtension == ".jpg" || fileExtension == ".jpeg")
                {
                    BitmapImage bitmap = new BitmapImage(new System.Uri(files[0]));
                    image.Source = bitmap;
                    image.Visibility = Visibility.Visible;
                    PdfView.Visibility = Visibility.Hidden;
                    string new_image_FilePath = System.IO.Path.Combine(Image_File_Path, System.IO.Path.GetFileName(files[0]));
                    File.Copy(files[0], Image_File_Path); // копируется в файл image

                    watcher.Path = new_image_FilePath; 
                    watcher.NotifyFilter = NotifyFilters.FileName; // Указываем, что будем отслеживать только добавление файлов
                    watcher.Created += Add_image_in_DB;  // Указываем событие, которое будет вызвано при добавлении файла
                    watcher.EnableRaisingEvents = true; // Включаем отслеживание

                }
                else if (fileExtension == ".pdf")
                {
                    PdfView.Load(files[0]);
                    image.Visibility = Visibility.Hidden;
                    PdfView.Visibility = Visibility.Visible;
                    string new_Pdf_FilePath = System.IO.Path.Combine(Pdf_File_Path, System.IO.Path.GetFileName(files[0]));
                    System.IO.File.Move(files[0], new_Pdf_FilePath);

                    watcher.Path = new_Pdf_FilePath;
                    watcher.NotifyFilter = NotifyFilters.FileName; // Указываем, что будем отслеживать только добавление файлов
                    watcher.Created += Add_image_in_DB;  // Указываем событие, которое будет вызвано при добавлении файла
                    watcher.EnableRaisingEvents = true;

                }
            }
        }
        private void Add_image_in_DB(object sender, FileSystemEventArgs e) // загрузка в таблицу images
        {
            string name = e.Name;
            string link = e.FullPath;
            Image images = new Image(name,link);
            file_db.Images.Add(images); // Ввод в базу данных
            file_db.SaveChanges(); // сохранение в базу данных


        }
        private void Add_pdf_in_DB(object sender, FileSystemEventArgs e) // загрузка в таблицу PDF
        {
            string name = e.Name;
            string link = e.FullPath;
            PDFS pdf = new PDFS(name,link);
            file_db.PDF.Add(pdf);
            file_db.SaveChanges();
        }
        private void treeView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void table_db_Click(object sender, RoutedEventArgs e)
        {
            table_db.Content = new Page_DB();
        }
    }
}
