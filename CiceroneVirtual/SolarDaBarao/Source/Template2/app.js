var app = (function()
{
	// Application object.
	var app = {};
    var sessionUID = null;
	
    // Specify your beacon 128bit UUIDs here.
	var regions = [];
    
	// Dictionary of beacons.
	var beacons = {};
    var obras = {};
    
	// Timer that displays list of beacons.
	var updateTimer = null;
    var hasBeaconTimer = null;
    var deviceReadyHasFired = false;
    
	app.initialize = function() {
		
        document.addEventListener('deviceready', onDeviceReady, false);
        BaasBox.setEndPoint("http://54.233.69.169:9000");
		BaasBox.appcode = "1234567890";
        
        hasBeaconTimer = setTimeout( function() {checkHasBeacons();}, 2000)

        //define tab or click event type on rool level (can be combined with modernizr)
        var iaEvent = "click";
        if (typeof navigator !== "undefined" && navigator.app) {
           iaEvent = "tap";
        }
        
        $('.ext-link').each.bind(iaEvent, function() {
            if (typeof navigator !== "undefined" && navigator.app) {
                // Mobile device.
                var linktarget = this.attr("href");
                navigator.app.loadUrl(linktarget, {openExternal: true});
            } else {
                // Possible web browser
                window.open(linktarget, "_blank");
            }
        });
        
        $("#btnSalvar").click( function() { 
            
        });

	};

    function getComments() {
        BaasBox.loadCollectionWithParams("Comentarios", {where: "Approved = true"})
          .done(function(res) {
            console.log("res ", res);

            if( res.length > 0 ) {
                
                $("#nenhumComentario").remove();

                if( $(
                for( var i=0; i < res.length; i++ ) {
                    
                    if( $("#" + formatId(res[i].id)).length == 0 ) {
                        var comment = $(
                              '<div id="' + formatId(res[i].id) + '" class="mdl-cell mdl-cell--12-col mdl-cell--12-col-tablet mdl-cell--12-col-phone mdl-card mdl-shadow--3dp">'
                            + '    <div class="mdl-card__title">'
                            + '       <h4 class="mdl-card__title-text">' + res[i].Name + '</h4>'
                            + '    </div>'
                            + '    <div class="mdl-card__supporting-text">'
                            + '       <span class="mdl-typography--font-light mdl-typography--subhead">'
                            +             res[i].Comment
                            + '       </span>'
                            + '   </div>'
                            + '   <div class="mdl-card__menu">'
                            + '       <div class="raty" id="starts' + formatId(res[i].id) + '"></div>'
                            + '       <script type="text/javascript">$("#starts' + formatId(res[i].id) + '").raty({   readOnly: true, score: ' + res[i].Stars + ' });</script>
                            + '   </div>'
                            + '   <div class="mdl-card__actions">'
                            +       res[i]._creation_date
                            + '   </div>'
                            + '</div>'
                        );
                        $("#commentaries").append(comment);
                    }
                }
            }
          })
          .fail(function(error) {
            console.log("error ", error);
          })	
    }

    app.addComment = function(email, name, stars, comment) {
        
        var model = {
				Name: name,
				Email: email,
				Stars: stars,
				Comment: comment,
                Approved: null,
                ApprovedBy: null
			};
        
        BaasBox.save(model, "Comentarios")
			  .done(function(res) {
			  	console.log("res ", res['data']);
                getComments();
			  })
			  .fail(function(error) {
			  	console.log("error ", error);
			  })
    }
    
    function getItem(key) {
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
        }
    }
    
    app.novoComentario = function() {
        
        $("#novoComentario").dialog({
            title: "Novo Comentário",
            width: $( window ).width() - 300,
            height: 350,
            modal: true,
            closeOnEscape: true,
        });

    }
        
    app.showDetails = function (id) {
        
        var html = $("#modal" + id).html();
        var title= $("#title" + id).html();
        
/*        BaasBox.loadObject("Items", id)
          .done(function(res) {
            console.log("Obras.Carregar: ", res['data']);

            res['data']['Visitors'] = res['data']['Visitors'] + 1;
            
            BaasBox.save(res['data'], "Items")
			  .done(function(res) {
			  	console.log("res ", res['data']);
  */              
                $("#dialog").html(html);
                $("#dialog").dialog({
                    title: title,
                    width: $( window ).width() - 300,
                    height:$( window ).height() - 300,
                    modal: true,
                    closeOnEscape: true,
                });
/*
			  })
			  .fail(function(error) {
			  	console.log("error ", error);
			  })
            
          })
          .fail(function(error) {
            console.log("error ", error);
          })
*/
    }
    
    function formatId(id) {
        return id.replace('-', '')
                 .replace('-', '')
                 .replace('-', '')
                 .replace('-', '')
                 .replace('-', '');
    }
    
    app.loadAll = function() {
        
        BaasBox.login("jaimert@msn.com", "jj321456")
            .done(function (user) {
                
                console.log("User.Login.Done:", user);
            
                BaasBox.loadCollection("Items")
                    .done(function(res) {
                    
                        console.log("Obras.Todos.Done ", res);
                        $('#warning').remove();
                        $('#found-beacons').empty();
                    
                        for( var i=0; i < res.length; i++ ) {
                            criarCard(res[i], null);
                        }

                      })
                      .fail(function(error) {
                        console.log("Obras.Totos.Error ", error);
                      })
            })
            .fail(function (err) {
                console.log("User.Login.Fail:", err);
            })
    }
    
	function onDeviceReady() {
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
                    
                    $("#commentaries").empty();
                    getComments();
                    
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

        deviceReadyHasFired = true;
        
		// Display refresh timer.
		updateTimer = setInterval(displayBeaconList, 500);
        //hasBeaconTimer = setTimeout( function() {checkHasBeacons();}, 2000)
	}

    function checkHasBeacons() {

        console.log('checkHasBeacons');
        console.log('beacons:', beacons);
        console.log('regions:', regions);

        var empty = true;
        for( var key in beacons ) {
            empty = false;
            break;
        }
            
        if( empty ) {
            if( regions.length == 0 && deviceReadyHasFired ) {
                
                $("#warning").text("Não foi possível encontrar o Servidor do Cicerone Virtual, por favor verifique sua conexão com a Internet!");
                
            } else {
                
                $("#warning").html("Não foi possível encontrar nenhum item do acervo nas proximidades. Clique <a href='#' onclick='app.loadAll();'>aqui</a> para carregar nssos itens cadastrados?");
                
            }
        } 
            
        
    }
    
	function startScan() {
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

    function sortByClass(a, b) {
        var vlr1 = $(a).prop('rssi');
        if( vlr1 == null )
            vlr1 = 0;

        var vlr2 = $(b).prop('rssi');
        if( vlr2 == null )
            vlr2 = 0;

        return vlr1 < vlr2;
    }
    
    function criarCard(obra, rssi) {
        
        var id = formatId(obra.id);
        if( rssi == null )
            rssi = 0;

        var rssiWidth = 1; // Used when RSSI is zero or greater.
        if (rssi < -100 ) { rssiWidth = 100; }
        else if (rssi < 0) { rssiWidth = 100 + rssi; }
        //else if (beacon.rssi > 0) { rssiWidth = 100 - beacon.rssi; }
        
        if( $("#" + id).length == 0 )
        {
            var element = $(
                          '<div id="' + id + '" rssi="' + rssi + '" class="cardObra mdl-cell mdl-cell--3-col mdl-cell--4-col-tablet mdl-cell--4-col-phone mdl-card mdl-shadow--3dp" >'
                        + ' <div class="mdl-card__media">'
                        + '     <img src="' + obra.Card.Image + '">'
                        + ' </div>'
                        + ' <div class="mdl-card__title">'
                        + '     <h4 id="title' + id + '" class="mdl-card__title-text">' + obra.Title + '</h4>'
                        + ' </div>'
                        + ' <div class="mdl-card__supporting-text">'
                        + '     <span class="mdl-typography--font-light mdl-typography--subhead">'
                        +           obra.Card.Description
                        + '     </span>'
                        + ' </div>'
                        + ' <div class="mdl-card__actions">'
                        + '     <a class="android-link mdl-button mdl-js-button mdl-typography--text-uppercase" href="javascript:app.showDetails(\'' + id +'\');" data-upgraded=",MaterialButton" >'
                        + '         Saiba Mais'
                        + '         <i class="material-icons">chevron_right</i>'
                        + '     </a>'
                        + 	'<div id="bar' + id + '" style="background:#77c159;height:1px;width:'
					    + 		rssiWidth 
                        + '%;"></div>'
                        + ' </div>'
                        + ' <div id="modal' + formatId(obra.id) + '" style="display:none;">'
                        +       obra.ContentHTML 
                        + ' </div>'        
                        + '</div>'            
                    
            );
        
            $('#found-beacons').append(element);
            
        } else {
            
            $("#" + id).prop('rssi', rssi);
            $("#bar" + id).width(rssiWidth);
        }
        
        return $("#" + id);
    }
    
	function displayBeaconList() {
        // Clear beacon list.
        //$('#found-beacons').empty();

		var timeNow = Date.now();
        
		// Update beacon list.
        //beacons = sortOnKeys(beacons);
        //beacons = sortObjectByKey(beacons);
		$.each(beacons, function(key, beacon)
		{
			// Only show beacons that are updated during the last 60 seconds.
			if (beacon.timeStamp + (2*60000) > timeNow)
			{
                $('#warning').remove();
                
				// Map the RSSI value to a width in percent for the indicator.

                var element = null;
                var listaObras = obras[key];
                console.log('obras para a chave[' + key + ']:', listaObras);
                
                try
                {
                    if( listaObras != undefined )
                    {
                        for( var x=0; x < listaObras.length; x++ )
                        {
                            var obra = listaObras[x];
                            var title = $("#" + formatId(obra.id));
                            //if( title.length == 0 ) //if( beacon.proximity.indexOf("Near") > 0 && title.length == 0 )
                            //{
                            
                            criarCard(obra, beacon.rssi);   
                            //} else {
                            //    criarCard(obra, beacon.rssi);
                            //}
                        }
                        
                        var elem = $('#found-beacons').find('.cardObra').sort(sortByClass);
                        var allElem = elem.get();
                        (function append() {

                            var $this = $(allElem.shift());
                            $('#found-beacons').append($this.fadeOut('slow')).find($this).fadeIn('slow', function () {
                                if (allElem.length > 0) window.setTimeout(append);
                            });
                        })();

                    }
                    
                } catch(e) {
                    console.log('Erro no Display da Obras', e);
                }
                
                //$('#warning').remove();
                /*
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
                
                $('#found-beacons').append(element);
                */
				
			}
		});
	}

	return app;
    
})();

app.initialize();

