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
    var obras = {};
    
	// Timer that displays list of beacons.
	var updateTimer = null;

	app.initialize = function()
	{
		document.addEventListener('deviceready', onDeviceReady, false);
        BaasBox.setEndPoint("http://54.233.69.169:9000");
		BaasBox.appcode = "1234567890";
        //onDeviceReady();
	};

    function getItem(key)
    {
        var keyData = key.split(':');
        if( obras[key] == undefined )
        {
            BaasBox.loadCollectionWithParams("Items", {where: "Beacon.UID='{0}' and Beacon.Major='{1}' and Beacon.Minor='{2}'".replace("{0}", keyData[0]).replace("{1}", keyData[1]).replace("{2}", keyData[2]) })
			  .done(function(res) {
			  	console.log("res ", JSON.stringify(res));
                
                if( res.length > 0 )
                    obras[key] = res;
			  })
			  .fail(function(error) {
			  	console.log("Obras.Item.Erro ", error);
			  })	
            /*
            var where = "Beacon.UID%3D%27{0}%27+and+Beacon.Major%3D%27{1}%27+and+Beacon.Minor%3D%27{2}%27".replace("{0}", keyData[0]).replace("{1}", keyData[1]).replace("{2}", keyData[2]);
            $.ajax({
                url: ('http://54.233.65.245:9000/document/Items?where=' + where),
                type: "GET",
                //datatype: "json",
                //contentType: "application/json; charset=utf-8",
                crossDomain: true,
                async: true,
                headers: {
                    'X-BAASBOX-APPCODE': '1234567890',
                    'X-BB-SESSION': sessionUID
                },
                success: function (retorno) {

                    if( retorno.result == "ok" )
                        obras[key] = retorno;

                },
                error: function (retorno, ajaxOptions, thrownError) {
                    console.log('Obras.Item.Erro', retorno);
                },
            });
            */
        }
    }
    
	function onDeviceReady()
	{
		// Specify a shortcut for the location manager holding the iBeacon functions.
        window.locationManager = cordova.plugins.locationManager;
        console.log('locationManager:', window.locationManager);
        console.log('ready');
        
        BaasBox.login("jaimert@msn.com", "jj321456")
            .done(function (user) {
                console.log("User.Login.Done:", user);

                BaasBox.loadCollection("Beacons")
                  .done(function(res) {
                    console.log("Beacons.Todos.Done ", res);

                    for( var i=0; i < res.length; i++ ) {
                        var add = true;
                        for( x=0; x < regions.length; x++ ) {

                            if( regions[x].uuid == res[i].UID ) {
                                add = false;
                                break;
                            }
                        }

                        if( add )
                            regions.push( {uuid: res[i].UID });
                    }

                    console.log('regions:', regions);

                    // Start tracking beacons!
                    startScan();
                    
                  })
                  .fail(function(error) {
                    console.log("Beacons.Totos.Error ", error);
                  })
            })
            .fail(function (err) {
                console.log("User.Login.Fail:", err);
            })
/*
            $.ajax({
                url: 'http://54.233.65.245:9000/login',
                type: 'POST',
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                crossDomain: true,
                data: 'username=jaimert%40msn.com&password=jj321456&appcode=1234567890',
                headers: {
                    'X-BAASBOX-APPCODE': '1234567890',
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
*/
		// Display refresh timer.
		updateTimer = setInterval(displayBeaconList, 500);
	}

	function startScan()
	{
        try
        {
            // The delegate object holds the iBeacon callback functions
            // specified below.
            var delegate = new locationManager.Delegate();

            // Called continuously when ranging beacons.
            delegate.didRangeBeaconsInRegion = function(pluginResult)
            {
                for (var i in pluginResult.beacons)
                {
                    // Insert beacon into table of found beacons.
                    var beacon = pluginResult.beacons[i];
                    beacon.timeStamp = Date.now();
                    var key = beacon.uuid + ':' + beacon.major + ':' + beacon.minor;
                    beacons[key] = beacon;
                    
                    getItem(key);
                    
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
    
    
    function sortObjectByKey(obj) {
        var keys = [];
        var sorted_obj = {};

        for(var key in obj){
            if(obj.hasOwnProperty(key)){
                keys.push( obj.rssi + "$" + key );
            }
        }

        // sort keys
        keys.sort();

        // create new array based on Sorted Keys
        jQuery.each(keys, function(i, key){
            
            var arr  = key.split('$');
            var nKey = arr[1]; 
            sorted_obj[nKey] = obj[nKey];
            
        });

        return sorted_obj;
    }

    
	function displayBeaconList()
	{
		// Clear beacon list.
		$('#found-beacons').empty();

		var timeNow = Date.now();
        
		// Update beacon list.
        //beacons = sortOnKeys(beacons);
        //beacons = sortObjectByKey(beacons);
		$.each(beacons, function(key, beacon)
		{
			// Only show beacons that are updated during the last 60 seconds.
			if (beacon.timeStamp + 90000 > timeNow)
			{
                $('#warning').remove();
                
				// Map the RSSI value to a width in percent for the indicator.
				var rssiWidth = 1; // Used when RSSI is zero or greater.
				if (beacon.rssi < -100) { rssiWidth = 100; }
				else if (beacon.rssi < 0) { rssiWidth = 100 + beacon.rssi; }
                var element = null;
                var listaObras = obras[key];
                console.log('obras para a chave[' + key + ']:', listaObras);
                
                try
                {
                    if( listaObras != undefined )
                    {
                        for( var x=0; x < listaObras.length; x++ )
                        {
                            //if( beacon.proximity != "ProximityUnknown")
                            {
                                var obra = listaObras[x];
                                element = $(
                                      '<div class="mdl-cell mdl-cell--3-col mdl-cell--4-col-tablet mdl-cell--4-col-phone mdl-card mdl-shadow--3dp">'
                                    + '<div class="mdl-card__media">'
                                    + '<img src="' + obra.Card.Image + '">'
                                    + '</div>'
                                    + '<div class="mdl-card__title">'
                                    + '<h4 class="mdl-card__title-text">' + obra.Title + '</h4>'
                                    + '</div>'
                                    + '<div class="mdl-card__supporting-text">'
                                    + '<span class="mdl-typography--font-light mdl-typography--subhead">'
                                    +  obra.Card.Description
                                    + '</span>'
                                    + '</div>'
                                    + '<div class="mdl-card__actions">'
                                    + '<a class="android-link mdl-button mdl-js-button mdl-typography--text-uppercase" href="" data-upgraded=",MaterialButton">'
                                    + 'Saiba Mais'
                                    + '<i class="material-icons">chevron_right</i>'
                                    + '</a>'
                                    + '</div>'
                                    + '<div class="mdl-card__actions">'
                                    + 'Proximity: ' + beacon.proximity + '<br />'
                                    + '<div style="background:rgb(255,128,64);height:20px;width:' + rssiWidth + '%;"></div>'
                                    + '</div>'
                                    + '</div>')

                                $('#found-beacons').append(element);
                            }
                        }
                    }
                } catch(e) {
                    console.log('Erro no Display da Obras', e);
                }
                element = $(
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
                
				//$('#warning').remove();
                //$('#found-beacons').append(element);
			}
		});
	}

	return app;
})();

app.initialize();
