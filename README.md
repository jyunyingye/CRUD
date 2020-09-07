# 實作 WEB API CRUD Smiple


## 專案說明 

	1. 建檔日期: 2020-09-06
	2. 開發人員: Sam
	3. 框架: .Net Core 3.1
	4. 程式語言: C#
	5. 資料庫版本: SQL Server 2017
	6. 資料表資料: 微軟北風資料庫
	7. 資料存取: Dapper
	8. 版本控制: GitHub


## API 說明

```
1. 取商品清單 
GET -- http://{host}/api/v1/Products

2. 取單筆商品 
GET -- http://{host}/api/v1/Products/{prdtuctid}

3. 新增商品資料 
POST -- http://{host}/api/v1/Products

4. 更新商品資料 
PUT -- http://{host}/api/v1/Products/{prdtuctid}

5. 刪除商品資料 
DELETE -- http://{host}/api/v1/Products/{prdtuctid}
```