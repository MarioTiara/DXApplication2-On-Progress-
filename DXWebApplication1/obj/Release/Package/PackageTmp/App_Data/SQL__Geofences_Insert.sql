INSERT INTO [dbo].[GEOFENCE]
           ([COMPANY_SID]
           ,[DIVISION_SID]
           ,[SUBDIVISION_SID]
           ,[GEOFENCE_NAME]
           ,[GEOFENCE_CODE]
           ,[GEOFENCE_TYPE]
           ,[GEOFENCE_SPEED]
           ,[GEOFENCE_SPEED2]
           ,[GEOFENCE_ALERT]
           ,[GEOFENCE_GEOM]
           ,[ACCOUNT_SID]
		   ,[IS_ACTIVE]
		   ,[GEOFENCE_LAT]
		   ,[GEOFENCE_LON]
		   ,[CREATE_DATE])
     VALUES
           (@COMPANY_SID
           ,@DIVISION_SID
           ,@SUBDIVISION_SID
           ,@GEOFENCE_NAME
           ,@GEOFENCE_CODE
           ,@GEOFENCE_TYPE
           ,@GEOFENCE_SPEED
           ,@GEOFENCE_SPEED2
           ,@GEOFENCE_ALERT
           ,geometry::STGeomFromText(@GEOFENCE_GEOM, 4326)
           ,@ACCOUNT_SID
		   ,@IS_ACTIVE
		   ,@GEOFENCE_LAT
		   ,@GEOFENCE_LON
		   ,GETDATE())

