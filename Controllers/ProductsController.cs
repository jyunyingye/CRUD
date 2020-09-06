using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Utils;

namespace webapp.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private DapperUtils dapper = new DapperUtils();

        /// <summary>
        /// 取商品清單
        /// </summary> 
        [HttpGet]
        public object Get()
        {
            List<ProductsModel> query = dapper.Query<ProductsModel>("select * from Products");

            return new
            {
                status = "ok",
                message = "成功",
                data = query,
            };
        }

        /// <summary>
        /// 取單筆商品資料
        /// </summary>
        /// <param name="id">商品ID</param> 
        [HttpGet("{id}")]
        public object Get(int id)
        {
            List<ProductsModel> query = dapper.Query<ProductsModel>("select * from Products where ProductID=@ProductID", new { ProductID = id });

            if (query.Count == 0)
            {
                return new
                {
                    status = "err",
                    message = "查不到商品ID",
                    data = new { }
                };
            }
            else
            {
                return new
                {
                    status = "ok",
                    message = "成功",
                    data = query[0],
                };
            }
        }

        /// <summary>
        /// 新增商品資料
        /// </summary>
        /// <param name="id">商品ID</param> 
        [HttpPost]
        public object Post([FromBody] ProductsModel product)
        {
            int execute = dapper.Execute(@$"
insert into Products (
    productName, supplierID, categoryID, quantityPerUnit, unitPrice, unitsInStock, reorderLevel, discontinued
) values (
    @productName, @supplierID, @categoryID, @quantityPerUnit, @unitPrice,  @unitsInStock, @reorderLevel, @discontinued
)",
      new
      {
          productName = product.ProductName,
          supplierID = product.SupplierID,
          categoryID = product.CategoryID,
          quantityPerUnit = product.QuantityPerUnit,
          unitPrice = product.UnitPrice,
          unitsInStock = product.UnitsInStock,
          reorderLevel = product.ReorderLevel,
          discontinued = product.Discontinued,
      });

            return new
            {
                status = "ok",
                message = "成功",
                data = execute,
            };
        }

        /// <summary>
        /// 更新商品資料
        /// </summary>
        /// <param name="id">商品ID</param>
        /// <param name="product">更新的商品結構</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public object Put(int id, [FromBody] ProductsModel product)
        {
            int execute = dapper.Execute(
                @$"
update Products 
set 
    productName = @productName,
    supplierID = @supplierID,
    categoryID = @categoryID,
    quantityPerUnit = @quantityPerUnit,
    unitPrice = @unitPrice,
    unitsInStock = @unitsInStock,
    unitsOnOrder = @unitsOnOrder,
    reorderLevel = @reorderLevel,
    discontinued = @discontinued
where 
    productID = @productID",
                new
                {
                    ProductID = id,
                    productName = product.ProductName,
                    supplierID = product.SupplierID,
                    categoryID = product.CategoryID,
                    quantityPerUnit = product.QuantityPerUnit,
                    unitPrice = product.UnitPrice,
                    unitsInStock = product.UnitsInStock,
                    unitsOnOrder = product.UnitsOnOrder,
                    reorderLevel = product.ReorderLevel,
                    discontinued = product.Discontinued,
                });

            return new
            {
                status = "ok",
                message = "成功",
                data = execute,
            };
        }

        /// <summary>
        /// 刪除商品資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            int execute = dapper.Execute("delete from Products where ProductID=@ProductID", new { ProductID = id });

            return new
            {
                status = "ok",
                message = "成功",
                data = execute,
            };
        }
    }
}
