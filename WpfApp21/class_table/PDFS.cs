using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp21
{
    class PDFS
    {
        public int id_pdf { get; set; }

        private string Name_pdf, Link_pdf;
        public string name_pdf
        {
            get { return Name_pdf; }
            set { Name_pdf = value; }
        }
        public string pdf_link
        {
            get { return Link_pdf; }
            set { Link_pdf = value; }
        }

        public PDFS() { }
        public PDFS(string Name_pdf, string Link_pdf)
        {
            this.Name_pdf = Name_pdf;
            this.Link_pdf = Link_pdf;
        }
    }
}
