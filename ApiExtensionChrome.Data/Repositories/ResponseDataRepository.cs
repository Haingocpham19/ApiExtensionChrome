//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Linq;

//namespace ApiExtensionChrome.Data.Repositories
//{
//    public class ResponseDataRepository : IResponseDataRepository
//    {
//        private readonly ExtensionContext _extensionContext;
//        public ResponseDataRepository(ExtensionContext amazonExtraContext)
//        {
//            _extensionContext = amazonExtraContext;
//        }
//        public void Delete(int id)
//        {
//            ResponseData reponse = _extensionContext.ReponseDataDbSet.Find(id);
//            _extensionContext.ReponseDataDbSet.Remove(reponse);
//        }

//        public IEnumerable<ResponseData> GetAll(string token)
//        {
//            var lstProduct = from x in _extensionContext.ReponseDataDbSet
//                             where x.Token == token
//                             select x;
                                                             
//            return lstProduct.ToList();
//        }

//        public ResponseData GetById(int id)
//        {
//            return _extensionContext.ReponseDataDbSet.Find(id);
//        }
//        public int Insert(ResponseData response)
//        {
//            ResponseData newResponseData = new ResponseData
//            {
//                ProductTitle = response.ProductTitle,
//                Price = response.Price,
//                ProductImageSrc = response.ProductImageSrc,
//                Availability = response.Availability,
//                GetDate = response.GetDate,
//                Url = response.Url,
//                PageName = response.PageName,
//                Status = CommanConstant.Contants.PENDING,
//                Token = response.Token
//            };
//            _extensionContext.Add(newResponseData);
//            return newResponseData.Id;
//        }

//        public void Save()
//        {
//            _extensionContext.SaveChanges();
//        }

//        public void Update(ResponseData reponseData)
//        {
//            _extensionContext.Entry(reponseData).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
//        }
//    }
//}
