using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Responsi_APP
{
    internal class Karyawan_Class
    {

        private string Nama;
        private string ID_karyawan;
        public Karyawan_Class(string nama, string iD_karyawan)
        {
            Nama = nama;
            ID_karyawan = iD_karyawan;
        }
        public virtual string GetName()
        {
            return Nama;
        }
        public virtual string GetID()
        {
            return Nama;
        }
    }
}
