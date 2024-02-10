using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp21
{
    class Image // описание таблицы images в SQL Lite
    {
        public int id_images { get; set; }

        private string Name_images, Images_Link;
        public string name_images {
            get {  return Name_images;} 
            set { Name_images = value; }
        }
        public string images_link {
            get {return Images_Link; }
            set { Images_Link = value;}
        }
        public Image() { }
        public Image(string Name_images, string Images_Link) { 
            this.Name_images = Name_images;
            this.Images_Link = Images_Link;
        }
    }
}
