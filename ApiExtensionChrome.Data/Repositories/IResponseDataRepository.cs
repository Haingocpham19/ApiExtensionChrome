using ApiExtensionChrome.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiExtensionChrome.Data.Repositories
{
    public interface IResponseDataRepository
    {
        IEnumerable<ResponseData> GetAll(string token);
        ResponseData GetById(int ReponseData);
        int Insert(ResponseData reponseData);
        void Update(ResponseData reponseData);
        void Delete(int ReponseData);
        void Save();
    }
}
