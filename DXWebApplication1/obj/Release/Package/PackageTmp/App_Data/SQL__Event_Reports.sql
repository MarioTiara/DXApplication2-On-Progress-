SELECT 
	E.REG_NO, A.VehicleSid, 
	A.EventTime, A.PositionID, 
	B.EventName, B.ID,
	C.WP_SID,C.POLYGON,
	C.WP_PROPINSI,C.WP_KABUPATEN,
	C.WP_KECAMATAN,C.WP_JALAN,
	C.WP_KELURAHAN,D.GEOFENCE_NAME, 
	F.IO1_Caption, F.IO1_Visible,
	F.IO1_On_Caption, F.IO1_Off_Caption, 
	F.IO2_Caption, F.IO2_Visible,
	F.IO2_On_Caption, F.IO2_Off_Caption, 
	F.IO3_Caption, F.IO3_Visible,
	F.IO3_On_Caption, F.IO3_Off_Caption, 
	F.IO4_Caption, F.IO4_Visible,
	F.IO4_On_Caption, F.IO4_Off_Caption, 
	F.Suhu01_Caption, F.Suhu01_Visible, 
	F.Suhu02_Caption, F.Suhu02_Visible, 
	G.LAST_IO1 , G.LAST_IO2, 
	G.LAST_IO3,G.LAST_IO4 , 
	G.LAST_IO5, G.LAST_IO6 
FROM EventReport A 
INNER JOIN EventType B ON B.ID = A.EventType 
INNER JOIN WP_5b9241a1b00f41088d1e09a462b1d6b6 C ON C.WP_SID = A.PositionID 
LEFT JOIN GEOMAP D ON D.GEOFENCE_CODE = A.ObjectID 
LEFT JOIN VEHICLES E ON E.VEHICLE_SID = A.VehicleSid 	
LEFT JOIN VehicleConfig F ON F.VehicleSid = A.VehicleSid 
LEFT JOIN VEHICLES G ON G.VEHICLE_SID = A.VehicleSid 
WHERE B.ID NOT IN(3,4,17,18) 
	AND A.VehicleSid =@VehicleSid
	AND A.EventTime >=@FROM_DATE 
	AND A.EventTime <=@TO_DATE ORDER BY A.EventTime DESC