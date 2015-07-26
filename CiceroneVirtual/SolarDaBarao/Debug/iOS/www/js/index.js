var app = (function()
{
	// Application object.
	var app = {};

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
	};

	function onDeviceReady()
	{
		// Specify a shortcut for the location manager holding the iBeacon functions.
		window.locationManager = cordova.plugins.locationManager;

		// Start tracking beacons!

        console.log('ciceroneVirtual.Init');
        ciceroneVirtual.Init();


        console.log('reading my beacons...');
        ciceroneVirtual.Beacons.Todos( function( data ) {
            
            console.log('ciceroneVirtual.Beacons:', data);
            
            for( var i=0; i < data.length; i++ )
            {
                var add = true;
                /*for( var x=0; x < regions.length; x++ )
                {
                    if( regions[x].uid == data[i].UID)
                    {
                        add = false;
                        break;
                    }
                }*/
                var model = { uid : data[i].UID };
                if( add )
                    regions.push(model);
            }

            for( var i=0; i < regions.length; i++ )
            {
                console.log('beacon readed:', regions[i]);
            }

            if( regions.length == 0 )
                regions.push({ uid : "07775DD0-111B-11E4-9191-0800200C9A66" });
            
            startScan();
            // Display refresh timer.
		    updateTimer = setInterval(displayBeaconList, 500);
            
        }, null);

	}

	function startScan()
	{
        console.log('startScan...');
        console.log('startScan.regions:', regions.length);
		// The delegate object holds the iBeacon callback functions
		// specified below.
		var delegate = new locationManager.Delegate();

		// Called continuously when ranging beacons.
		delegate.didRangeBeaconsInRegion = function(pluginResult)
		{
			//console.log('didRangeBeaconsInRegion: ' + JSON.stringify(pluginResult))
			for (var i in pluginResult.beacons)
			{
                console.log('find beacon...');
				// Insert beacon into table of found beacons.
				var beacon = pluginResult.beacons[i];
				beacon.timeStamp = Date.now();
				var key = beacon.uuid + ':' + beacon.major + ':' + beacon.minor;
				beacons[key] = beacon;
			}
		};

		// Called when starting to monitor a region.
		// (Not used in this example, included as a reference.)
		delegate.didStartMonitoringForRegion = function(pluginResult)
		{
			//console.log('didStartMonitoringForRegion:' + JSON.stringify(pluginResult))
		};

		// Called when monitoring and the state of a region changes.
		// (Not used in this example, included as a reference.)
		delegate.didDetermineStateForRegion = function(pluginResult)
		{
			//console.log('didDetermineStateForRegion: ' + JSON.stringify(pluginResult))
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

	function displayBeaconList()
	{
		// Clear beacon list.
		$('#found-beacons').empty();

		var timeNow = Date.now();

        //console.log('display Beacon List...');
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

                $('#warning').remove();
                
				// Create tag to display beacon data.
                var element = null;
                console.log('search beacon referente on Cicerone Virtual ...');
                ciceroneVirtual.Obras.ConsultarPorBeacon( beacon.uid, beacon.major, beacon.minor, function( data ) {
                    element = $(
                        '<div class="mdl-cell mdl-cell--3-col mdl-cell--4-col-tablet mdl-cell--4-col-phone mdl-card mdl-shadow--3dp">'
                        + '<div class="mdl-card__media">'
                        + '<img src="' + data.Card.Image + '">'
                        + '</div>'
                        + '<div class="mdl-card__title">'
                        + '<h4 class="mdl-card__title-text">' + data.Title + '</h4>'
                        + '</div>'
                        + '<div class="mdl-card__supporting-text">'
                        + '<span class="mdl-typography--font-light mdl-typography--subhead">'
                        + data.Card.Description
                        + '</span>'
                        + '</div>'
                        + '<div class="mdl-card__actions">'
                        + '<a class="android-link mdl-button mdl-js-button mdl-typography--text-uppercase" href="">'
                        + 'Saiba Mais'
                        + '<i class="material-icons">chevron_right</i>'
                        + '</a>'
                        + '</div>'
                        + '</div>');
                    
                    if( element != null )
				        $('#found-beacons').append(element);
                    
                }, null);
                /*
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
                */
				
                
			}
		});
	}

	return app;
})();

app.initialize();
