
    var wScr = $(window).width();
    var hScr = $(window).height();
    var defaultMap = "http://map01.xlocate.com:8080/map/{z}/{x}/{y}.png";
    var OpenStreetMap = L.tileLayer('//{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    });
    var cpnMap = L.tileLayer('http://map01.xlocate.com:8080/map/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '&copy; <a href="http://cpn.co.id/id/">Cakrawala Putra Nusantara</a>'
    });
    var StamenToner = L.tileLayer('//stamen-tiles-{s}.a.ssl.fastly.net/toner/{z}/{x}/{y}.{ext}', {
        attribution: 'Map tiles by <a href="http://stamen.com">Stamen Design</a>, <a href="http://creativecommons.org/licenses/by/3.0">CC BY 3.0</a> &mdash; Map data &copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>',
        subdomains: 'abcd',
        minZoom: 0,
        maxZoom: 20,
        ext: 'png'
    });
    var googleStreets = L.tileLayer('http://{s}.google.com/vt/lyrs=m&x={x}&y={y}&z={z}', {
        maxZoom: 20,
        subdomains: ['mt0', 'mt1', 'mt2', 'mt3']
    });
    var googleHybrid = L.tileLayer('http://{s}.google.com/vt/lyrs=s,h&x={x}&y={y}&z={z}', {
        maxZoom: 20,
        subdomains: ['mt0', 'mt1', 'mt2', 'mt3']
    });
    var googleTraffic = L.tileLayer('https://{s}.google.com/vt/lyrs=m@221097413,traffic&x={x}&y={y}&z={z}', {
        maxZoom: 20,
        minZoom: 2,
        subdomains: ['mt0', 'mt1', 'mt2', 'mt3'],
    });
    var marker = {};
    var vehicle, map, targetMarker, markerCluster, chart, omarkerPuls, linePanel, engineCluster, posCount, mplayProp, repLatLon, playbackData, accuCluster;
    var vehicleTemp;
    var pathLine = [];
    var engineMarker = [];
    var accuMarker = [];
    var updateTimer = false;
    var playTimer = false;
    var playSpeed = 1000;
    var updatePeriod = 45000;
    var regNo = "";
    var my_val = 0;
    var otargetMarker;
    var regNoSource = [], regNoSourcePlayback = [];
    var ofgoensnData = [], ofguetsnData = [], ofguefsnData = [], otgdensnData = [], otgueosovsData = [], otguensnldData = [], otguenswtgData = [], otguensondData = [], otguensovnData = [], otguensabnData = [];
    var gpsActive = [];
    var gpsInactive = [];
    var gpsDelay = [];
    var chart;
    var setGeofence;
    var GEO_NAME;
    var geoNames = [];
    var geoArpos = [];
    var original = [];
    var latlonedit = [];
    var track; // this will be the L.polyline containing the points

    var trailLayer = L.featureGroup();
    var editLayer;
    var selectedFeature = null;
    var geojsonlayer;
    var polygonDrawer;
    var drawControl;
    var layerAddGeo;
    var type;
    var repLatLon;
    var dataEditGeo;
    var TYPE;
    var polygon = [];
    var polyline = [];
    var value = '@Request.RequestContext.HttpContext.Session["ACCOUNT_SID"]';
    
    var LinemarkersLayer;
    var PointsMarkersLayer;
    var StepsMarkersLayer;
    
    if (value == null) {

    }
    //*****************************************************************************************************************************
    // Button Slider Sisi Kanan
    $("#mybutton").click(function () {
        getSession();
        my_val = my_val + 1;

        if (my_val % 2 != 0) {
            $("div.formholder").animate({ width: 300 }, 500);
            $("#mybutton").animate({ right: 300 }, 500);
        }
        else {
            $("div.formholder").animate({ width: 0 }, 500);
            $("#mybutton").animate({ right: 0 }, 500);
        }
   
    });


   
    //*****************************************************************************************************************************
    $("#ofgoensn").click(function () {
        var order_sts = 'ofgoensn';
        $.ajax({
            url: "Maps/GridViewPartialView",
            type: 'POST',
            data: { ORDERSTS: order_sts.toUpperCase() },
            beforeSend: function () {
                CallbackPanel.PerformCallback();
            },
            success: function (data) {
                leftPanel.SetVisible(false);
                pcModalMode.Show();
                $("#containers").html(data);
                $("#pcModalMode_PWH-1T").html("No Orders - GPS OFF");
                
            }
        });
       
    });
    //*****************************************************************************************************************************
    $("#ofguetsn").click(function () {
        var order_sts = 'ofguetsn';
        $.ajax({
            url: "Maps/GridViewPartialView",
            type: 'POST',
            data: { ORDERSTS: order_sts.toUpperCase() },
            beforeSend: function () {
               CallbackPanel.PerformCallback();
            },
            success: function (data) {
                pcModalMode.Show();
                $("#containers").html(data);
                $("#pcModalMode_PWH-1T").html("No Orders - Engine ON");

            }
        });
     
    });
    //*****************************************************************************************************************************
    $("#ofguefsn").click(function () {
        var order_sts = 'ofguefsn';
        $.ajax({
            url: "Maps/GridViewPartialView",
            type: 'POST',
            data: { ORDERSTS: order_sts.toUpperCase() },
            beforeSend: function () {
                CallbackPanel.PerformCallback();
            },
            success: function (data) {
                pcModalMode.Show();
                $("#containers").html(data);
                $("#pcModalMode_PWH-1T").html("No Orders - Engine Off");

            }
        });

    });
   
//*****************************************************************************************************************************

    $("#otgdensn").click(function () {
        var order_sts = 'otgdensn';
        $.ajax({
            url: "Maps/GridViewPartialView",
            type: 'POST',
            data: { ORDERSTS: order_sts.toUpperCase() },
            beforeSend: function () {
                CallbackPanel.PerformCallback();
            },
            success: function (data) {
                pcModalMode.Show();
                $("#containers").html(data);
                $("#pcModalMode_PWH-1T").html("With Orders - GPS Delay");

            }
        });

    });
    
    //*****************************************************************************************************************************
   
    $("#otgueosovs").click(function () {
        var order_sts = 'otgueosovs';
        $.ajax({
            url: "Maps/GridViewPartialView",
            type: 'POST',
            data: { ORDERSTS: order_sts.toUpperCase() },
            beforeSend: function () {
                CallbackPanel.PerformCallback();
            },
            success: function (data) {
                pcModalMode.Show();
                $("#containers").html(data);
                $("#pcModalMode_PWH-1T").html("With Orders - Overstay");

            }
        });

    });
    //*****************************************************************************************************************************
    $("#otguensnld").click(function () {
        var order_sts = 'otguensnld';
        $.ajax({
            url: "Maps/GridViewPartialView",
            type: 'POST',
            data: { ORDERSTS: order_sts.toUpperCase() },
            beforeSend: function () {
                CallbackPanel.PerformCallback();
            },
            success: function (data) {
                pcModalMode.Show();
                $("#containers").html(data);
                $("#pcModalMode_PWH-1T").html("With Orders - No Load");

            }
        });

    });
    //*****************************************************************************************************************************
    $("#otguenswtg").click(function () {
        var order_sts = 'otguenswtg';
        $.ajax({
            url: "Maps/GridViewPartialView",
            type: 'POST',
            data: { ORDERSTS: order_sts.toUpperCase() },
            beforeSend: function () {
                CallbackPanel.PerformCallback();
            },
            success: function (data) {
                pcModalMode.Show();
                $("#containers").html(data);
                $("#pcModalMode_PWH-1T").html("With Orders - Waiting For Loading");

            }
        });

    });
    
    //*****************************************************************************************************************************
    $("#otguensond").click(function () {
        var order_sts = 'otguensond';
        $.ajax({
            url: "Maps/GridViewPartialView",
            type: 'POST',
            data: { ORDERSTS: order_sts.toUpperCase() },
            beforeSend: function () {
                CallbackPanel.PerformCallback();
            },
            success: function (data) {
                pcModalMode.Show();
                $("#containers").html(data);
                $("#pcModalMode_PWH-1T").html("With Orders - On Delivery");

            }
        });

    });

    //*****************************************************************************************************************************
    $("#otguensovn").click(function () {
        var order_sts = 'otguensovn';
        $.ajax({
            url: "Maps/GridViewPartialView",
            type: 'POST',
            data: { ORDERSTS: order_sts.toUpperCase() },
            beforeSend: function () {
                CallbackPanel.PerformCallback();
            },
            success: function (data) {
                pcModalMode.Show();
                $("#containers").html(data);
                $("#pcModalMode_PWH-1T").html("With Orders - Overnigth");

            }
        });

    });

    //*****************************************************************************************************************************
    $("#otguensabn").click(function () {
        var order_sts = 'otguensabn';
        $.ajax({
            url: "Maps/GridViewPartialView",
            type: 'POST',
            data: { ORDERSTS: order_sts.toUpperCase() },
            beforeSend: function () {
                CallbackPanel.PerformCallback();
            },
            success: function (data) {
                pcModalMode.Show();
                $("#containers").html(data);
                $("#pcModalMode_PWH-1T").html("With Orders - Late Pickup or Late Arrival");

            }
        });

    });
    
    //*****************************************************************************************************************************
    Highcharts.setOptions({ lang: { thousandsSep: "" } });
    chart = new Highcharts.chart('containerPie', {
        chart: {
            backgroundColor: 'transparent',
            type: 'pie',
            spacing: [20, 0, 0, 0]
        },
        exporting: {
            enabled: false
        },
        title: {
            text: null
        },
        credits: {
            enabled: false
        },
        tooltip: {
            pointFormat: '{point.percentage:.1f} % {point.y} units'
        },
        plotOptions: {
            pie: {
                colors: ['#0ead69', '#bc4749', '#a1aaa1'],
                allowPointSelect: true,
                cursor: 'pointer',
                showInLegend: true,
                dataLabels: { enabled: false },
                size: 175
            }
        },
        legend: {
            itemStyle: {
                fontSize: '15px',
                fontFamily: 'Segoe UI',
                fontWeight: 'regular'
            }
        },
        series: [{
            colorByPoint: true,
            point: {
                events: {
                    click: function (e) {
                            
                       
                            $.ajax({
                                type: "POST",
                                url: 'Maps/GridViewPartialViewGPS',
                                data: { GPSTAT: e.point.name.toUpperCase() },
                                beforeSend: function () {
                                    CallbackPanel.PerformCallback();
                                },
                                success: function (data) {
                                    pcModalMode.Show();
                                    $("#containers").html(data);
                                    if (e.point.name.toUpperCase() == 'INACTIVE') {
                                        $("#pcModalMode_PWH-1T").html("GPS - Inactive");

                                    } else if (e.point.name.toUpperCase() == 'DELAY') {
                                        $("#pcModalMode_PWH-1T").html("GPS - Delay");

                                    } else if (e.point.name.toUpperCase() == 'ACTIVE') {
                                        $("#pcModalMode_PWH-1T").html("GPS - Active");
                                    }
                                   
                                }
                            });
                        
                   
                    }
                }
            },
            data: [{ name: 'Active' }, { name: 'Delay' }, { name: 'Inactive' }]
        }]
    });
    //*****************************************************************************************************************************
  
    $.mockjaxSettings.logging = 0;
    //*****************************************************************************************************************************
    $.mockjax({
        url: '/localVehicle',
        response: function () {
            this.responseText = vehicle;
        }
    });
    
    //*****************************************************************************************************************************
    // Inisialisasi Map
    function initMap() {
        getSession();
        $("#pcModalHistory_DXPWMB-1").remove();
        $(window).resize(function () {
            var height = hScr;
            $('#map').height(height);
        })
        $(window).resize(); //on page load
        map = L.map('map', {
            layers: [googleTraffic],
            editable: true// Offending line
        });
        var baseMaps = {
            "Google Traffic": googleTraffic,
            "Google Streets": googleStreets,
            "Google Hybrid": googleHybrid,
            "OpenStreetMap": OpenStreetMap,
            "CPN": cpnMap
        };
        //Create overlay group for Leaflet Layer Control
        var overlayMaps = {};
        //Create Leaflet Layer Control and add to map
        L.control.layers(baseMaps, overlayMaps,
        {
            position: 'topleft',
            collapsed: true
        }
        ).addTo(map);
        map.fitBounds([[5.5769167874644966, 94.81858018012717], [-9.0769167874644966, 130.01858018012717]]);
        markerCluster = new L.markerClusterGroup({ showCoverageOnHover: false, maxClusterRadius: 40 });
        initVehicle();
        updateTimer = setInterval(updateData, updatePeriod);

        getGeofence();


    }

//*****************************************************************************************************************************

    function getGeofence() {
        btnEdit.SetEnabled(false);
        btnSave.SetVisible(false);
        btnCancelGeo.SetVisible(false);
        $.ajax({
            type: "GET",
            url: "Maps/getDataGeo",
            success: function (data) {
                geofence = data;

                for (var i in data) {
                    $("#srcGeofence").append('<option value="' + data[i].GEOFENCE_NAME + '">' + data[i].GEOFENCE_NAME + '</option>');
                    if (data[i].GEOFENCE_TYPE == "FTY") {
                        var geoColor = "purple";
                    }
                    else if (data[i].GEOFENCE_TYPE == "OFC") {
                        var geoColor = "green";
                    }
                    else if (data[i].GEOFENCE_TYPE == "LDG") {
                        var geoColor = "purple";
                    }
                    else if (data[i].GEOFENCE_TYPE == "ULD") {
                        var geoColor = "purple";
                    }
                    else if (data[i].GEOFENCE_TYPE == "OTH") {
                        var geoColor = "black";
                    }
                    else if (data[i].GEOFENCE_TYPE == "QUE") {
                        var geoColor = "blue";
                    }
                    else if (data[i].GEOFENCE_TYPE == "WHS") {
                        var geoColor = "orange";
                    }
                    geoNames.push(data[i].GEOFENCE_NAME);
                    var geoGeoms = data[i].GEOFENCE_GEOM;

                    if (geoGeoms.startsWith("POLYGON")) {
                        var geoSubstr = geoGeoms.substring(10, geoGeoms.length - 2);
                        var geoCoord = geoSubstr.split(", ");
                        geoArpos = [];
                        for (var c in geoCoord) {
                            var geoLatLon = geoCoord[c].split(" ");
                            var geoLat = parseFloat(geoLatLon[1]);
                            var geoLon = parseFloat(geoLatLon[0]);
                            geoArpos.push([geoLat, geoLon]);
                        }
                        polygon[i] = L.polygon(geoArpos, {
                            color: geoColor,
                            weight: 1,
                            opacity: 0.5
                        });
                        polygon[i].bindTooltip(data[i].GEOFENCE_NAME, {
                            permanent: false,
                            direction: "center",
                            sticky: true
                        }).openTooltip();
                        polygon[i].addTo(map);
                    }
                    else if (geoGeoms.startsWith("MULTIPOLYGON")) {
                        var geoSubstr = geoGeoms.substring(16, geoGeoms.length - 3);
                        var geoString = geoSubstr.split(")), ((");
                        for (var m in geoString) {
                            try {
                                var geoCoord = geoString[m].split(", ");
                                geoArpos = [];
                                for (var c in geoCoord) {
                                    var geoLatLon = geoCoord[c].split(" ");
                                    var geoLat = parseFloat(geoLatLon[1]);
                                    var geoLon = parseFloat(geoLatLon[0]);
                                    geoArpos.push([geoLat, geoLon]);
                                }
                                polygon[i] = L.polygon(geoArpos, {
                                    color: geoColor,
                                    weight: 1,
                                    opacity: 0.5
                                });
                                polygon[i].bindTooltip(data[i].GEOFENCE_NAME, {
                                    permanent: false,
                                    direction: "center",
                                    sticky: true
                                }).openTooltip();
                                polygon[i].addTo(map);
                            }
                            catch (e) {
                                console.log(e, geoString[m]);
                            }
                        }
                    }
                    else if (geoGeoms.startsWith("GEOMETRYCOLLECTION")) {
                        var geoSubstr = geoGeoms.substring(20, geoGeoms.length - 1);
                        var lineCount = geoSubstr.match(/LINESTRING/g);
                        var polyCount = geoSubstr.match(/POLYGON/g);
                        var geoCollec = lineCount + polyCount;
                        for (var gc = 0; gc < geoCollec.length; gc++) {
                            try {
                                if (geoSubstr.startsWith("LINESTRING")) {
                                    var strEnd = geoSubstr.indexOf(")");
                                    var geomTemps = geoSubstr.substring(12, strEnd);
                                    var geoCoord = geomTemps.split(", ");
                                    geoArpos = [];
                                    for (var c in geoCoord) {
                                        var geoLatLon = geoCoord[c].split(" ");
                                        var geoLat = parseFloat(geoLatLon[1]);
                                        var geoLon = parseFloat(geoLatLon[0]);
                                        geoArpos.push([geoLat, geoLon]);
                                    }
                                    polyline[i] = L.polyline(geoArpos, {
                                        color: geoColor,
                                        weight: 1,
                                        opacity: 0.5
                                    });
                                    polyline[i].bindTooltip(data[i].GEOFENCE_NAME, {
                                        permanent: false,
                                        direction: "center",
                                        sticky: true
                                    }).openTooltip();
                                    polyline[i].addTo(map);
                                }
                                else if (geoSubstr.startsWith("POLYGON")) {
                                    var strEnd = geoSubstr.indexOf(")");
                                    var geomTemps = geoSubstr.substring(10, strEnd);
                                    var geoCoord = geomTemps.split(", ");
                                    geoArpos = [];
                                    for (var c in geoCoord) {
                                        var geoLatLon = geoCoord[c].split(" ");
                                        var geoLat = parseFloat(geoLatLon[1]);
                                        var geoLon = parseFloat(geoLatLon[0]);
                                        geoArpos.push([parseFloat(geoLatLon[1]), parseFloat(geoLatLon[0])]);
                                    }
                                    polygon[i] = L.polygon(geoArpos, {
                                        color: geoColor,
                                        weight: 1,
                                        opacity: 0.5
                                    });
                                    polygon[i].bindTooltip(data[i].GEOFENCE_NAME, {
                                        permanent: false,
                                        direction: "center",
                                        sticky: true
                                    }).openTooltip();
                                    polygon[i].addTo(map);
                                }
                                geoSubstr = geoSubstr.substring(strEnd + 3, geoSubstr.length);
                            }
                            catch (e) {
                                console.log(e);
                            }
                        }
                    }
                }
            }
        });

        initMapCreateGeofence();
    }
//*****************************************************************************************************************************

    // Fungsi Inisialisasi Vehicle
    function initVehicle() {
        getSession();
        $.ajax({
            type: "GET",
            url: "Maps/getData",
            success: function (data) {
                vehicle = data
                updateChart();
                //updateRegno();
                if (regNo == "") {
                    for (var i = 0; i < data.length; i++) {
                        if (data[i].ORDSTS == 'OFGOENSN') {
                            var markerProp = {
                                className: "ofgoensnMarker",
                                html: '<div class="ofgoensnHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OFGUETSN') {
                            var markerProp = {
                                className: "ofguetsnMarker",
                                html: '<div class="ofguetsnHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OFGUEFSN') {
                            var markerProp = {
                                className: "ofguefsnMarker",
                                html: '<div class="ofguefsnHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OTGDENSN') {
                            var markerProp = {
                                className: "otgdensnMarker",
                                html: '<div class="otgdensnHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OTGUEOSOVS') {
                            var markerProp = {
                                className: "otgueosovsMarker",
                                html: '<div class="otgueosovsHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OTGUENSNLD') {
                            var markerProp = {
                                className: "otguensnldMarker",
                                html: '<div class="otguensnldHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OTGUENSWTG') {
                            var markerProp = {
                                className: "otguenswtgMarker",
                                html: '<div class="otguenswtgHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OTGUENSOND') {
                            var markerProp = {
                                className: "otguensondMarker",
                                html: '<div class="otguensondHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OTGUENSOVN') {
                            var markerProp = {
                                className: "otguensovnMarker",
                                html: '<div class="otguensovnHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OTGUENSABN') {
                            var markerProp = {
                                className: "otguensabnMarker",
                                html: '<div class="otguensabnHead"></div>'
                            }
                        }
                        var markerIcon = L.divIcon(markerProp);
                        marker[i] = L.marker([data[i].X, data[i].Y], {
                            alt: data[i].REGNO,
                            icon: markerIcon,
                            rotationAngle: data[i].ANGLE,
                            rotationOrigin: "center"
                        }).bindTooltip(data[i].REGNO, {
                            permanent: true,
                            className: "markerLabel",
                            offset: [0, 22],
                            direction: "center"
                        }).openTooltip();
                        marker[i].on('click', onClick);
                        markerCluster.addLayer(marker[i]);
                    }
                    map.addLayer(markerCluster);
                }
            
            }
        });
    }


 
//*****************************************************************************************************************************
    function updateChart() {
        getSession();
        $.ajax({
            type: "GET",
            url: "/localVehicle",
            success: function (data) {
                clearChartbuf();
                for (var i = 0; i < data.length; i++) {
                    var vehicleData = {
                        "REGNO": data[i].REGNO,
                        "IO1": data[i].IO1,
                        "SPEED": data[i].SPEED,
                        "LASTUPDATE": data[i].LASTUPDATE,
                        "POLYGON": data[i].POLYGON,
                        "VEHICLE_IMEI": data[i].IMEI,
                        "LOCATION": data[i].LOC,
                        "ODO": data[i].ODO,
                        "GPSFIX": data[i].GPSFIX,
                        "IO2": data[i].IO2,
                        "IO3": data[i].IO3,
                        "IO4": data[i].IO4,
                        "PWR": data[i].PWR,
                        "ORDERNO": data[i].ORDERNO,
                        "ORIGIN": data[i].ORIGIN,
                        "DESTIN": data[i].DESTIN,
                        "STATUS": data[i].STATUS,
                    };
                    if (data[i].ORDSTS == "OFGOENSN") {
                        ofgoensnData.push(vehicleData);
                    }
                    else if (data[i].ORDSTS == "OFGUETSN") {
                        ofguetsnData.push(vehicleData);
                    }
                    else if (data[i].ORDSTS == "OFGUEFSN") {
                        ofguefsnData.push(vehicleData);
                    }
                    else if (data[i].ORDSTS == "OTGDENSN") {
                        otgdensnData.push(vehicleData);
                    }
                    else if (data[i].ORDSTS == "OTGUEOSOVS") {
                        otgueosovsData.push(vehicleData);
                    }
                    else if (data[i].ORDSTS == "OTGUENSNLD") {
                        otguensnldData.push(vehicleData);
                    }
                    else if (data[i].ORDSTS == "OTGUENSWTG") {
                        otguenswtgData.push(vehicleData);
                    }
                    else if (data[i].ORDSTS == "OTGUENSOND") {
                        otguensondData.push(vehicleData);
                    }
                    else if (data[i].ORDSTS == "OTGUENSOVN") {
                        otguensovnData.push(vehicleData);
                    }
                    else if (data[i].ORDSTS == "OTGUENSABN") {
                        otguensabnData.push(vehicleData);
                    }
                    if (data[i].GPS == "ACTIVE") {
                        gpsActive.push(vehicleData);
                    }
                    else if (data[i].GPS == "INACTIVE") {
                        gpsInactive.push(vehicleData);
                    }
                    else if (data[i].GPS == "DELAY") {
                        gpsDelay.push(vehicleData);
                    }
                }
                $("#ofgoensn").html(ofgoensnData.length);
                $("#ofguetsn").html(ofguetsnData.length);
                $("#ofguefsn").html(ofguefsnData.length);
                $("#otgdensn").html(otgdensnData.length);
                $("#otgueosovs").html(otgueosovsData.length);
                $("#otguensnld").html(otguensnldData.length);
                $("#otguenswtg").html(otguenswtgData.length);
                $("#otguensond").html(otguensondData.length);
                $("#otguensovn").html(otguensovnData.length);
                $("#otguensabn").html(otguensabnData.length);
                chart.series[0].update({ data: [gpsActive.length, gpsDelay.length, gpsInactive.length] }, true);
            }
        });
    }


//*****************************************************************************************************************************
    function clearChartbuf() {
        ofgoensnData = [];
        ofguetsnData = [];
        ofguefsnData = [];
        otgdensnData = [];
        otgueosovsData = [];
        otguensnldData = [];
        otguenswtgData = [];
        otguensondData = [];
        otguensovnData = [];
        otguensabnData = [];
        gpsActive = [];
        gpsDelay = [];
        gpsInactive = [];
    }
    //*****************************************************************************************************************************
    function updateRegno(reg) {
        $.ajax({
            type: "GET",
            url: "/localVehicle",
            success: function (data) {
                $("#comboBox_VI").empty().append('<option></option>');
                $("#srcPlayback").empty().append('<option value="" selected></option>');
                for (var i = 0; i < data.length; i++) {
                    $("#comboBox_VI").append('<option value="' + data[i].REGNO + '">' + data[i].REGNO + '</option>');
                    $("#srcPlayback").append('<option value="' + data[i].VSID + '">' + data[i].REGNO + '</option>');
                }
                $("#comboBox_VI").val(reg).trigger('change.select2');
            }
        });
    }
    //*****************************************************************************************************************************

    $("#getCenter").click(function () {
        if (targetMarker) {
            var targetPos = targetMarker.getLatLng();
            console.log(targetPos);
            map.setView([targetPos.lat, targetPos.lng], 14);
        }
    });

    //*****************************************************************************************************************************
    function getVehicleInfo(s, e) {
        for (var i = 0; i < vehicle.length; i++) {
            if (vehicle[i].REGNO == $("#comboBox_I").val()) {
                if (vehicle[i].ORDSTS == 'OFGOENSN') {
                    var markerPuls = "ofgoensnPulse";
                    var markerProp = {
                        className: "ofgoensnMarker",
                        html: '<div class="ofgoensnHead"></div>'
                    }
                }
                else if (vehicle[i].ORDSTS == 'OFGUETSN') {
                    var markerPuls = "ofguetsnPulse";
                    var markerProp = {
                        className: "ofguetsnMarker",
                        html: '<div class="ofguetsnHead"></div>'
                    }
                }
                else if (vehicle[i].ORDSTS == 'OFGUEFSN') {
                    var markerPuls = "ofguefsnPulse";
                    var markerProp = {
                        className: "ofguefsnMarker",
                        html: '<div class="ofguefsnHead"></div>'
                    }
                }
                else if (vehicle[i].ORDSTS == 'OTGDENSN') {
                    var markerPuls = "otgdensnPulse";
                    var markerProp = {
                        className: "otgdensnMarker",
                        html: '<div class="otgdensnHead"></div>'
                    }
                }
                else if (vehicle[i].ORDSTS == 'OTGUEOSOVS') {
                    var markerPuls = "otgueosovsPulse";
                    var markerProp = {
                        className: "otgueosovsMarker",
                        html: '<div class="otgueosovsHead"></div>'
                    }
                }
                else if (vehicle[i].ORDSTS == 'OTGUENSNLD') {
                    var markerPuls = "otguensnldPulse";
                    var markerProp = {
                        className: "otguensnldMarker",
                        html: '<div class="otguensnldHead"></div>'
                    }
                }
                else if (vehicle[i].ORDSTS == 'OTGUENSWTG') {
                    var markerPuls = "otguenswtgPulse";
                    var markerProp = {
                        className: "otguenswtgMarker",
                        html: '<div class="otguenswtgHead"></div>'
                    }
                }
                else if (vehicle[i].ORDSTS == 'OTGUENSOND') {
                    var markerPuls = "otguensondPulse";
                    var markerProp = {
                        className: "otguensondMarker",
                        html: '<div class="otguensondHead"></div>'
                    }
                }
                else if (vehicle[i].ORDSTS == 'OTGUENSOVN') {
                    var markerPuls = "otguensovnPulse";
                    var markerProp = {
                        className: "otguensovnMarker",
                        html: '<div class="otguensovnHead"></div>'
                    }
                }
                else if (vehicle[i].ORDSTS == 'OTGUENSABN') {
                    var markerPuls = "otguensabnPulse";
                    var markerProp = {
                        className: "otguensabnMarker",
                        html: '<div class="otguensabnHead"></div>'
                    }
                }
                var markerIcon = L.divIcon(markerProp);
                if (targetMarker) {
                    L.DomUtil.removeClass(targetMarker._icon, omarkerPuls);
                    otargetMarker = targetMarker;
                }
                omarkerPuls = markerPuls;
                targetMarker = L.marker([vehicle[i].X, vehicle[i].Y], {
                    alt: vehicle[i].REGNO,
                    icon: markerIcon,
                    rotationAngle: vehicle[i].ANGLE,
                    rotationOrigin: "center"
                }).bindTooltip(vehicle[i].REGNO, {
                    permanent: true,
                    className: "markerLabel",
                    offset: [0, 22],
                    direction: "center"
                }).openTooltip();
                targetMarker.addTo(map);
                L.DomUtil.addClass(targetMarker._icon, markerPuls);
                targetMarker.setZIndexOffset(9999);
                map.setView([vehicle[i].X, vehicle[i].Y], 15);
                pcFeaturesSub.SetActiveTabIndex(0);
                $("#orderNumber").html(vehicle[i].ORDERNO);
                $("#originOrder").html("Origin<br>" + vehicle[i].ORIGIN.replace("&", "&#38;"));
                $("#destinOrder").html("Destination<br>" + vehicle[i].DESTIN.replace("&", "&#38;"));
                $("#statusOrder").html(vehicle[i].STATUS);
                setVehicleinfo(vehicle[i]);
                break;
            }
        }
        buildVehicles($("#comboBox_VI").val());
    }
    //*****************************************************************************************************************************
    function onClick(e) {
        getSession();
        my_val = 1;
        if (my_val % 2 != 0) {
            $("div.formholder").animate({ width: 300 }, 500);
            $("#mybutton").animate({ right: 300 }, 500);
        }
        for (var i = 0; i < vehicle.length; i++) {
            if (vehicle[i].REGNO == e.target.options.alt) {
                if (vehicle[i].ORDSTS == 'OFGOENSN') {
                    var markerPuls = "ofgoensnPulse";
                    var markerProp = {
                        className: "ofgoensnMarker",
                        html: '<div class="ofgoensnHead"></div>'
                    }
                }
                else if (vehicle[i].ORDSTS == 'OFGUETSN') {
                    var markerPuls = "ofguetsnPulse";
                    var markerProp = {
                        className: "ofguetsnMarker",
                        html: '<div class="ofguetsnHead"></div>'
                    }
                }
                else if (vehicle[i].ORDSTS == 'OFGUEFSN') {
                    var markerPuls = "ofguefsnPulse";
                    var markerProp = {
                        className: "ofguefsnMarker",
                        html: '<div class="ofguefsnHead"></div>'
                    }
                }
                else if (vehicle[i].ORDSTS == 'OTGDENSN') {
                    var markerPuls = "otgdensnPulse";
                    var markerProp = {
                        className: "otgdensnMarker",
                        html: '<div class="otgdensnHead"></div>'
                    }
                }
                else if (vehicle[i].ORDSTS == 'OTGUEOSOVS') {
                    var markerPuls = "otgueosovsPulse";
                    var markerProp = {
                        className: "otgueosovsMarker",
                        html: '<div class="otgueosovsHead"></div>'
                    }
                }
                else if (vehicle[i].ORDSTS == 'OTGUENSNLD') {
                    var markerPuls = "otguensnldPulse";
                    var markerProp = {
                        className: "otguensnldMarker",
                        html: '<div class="otguensnldHead"></div>'
                    }
                }
                else if (vehicle[i].ORDSTS == 'OTGUENSWTG') {
                    var markerPuls = "otguenswtgPulse";
                    var markerProp = {
                        className: "otguenswtgMarker",
                        html: '<div class="otguenswtgHead"></div>'
                    }
                }
                else if (vehicle[i].ORDSTS == 'OTGUENSOND') {
                    var markerPuls = "otguensondPulse";
                    var markerProp = {
                        className: "otguensondMarker",
                        html: '<div class="otguensondHead"></div>'
                    }
                }
                else if (vehicle[i].ORDSTS == 'OTGUENSOVN') {
                    var markerPuls = "otguensovnPulse";
                    var markerProp = {
                        className: "otguensovnMarker",
                        html: '<div class="otguensovnHead"></div>'
                    }
                }
                else if (vehicle[i].ORDSTS == 'OTGUENSABN') {
                    var markerPuls = "otguensabnPulse";
                    var markerProp = {
                        className: "otguensabnMarker",
                        html: '<div class="otguensabnHead"></div>'
                    }
                }
                var markerIcon = L.divIcon(markerProp);
                if (targetMarker) {
                    L.DomUtil.removeClass(targetMarker._icon, omarkerPuls);
                    otargetMarker = targetMarker;
                }
                omarkerPuls = markerPuls;
                targetMarker = L.marker([vehicle[i].X, vehicle[i].Y], {
                    alt: vehicle[i].REGNO,
                    icon: markerIcon,
                    rotationAngle: vehicle[i].ANGLE,
                    rotationOrigin: "center"
                }).bindTooltip(vehicle[i].REGNO, {
                    permanent: true,
                    className: "markerLabel",
                    offset: [0, 22],
                    direction: "center"
                }).openTooltip();
                targetMarker.addTo(map);
                L.DomUtil.addClass(targetMarker._icon, markerPuls);
               
                $('#pcFeatures_T1').removeClass('dxtc-activeTab');
                $('#pcFeatures_T2').removeClass('dxtc-activeTab');
                $('#pcFeatures_T0').addClass("dxtc-activeTab");
                pcFeatures.SetActiveTabIndex(0);
                pcFeaturesSub.SetActiveTabIndex(0);
                $("#comboBox_I").val(vehicle[i].REGNO);
               
                setVehicleinfo(vehicle[i]);
               break;
            }
        }
        buildVehicles(e.target.options.alt);
    }


    //*****************************************************************************************************************************
    function buildVehicles(exc) {
        $.ajax({
            type: "GET",
            url: "/localVehicle",
            success: function (data) {
                destroyMarker();
                for (var i = 0; i < data.length; i++) {
                    if (data[i].REGNO != exc) {
                        if (data[i].ORDSTS == 'OFGOENSN') {
                            var markerProp = {
                                className: "ofgoensnMarker",
                                html: '<div class="ofgoensnHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OFGUETSN') {
                            var markerProp = {
                                className: "ofguetsnMarker",
                                html: '<div class="ofguetsnHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OFGUEFSN') {
                            var markerProp = {
                                className: "ofguefsnMarker",
                                html: '<div class="ofguefsnHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OTGDENSN') {
                            var markerProp = {
                                className: "otgdensnMarker",
                                html: '<div class="otgdensnHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OTGUEOSOVS') {
                            var markerProp = {
                                className: "otgueosovsMarker",
                                html: '<div class="otgueosovsHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OTGUENSNLD') {
                            var markerProp = {
                                className: "otguensnldMarker",
                                html: '<div class="otguensnldHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OTGUENSWTG') {
                            var markerProp = {
                                className: "otguenswtgMarker",
                                html: '<div class="otguenswtgHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OTGUENSOND') {
                            var markerProp = {
                                className: "otguensondMarker",
                                html: '<div class="otguensondHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OTGUENSOVN') {
                            var markerProp = {
                                className: "otguensovnMarker",
                                html: '<div class="otguensovnHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OTGUENSABN') {
                            var markerProp = {
                                className: "otguensabnMarker",
                                html: '<div class="otguensabnHead"></div>'
                            }
                        }
                        var markerIcon = L.divIcon(markerProp);
                        marker[i] = L.marker([data[i].X, data[i].Y], {
                            alt: data[i].REGNO,
                            icon: markerIcon,
                            rotationAngle: data[i].ANGLE,
                            rotationOrigin: "center"
                        }).bindTooltip(data[i].REGNO, {
                            permanent: true,
                            className: "markerLabel",
                            offset: [0, 22],
                            direction: "center"
                        }).openTooltip();
                        marker[i].on('click', onClick);
                        markerCluster.addLayer(marker[i]);
                    }
                }
                map.addLayer(markerCluster);
            }
        });
    }

//*****************************************************************************************************************************
    function updateData() {
        getSession();
        $.ajax({
            type: "GET",
            url: "Maps/getData",
            success: function (data) {
                //if (data.length == 0) {
                  
                //    window.location.href = 'Login';
                //}
                vehicle = data;
                updateChart();

                if ($("#comboBox_I").val() == "") {
                    destroyMarker();
                    for (var i = 0; i < data.length; i++) {
                        if (data[i].ORDSTS == 'OFGOENSN') {
                            var markerProp = {
                                className: "ofgoensnMarker",
                                html: '<div class="ofgoensnHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OFGUETSN') {
                            var markerProp = {
                                className: "ofguetsnMarker",
                                html: '<div class="ofguetsnHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OFGUEFSN') {
                            var markerProp = {
                                className: "ofguefsnMarker",
                                html: '<div class="ofguefsnHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OTGDENSN') {
                            var markerProp = {
                                className: "otgdensnMarker",
                                html: '<div class="otgdensnHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OTGUEOSOVS') {
                            var markerProp = {
                                className: "otgueosovsMarker",
                                html: '<div class="otgueosovsHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OTGUENSNLD') {
                            var markerProp = {
                                className: "otguensnldMarker",
                                html: '<div class="otguensnldHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OTGUENSWTG') {
                            var markerProp = {
                                className: "otguenswtgMarker",
                                html: '<div class="otguenswtgHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OTGUENSOND') {
                            var markerProp = {
                                className: "otguensondMarker",
                                html: '<div class="otguensondHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OTGUENSOVN') {
                            var markerProp = {
                                className: "otguensovnMarker",
                                html: '<div class="otguensovnHead"></div>'
                            }
                        }
                        else if (data[i].ORDSTS == 'OTGUENSABN') {
                            var markerProp = {
                                className: "otguensabnMarker",
                                html: '<div class="otguensabnHead"></div>'
                            }
                        }
                        var markerIcon = L.divIcon(markerProp);
                        marker[i] = L.marker([data[i].X, data[i].Y], {
                            alt: data[i].REGNO,
                            icon: markerIcon,
                            rotationAngle: data[i].ANGLE,
                            rotationOrigin: "center"
                        }).bindTooltip(data[i].REGNO, {
                            permanent: true,
                            className: "markerLabel",
                            offset: [0, 22],
                            direction: "center"
                        }).openTooltip();
                        marker[i].on('click', onClick);
                        markerCluster.addLayer(marker[i]);
                    }
                    map.addLayer(markerCluster);
                }
                else {
                    for (var i = 0; i < data.length; i++) {
                        if (data[i].REGNO == $("#comboBox_I").val()) {
                            if (data[i].ORDSTS == 'OFGOENSN') {
                                var markerPuls = "ofgoensnPulse";
                                var markerProp = {
                                    className: "ofgoensnMarker",
                                    html: '<div class="ofgoensnHead"></div>'
                                }
                            }
                            else if (data[i].ORDSTS == 'OFGUETSN') {
                                var markerPuls = "ofguetsnPulse";
                                var markerProp = {
                                    className: "ofguetsnMarker",
                                    html: '<div class="ofguetsnHead"></div>'
                                }
                            }
                            else if (data[i].ORDSTS == 'OFGUEFSN') {
                                var markerPuls = "ofguefsnPulse";
                                var markerProp = {
                                    className: "ofguefsnMarker",
                                    html: '<div class="ofguefsnHead"></div>'
                                }
                            }
                            else if (data[i].ORDSTS == 'OTGDENSN') {
                                var markerPuls = "otgdensnPulse";
                                var markerProp = {
                                    className: "otgdensnMarker",
                                    html: '<div class="otgdensnHead"></div>'
                                }
                            }
                            else if (data[i].ORDSTS == 'OTGUEOSOVS') {
                                var markerPuls = "otgueosovsPulse";
                                var markerProp = {
                                    className: "otgueosovsMarker",
                                    html: '<div class="otgueosovsHead"></div>'
                                }
                            }
                            else if (data[i].ORDSTS == 'OTGUENSNLD') {
                                var markerPuls = "otguensnldPulse";
                                var markerProp = {
                                    className: "otguensnldMarker",
                                    html: '<div class="otguensnldHead"></div>'
                                }
                            }
                            else if (data[i].ORDSTS == 'OTGUENSWTG') {
                                var markerPuls = "otguenswtgPulse";
                                var markerProp = {
                                    className: "otguenswtgMarker",
                                    html: '<div class="otguenswtgHead"></div>'
                                }
                            }
                            else if (data[i].ORDSTS == 'OTGUENSOND') {
                                var markerPuls = "otguensondPulse";
                                var markerProp = {
                                    className: "otguensondMarker",
                                    html: '<div class="otguensondHead"></div>'
                                }
                            }
                            else if (data[i].ORDSTS == 'OTGUENSOVN') {
                                var markerPuls = "otguensovnPulse";
                                var markerProp = {
                                    className: "otguensovnMarker",
                                    html: '<div class="otguensovnHead"></div>'
                                }
                            }
                            else if (data[i].ORDSTS == 'OTGUENSABN') {
                                var markerPuls = "otguensabnPulse";
                                var markerProp = {
                                    className: "otguensabnMarker",
                                    html: '<div class="otguensabnHead"></div>'
                                }
                            }
                            var markerIcon = L.divIcon(markerProp);
                            if (targetMarker) {
                                map.removeLayer(targetMarker);
                            }
                            omarkerPuls = markerPuls;
                            targetMarker = L.marker([data[i].X, data[i].Y], {
                                alt: data[i].REGNO,
                                icon: markerIcon,
                                rotationAngle: data[i].ANGLE,
                                rotationOrigin: "center"
                            }).bindTooltip(data[i].REGNO, {
                                permanent: true,
                                className: "markerLabel",
                                offset: [0, 22],
                                direction: "center"
                            }).openTooltip();
                            targetMarker.addTo(map);
                            L.DomUtil.addClass(targetMarker._icon, markerPuls);
                            targetMarker.setZIndexOffset(9999);
                            $("#orderNumber").html(data[i].ORDERNO);
                            $("#originOrder").html("Origin<br>" + data[i].ORIGIN.replace("&", "&#38;"));
                            $("#destinOrder").html("Destination<br>" + data[i].DESTIN.replace("&", "&#38;"));
                            $("#statusOrder").html(data[i].STATUS);
                            setVehicleinfo(data[i]);
                            break;
                        }
                    }
                    buildVehicles($("#comboBox_VI").val());
                }
            }
        });
    }
    //*****************************************************************************************************************************
    function setVehicleinfo(data) {
      
        var n = new Date(parseInt(data.LASTUPDATE.substr(6)));
        var d = ("0" + n.getDate()).slice(-2) + "/" + ("0" + (n.getMonth() + 1)).slice(-2) + "/" + n.getFullYear();
        var t = ("0" + n.getHours()).slice(-2) + ":" + ("0" + n.getMinutes()).slice(-2);
        var lastupdate = d + " " + t;
        var engine;
        var powersource = "Accu";
        var input1 = data.I01VALUE;
        var input2 = data.I02VALUE;
        var input3 = data.I03VALUE;
        var input4 = data.I04VALUE;
        var labelinput1, labelinput2, labelinput3, labelinput4, lblsuhu1, lblsuhu2;
        engine = "";
        if (data.IO1KEY == 'Engine') {
            engine = data.IO1VALUE;
        } else if (data.IO2KEY == 'Engine') {
            engine = data.IO2VALUE;
        } else if (data.IO3KEY == 'Engine') {
            engine = data.IO3VALUE;
        } else if (data.IO4KEY == 'Engine') {
            engine = data.IO4VALUE;
        }
        var suhu1 = Math.round(data.SUHU1);
        var suhu2 = Math.round(data.SUHU2);
        if (data.IO1 == true) engine = engine;
        if (data.PWR < 9) powersource = "Battery";
        labelinput1 = data.IO1KEY;
        input1 = data.IO1VALUE;
        labelinput2 = data.IO2KEY;
        input2 = data.IO2VALUE;
        labelinput3 = data.IO3KEY;
        input3 = data.IO3VALUE;
        labelinput4 = data.IO4KEY;
        input4 = data.IO4VALUE;

       

        if(data.SUHU1 == 2000 || data.SUHU1 == 2003){
            suhu1 = "No Sensor";
        }else if (data.SUHU1 == 850 || data.SUHU1 == 2001 ||  data.SUHU1 == 2002 || data.SUHU1 == 2004 ){
            suhu1 = "Error"
        }else{
            suhu1 = data.SUHU1;
        }

        if (data.SUHU2 == 2000 || data.SUHU2 == 2003) {
            suhu2 = "No Sensor";
        } else if (data.SUHU2 == 850 || data.SUHU2 == 2001 || data.SUHU2 == 2002 || data.SUHU2 == 2004) {
            suhu2 = "Error"
        } else {
            suhu2 = data.SUHU2;
        }
      
            lblsuhu1 = data.SUHU1KEY;
   
            lblsuhu2 = data.SUHU2KEY;
      
        $("#streetName").html(data.LOC + "<br>(" + data.POLYGON + ")");
        $("#vehicleNumber").html(data.REGNO);
        $("#gsmNumber").html(data.GSMNO);
        $("#lastUpdate").html(lastupdate);
        $("#position").html((data.X).toFixed(7) + ", " + (data.Y).toFixed(7));
        $("#engine").html(engine);
        $("#speed").html(data.SPEED);
        $("#direction").html(Math.round(data.ANGLE));
        $("#odometer").html(Math.round(data.ODO));
        $("#powerSource").html(powersource);
        $("#valinput1").html(input1);
        $("#input1").html(labelinput1);
        $("#valinput2").html(input2);
        $("#input2").html(labelinput2);
        $("#valinput3").html(input3);
        $("#input3").html(labelinput3);
        $("#valinput4").html(input4);
        $("#input4").html(labelinput4);
        $("#valtemp1").html(suhu1);
        $("#temp1").html(lblsuhu1);
        $("#valtemp2").html(suhu2);
        $("#temp2").html(lblsuhu2);
        $("#orderNumber").html(data.ORDERNO);
        $("#originOrder").html("Origin<br>" + data.ORIGIN.replace("&", "&#38;"));
        $("#destinOrder").html("Destination<br>" + data.DESTIN.replace("&", "&#38;"));
        $("#statusOrder").html(data.STATUS);

    }

    //*****************************************************************************************************************************

    function destroyMarker() {
        if (otargetMarker) map.removeLayer(otargetMarker);
        markerCluster.clearLayers();
    }
    //*****************************************************************************************************************************
// Fungsi Draw Geofence
   

    function getGeofencesInfo() {
        getSession();
        var geoName = comboBoxGeo.GetValue();
        $.ajax({
            type: "POST",
            url: "Maps/getGeofencesInfo",
            data:{GEONAME : geoName},
            success: function (data) {
                if (data) {
                    dataEditGeo = data;
                    var geoGeoms = data[0].GEOFENCE_POINT;
                    var geoSubstr = geoGeoms.substring(7, geoGeoms.length - 1);
                    var geoCoord = geoSubstr.split(" ");
                    var geoLat = parseFloat(geoCoord[1]);
                    var geoLon = parseFloat(geoCoord[0]);
                    map.setView([geoLat, geoLon], 17);
                    if (data[0].GEOFENCE_TYPE == "FTY") {
                        var geoType = "Factory";
                    }
                    else if (data[0].GEOFENCE_TYPE == "OFC") {
                        var geoType = "Office";
                    }
                    else if (data[0].GEOFENCE_TYPE == "LDG") {
                        var geoType = "Loading";
                    }
                    else if (data[0].GEOFENCE_TYPE == "ULD") {
                        var geoType = "Unloading";
                    }
                    else if (data[0].GEOFENCE_TYPE == "OTH") {
                        var geoType = "Other";
                    }
                    else if (data[0].GEOFENCE_TYPE == "QUE") {
                        var geoType = "Queueing";
                    }
                    else if (data[0].GEOFENCE_TYPE == "WHS") {
                        var geoType = "Warehouse";
                    }
                    $("#geofenceName").html(data[0].GEOFENCE_NAME);
                    $("#geofenceCode").html(data[0].GEOFENCE_CODE);
                    $("#geofenceType").html(geoType);
                    $("#geofenceSpeed").html(Math.round(data[0].GEOFENCE_SPEED));
                    var geomText =data[0].GEOFENCE_GEOM;
                    geomText.replace(/,/g, ', ');
                    setGeofence = geomText;
                    GEO_NAME = data[0].GEOFENCE_NAME;
                    btnEdit.SetEnabled(true);
                }
                else {
                    alert("Sorry, some kind of error has occurred");
                }
            }
    });
    }



    //*****************************************************************************************************************************
    linePanel = new Highcharts.chart('historyLine', {
        chart: {
            zoomType: 'x'
        },
        exporting: {
            enabled: false
        },
        title: {
            text: null
        },
        credits: {
            enabled: false
        },
        tooltip: {
            pointFormat: '{point.y} Km/h'
        },
        xAxis: {
            type: 'datetime',
            plotLines: [{
                color: 'orange',
                width: 1,
                value: 0,
                zIndex: 5
            }]
        },
        plotOptions: {
            area: {
                fillColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                    stops: [
                      [0, Highcharts.getOptions().colors[0]],
                      [1, Highcharts.color(Highcharts.getOptions().colors[0]).setOpacity(0).get('rgba')]
                    ]
                },
                marker: {
                    radius: 2
                },
                lineWidth: 1,
                states: {
                    hover: {
                        lineWidth: 1
                    }
                },
                threshold: null
            },
            series: {
                cursor: 'pointer',
                point: {
                    events: {
                        click: function (e) {
                            posCount = e.point.index;
                            if (!playTimer) {
                                playback();
                            }

                        },
                        onContainerClick: function (e) {

                            console.log(e);
                        }
                    }
                }
            }
        },
        yAxis: {
            title: {
                text: "Speed"
            }
        },
        series: [{
            showInLegend: false,
            type: 'area',
            data: 0,
            name: "Speed"
        }],
    });


//  ========================================SCRIPT DESTINATION POPUP==============================================================
    function convertHMS(value) {
        const sec = parseInt(value, 10); // convert value to number if it's string
        let hours = Math.floor(sec / 3600); // get hours
        let minutes = Math.floor((sec - (hours * 3600)) / 60); // get minutes
        let seconds = sec - (hours * 3600) - (minutes * 60); //  get seconds
        // add 0 if value < 10; Example: 2 => 02
        if (hours < 10) { hours = "0" + hours; }
        if (minutes < 10) { minutes = "0" + minutes; }
        if (seconds < 10) { seconds = "0" + seconds; }

        return hours + ":" + minutes + ":" + seconds;
    }

    $('#getDirection').click(function () {
        getSession();
        $('#pcModalHistory_HCB-1').hide();
        pcModalDirection.Show();

        $('#CoordinateStart').css('display', 'none');
        $('#CoordinateDestination').css('display', 'none');
        $('#comboBoxGeoForDerectionStart').css('display', 'none');
        $('#comboBoxGeoForDerectionDest').css('display', 'none');

    });

    function RouteBy()
    {
        var RouteByValue = cmbRouteBy.GetValue();
        if (RouteByValue == "Geofence") {
            $('#comboBoxGeoForDerectionStart').css('marginTop', '10px');
            $('#CoordinateStart').css('display', 'none');
            $('#CoordinateDestination').css('display', 'none');
            $('#comboBoxGeoForDerectionStart').css('display', 'block');
            $('#comboBoxGeoForDerectionDest').css('display', 'block');
            $('#tdcomboBoxGeoForDerectionStart').css('padding', '5px');
            $('#tdcomboBoxGeoForDerectionDest').css('padding', '5px');
            $('#tdCoordinateStart').css('padding', '0px');
            $('#tdCoordinateDestination').css('padding', '0px');
        }

        else if (RouteByValue == "Coordinate") {
            $('#comboBoxGeoForDerectionStart').css('display', 'none');
            $('#comboBoxGeoForDerectionDest').css('display', 'none');
            $('#CoordinateStart').css('display', 'block');
            $('#CoordinateDestination').css('display', 'block');
            $('#CoordinateStart').css('marginTop', '10px');
            $('#tdcomboBoxGeoForDerectionStart').css('padding', '0px');
            $('#tdcomboBoxGeoForDerectionDest').css('padding', '0px');
            $('#tdCoordinateStart').css('padding', '5px');
            $('#tdCoordinateDestination').css('padding', '5px');
        }

        else {
            $('#CoordinateStart').css('display', 'none');
            $('#CoordinateDestination').css('display', 'none');
            $('#comboBoxGeoForDerectionStart').css('display', 'none');
            $('#comboBoxGeoForDerectionDest').css('display', 'none');
        }

        return RouteByValue;
    }


    function CloseDirection(s, e) {
        pcModalDirection.Hide();
        if (PointsMarkersLayer) {
            map.removeLayer(PointsMarkersLayer);
        }
        if (LinemarkersLayer) {
            map.removeLayer(LinemarkersLayer);
        }
        
        if (StepsMarkersLayer) {
            map.removeLayer(StepsMarkersLayer);
        }

    }


    function RotesDirection() 
    {
        
        if (LinemarkersLayer) {
            map.removeLayer(LinemarkersLayer);
        }  

        if (PointsMarkersLayer) {
            map.removeLayer(PointsMarkersLayer);
        }

        if (StepsMarkersLayer) {
            map.removeLayer(StepsMarkersLayer);
        }


        var routeMethod = RouteBy();
        var latLongStart, latLongDest;
        var strLat, strLong, DesLat, DesLong;        
        var routeLine = [];
        var stepsDot = [];
        var Points;
        var StepsIcon = L.divIcon({ className: "instructionMark" });
        var greenIcon = new L.Icon({
            iconUrl: 'https://raw.githubusercontent.com/pointhi/leaflet-color-markers/master/img/marker-icon-2x-green.png',
            shadowUrl: 'https://cdnjs.cloudflare.com/ajax/libs/leaflet/0.7.7/images/marker-shadow.png',
            iconSize: [25, 41],
            iconAnchor: [12, 41],
            popupAnchor: [1, -34],
            shadowSize: [41, 41]
        });
        var DestMarkerCaption;
        var OriginMarkerCaption
        var lastDistance = 0;
        var lastDuration = 0;
        var stepsLocation;
        var stepsName;
        PointsMarkersLayer = new L.LayerGroup().addTo(map);
        LinemarkersLayer = new L.LayerGroup().addTo(map);
        StepsMarkersLayer = new L.LayerGroup().addTo(map);

        if (routeMethod == "Geofence")
        {
            latLongStart = comboBoxGeoForDerectionStart.GetValue().slice(7,-1);
            latLongDest = comboBoxGeoForDerectionDest.GetValue().slice(7, -1);
            var strGeoName = comboBoxGeoForDerectionStart.GetText();
            var destGeoName = comboBoxGeoForDerectionDest.GetText();

            strLat = latLongStart.split(" ")[1];
            strLong = latLongStart.split(" ")[0];
            DesLat = latLongDest.split(" ")[1];
            DesLong = latLongDest.split(" ")[0];

            OriginMarkerCaption = strGeoName;
            DestMarkerCaption = destGeoName;

        }

        else if (routeMethod == "Coordinate")
        {
            latLongStart = CoordinateStart.GetValue();
            latLongDest = CoordinateDestination.GetValue();

            strLat = latLongStart.split(",")[0];
            strLong = latLongStart.split(",")[1];
            DesLat = latLongDest.split(",")[0];
            DesLong = latLongDest.split(",")[1];
            OriginMarkerCaption=latLongStart;
            DestMarkerCaption = latLongDest;

        }

        if (latLongStart == latLongDest)
        {
            alert("Your input data is duplicated.")
        }
        else
        {
            $.ajax({
                type: "GET",
                url: "https://api.mapbox.com/directions/v5/mapbox/driving/" + strLong + "," + strLat + ";" + DesLong + "," + DesLat + "?access_token=pk.eyJ1Ijoic2Vpbm9rYWhmaSIsImEiOiJja285aWY5NHcwNHlyMm9xbWY3ZWhlcm0wIn0.kUzmIB4Vzg0A9XKE6O1ipA&geometries=geojson&steps=true",
                success: function (data) {
                    DataAllStep = data;

                    PointsMarkersLayer.addLayer(L.marker([strLat, strLong]))
                    console.log(data);
                    var distances = data.routes[0].legs[0].distance / 1000;
                    var duration = data.routes[0].legs[0].duration;

                    lengStepData = data.routes[0].legs[0].steps.length - 1;
                    for (y = 0 ; y < lengStepData; y++) {
                        lengRouteData = data.routes[0].legs[0].steps[y].geometry.coordinates.length - 1;
                        for (z = 0; z < lengRouteData; z++) {
                            let a = data.routes[0].legs[0].steps[y].geometry.coordinates[z][1];
                            let b = data.routes[0].legs[0].steps[y].geometry.coordinates[z][0];
                            let e = data.routes[0].legs[0].steps[y].geometry.coordinates[z + 1][1];
                            let f = data.routes[0].legs[0].steps[y].geometry.coordinates[z + 1][0];
                            routeLine[z] = L.polyline([[a, b], [e, f]], { color: "red", weight: 5 });
                            LinemarkersLayer.addLayer(routeLine[z]);
                        }

                        stepsLocation = data.routes[0].legs[0].steps[y].maneuver.location;
                        lastDistance = lastDistance + (data.routes[0].legs[0].steps[y].distance / 1000);
                        lastDuration = lastDuration + data.routes[0].legs[0].steps[y].duration;
                        leftDistance = distances - lastDistance;
                        leftDuration = duration - lastDuration;
                        stepsName = data.routes[0].legs[0].steps[y].name;
                        if (stepsName == "") {
                            stepsName = "---";
                        }

                        stepsDot[y] = L.marker([stepsLocation[1], stepsLocation[0]], { icon: StepsIcon });
                        stepsDot[y].bindTooltip(stepsName +
                                                "<br> Distance: " + lastDistance.toFixed(3) + " Km <br> Duration: "
                                                + convertHMS(lastDuration)).openTooltip();

                        StepsMarkersLayer.addLayer(stepsDot[y]);
                    }

                    PointsMarkersLayer.addLayer(L.marker([DesLat, DesLong], { icon: greenIcon }));
                    let destmarker = PointsMarkersLayer._layers[Object.keys(PointsMarkersLayer._layers)[1]];
                    let Originmarker = PointsMarkersLayer._layers[Object.keys(PointsMarkersLayer._layers)[0]];

                    destmarker.bindTooltip(DestMarkerCaption + "<br>Total Distance: " + distances.toFixed(3) + " Km <br>" + " Total Duration: " + convertHMS(duration), { permanent: true }).openTooltip();
                    Originmarker.bindTooltip(OriginMarkerCaption, { permanent: true }).openTooltip();
                    map.fitBounds([[strLat, strLong], [DesLat, DesLong]]);
                }

            });

        }
      
       
    }

//  ========================================end SCRIPT DESTINATION POPUP==============================================================



        //*****************************************************************************************************************************
        $('#getPlayback').click(function () {
            getSession();
            $('#pcModalHistory_HCB-1').hide();
            pcModalHistory.Show();
        
        });
        //*****************************************************************************************************************************
        function getPlayHistory() {
            var datasubstract;
       
            var minimticks;
            var fromDate = new Date(dateEditFrom.GetText());
            var toDate = new Date(dateEditTo.GetText());
            if (fromDate > toDate) {
                alert("Sorry, entered the correct time period");
            } else {
                var diffTime = Math.abs(toDate - fromDate);
                var diffDays = Math.ceil((diffTime * 1e-3) / 86400);
                if (diffDays > 7) {
                    alert("Sorry, maximum date range is 7 days");
                } else {
                    $("#streetName").empty();
                    $("#vehicleNumber").empty();
                    $("#vehicleType").empty();
                    $("#gsmNumber").empty();
                    $("#lastUpdate").empty();
                    $("#position").empty();
                    $("#engine").empty();
                    $("#speed").empty();
                    $("#direction").empty();
                    $("#odometer").empty();
                    $("#powerSource").empty();
                    $("#valinput1").empty();
                    $("#input1").html("Input 1"); //<div id="input1">Input 1</div> 
                    $("#valinput2").empty();
                    $("#input2").html("Input 2");
                    $("#valinput3").empty();
                    $("#input3").html("Input 3");
                    $("#valinput4").empty();
                    $("#input4").html("Input 4");
                    $("#valtemp1").empty();
                    $("#temp1").html("Temp 1");
                    $("#valtemp2").empty();
                    $("#temp2").html("Temp 2");
                    $("#orderNumber").empty();
                    $("#originOrder").empty();
                    $("#destinOrder").empty();
                    $("#statusOrder").empty();
                    $('#historyLine').empty();
                    linePanel = null;

                    //if (!$("#sidebar-wrapper").is(":hidden")) $("#sidebar-wrapper").hide();
                    //$("#historyPanel").dialog("open");
                    $.ajax({
                        type: "POST",
                        url: 'Maps/getWaypointInfo',
                        data: { VEHICLE_SID: cmbVehicleHistory.GetValue(), FROM_DATE: dateEditFrom.GetText(), TO_DATE: dateEditTo.GetText() },
                        beforeSend:function(){
                            CallbackPanel.PerformCallback();
                            linePanel;
                            leftPanel.SetVisible(false);
                        },
                        success: function (data) {
                       
                            if (updateTimer) {
                                clearInterval(updateTimer);
                                updateTimer = false;
                            }
                            if (targetMarker) map.removeLayer(targetMarker);
                            destroyMarker();
                            if (engineCluster) engineCluster.clearLayers();
                            if (accuCluster) accuCluster.clearLayers();
                            if (pathLine) {
                                for (var i = 0; i < pathLine.length; i++) {
                                    map.removeLayer(pathLine[i]);
                                }
                            }
                            $("#btnPlay").show();
                            if (data.length > 0) {
                                my_val = 1;

                                if (my_val % 2 != 0) {
                                    $("div.formholder").animate({ width: 300 }, 500);
                                    $("#mybutton").animate({ right: 300 }, 500);

                                }
                                playbackData = data;
                                engineCluster = new L.markerClusterGroup({
                                    showCoverageOnHover: false,
                                    iconCreateFunction: function (cluster) {
                                        return L.divIcon({
                                            className: "hexagon",
                                            html: '<div class="hexContent">' + cluster.getChildCount() + '</div>'
                                        });
                                    }
                                });

                                accuCluster = new L.markerClusterGroup({
                                    showCoverageOnHover: false,
                                    iconCreateFunction: function (cluster) {
                                        return L.divIcon({
                                            className: "hexagon",
                                            html: '<div class="hexContent">' + cluster.getChildCount() + '</div>'
                                        });
                                    }
                                });

                                engineMarker = [];
                                accuMarker = [];
                                var dsHistory = [];
                                var dtTrigger = [];
                                for (var i = 0; i < data.length - 1; i++) {
                                    var a = data[i].WP_LAT;
                                    var b = data[i].WP_LON;
                                    var x = data[i + 1].WP_LAT;
                                    var y = data[i + 1].WP_LON;
                                    if (data[i + 1].WP_SPEED <= 10) {
                                        var colorLine = "Black";
                                    } else if (data[i + 1].WP_SPEED > 10 && data[i + 1].WP_SPEED <= 20) {
                                        var colorLine = "Red";
                                    } else if (data[i + 1].WP_SPEED > 20 && data[i + 1].WP_SPEED <= 40) {
                                        var colorLine = "Blue";
                                    } else if (data[i + 1].WP_SPEED > 40 && data[i + 1].WP_SPEED <= 60) {
                                        var colorLine = "Purple";
                                    } else if (data[i + 1].WP_SPEED > 60 && data[i + 1].WP_SPEED <= 80) {
                                        var colorLine = "Green";
                                    } else if (data[i + 1].WP_SPEED > 80) {
                                        var colorLine = "Yellow";
                                    }
                                    pathLine[i] = L.polyline([[a, b], [x, y]], { color: colorLine, weight: 4, index: (i + 1) }).addTo(map);
                                    pathLine[i].on('click', lineClick);

                                    if (data[i].WP_IO1 == false && data[i + 1].WP_IO1 == true) {
                                        var n = new Date(parseInt(data[i].WP_TIME.substr(6)));
                                        var d = ("0" + n.getDate()).slice(-2) + "/" + ("0" + (n.getMonth() + 1)).slice(-2) + "/" + n.getFullYear();
                                        var t = ("0" + n.getHours()).slice(-2) + ":" + ("0" + n.getMinutes()).slice(-2) + ":" + ("0" + n.getSeconds()).slice(-2);
                                        var engposTime = d + " " + t;
                                        var engineInfo = engposTime + " <b>Engine ON</b><br>" + data[i].LOC ;
                                        var engineIcon = L.divIcon({
                                            className: "engonMarker",
                                            html: '<i class="fa fa-key">'
                                        });
                                        engineMarker[i] = L.marker([x, y], {
                                            icon: engineIcon
                                        });
                                        engineMarker[i].bindPopup(engineInfo, {
                                            "className": "engineLabel"
                                        });
                                        engineCluster.addLayer(engineMarker[i]);
                                    }
                                    else if (data[i].WP_IO1 == true && data[i + 1].WP_IO1 == false) {
                                        var n = new Date(parseInt(data[i].WP_TIME.substr(6)));
                                        var d = ("0" + n.getDate()).slice(-2) + "/" + ("0" + (n.getMonth() + 1)).slice(-2) + "/" + n.getFullYear();
                                        var t = ("0" + n.getHours()).slice(-2) + ":" + ("0" + n.getMinutes()).slice(-2) + ":" + ("0" + n.getSeconds()).slice(-2);
                                        var engposTime = d + " " + t;
                                        var engineInfo = engposTime + " <b>Engine OFF</b><br>" + data[i].LOC;
                                        var engineIcon = L.divIcon({
                                            className: "engofMarker",
                                            html: '<i class="fa fa-key">'
                                        });
                                        engineMarker[i] = L.marker([x, y], {
                                            icon: engineIcon
                                        });
                                        engineMarker[i].bindPopup(engineInfo, {
                                            "className": "engineLabel"
                                        });
                                        engineCluster.addLayer(engineMarker[i]);
                                    }

                                    if (data[i].PWR > 8 && data[i + 1].PWR <= 8) {
                                        var n = new Date(parseInt(data[i].WP_TIME.substr(6)));
                                        var d = ("0" + n.getDate()).slice(-2) + "/" + ("0" + (n.getMonth() + 1)).slice(-2) + "/" + n.getFullYear();
                                        var t = ("0" + n.getHours()).slice(-2) + ":" + ("0" + n.getMinutes()).slice(-2) + ":" + ("0" + n.getSeconds()).slice(-2);
                                        var engposTime = d + " " + t;
                                        var accuInfo = engposTime + " <b>Battery ON</b><br>" + data[i].LOC;
                                        var accuIcon = L.divIcon({
                                            className: "accuGreen",
                                            html: '<i class="fa fa-battery-three-quarters">'
                                        });
                                        accuMarker[i] = L.marker([x, y], {
                                            icon: accuIcon
                                        });
                                        accuMarker[i].bindPopup(accuInfo, {
                                            "className": "accuLabel"
                                        });
                                        accuCluster.addLayer(accuMarker[i]);
                                    }
                                    else if (data[i].PWR <= 8 && data[i + 1].PWR > 8) {
                                        var n = new Date(parseInt(data[i].WP_TIME.substr(6)));
                                        var d = ("0" + n.getDate()).slice(-2) + "/" + ("0" + (n.getMonth() + 1)).slice(-2) + "/" + n.getFullYear();
                                        var t = ("0" + n.getHours()).slice(-2) + ":" + ("0" + n.getMinutes()).slice(-2) + ":" + ("0" + n.getSeconds()).slice(-2);
                                        var engposTime = d + " " + t;
                                        var accuInfo = engposTime + " <b>Battery OFF</b><br>" + data[i].LOC;
                                        var accuIcon = L.divIcon({
                                            className: "accuRed",
                                            html: '<i class="fa fa-battery-three-quarters">'
                                        });
                                        accuMarker[i] = L.marker([x, y], {
                                            icon: accuIcon
                                        });
                                        accuMarker[i].bindPopup(accuIcon, {
                                            "className": "accuLabel"
                                        });
                                        accuCluster.addLayer(accuMarker[i]);
                                    }


                                    var n = new Date(parseInt(data[i].WP_TIME.substr(6)));
                                    var wptime = n.getTime() - ((n.getTimezoneOffset() * 60) * 1e3);
                                    dsHistory.push([wptime, data[i].WP_SPEED]);
                                    dtTrigger.push(n);
                              
                                }
                                map.addLayer(engineCluster);
                                map.addLayer(accuCluster);
                                var markerProp = {
                                    className: "vehicleloMarker",
                                    html: '<div class="vehicleloHead"></div>'
                                }
                                if (data[0].WP_IO1 == true) {
                                    markerProp = {
                                        className: "vehiclehiMarker",
                                        html: '<div class="vehiclehiHead"></div>'
                                    }
                                }
                                var markerIcon = L.divIcon(markerProp);
                                targetMarker = L.marker([data[0].WP_LAT, data[0].WP_LON], {
                                    icon: markerIcon,
                                    rotationAngle: data[0].ANGLE,
                                    rotationOrigin: "center"
                                }).bindTooltip(data[i].REGNO, {
                                    permanent: true,
                                    className: "markerLabel",
                                    offset: [0, 22],
                                    direction: "center"
                                }).openTooltip();
                                targetMarker.addTo(map);
                                targetMarker.setZIndexOffset(9999);
                                map.setView([data[0].WP_LAT, data[0].WP_LON], 15);
                           
                                pcFeatures.SetActiveTabIndex(0);
                                pcFeaturesSub.SetActiveTabIndex(0);
                                $("#comboBox_I").val(data[0].REGNO);
                                $("#cmbVehicleHistory_I").val(data[0].REGNO);
                                setWaypointinfo(data[0]);
                                $("#orderNumber").empty();
                                $("#originOrder").empty();
                                $("#destinOrder").empty();
                                $("#statusOrder").empty();
                          
                                linePanel = new Highcharts.chart('historyLine', {
                                    chart: {
                                        zoomType: 'x',
                                        events: {
                                            click: function (event) {
                                                var minim = null;
                                                for (var x = 0; x < linePanel.series[0].data.length; x++) {
                                                    datasubstract = Math.abs(linePanel.series[0].data[x].category - event.xAxis[0].value );
                                                    if (minim == null) {
                                                        minim = datasubstract;
                                                        minimticks = linePanel.series[0].data[x].index;
                                                    } else if (minim > datasubstract) {
                                                        minim = datasubstract;
                                                        minimticks = linePanel.series[0].data[x].index;
                                                    }
                                                }
                                                posCount =  minimticks;
                                                if (!playTimer) {
                                                    playback();
                                                }
                                            }
                                        }
                                    },
                                    exporting: {
                                        enabled: false
                                    },
                                    title: {
                                        text: null
                                    },
                                    credits: {
                                        enabled: false
                                    },
                                    tooltip: {
                                        pointFormat: '{point.y} Km/h'
                                    },
                                    xAxis: {
                                        type: 'datetime',
                                  
                                        plotLines: [{
                                            color: 'orange',
                                            width: 1,
                                            value: dsHistory[0][0],
                                            zIndex: 5,
                                            id:'plotplayback'
                                        }]
                                    },
                                    plotOptions: {
                                        area: {
                                            fillColor: {
                                                linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                                stops: [
                                                  [0, Highcharts.getOptions().colors[0]],
                                                  [1, Highcharts.color(Highcharts.getOptions().colors[0]).setOpacity(0).get('rgba')]
                                                ]
                                            },
                                            marker: {
                                                radius: 2
                                            },
                                            lineWidth: 1,
                                            states: {
                                                hover: {
                                                    lineWidth: 1
                                                }
                                            },
                                            threshold: null
                                        },
                                        series: {
                                            cursor: 'pointer',
                                            point: {
                                                events: {
                                                    click: function (e) {
                                                        //  alert('x: ' + e.point.x + ', y: ' + e.point.y);
                                                  
                                                        posCount = e.point.index;
                                                        if (!playTimer) {
                                                            playback();
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    },
                                    yAxis: {
                                        title: {
                                            text: "Speed"
                                        }
                                    },
                                    series: [{
                                        showInLegend: false,
                                        type: 'area',
                                        data: dsHistory,
                                        name: "Speed"
                                    }],
                                });
                                $("#comboBox_VI").prop("disabled", true);
                                posCount = 0;
                                $('#slider').show();
                                if (posCount == 0) {
                                    $('#btnBackward').prop('disabled', true);
                                }
                                $('#slider').slider({
                                    value: 0,
                                    step: 1,
                                    min: 0,
                                    max: playbackData.length - 1,
                                    slide: function (event, ui) {
                                  
                                        if (playTimer) {
                                            clearInterval(playTimer);
                                            playTimer = false;
                                            $("#btnPause").hide();
                                            $("#btnPlay").show();
                                        }
                                        posCount = ui.value;
                                        playback();
                                    }
                                });
                            } else {
                                $("#historyLine").html("Sorry, no historical data");
                                $('#slider').show();
                                $('#slider').slider({
                                    value: 0,
                                    min: 0,
                                    max: 0,
                                });

                            }


                       
                        }

                    });
                }
           

            }
            

        }
        //*****************************************************************************************************************************
  
        function closeHistory(s, e) {
     
            if (playbackData == null || playbackData == undefined) {
                pcModalHistory.Hide();
            } else if (playbackData) {
                pcModalHistory.Hide();
                if (targetMarker) {
                    map.removeLayer(targetMarker);
                    targetMarker = null;
                }
                if (engineCluster) engineCluster.clearLayers();
                if (accuCluster) accuCluster.clearLayers();
                for (var i = 0; i < pathLine.length; i++) {
                    map.removeLayer(pathLine[i]);
                }
                if (playTimer) {
                    clearInterval(playTimer);
                    playTimer = false;
                }
                $("#btnPause").hide();
                if ($("#sidebar-wrapper").is(":hidden")) $("#sidebar-wrapper").show();
                if ($("#btnMenu").is(":hidden")) $("#btnMenu").show();
                if ($("#sidenav").is(":visible")) $("#sidenav").hide();
                $('#dateEditFrom').show();
                $('#dateEditTo').show();
                pcFeatures.SetActiveTabIndex(0);
                pcFeaturesSub.SetActiveTabIndex(0);
                $("#comboBox_I").val("");
                $("#streetName").empty();
                $("#vehicleNumber").empty();
                $("#gsmNumber").empty();
                $("#lastUpdate").empty();
                $("#position").empty();
                $("#engine").empty();
                $("#speed").empty();
                $("#direction").empty();
                $("#odometer").empty();
                $("#powerSource").empty();
                $("#valinput1").empty();
                $("#input1").html("Input 1");
                $("#valinput2").empty();
                $("#input2").html("Input 2");
                $("#valinput3").empty();
                $("#input3").html("Input 3");
                $("#valinput4").empty();
                $("#input4").html("Input 4");
                $("#valtemp1").empty();
                $("#temp1").html("Temp 1");
                $("#valtemp2").empty();
                $("#temp2").html("Temp 2");
                $("#orderNumber").empty();
                $("#originOrder").empty();
                $("#destinOrder").empty();
                $("#statusOrder").empty();
                map.fitBounds([[5.5769167874644966, 94.81858018012717], [-9.0769167874644966, 130.01858018012717]]);
                updateData();
                updateTimer = setInterval(updateData, updatePeriod);
                $("#comboBox_VI").prop("disabled", false);
                $("#historyLine").empty();
                $('#slider').hide();
                linePanel = new Highcharts.chart('historyLine', {
                    chart: {
                        zoomType: 'x'
                    },
                    exporting: {
                        enabled: false
                    },
                    title: {
                        text: null
                    },
                    credits: {
                        enabled: false
                    },
                    tooltip: {
                        pointFormat: '{point.y} Km/h'
                    },
                    xAxis: {
                        type: 'datetime',
                        plotLines: [{
                            color: 'orange',
                            width: 1,
                            value: 0,
                            zIndex: 5
                        }]
                    },
                    plotOptions: {
                        area: {
                            fillColor: {
                                linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                stops: [
                                  [0, Highcharts.getOptions().colors[0]],
                                  [1, Highcharts.color(Highcharts.getOptions().colors[0]).setOpacity(0).get('rgba')]
                                ]
                            },
                            marker: {
                                radius: 2
                            },
                            lineWidth: 1,
                            states: {
                                hover: {
                                    lineWidth: 1
                                }
                            },
                            threshold: null
                        },
                        series: {
                            cursor: 'pointer',
                            point: {
                                events: {
                                    click: function (e) {
                                        posCount = e.point.index;
                                        if (!playTimer) {
                                            playback();
                                        }

                                    },
                                    onContainerClick: function (e) {

                                        console.log(e);
                                    }
                                }
                            }
                        }
                    },
                    yAxis: {
                        title: {
                            text: "Speed"
                        }
                    },
                    series: [{
                        showInLegend: false,
                        type: 'area',
                        data: 0,
                        name: "Speed"
                    }],
                });
            }
        
          
      


        }
        //*****************************************************************************************************************************

        function setWaypointinfo(data) {
        
            var n = new Date(parseInt(data.WP_TIME.substr(6)));
            var d = ("0" + n.getDate()).slice(-2) + "/" + ("0" + (n.getMonth() + 1)).slice(-2) + "/" + n.getFullYear();
            var t = ("0" + n.getHours()).slice(-2) + ":" + ("0" + n.getMinutes()).slice(-2) + ":" + ("0" + n.getSeconds()).slice(-2);
            var lastupdate = d + " " + t;
            var engine = "OFF";
            var powersource = "Accu";
            var input1 = data.I01VALUE;
            var input2 = data.I02VALUE;
            var input3 = data.I03VALUE;
            var input4 = data.I04VALUE;
            var labelinput1, labelinput2, labelinput3, labelinput4, lblsuhu1, lblsuhu2;
            engine = "";
            if (data.IO1KEY == 'Engine') {
                engine = data.IO1VALUE;
            } else if (data.IO2KEY == 'Engine') {
                engine = data.IO2VALUE;
            } else if (data.IO3KEY == 'Engine') {
                engine = data.IO3VALUE;
            } else if (data.IO4KEY == 'Engine') {
                engine = data.IO4VALUE;
            }
            var suhu1 = Math.round(data.SUHU1);
            var suhu2 = Math.round(data.SUHU2);
            if (data.WP_IO1 == true) engine = engine;
            if (data.PWR < 9) powersource = "Battery";

            labelinput1 = data.IO1KEY;
            input1 = data.IO1VALUE;
            labelinput2 = data.IO2KEY;
            input2 = data.IO2VALUE;
            labelinput3 = data.IO3KEY;
            input3 = data.IO3VALUE;
            labelinput4 = data.IO4KEY;
            input4 = data.IO4VALUE;
            if (data.SUHU1 == 85 || data.SUHU1 >= 2000) suhu1 = "";
            if (data.SUHU2 == 85 || data.SUHU2 >= 2000) suhu2 = "";

            if (data.SUHU1) {
                lblsuhu1 = data.SUHU1KEY;
            }
            if (data.SUHU2) {
                lblsuhu2 = data.SUHU2KEY;
            }
            $("#streetName").html(data.LOC);
            $("#vehicleNumber").html(data.REGNO);
            $("#gsmNumber").html(data.GSMNO);
            $("#lastUpdate").html(lastupdate);
            $("#position").html((data.WP_LAT).toFixed(7) + ", " + (data.WP_LON).toFixed(7));
            $("#engine").html(engine);
            $("#speed").html(data.WP_SPEED);
            $("#direction").html(Math.round(data.ANGLE));
            $("#odometer").html(Math.round(data.ODO));
            $("#powerSource").html(powersource);
            $("#valinput1").html(input1);
            $("#input1").html(labelinput1);
            $("#valinput2").html(input2);
            $("#input2").html(labelinput2);
            $("#valinput3").html(input3);
            $("#input3").html(labelinput3);
            $("#valinput4").html(input4);
            $("#input4").html(labelinput4);
            $("#valtemp1").html(suhu1);
            $("#temp1").html(lblsuhu1);
            $("#valtemp2").html(suhu2);
            $("#temp2").html(lblsuhu2);
        }
        //*****************************************************************************************************************************

        function lineClick(e) {
            if (playTimer) {
                clearInterval(playTimer);
                playTimer = false;
                $("#btnPause").hide();
                $("#btnPlay").show();
            }
            posCount = e.target.options.index;
            playback();
        }
        $("#cancelGeo").click(function () {
            $('#formGeofence').dialog('close');
        });


        $("#cal_start").on("click", function () {
            $("#input-fromdate").focus();
        });
        $("#cal_end").on("click", function () {
            $("#input-todate").focus();
        });
        //*****************************************************************************************************************************
        function playback(e) {

            var nCount = posCount;
            if (playTimer) {
                nCount = posCount++;
            }
            if (nCount == playbackData.length) {
                posCount = 0;
                if (playTimer) {
                    clearInterval(playTimer);
                    playTimer = false;
                    $("#btnPause").hide();
                    $("#btnPlay").show();
                }
            }
            if (playbackData[nCount].WP_IO1 == false) {
                var markerIcon = L.divIcon({
                    className: "vehicleloMarker",
                    html: '<div class="vehicleloHead"></div>'
                });
                targetMarker.setIcon(markerIcon);
            }
            else if (playbackData[nCount].WP_IO1 == true) {
                var markerIcon = L.divIcon({
                    className: "vehiclehiMarker",
                    html: '<div class="vehiclehiHead"></div>'
                });
                targetMarker.setIcon(markerIcon);
            }
            var nLatlon = new L.LatLng(playbackData[nCount].WP_LAT, playbackData[nCount].WP_LON);
            var nBound = map.getBounds();
            if (!nBound.contains(nLatlon)) {
                map.setView([playbackData[nCount].WP_LAT, playbackData[nCount].WP_LON], map.getZoom());
            }
            targetMarker.setLatLng(nLatlon);
            targetMarker.setRotationAngle(playbackData[nCount].ANGLE);
            targetMarker.setRotationOrigin("center");
            setWaypointinfo(playbackData[nCount]);
            var n = new Date(parseInt(playbackData[nCount].WP_TIME.substr(6)));
      
            var wptime = n.getTime() - ((n.getTimezoneOffset() * 60) * 1e3)
            linePanel.xAxis[0].options.plotLines[0].value = wptime;
            linePanel.xAxis[0].update();

            if (nCount == playbackData.length - 1) {
                $('#btnForward').prop('disabled', true);
                $('#btnPlay').prop('disabled', true);
                if (playTimer) {
                    clearInterval(playTimer);
                    playTimer = false;
                    $("#btnPause").hide();
                    $("#btnPlay").show();
                }
            } else if (nCount > 0) {
                $('#btnBackward').prop('disabled', false);
                $('#btnForward').prop('disabled', false);
                $('#btnPlay').prop('disabled', false);
            } else if (nCount == 0) {
                $('#btnForward').prop('disabled', false);
                $('#btnPlay').prop('disabled', false);
                $('#btnBackward').prop('disabled', true);

            }
            $("#slider").slider("value", nCount);


        }
        //*****************************************************************************************************************************
        $("#getPlayback").click(function () {
            if (playTimer) {
                clearInterval(playTimer);
                playTimer = false;
                $("#btnPause").hide();
                $("#btnPlay").show();
            }
            $("#historyWindows").dialog('open');
        });
        //*****************************************************************************************************************************
        $("#btnPause").hide();
        $("#btnPlay").click(function () {
            $("#btnPlay").hide();
            $("#btnPause").show();
            if (!playTimer) {
                playTimer = setInterval(playback, playSpeed);
            }
        });
        //*****************************************************************************************************************************
        $("#btnPause").click(function () {
            $("#btnPause").hide();
            $("#btnPlay").show();
            if (playTimer) {
                clearInterval(playTimer);
                playTimer = false;
            }
        });
        //*****************************************************************************************************************************
        $("#btnBackward").click(function () {

            if (playTimer) {
                clearInterval(playTimer);
                playTimer = false;
                $("#btnPause").hide();
                $("#btnPlay").show();
            }
            $("#slider").slider("value", posCount);
            posCount--;
            playback();
        });
        //*****************************************************************************************************************************
        $("#btnForward").click(function () {
            if (playTimer) {
                clearInterval(playTimer);
                playTimer = false;
                $("#btnPause").hide();
                $("#btnPlay").show();
            }
            $("#slider").slider("value", posCount);
            posCount++;
            playback();
        });
        //*****************************************************************************************************************************

        $("#viewSpeed").click(function () {
            $("#historyLine").toggle();
        });

        //*****************************************************************************************************************************
        function initMapCreateGeofence() {
            polygonDrawer = new L.Draw.Polygon(map);
            map.on('draw:created', function (e) {
                type = e.layerType,
                layerAddGeo = e.layer;
           
                layerAddGeo.addTo(map);

                var shape = layerAddGeo.toGeoJSON()
                var shape_for_db = JSON.stringify(shape.geometry.coordinates);

                var latlongeo = shape_for_db.replace('[[[', 'POLYGON((');
                var latlongeoF = latlongeo.substring(0, latlongeo.length - 3) + "))";
                repLatLon = latlongeoF.replace(/,/g, " ").replace(/\[/g, '').replace(/\]/g, ',');
                $('#Geometry_I').val(repLatLon);
                    
            });  
        }
        //*****************************************************************************************************************************
        function cloneCoords(sourceArray) {
            var destArray = [];
            for (var i = 0; i < sourceArray.length; i++) {
                destArray.push([sourceArray[i][0], sourceArray[i][1]]);
            }
            return destArray;
        }
        //*****************************************************************************************************************************
        function convertToArrayOfArray(sourceArray) {
            var destArray = [];
            for (var i = 0; i < sourceArray.length; i++) {
                destArray.push([sourceArray[i].lat, sourceArray[i].lng]);
            }
            return destArray;
        }
        //*****************************************************************************************************************************
        // Load data and revert shape to original points
        var lengcoord;
        var points;
        var simplified;
        function onlyUnique(value, index, self) {
            return self.indexOf(value) === index;
        }
        function loadFromDatabase() {
            points = cloneCoords(original);
            simplified = cloneCoords(original);
            if (points.length == 0 || confirm("Reset all changes and revert to original path?")) {
                original = convertToArrayOfArray(geoArpos);
           
                points = cloneCoords(original);
                simplified = cloneCoords(original);
                if (!track) {
               
                    track = L.polygon(points, { color: 'red' }).addTo(map);
                    track.enableEdit();
              
                    map.on('editable:vertex:dragend', function (e) {
                        lengcoord = e.layer;
                        for (var i = 0; i < lengcoord.length; i++) {
                            latlonedit.push(lengcoord[i].lat + ", " + lengcoord[i].lng);
                        }
                        var shape = lengcoord.toGeoJSON()
                        var shape_for_db = JSON.stringify(shape.geometry.coordinates);
                        var latlongeo = shape_for_db.replace('[[[', 'POLYGON((');
                        var latlongeoF = latlongeo.substring(0, latlongeo.length - 3) + "))";
                        repLatLon = latlongeoF.replace(/,/g, " ").replace(/\[/g, '').replace(/\]/g, ',');
                        $('#Geometry_I').val(repLatLon);
                        
                    });
               
                } else {
                    track.setLatLngs(original);
                }
            }
        }

        //*****************************************************************************************************************************
        function getGeoDataLMS() {
            var geoCode = cmbKode.GetValue();
        
            $.ajax({
                type: "POST",
                url: "Maps/GetGeofenceInfoLMS",
                data: { GEOFENCE_CODE: geoCode },
                success: function (data) {
                    $('#txtNama_I').val(data[0].GEOFENCE_NAME);
                    $('#txtCoordlat_I').val(data[0].GEOFENCE_LAT);
                    $('#txtCoordlon_I').val(data[0].GEOFENCE_LON);

                    var ltgeo = data[0].GEOFENCE_LAT.replace(/,/g, '.');
                    var lngeo = data[0].GEOFENCE_LON.replace(/,/g, '.');
                
                    map.setView([ltgeo, lngeo], 12);
                }
            });


        }
        //*****************************************************************************************************************************
        var codeGeo;
        var typeGeo;
        var maxspeedgeo;
        function editGeofence() {
            var geoGeoms = setGeofence;
            var geoColor = "red";
            TYPE = 'Edit';
            if (geoGeoms.startsWith("POLYGON")) {
                var geoSubstr = geoGeoms.substring(10, geoGeoms.length - 2);
                var geoCoord = geoSubstr.split(", ");
                geoArpos = [];
                for (var c in geoCoord) {
                    var geoLatLon = geoCoord[c].split(" ");
                    var geoLat = parseFloat(geoLatLon[1]);
                    var geoLon = parseFloat(geoLatLon[0]);
                    geoArpos.push({
                        lat: geoLat,
                        lng: geoLon
                    });
                }
            
            }
            else if (geoGeoms.startsWith("MULTIPOLYGON")) {
                var geoSubstr = geoGeoms.substring(16, geoGeoms.length - 3);
                var geoString = geoSubstr.split(")), ((");
                for (var m in geoString) {
                    try {
                        var geoCoord = geoString[m].split(", ");
                        geoArpos = [];
                        for (var c in geoCoord) {
                            var geoLatLon = geoCoord[c].split(" ");
                            var geoLat = parseFloat(geoLatLon[1]);
                            var geoLon = parseFloat(geoLatLon[0]);
                            geoArpos.push({
                                lat: geoLat,
                                lng: geoLon
                            });
                        }
                  
                    }
                    catch (e) {
                        console.log(e, geoString[m]);
                    }
                }
            }
            else if (geoGeoms.startsWith("GEOMETRYCOLLECTION")) {
                var geoSubstr = geoGeoms.substring(20, geoGeoms.length - 1);
                var lineCount = geoSubstr.match(/LINESTRING/g);
                var polyCount = geoSubstr.match(/POLYGON/g);
                var geoCollec = lineCount + polyCount;
                for (var gc = 0; gc < geoCollec.length; gc++) {
                    try {
                        if (geoSubstr.startsWith("LINESTRING")) {
                            var strEnd = geoSubstr.indexOf(")");
                            var geomTemps = geoSubstr.substring(12, strEnd);
                            var geoCoord = geomTemps.split(", ");
                            geoArpos = [];
                            for (var c in geoCoord) {
                                var geoLatLon = geoCoord[c].split(" ");
                                var geoLat = parseFloat(geoLatLon[1]);
                                var geoLon = parseFloat(geoLatLon[0]);
                                geoArpos.push({
                                    lat: geoLat,
                                    lng: geoLon
                                });
                            }
                       
                        }
                        else if (geoSubstr.startsWith("POLYGON")) {
                            var strEnd = geoSubstr.indexOf(")");
                            var geomTemps = geoSubstr.substring(10, strEnd);
                            var geoCoord = geomTemps.split(", ");
                            geoArpos = [];
                            for (var c in geoCoord) {
                                var geoLatLon = geoCoord[c].split(" ");
                                var geoLat = parseFloat(geoLatLon[1]);
                                var geoLon = parseFloat(geoLatLon[0]);
                                geoArpos.push({
                                    lat: parseFloat(geoLatLon[1]),
                                    lng: parseFloat(geoLatLon[0])
                                });
                            }
                       
                        }
                        geoSubstr = geoSubstr.substring(strEnd + 3, geoSubstr.length);
                    }
                    catch (e) {
                        console.log(e);
                    }
                }
            }
            $.ajax({
                url: "Maps/SetFormGeofence",
                type: 'POST',
                data: { TYPE: TYPE },
                beforeSend: function () {
                    CallbackPanel.PerformCallback();
                },
                success: function (data) {
                    $("#formgeo").show();
                    $("#formgeo").html(data);
                    $('#infogeo').hide();
                    btnEdit.SetVisible(false);
                    btnAdd.SetVisible(false);
                    btnSave.SetVisible(true);
                    btnCancelGeo.SetVisible(true);
                    $('.dxflHALSys').hide();
                
                    $('#cmbTipe_I').val(dataEditGeo[0].GEOFENCE_TYPE);
                    $('#cmbKode_I').val(dataEditGeo[0].GEOFENCE_CODE);
                    $('#txtNama_I').val(dataEditGeo[0].GEOFENCE_NAME);
                    $('#txtCoordlat_I').val(dataEditGeo[0].GEOFENCE_LAT);
                    $('#txtCoordlon_I').val(dataEditGeo[0].GEOFENCE_LON);
                    $('#maxKecepatan_I').val(dataEditGeo[0].GEOFENCE_SPEED)
                    $('#Geometry_I').val(dataEditGeo[0].GEOFENCE_GEOM);
                    $('#cmbKode_I').prop("disable", true);
                    comboBoxGeo.SetEnabled(false);
                    cmbTipe.SetValue(dataEditGeo[0].GEOFENCE_TYPE);
                    maxKecepatan.SetValue(dataEditGeo[0].GEOFENCE_SPEED);
                    codeGeo = dataEditGeo[0].GEOFENCE_CODE;
                    typeGeo = dataEditGeo[0].GEOFENCE_TYPE;
                    maxspeedgeo = dataEditGeo[0].GEOFENCE_SPEED;
                    cmbTipe.SetEnabled(false);
                    cmbKode.SetEnabled(false);
                    txtNama.SetEnabled(false);
                    txtCoordlat.SetEnabled(false);
                    txtCoordlon.SetEnabled(false);
                    Geometry.SetEnabled(false);
                    Alert.SetChecked(dataEditGeo[0].GEOFENCE_ALERT);
                    Active.SetChecked(dataEditGeo[0].IS_ACTIVE);
            
                    $('#getDirection').css("pointer-events", "none");
                    $('#getPlayback').css("pointer-events", "none");
                    $('#getCenter').css("pointer-events", "none");
                }
            });
            loadFromDatabase();
     
       
            $('#pcModalGeofence_DXPWMB-1').css('visibility', 'hidden');
            $('.dxpcModalBackLite_Office365').css('visibility', 'hidden');

        }

        //*****************************************************************************************************************************
        function addPolygon() {
            polygonDrawer.enable();
            TYPE = 'Add'
            $.ajax({
                url: "Maps/SetFormGeofence",
                type: 'POST',
                data: { TYPE: TYPE },
                beforeSend: function () {
                    CallbackPanel.PerformCallback();
                },
                success: function (data) {
                    $("#formgeo").show();
                    $("#formgeo").html(data);
                    $('#infogeo').hide();
                    btnEdit.SetVisible(false);
                    btnAdd.SetVisible(false);
                    btnSave.SetVisible(true);
                    btnCancelGeo.SetVisible(true);
                    comboBoxGeo.SetValue(null);
                    comboBoxGeo.SetEnabled(false);
                    cmbKode.SetEnabled(false);
                    $('.dxflHALSys').hide();
                    $('#getDirection').css("pointer-events", "none");
                    $('#getPlayback').css("pointer-events", "none");
                    $('#getCenter').css("pointer-events", "none");

                }
            });
        }

        //*****************************************************************************************************************************

        function cancelFormGeo() {
            $("#formgeo").hide();
            $('#infogeo').show();
            $("#geofenceName").html("");
            $("#geofenceCode").html("");
            $("#geofenceType").html("");
            $("#geofenceSpeed").html("");
            comboBoxGeo.SetValue(null);
            btnAdd.SetVisible(true);
            btnEdit.SetVisible(true);
            btnEdit.SetEnabled(false);
            btnSave.SetVisible(false);
            btnCancelGeo.SetVisible(false);
            comboBoxGeo.SetEnabled(true);
            $('#getDirection').css("pointer-events", "auto");
            $('#getPlayback').css("pointer-events", "auto");
            $('#getCenter').css("pointer-events", "auto");
            if (track) {
                track.disableEdit();
                map.removeLayer(track);
                track = null;
                original = [];
            } else if (layerAddGeo) {
                polygonDrawer.disable();
                map.removeLayer(layerAddGeo);
            } else {
                polygonDrawer.disable();
            }
       
        }
        //*****************************************************************************************************************************
        function submitGeofence() {
            var dataGeoType = cmbTipe.GetValue();
            var dataGeoCode;
            if (codeGeo == null || codeGeo == "") {
                dataGeoCode = cmbKode.GetText();
            } else if (codeGeo != null || codeGeo != "") {
                dataGeoCode = codeGeo;
            }
            var dataGeoName = txtNama.GetText();
            var dataGeoLat = txtCoordlat.GetText();
            var dataGeoLon = txtCoordlon.GetText();
            var dataGeoMaxSpeed = maxKecepatan.GetValue();
            var dataGeoGeom = Geometry.GetText();
            var dataGeoAlert = Alert.GetChecked();
            var dataGeoActive = Active.GetChecked();
            
        
            var url;
            if (TYPE == 'Add') {
                url = "Maps/SaveNewGeofence";
            } else if (TYPE == 'Edit') {
                url = "Maps/UpdateGeofence";
            }
            if (dataGeoType == "" || dataGeoType == null) {
                alert("Fill Geofence Type Field");
            }
            else if ((dataGeoCode == "" || dataGeoCode == null) && dataGeoType != "OTH") {
                alert("Fill Geofence Code Field");
            } else if (dataGeoName == "" || dataGeoName == null) {
                alert("Fill Geofence Name  Field");
            } else if ((dataGeoLat == "" || dataGeoLat == null) && dataGeoType != "OTH") {
                alert("Fill Geofence Latitude Field");
            } else if ((dataGeoLon == "" || dataGeoLon == null) && dataGeoType != "OTH") {
                alert("Fill Geofence Longitude Field");
            } else if (dataGeoGeom == "" || dataGeoGeom == null) {
                alert("Finish Your Polygon");
            } else {

                if (dataGeoMaxSpeed == "" || dataGeoMaxSpeed == null) {
                    dataGeoMaxSpeed = 0;
                }
                $.ajax({
                    url: url,
                    type: 'POST',
                    data: {
                        GEOFENCE_TYPE: dataGeoType,
                        GEOFENCE_CODE: dataGeoCode,
                        GEOFENCE_NAME: dataGeoName,
                        GEOFENCE_LAT: dataGeoLat,
                        GEOFENCE_LON: dataGeoLon,
                        GEOFENCE_SPEED: dataGeoMaxSpeed,
                        GEOFENCE_GEOM: dataGeoGeom,
                        GEOFENCE_ALERT: dataGeoAlert,
                        IS_ACTIVE: dataGeoActive
                    },
                    beforeSend: function () {
                        CallbackPanel.PerformCallback();
                    },
                    success: function (data) {
                        codeGeo = "";
                        typeGeo = "";
                        $("#formgeo").hide();
                        $('#infogeo').show();
                        btnAdd.SetVisible(true);
                        btnEdit.SetVisible(true);
                        btnEdit.SetEnabled(true);
                        btnSave.SetVisible(false);
                        btnCancelGeo.SetVisible(false);
                        if (track) {
                            track.disableEdit();
                            map.removeLayer(track);
                            track = null;
                            original = [];
                        } else if (layerAddGeo) {
                            polygonDrawer.disable();
                            map.removeLayer(layerAddGeo);
                        } else {
                            polygonDrawer.disable();
                        }
                        $('#comboBoxGeo_I').val("");
                        $("#geofenceName").html("");
                        $("#geofenceCode").html("");
                        $("#geofenceType").html("");
                        $("#geofenceSpeed").html("");
                        comboBoxGeo.SetEnabled(true);
                        comboBoxGeo.SetValue(null);
                        map.fitBounds([[5.5769167874644966, 94.81858018012717], [-9.0769167874644966, 130.01858018012717]]);
                        if (polygon) {
                            for (var i = 0; i < polygon.length; i++) {
                                map.removeLayer(polygon[i]);
                            }
                        }
                        getGeofence();
                    }
                });

            }

       
        }


        function getGeoCode(s, e) {
     
            if (cmbTipe.GetValue() == "OTH") {
                cmbKode.SetEnabled(false);
                Geometry.SetEnabled(false);
                txtNama.SetEnabled(true);
                txtCoordlat.SetEnabled(true);
                txtCoordlon.SetEnabled(true);
                cmbKode.SetValue(null);
                txtNama.SetValue(null);
                txtCoordlat.SetValue(null);
                txtCoordlon.SetValue(null);
                Geometry.SetEnabled(false);
            } else if (cmbTipe.GetValue() != "OTH") {
                cmbKode.SetEnabled(true);
                txtNama.SetEnabled(false);
                txtCoordlat.SetEnabled(false);
                txtCoordlon.SetEnabled(false);
                Geometry.SetEnabled(false);
           
            }
        }


        $('#pcFeatures_TC').click(function () {
            getSession();
        })
        $('#comboBox').click(function () {
            getSession();
        });
  
        function getSession() {
            $.ajax({
                url: 'Maps/GetSession',
                type: 'GET',
                success: function (data) {
                    if (data == null || data == "") {
                        window.location.href = 'Login';
                    }
                }
            });
            
        }
        //*****************************************************************************************************************************
        window.onload = initMap;
        //*****************************************************************************************************************************