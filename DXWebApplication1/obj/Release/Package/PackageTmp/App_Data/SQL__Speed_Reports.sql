﻿SELECT  
	A.VEHICLE_SID, 
	A.WP_TIME,
	A.WP_JALAN,
	A.WP_KELURAHAN,
	A.WP_KECAMATAN,
	A.WP_KABUPATEN,
	A.WP_PROPINSI, 
	A.POLYGON, 
	A.WP_SPEED, 
	A.HEADING, 
	A.KM_ODO 
	INTO #GETDATA
FROM WP_5b9241a1b00f41088d1e09a462b1d6b6 A 
WHERE A.VEHICLE_SID = @VEHICLE_SID 
	AND A.WP_TIME >= @WP_FROM_DATE 
	AND A.WP_TIME <= @WP_TO_DATE ORDER BY A.WP_TIME DESC

SELECT 
	A.*, B.REG_NO 
FROM #GETDATA A 
	INNER JOIN VEHICLES B ON B.VEHICLE_SID = A.VEHICLE_SID

DROP TABLE #GETDATA