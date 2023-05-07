using Infrastructure.Entities;
using Infrastructure.Repository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
	public interface IHocSinhService
	{
		IQueryable<HocSinh> GetHocSinhs();
        HocSinh GetHocSinh(string id);
		void DeleteHocSinh(HocSinh hocsinh);
		void UpdateHocSinh(HocSinh hocsinh);
		void InsertHocSinh(HocSinh hocsinh);
	}
	public class HocSinhService : IHocSinhService
    {
		private IHocSinhRepository repo;

		public HocSinhService(IHocSinhRepository repo)
		{
			this.repo = repo;
		}

        public void DeleteHocSinh(HocSinh hocsinh)
        {
            repo.Delete(hocsinh);
        }

        public HocSinh GetHocSinh(string id)
        {
            return repo.GetById(id);
        }

        public IQueryable<HocSinh> GetHocSinhs()
        {
            return repo.GetAll();
        }

        public void InsertHocSinh(HocSinh hocsinh)
        {
            repo.Insert(hocsinh);
        }

        public void UpdateHocSinh(HocSinh hocsinh)
        {
            repo.Update(hocsinh);
        }
    }
}
