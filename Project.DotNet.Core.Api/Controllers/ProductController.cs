using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Project.DotNet.Core.Api.Entity;
using Project.DotNet.Core.Api.Models;
using Project.DotNet.Core.Api.Repository;
using System;
using System.Net;

namespace Project.DotNet.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _repository;

        public ProductController(IConfiguration configuration)
        {
            _repository = new ProductRepository(configuration);
        }

        [HttpGet]
        public ResponseHandler FindAll()
        {
            var entities = _repository.GetAll();
            return ResponseHandler.BuildResponse(entities, "v1",
                DateTime.Now, HttpStatusCode.OK, HttpContext.Response);
        }

        [HttpGet("{id}")]
        public ResponseHandler FindById(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                return ResponseHandler.BuildResponse("v1", "Objeto Não encontrado", 
                    DateTime.Now, HttpStatusCode.NotFound, HttpContext.Response);
            }

            return ResponseHandler.BuildResponse(entity, "v1", 
                DateTime.Now, HttpStatusCode.OK, HttpContext.Response);
        }

        [HttpPost]
        public ResponseHandler Save([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
            }

            try {
                _repository.Insert(product);
                return ResponseHandler.BuildResponse(product, "v1",
                    DateTime.Now, HttpStatusCode.Created, HttpContext.Response);
            }
            catch (Exception ex)
            {
                return ResponseHandler.BuildResponse("v1", $"Erro ao Salvar exception: {ex.Message} ",
                    DateTime.Now, HttpStatusCode.NotFound, HttpContext.Response);
            }
        }

        [HttpPut("{id}")]
        public ResponseHandler Update(int id, [FromBody] Product product)
        {
            try
            {
                var entity = _repository.GetById(id);
                if (entity == null)
                {
                    return ResponseHandler.BuildResponse("v1", "Objeto Não encontrado", DateTime.Now, 
                        HttpStatusCode.NotFound, HttpContext.Response);
                }

                _repository.Update(product);
                return ResponseHandler.BuildResponse("v1", "Atualizado com sucesso!", DateTime.Now, 
                    HttpStatusCode.NoContent, HttpContext.Response);
            }
            catch (Exception ex)
            {
                return ResponseHandler.BuildResponse("v1", $"Erro ao atualizar exception: {ex.Message} ",
                    DateTime.Now, HttpStatusCode.NotFound, HttpContext.Response);
            }
        }

        [HttpDelete("{id}")]
        public ResponseHandler Delete(int id)
        {
            try
            {
                var entity = _repository.GetById(id);
                if (entity == null)
                {
                    return ResponseHandler.BuildResponse("v1", "Objeto Não encontrado", 
                        DateTime.Now, HttpStatusCode.NotFound, HttpContext.Response);
                }
                _repository.Delete(id);
                return ResponseHandler.BuildResponse("v1", "Deletado com sucesso!", 
                    DateTime.Now, HttpStatusCode.NoContent, HttpContext.Response);
            }
            catch (Exception ex)
            {
                return ResponseHandler.BuildResponse("v1", $"Erro ao deletar exception: {ex.Message} ",
                    DateTime.Now, HttpStatusCode.NotFound, HttpContext.Response);
            }
        }
    }
}