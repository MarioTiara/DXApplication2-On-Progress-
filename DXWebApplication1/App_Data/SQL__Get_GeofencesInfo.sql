SELECT
 GEOFENCE_SID,
 GEOFENCE_CODE, GEOFENCE_NAME, 
 GEOFENCE_TYPE, GEOFENCE_SPEED, 
 GEOFENCE_GEOM,
 GEOFENCE_GEOM.STPointOnSurface().ToString() GEOFENCE_POINT ,
 GEOFENCE_ALERT,IS_ACTIVE,GEOFENCE_LAT,GEOFENCE_LON,CREATE_DATE,UPDATE_DATE,UPDATE_BY

 FROM GEOFENCE WHERE GEOFENCE_NAME = @GEONAME AND GEOFENCE_GEOM.STPointOnSurface().ToString() IS NOT NULL