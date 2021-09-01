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

WHERE
	A.CaptureTime >= '2021-08-04 00:00:00' AND A.CaptureTime <= '2021-08-04 23:59:59'
	AND B.REG_NO = 'B 9660 SXR'