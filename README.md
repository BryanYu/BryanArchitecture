# BryanArchitecture

自己設計的的.NET Web的開發架構，包含前後端專案架構與設計。

* * *

# 架構圖

![架構圖](https://github.com/BryanYu/BryanArchitecture/blob/master/BryanArchitecture.png)

# 專案功能說明：
* ### BusinessLogic：實現商業邏輯
* ### DataAccess：實現資料存取
* ### Infrastructure：所有專案的共用程式、基礎服務、及AOP實作。
* ### Presentation：展示層，為End-User使用的介面，例如：Web、Mobile、Winform、Console...等
* ### Service：調用BusinessLogic並開放成為Web API，給各種Presentation介接使用
* ### Test：單元測試、整合測試專案

* * *

# 程式服務：

### Logging：

| Log分級 	| 用途 	                                     | 使用組態 | 儲存位置 |
|-------- 	|------	                                    |----------|----------	|
| Trace   	| 追蹤Method執行過程                         | Debug、Dev | File |
| Debug   	| 執行查詢、身分認證、認證延長...等操作     	  | Debug、Dev | File |
| Info    	| 一般操作，如寄mail、更新資料      	        | Debug、Dev | File |
| Warn    	| 錯誤操作，但程式可以執行，例如：驗證資料      | Debug、Dev、Prod | File、DataBase |
| Error    	| 應用程式錯誤，或有例外狀況                   | Debug、Dev、Prod | File、DataBase、Email |
| Fatal    	| 應用程式損壞      	                        | Debug、Dev、Prod | File、DataBase、Email |

### Cache
* MemoryCache
* RedisCache

### Cryptography
* JwtToken
* MD5

* * *

# 預計會使用的技術棧：
### 前端：
* Vue.js
* TypeScript
* Boostrap
* Html

### 後端：
* .NET Web API
* LINQ
* Entity Framework

### 資料庫：
* MS SQL Server

### 套件：
* Swagger
* Autofac
* NLog
* Json.net






