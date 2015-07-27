var app = (function()
{
	// Application object.
	var app = {};
    var sessionUID = null;
	// Specify your beacon 128bit UUIDs here.
	var regions = [];
    /*
	[
		// Estimote Beacon factory UUID.
		{uuid:'07775DD0-111B-11E4-9191-0800200C9A66'},
        
		// Sample UUIDs for beacons in our lab.
		{uuid:'F7826DA6-4FA2-4E98-8024-BC5B71E0893E'},
		{uuid:'8DEEFBB9-F738-4297-8040-96668BB44281'},
		{uuid:'A0B13730-3A9A-11E3-AA6E-0800200C9A66'},
		{uuid:'E20A39F4-73F5-4BC4-A12F-17D1AD07A961'},
		{uuid:'A4950001-C5B1-4B44-B512-1370F02D74DE'}
	];
    */

    
	// Dictionary of beacons.
	var beacons = {};

	// Timer that displays list of beacons.
	var updateTimer = null;

	app.initialize = function()
	{
		document.addEventListener('deviceready', onDeviceReady, false);
        //onDeviceReady();
	};


	function onDeviceReady()
	{
		// Specify a shortcut for the location manager holding the iBeacon functions.
        window.locationManager = cordova.plugins.locationManager;
        console.log('locationManager:', window.locationManager);
        console.log('ready');

            $.ajax({
                url: 'http://54.233.65.245:9000/login',
                type: 'POST',
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                crossDomain: true,
                data: 'username=jaimert%40msn.com&password=jj321456&appcode=1234567890',
                headers: {
                    'X-BAASBOX-APPCODE': '1234567890',
                    'Accept': '*/*',
                    'Accept-Language': 'en-US,en;q=0.8,pt;q=0.6',
                },
                success: function (retorno) {

                    console.log('Sucesso!');
                    console.log(retorno);
                    
                    sessionUID = retorno.data["X-BB-SESSION"];
                    
                    console.log('Session: ' + sessionUID);

                    $.ajax({
                        url: ('http://54.233.65.245:9000/document/Beacons?page=0&recordsPerPage=50'),
                        type: "GET",
                        datatype: "json",
                        contentType: "application/json; charset=utf-8",
                        crossDomain: true,
                        async: true,
                        headers: {
                            'X-BAASBOX-APPCODE': '1234567890',
                            'X-BB-SESSION': sessionUID
                        },
                        success: function (retorno) {
                            
                            for( var i=0; i < retorno.data.length; i++ ) {

                                var add = true;

                                for( x=0; x < regions.length; x++ ) {

                                    if( regions[x].uuid == retorno.data[i].UID ) {
                                        add = false;
                                        break;
                                    }
                                }

                                if( add )
                                    regions.push( {uuid: retorno.data[i].UID });
                            }

                            console.log('regions:', regions);
                            
                            // Start tracking beacons!
                            startScan();

                        },
                        error: function (retorno, ajaxOptions, thrownError) {
                            alert('Obras.Todos.Erro');
                        },
                    });
                },
                error: function (retorno, ajaxOptions, thrownError) {
                    console.log('Login.Erro');
                    console.log(retorno);
                    console.log(ajaxOptions);
                    console.log(thrownError);
                    
                },
            });

		// Display refresh timer.
		updateTimer = setInterval(displayBeaconList, 500);
	}

	function startScan()
	{
        console.log('startScan');
        console.log('regions to search:', regions.length);
        console.log('currentSession:', sessionUID);

        try
        {
            // The delegate object holds the iBeacon callback functions
            // specified below.
            var delegate = new locationManager.Delegate();

            // Called continuously when ranging beacons.
            delegate.didRangeBeaconsInRegion = function(pluginResult)
            {
                console.log('didRangeBeaconsInRegion: ' + JSON.stringify(pluginResult))
                for (var i in pluginResult.beacons)
                {
                    // Insert beacon into table of found beacons.
                    var beacon = pluginResult.beacons[i];
                    beacon.timeStamp = Date.now();
                    var key = beacon.uuid + ':' + beacon.major + ':' + beacon.minor;
                    console.log('Beacon Found:', key);
                    beacons[key] = beacon;
                }
            };

            // Called when starting to monitor a region.
            // (Not used in this example, included as a reference.)
            delegate.didStartMonitoringForRegion = function(pluginResult)
            {
                console.log('didStartMonitoringForRegion:' + JSON.stringify(pluginResult))
            };

            // Called when monitoring and the state of a region changes.
            // (Not used in this example, included as a reference.)
            delegate.didDetermineStateForRegion = function(pluginResult)
            {
                console.log('didDetermineStateForRegion: ' + JSON.stringify(pluginResult))
            };

            // Set the delegate object to use.
            locationManager.setDelegate(delegate);

            // Request permission from user to access location info.
            // This is needed on iOS 8.
            locationManager.requestAlwaysAuthorization();

            // Start monitoring and ranging beacons.
            for (var i in regions)
            {
                var beaconRegion = new locationManager.BeaconRegion(
                    i + 1,
                    regions[i].uuid);

                // Start ranging.
                locationManager.startRangingBeaconsInRegion(beaconRegion)
                    .fail(console.error)
                    .done();

                // Start monitoring.
                // (Not used in this example, included as a reference.)
                locationManager.startMonitoringForRegion(beaconRegion)
                    .fail(console.error)
                    .done();
            }
        }
        catch(e)
        {
            console.log('Erro Generico em StartScan');
            console.log(e);
        }
	}

	function displayBeaconList()
	{
		// Clear beacon list.
		$('#found-beacons').empty();

		var timeNow = Date.now();

		// Update beacon list.
		$.each(beacons, function(key, beacon)
		{
			// Only show beacons that are updated during the last 60 seconds.
			if (beacon.timeStamp + 60000 > timeNow)
			{
				// Map the RSSI value to a width in percent for the indicator.
				var rssiWidth = 1; // Used when RSSI is zero or greater.
				if (beacon.rssi < -100) { rssiWidth = 100; }
				else if (beacon.rssi < 0) { rssiWidth = 100 + beacon.rssi; }

				// Create tag to display beacon data.
				var element = $(
					'<li>'
					+	'<strong>UUID: ' + beacon.uuid + '</strong><br />'
					+	'Major: ' + beacon.major + '<br />'
					+	'Minor: ' + beacon.minor + '<br />'
					+	'Proximity: ' + beacon.proximity + '<br />'
					+	'RSSI: ' + beacon.rssi + '<br />'
					+ 	'<div style="background:rgb(255,128,64);height:20px;width:'
					+ 		rssiWidth + '%;"></div>'
					+ '</li>'
				);

				$('#warning').remove();
				$('#found-beacons').append(element);
			}
		});
	}

	return app;
})();

app.initialize();
