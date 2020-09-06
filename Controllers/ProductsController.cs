using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; 

namespace webapp.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    { 
        /// <summary>
        /// 取商品清單
        /// </summary> 
        [HttpGet]
        public object Get()
        {
            return new { };
        }

        /// <summary>
        /// 取單筆商品資料
        /// </summary>
        /// <param name="id">商品ID</param> 
        [HttpGet("{id}")]
        public object Get(int id)
        {
            return new { };
        }

        /// <summary>
        /// 新增商品資料
        /// </summary>
        /// <param name="id">商品ID</param> 
        [HttpPost]
        public object Post([FromBody] object product)
        { 
            return new { };
        }

        /// <summary>
        /// 更新商品資料
        /// </summary>
        /// <param name="id">商品ID</param>
        /// <param name="product">更新的商品結構</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public object Put(int id, [FromBody] object product)
        {
            return new { };
        }

        /// <summary>
        /// 刪除商品資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            return new { };
        }
    }
}
