using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DokumenWebApps.Models;

using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DokumenWebApps.DAL
{
    public class KlasifikasiDALDapper : IKlasifikasi
    {
        private IConfiguration _config;

        public KlasifikasiDALDapper(IConfiguration config)
        {
            _config = config;
        }

        public void Create(Klasifikasi obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Klasifikasi> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Klasifikasi> GetAllAktifStatus()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Klasifikasi> GetAllByNama(string nama)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Klasifikasi> GetAllWithDapper()
        {
            throw new NotImplementedException();
        }

        public Klasifikasi GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void UbahStatusAktif(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(Klasifikasi obj)
        {
            throw new NotImplementedException();
        }
    }
}
