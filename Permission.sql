
--DELETE FROM [dbo].[Permissions]
--DBCC CHECKIDENT('Permissions', RESEED,0)    

INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'បុគ្គលិក','1','0','1','Employee','2','InitData',GetDate(),'Init','1','1')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'អតិថិជន','1','0','1','Customer','1','InitData',GetDate(),'Init','1','2')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'ទំនិញ','1','0','1','Product','3','InitData',GetDate(),'Init','1','3')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'ការលក់','1','0','1','Sale','4','InitData',GetDate(),'Init','1','4')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'អ្នកផ្គត់ផ្គង់','1','0','1','Supplier','5','InitData',GetDate(),'Init','0','5')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'របាយការណ៍','1','0','1','Report','6','InitData',GetDate(),'Init','1','6')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'កំណត់ប្រព័ន្ធ','1','0','1','Setting','7','InitData',GetDate(),'Init','1','7')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'ទំនិញ','2','3','1','Product_Product','1','InitData',GetDate(),'Init','1','8')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'ប្រភេទំនិញ','2','3','1','Product_Category','2','InitData',GetDate(),'Init','1','9')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'បុគ្គលិក','2','1','1','Employee_Employee','1','InitData',GetDate(),'Init','1','10')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'ការទូទាត់បុគ្គលិក','2','1','1','Employee_EmployeeBill','2','InitData',GetDate(),'Init','1','11')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'ការលក់','2','4','1','Sale_Sale','1','InitData',GetDate(),'Init','1','12')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'ការបង្កើតវិក័យប័ត្រ','2','4','1','Sale_CreateInvoice','2','InitData',GetDate(),'Init','1','13')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'បញ្ជាទិញ','2','4','1','Sale_PurchaseOrder','3','InitData',GetDate(),'Init','1','14')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'អ្នកប្រើប្រាស់','2','7','1','Setting_User','1','InitData',GetDate(),'Init','1','15')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'មើល','3','8','2','Product_Product_View','1','InitData',GetDate(),'Init','1','16')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'បន្ថែម','3','8','2','Product_Product_Add','2','InitData',GetDate(),'Init','1','17')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'កែប្រែ','3','8','2','Product_Product_Update','3','InitData',GetDate(),'Init','1','18')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'លុប','3','8','2','Product_Product_Remove','4','InitData',GetDate(),'Init','1','19')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'មើល','3','9','2','Product_Category_View','1','InitData',GetDate(),'Init','1','20')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'បន្ថែម','3','9','2','Product_Category_Add','2','InitData',GetDate(),'Init','1','21')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'កែប្រែ','3','9','2','Product_Category_Update','3','InitData',GetDate(),'Init','1','22')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'លុប','3','9','2','Product_Category_Remove','4','InitData',GetDate(),'Init','1','23')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'មើល','3','10','2','Employee_Employee_View','1','InitData',GetDate(),'Init','1','24')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'បន្ថែម','3','10','2','Employee_Employee_Add','2','InitData',GetDate(),'Init','1','25')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'កែប្រែ','3','10','2','Employee_Employee_Update','3','InitData',GetDate(),'Init','1','26')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'លុប','3','10','2','Employee_Employee_Remove','4','InitData',GetDate(),'Init','1','27')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'មើល','3','11','2','Employee_EmployeeBill_View','1','InitData',GetDate(),'Init','1','28')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'បន្ថែម','3','11','2','Employee_EmployeeBill_Add','2','InitData',GetDate(),'Init','1','29')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'កែប្រែ','3','11','2','Employee_EmployeeBill_Update','3','InitData',GetDate(),'Init','1','30')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'លុប','3','11','2','Employee_EmployeeBill_Remove','4','InitData',GetDate(),'Init','1','31')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'មើល','3','12','2','Sale_Sale_View','1','InitData',GetDate(),'Init','1','32')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'បន្ថែម','3','12','2','Sale_Sale_Add','2','InitData',GetDate(),'Init','1','33')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'កែប្រែ','3','12','2','Sale_Sale_Update','3','InitData',GetDate(),'Init','1','34')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'លុប','3','12','2','Sale_Sale_Remove','4','InitData',GetDate(),'Init','1','35')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'មើល','3','13','2','Sale_CreateInvoice_View','1','InitData',GetDate(),'Init','1','36')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'បន្ថែម','3','13','2','Sale_CreateInvoice_Add','2','InitData',GetDate(),'Init','1','37')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'កែប្រែ','3','13','2','Sale_CreateInvoice_Update','3','InitData',GetDate(),'Init','1','38')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'លុប','3','13','2','Sale_CreateInvoice_Remove','4','InitData',GetDate(),'Init','1','39')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'មើល','3','14','2','Sale_PurchaseOrder_View','1','InitData',GetDate(),'Init','1','40')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'បន្ថែម','3','14','2','Sale_PurchaseOrder_Add','2','InitData',GetDate(),'Init','1','41')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'កែប្រែ','3','14','2','Sale_PurchaseOrder_Update','3','InitData',GetDate(),'Init','1','42')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'លុប','3','14','2','Sale_PurchaseOrder_Remove','4','InitData',GetDate(),'Init','1','43')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'មើល','3','15','2','Setting_User_View','1','InitData',GetDate(),'Init','1','44')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'បន្ថែម','3','15','2','Setting_User_Add','2','InitData',GetDate(),'Init','1','45')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'កែប្រែ','3','15','2','Setting_User_Update','3','InitData',GetDate(),'Init','1','46')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'លុប','3','15','2','Setting_User_Remove','4','InitData',GetDate(),'Init','1','47')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'អតិថិជន','2','2','2','Customer_Customer','1','InitData',GetDate(),'Init','1','48')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'មើល','3','48','2','Customer_Customer_View','1','InitData',GetDate(),'Init','1','49')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'បន្ថែម','3','48','2','Customer_Customer_Add','2','InitData',GetDate(),'Init','1','50')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'កែប្រែ','3','48','2','Customer_Customer_Update','3','InitData',GetDate(),'Init','1','51')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'លុប','3','48','2','Customer_Customer_Remove','4','InitData',GetDate(),'Init','1','52')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'ទូទៅ','1','0','2','General','8','InitData',GetDate(),'Init','1','53')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'ចំណូលចំណាយ','2','53','2','General_IncomeOutcome','1','InitData',GetDate(),'Init','1','54')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'មើល','3','54','2','General_IncomeOutcome_View','1','InitData',GetDate(),'Init','1','55')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'បន្ថែម','3','54','2','General_IncomeOutcome_Add','2','InitData',GetDate(),'Init','1','56')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'កែប្រែ','3','54','2','General_IncomeOutcome_Update','3','InitData',GetDate(),'Init','1','57')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'លុប','3','54','2','General_IncomeOutcome_Remove','4','InitData',GetDate(),'Init','1','58')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'របាយការណ៍ដឹកលម្អិត','2','6','3','Report_DriverDeliveryDetail','1','InitData',GetDate(),'Init','1','59')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'របាយការណ៍ចំណូលចំណាយផ្សេង','2','6','3','Report_IncomeExpense','2','InitData',GetDate(),'Init','1','60')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'របាយការណ៍ចំណូល','2','6','3','Report_Income','3','InitData',GetDate(),'Init','1','61')
INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'របាយការណ៍ចំណាយ','2','6','3','Report_Expense','4','InitData',GetDate(),'Init','1','62')

--INSERT ADMIN USER
SET IDENTITY_INSERT Users ON
GO
INSERT INTO Users(Id, Name, FullName, PasswordHash, Active, RowDate, CreatedBy, Note) VALUES(0, 'Administrator','admin','915a695714ea2f7b7a869d42a91c94c191b3270076be77ab2a2874133b69b6d5',1,GETDATE(),'INIT',N'អ្នកប្រើប្រាស់មិនអាចលុបបាន')
SET IDENTITY_INSERT Users OFF
GO


DROP TABLE IF EXISTS #TempUserPermissions 
SELECT 
UserId = 0,
PermissionId = p.Id,
Active = 1,
RowDate = GETDATE(), 
CreatedBy = 'INIT DATA'
INTO #TempUserPermissions
FROM Permissions P

INSERT INTO UserPermissions
SELECT * FROM #TempUserPermissions