using KhipoAPI.Models;
using KhipoAPI.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KhipoAPI.Controllers
{
    public class ProductsController : ApiController
    {
          [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(ProdutosRepositorio.All());            
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Json(ProdutosRepositorio.Get(id));            
        }

        [HttpPost]
        public IHttpActionResult Post(Produto product)
        {
            return Json(ProdutosRepositorio.Inserir(product));
        }

        [HttpPut]
        public IHttpActionResult Put(Produto product)
        {
            return Json(ProdutosRepositorio.Update(product));
        }

        [HttpDelete]
        public IHttpActionResult Deletar(int id)
        {
            return Json(ProdutosRepositorio.Deletar(id));
        }
    }
}
