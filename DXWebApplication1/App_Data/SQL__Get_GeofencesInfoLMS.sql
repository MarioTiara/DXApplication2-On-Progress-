		SELECT	NamaLokasi GEOFENCE_NAME,
		Latitude GEOFENCE_LAT,
		Longitude GEOFENCE_LON
FROM Production.LMS.dbo.MsAssortLokasi
WHERE KodeLokasi = @GEOFENCE_CODE