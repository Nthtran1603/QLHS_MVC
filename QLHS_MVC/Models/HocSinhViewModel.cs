using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;
using Infrastructure.Entities;
using System;

namespace  QLHS_MVC.Models
{
	public class HocSinhViewModel
	{


        public string maHS { get; set; }
        public string tenHS { get; set; }
        public string diachi { get; set; }
        public DateTime ngaysinh { get; set; }
        public string gioitinh { get; set; }
    }
}
