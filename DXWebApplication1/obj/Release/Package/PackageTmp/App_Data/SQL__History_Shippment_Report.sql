﻿SELECT 
		XTR.TripTripNo, XTR.OrderCustomerCode, XTR.TripPlateNo, 
		XTR.OrderGPNo1, XTR.OrderGPNo2, XTR.AllocOrderWaybillNo, 
		XTR.OrderOrderNo, XTR.AllocOrderLPointCode, XTR.AllocOrderLPointName, 
		XTR.AllocOrderUPointCode, XTR.AllocOrderUPointName, XTR.OrderLPointEDD, 
		XTR.OrderLPointETD, XTR.TripAAD, XTR.TripAAT, 
		XTR.TripDriverNo, XTR.TripDriverTel1 INTO #PURETRORDER 
FROM PRODUCTION.LMS.dbo.TrOrderAssortHdr XTR WHERE  XTR.OrderLPointEDD >= @FROM_DATE AND XTR.TripAAD <= @TO_DATE 
SELECT 
		ROW_NUMBER() OVER (ORDER BY A.TripTripNo) AS RECORD_ID,  
		MAX(A.TripTripNo) AS ORDER_NUMBER , MAX(A.OrderCustomerCode) AS CUSTOMER_SID, 
		MAX(A.TripPlateNo) AS REG_NO, MAX(A.OrderGPNo1) AS OrderGPNo1, 
		MAX(A.OrderGPNo2) AS OrderGPNo2, MAX(A.AllocOrderWaybillNo) AS AllocOrderWaybillNo, 
		MAX(A.AllocOrderLPointCode) AS ORIGIN_CODE, MAX(A.AllocOrderLPointName) AS ORIGIN_NAME, 
		MAX(A.AllocOrderUPointCode) AS DESTINATION_CODE, MAX(A.AllocOrderUPointName) AS DESTINATION_NAME, 
		CAST(MAX(A.OrderLPointEDD) + ' ' + LEFT(LTRIM(RTRIM(MAX(A.OrderLPointETD))),2) + ':' + SUBSTRING(LTRIM(RTRIM(MAX(A.OrderLPointETD))),3,4) + ':00' AS DATETIME) AS PICKUP_DATE, 
		CAST(MAX(A.TripAAD) + ' ' + LEFT(LTRIM(RTRIM(MAX(A.TripAAT))),2) + ':' + SUBSTRING(LTRIM(RTRIM(MAX(A.TripAAT))),3,4) + ':00' AS DATETIME) AS DUE_DATE, 
		MAX(A.TripDriverNo) AS DRIVER_SID, MAX(A.TripDriverTel1) AS DRIVER_PHONE,  
		MAX(B.HISTORY_DATE) AS HISTORY_DATE, MAX(B.HISTORY_LOCATION) AS HISTORY_LOCATION, 
		MAX(B.ORDER_NUMBER) AS ORDER_NUMBER, MAX(B.STATUS) AS STATUS 
FROM #PURETRORDER A INNER JOIN DATA_ORDER_HISTORY B WITH (NOLOCK,NOWAIT) ON B.ORDER_NUMBER = A.TripTripNo GROUP BY A.TripTripNo DROP TABLE #PURETRORDER