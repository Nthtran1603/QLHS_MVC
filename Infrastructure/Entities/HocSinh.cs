using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
	[Table("HocSinh")]
	public class HocSinh
    {
		[Key]
		public string maHS { get; set; }
		public string tenHS { get; set; }
		public string diachi { get; set; }
		public DateTime ngaysinh { get; set; }
		public string gioitinh { get; set; }

	}
}
