using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThuChi.Model
{
    public class Lydo
    {
        public int LydoId { get; set; }
        public string lydo { get; set; }
        public string Ghichu { get; set; }
    }

    public class Nguoithuchi
    {
        public int nguoithuchi_id { get; set; }
        public string hovaten { get; set; }
        public string ghichu { get; set; }
    }

    public class Thuchi
    {
        public int thuchi_id { get; set; }
        public int nguoithuchi_id { get; set; }
        public DateTime? ngaythuchi { get; set; }
        public bool? kieuthu { get; set; }
        public double? tien { get; set; }
        public int? lydo_id { get; set; }
        public string ghichu { get; set; }
    }

    public class Thuchi_Lydo
    {
        public int thuchi_id { get; set; }
        public int lydo_id { get; set; }
    }
}
