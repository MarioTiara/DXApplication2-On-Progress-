SELECT  
		ACCOUNT_SID, 
		PASSWORDZ,
		FULL_NAME,
		CUSTOMER_SID,
		PROJECT_SID,
		ROLE,
		COMPANY_SID,
		DIVISION_SID,
		SUBDIVISION_SID
FROM ACCOUNTS 
WHERE 
		ACCOUNT_SID = @ACCOUNT_SID 
		AND REPLACE(PASSWORDZ,'-','')  =  CONVERT(varchar(50),HashBytes('MD5', CONVERT(NVARCHAR(50), @PASSWORDZ)), 2)