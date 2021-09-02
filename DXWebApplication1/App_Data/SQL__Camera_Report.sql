SELECT
	A.VehicleSid,
	B.REG_NO,
	A.CaptureTime,
	C.SourceId,
	C.ImageData
FROM
	Report_Camera_60c8dfca03b34dbab7a62db53d3cba2e A
	INNER JOIN VEHICLES B ON A.VehicleSid = B.VEHICLE_SID
	INNER JOIN CAMDataSrc C ON A.DataSource = C.Id

WHERE A.VehicleSid =@VEHICLE_SID AND A.CaptureTime >=@CAPTURE_FROM_DATE AND A.CaptureTime <= @CAPTURE_TO_DATE 