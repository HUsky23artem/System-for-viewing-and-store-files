using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; // библиотека для работы с базой данных

namespace WpfApp21
{
    class App_Context : DbContext
    {
        public DbSet<Image> Images { get; set; } // DbSet - это класс, для элементов таблицы Images

        public DbSet<PDFS> PDF { get; set; }
        public App_Context() : base("DefaultConnection") {} // подключение к базе данных SQL Lite
    }
}
