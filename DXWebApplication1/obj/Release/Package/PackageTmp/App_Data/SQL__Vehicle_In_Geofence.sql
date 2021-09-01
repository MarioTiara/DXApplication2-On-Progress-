SELECT D.REG_NO, A.VehicleSid, A.EnterId, A.ExitId,A.Polygon,B.EventTime AS EnterTime, B.EventType,  C.EventTime AS ExitTime,C.EventType FROM Report_Geofence_Visits_60c8dfca03b34dbab7a62db53d3cba2e A
INNER JOIN EventReport B  ON B.ID = A.EnterId 
INNER JOIN EventReport C ON C.ID = A.ExitId
INNER JOIN VEHICLES D ON D.VEHICLE_SID = A.VehicleSid
WHERE B.EventTime >= @STARTDATE AND B.EventTime <= @ENDDATE AND A.Polygon = @POLYGON
 ORDER BY EnterId ASC