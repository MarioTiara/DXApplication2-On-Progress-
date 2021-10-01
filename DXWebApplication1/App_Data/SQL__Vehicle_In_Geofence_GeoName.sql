SELECT
A.VehicleSid,
C.REG_NO,
A.EnterDate,
A.ExitDate,
B.GEOFENCE_NAME
FROM Report_Vehicle_In_Geofence_60c8dfca03b34dbab7a62db53d3cba2e A
	 INNER JOIN VEHICLES C ON C.VEHICLE_SID = A.VehicleSid	
	 LEFT JOIN GEOFENCE B ON B.GEOFENCE_SID = A.ObjectID

WHERE A.ExitDate<>0  and  B.GEOFENCE_SID=@GEOFENCE_SID and  A.EnterDate>=@FROM_DATE and A.EnterDate<=@TO_DATE