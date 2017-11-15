# BryanArchitecture

自己製作的.NET Web開發架構

以開發一個後台管理系統為目標 實作自己的架構


# 專案分層：
### BusinessLogic 
用途：實現商業邏輯

### DataAccess
用途：實現商業邏輯

### Infrastructure
用途：所有專案的共用工具及程式服務實作

### Presentation
用途：所有End-User接觸的介面專案(例如：Web、Console、WinForm...等)

### Service
用途：開放BusinessLogic成為API，給各種Presentation使用

### Test
用途：單元測試、整合測試專案

# 程式服務：

## Logging：

| Log分級 	| 用途 	                                     | 使用組態 | 儲存位置 |
|-------- 	|------	                                    |----------|----------	|
| Trace   	| 追蹤Method執行過程                         | Debug、Dev | File、Console |
| Debug   	| 執行查詢、身分認證、認證延長...等操作     	  | Debug、Dev | File、Console |
| Info    	| 一般操作，如寄mail、更新資料      	        | Debug、Dev | File、Console |
| Warn    	| 錯誤操作，但程式可以執行，例如：驗證資料      | Debug、Dev、Prod | File、Console |
| Error    	| 應用程式錯誤，或有例外狀況                   | Debug、Dev、Prod | File、Email、Console |
| Fatal    	| 應用程式損壞      	                        | Debug、Dev、Prod | File、Email、Console |

## Email：

## Cache：

# 預計會使用的技術棧：
## 前端：
* Vue.js
* TypeScript
* Boostrap
## 後端：
* .NET Web API
* LINQ
* Entity Framework
## 資料庫：
* MS SQL Server

Comming Soon!



