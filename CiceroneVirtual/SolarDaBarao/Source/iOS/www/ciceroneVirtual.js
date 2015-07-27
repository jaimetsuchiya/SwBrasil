var ciceroneVirtual = {
    
    url: "http://54.233.65.245:9000",
    app: "1234567890",
    
	Init: function () {
		BaasBox.setEndPoint("http://54.233.65.245:9000");
		BaasBox.appcode = "1234567890";
	},
	
	User : {
		
		Login: function(user, password, successCallBack, failCallBack) {
			BaasBox.login(user, password)
				.done(function (user) {
					console.log("User.Login.Done:", user);
	
					if( successCallBack != null )
						successCallBack(user);
				})
				.fail(function (err) {
					console.log("User.Login.Fail:", err);
					if( failCallBack != null )
						failCallBack(err);
				})
		},
		
		LogOff: function() {
			BaasBox.logout()
			  .done(function (res) {
			  	console.log('User.LogOff.Done:' + res);
				document.location.href = "Login.html";
			  })
			  .fail(function (error) {
			  	console.log("User.LogOff.Fail:" + error);
				document.location.href = "Login.html";
			  })
			  
		},
		
		CurrentUser : function(callback) {
			
			BaasBox.fetchCurrentUser()
			  .done(function(res) {
			  	console.log("User.CurrentUser.Done:", res['data']);
				if( callback != null )
					callback(res["data"]);
			  })
			  .fail(function(error) {
			  	console.log("User.CurrentUser.Fail:", error);
				document.location.href = "Login.html?msg=Sessao+Expirada!"; 
			  })
		},	
	
		ChangePassword: function (currentPassword, newPassword, successCallBack, failCallBack) {
			BaasBox.changePassword(currentPassword, newPassword)
			  .done(function(res) {
			  	 console.log("User.ChangePassword.Done:", res);
				 if(successCallBack != null )
				 	successCallBack(res);
			  })
			  .fail(function(error) {
			  	 console.log("User.ChangePassword.Fail:", error);
				 if(failCallBack != null )
				 	failCallBack(error);
			  })
		},

		ResetPassowrd: function(successCallBack, failCallBack) {
			BaasBox.resetPassword()
			  .done(function(res) {
			  	console.log("User.ResetPassword.Done: ", res);
				if(successCallBack != null )
				 	successCallBack(res);
			  })
			  .fail(function(error) {
			  	console.log("User.ResetPassword.Fail:", error);
				if(failCallBack != null )
				 	failCallBack(error);
			  })
		},
		
		Todos: function( successCallBack, failCallBack) {
			
            BaasBox.fetchUsers()
			  .done(function(res) {
			  	console.log("res ", res['data']);
                
                if( successCallBack != null )
                    successCallBack(res['data']);
			  })
			  .fail(function(error) {
			  	console.log("error ", error);
                
                if( failCallBack != null )
                    failCallBack(error);
			  })
		},	
	},

	Comentarios: {
		Novo: function() {
			return {
				Name: null,
				Email: null,
				Stars: 0,
				Comment: null,
                Approved: null,
                ApprovedBy: null,
                CreatedAt: null
			};
		},
		
		Salvar: function( model, successCallBack, failCallBack) {
		
            BaasBox.save(model, "Comentarios")
			  .done(function(res) {
			  	console.log("res ", res['data']);
                
                if( successCallBack != null )
                    successCallBack(res['data']);
			  })
			  .fail(function(error) {
			  	console.log("error ", error);
                
                if( failCallBack != null )
                    failCallBack(error);
			  })	
		},
		
		Pendentes: function( successCallBack, failCallBack) {
			BaasBox.loadCollectionWithParams("Comentarios", {where: "Approved is null"})
			  .done(function(res) {
			  	console.log("res ", res);
                
                if( successCallBack != null )
                    successCallBack(res);
			  })
			  .fail(function(error) {
			  	console.log("error ", error);
                
                if( failCallBack != null )
                    failCallBack(error);
			  })	
		},
		
		Recentes: function( successCallBack, failCallBack) {
			BaasBox.loadCollectionWithParams("Obras", {orderBy: "CreatedAt desc"})
			  .done(function(res) {
			  	console.log("res ", res['data']);
                
                if( successCallBack != null )
                    successCallBack(res['data']);
			  })
			  .fail(function(error) {
			  	console.log("error ", error);
                
                if( failCallBack != null )
                    failCallBack(error);
			  })
		},
		
		Todos: function( successCallBack, failCallBack) {
            
			BaasBox.loadCollection("Comentarios ")
			  .done(function(res) {
			  	console.log("res ", res['data']);
                
                if( successCallBack != null )
                    successCallBack(res['data']);
			  })
			  .fail(function(error) {
			  	console.log("error ", error);
                
                if( failCallBack != null )
                    failCallBack(error);
			  })
		},
	},
	
	Visitas: {
		
		Novo: function() {
			return {
				Name: null,
				Email: null,
				PhoneNumber: null,
				DeviceUID: null,
				PlatForm: null,
				LastVisit: null,
			};
		},
		
		Salvar: 	function( successCallBack, failCallBack) {
            
			BaasBox.save(model, "Visitas")
			  .done(function(res) {
			  	console.log("res ", res['data']);
                
                if( successCallBack != null )
                    successCallBack(res['data']);
			  })
			  .fail(function(error) {
			  	console.log("error ", error);
                
                if( failCallBack != null )
                    failCallBack(error);
			  })	
		},
		
		Recuperar: function( deviceUID, PlatForm, successCallBack, failCallBack) {
			
		},
		
		Todos: function( successCallBack, failCallBack) {
			
		},
	},
	
	Obras: {
        
		Novo: function() {
			return {
				Title: null,
				Card: {
                    Description: null,
                    Image: null
                },
				ContentHTML: null,
				Visitors: 0,
                Beacon: null
			};
		},
		
        Carregar: function( id, successCallBack, failCallBack) {
            
            BaasBox.loadObject("Items", id)
			  .done(function(res) {
			  	console.log("Obras.Carregar: ", res['data']);
                
                if( successCallBack != null )
                    successCallBack(res['data']);
			  })
			  .fail(function(error) {
			  	console.log("error ", error);
                
                if( failCallBack != null )
                    failCallBack(error);
			  })
 
		},
        
		Salvar: function( model, successCallBack, failCallBack) {
            
			BaasBox.save(model, "Items")
			  .done(function(res) {
			  	console.log("res ", res['data']);
                
                if( successCallBack != null )
                    successCallBack(res['data']);
			  })
			  .fail(function(error) {
			  	console.log("error ", error);
                
                if( failCallBack != null )
                    failCallBack(error);
			  })	
		},
		
		ConsultarPorBeacon: function( beaconUID, majorVersion, minorVersion, successCallBack, failCallBack) {
		  
            BaasBox.loadCollectionWithParams("Items", {where: "Beacon.UID='{0}' and Beacon.Major='{1}' and Beacon.Minor='{2}'".replace("{0}", beaconUID).replace("{1}", majorVersion).replace("{2}", minorVersion) })
			  .done(function(res) {
			  	console.log("res ", res['data']);
                
                if( successCallBack != null )
                    successCallBack(res['data']);
			  })
			  .fail(function(error) {
			  	console.log("error ", error);
                
                if( failCallBack != null )
                    failCallBack(error);
			  })	
		},
		
		AdicionarVisualizacao: function( model, successCallBack, failCallBack ) {
			
            BaasBox.loadCollectionWithParams("Items", {orderBy: "Visitors"})
			  .done(function(res) {
			  	console.log("res ", res['data']);
                
                if( successCallBack != null )
                    successCallBack(res['data']);
			  })
			  .fail(function(error) {
			  	console.log("error ", error);
                
                if( failCallBack != null )
                    failCallBack(error);
			  })
		}, 
		
		MaisVisualizados: function( model, successCallBack, failCallBack ) {
			
		}, 
        
        Todos: function( successCallBack, failCallBack ) {
            
            $.ajax({

                url: (ciceroneVirtual.url + '/document/Beacons?page=0&recordsPerPage=50'),
                type: "GET",
                datatype: "json",
                contentType: "application/json; charset=utf-8",
                crossDomain: true,
                async: true,
                success: function (retorno) {
                    successCallBack(retorno);
                },
                error: function (retorno, ajaxOptions, thrownError) {
                    failCallBack(retorno);
                },
            });
        },
        
        ObrasNaoAssociadas: function( successCallBack, failCallBack) {
		  
            BaasBox.loadCollectionWithParams("Items", {where: "Beacon is null" })
			  .done(function(res) {
			  	console.log("res ", res);
                
                if( successCallBack != null )
                    successCallBack(res);
			  })
			  .fail(function(error) {
			  	console.log("error ", error);
                
                if( failCallBack != null )
                    failCallBack(error);
			  })
		},

        AssociarBeacon: function( model, beaconId, successCallBack, failCallBack) {
            
            BaasBox.loadObject("Beacons", beaconId)
			  .done(function(beacon) {
			     
                console.log("Beacons.Load", beacon['data']);

                model.Beacon = {
                    UID: beacon['data'].UID,
                    Major: beacon['data'].Major,
                    Minor: beacon['data'].Minor
                };
                
                console.log("Obra.Model", model);
                
                BaasBox.save(model, "Items")
                  .done(function(res) {
                    console.log("Obra.Salvar", beacon['data']);

                    beacon['data'].Associated = true;
                    ciceroneVirtual.Beacons.Salvar(beacon['data'], function(data) {

                        if( successCallBack != null )
                            successCallBack(data);
                        return;

                    }, function( fail ) {
                        if( failCallBack != null )
                            failCallBack(fail);
                        return;
                    });
                  })
                  .fail(function(error) {
                    console.log("error ", error);

                    if( failCallBack != null )
                        failCallBack(error);
                    return;
                  })	    
			  })
			  .fail(function(error) {
			  	console.log("error ", error);
                if( failCallBack != null )
                        failCallBack(error);
                return;
			  })
		},
	},
	
	Beacons: {
        
        Novo: function() {
			return {
				UID: null,
				Major: null,
				Minor: 0,
				Battery: null,
                LastChange: null,
                Associated: false,
                id: null
			};
		},
        
        Carregar: function( id, successCallBack, failCallBack) {
            
            BaasBox.loadObject("Beacons", id)
			  .done(function(res) {
			  	console.log("res ", res['data']);
                
                if( successCallBack != null )
                    successCallBack(res['data']);
			  })
			  .fail(function(error) {
			  	console.log("error ", error);
                
                if( failCallBack != null )
                    failCallBack(error);
			  })
 
		},
        
        Editar: function( uid, major, minor, successCallBack, failCallBack ) {
            
            BaasBox.loadCollectionWithParams("Beacons", {where: "UID='{0}' and major='{1}' and minor='{2}'".replace("{0}", uid).replace("{1}", major).replace("{2}", minor) })
			  .done(function(res) {
			  	console.log("res ", res['data']);
                
                if( successCallBack != null )
                    successCallBack(res['data']);
			  })
			  .fail(function(error) {
			  	console.log("error ", error);
                
                if( failCallBack != null )
                    failCallBack(error);
			  })	
        },
        
        Salvar: function( model, successCallBack, failCallBack) {
		
            var query = "UID='{0}' and Major='{1}' and Minor='{2}' and id".replace("{0}", model.UID).replace("{1}", model.Major).replace("{2}", model.Minor);
            if( model.id == null )
                query+= " IS NOT NULL"
            else
                query+= " <> '" + model.id + "'";
            console.log('query: ', query);
            
            BaasBox.loadCollectionWithParams("Beacons", {where: query })
            .done(function(res) {
			  	console.log("query res ", res);
                
                if( res.length == 0 ) {
                    BaasBox.save(model, "Beacons")
                      .done(function(res) {
                        console.log("res ", res['data']);

                        if( successCallBack != null )
                            successCallBack(res['data']);
                      })
                      .fail(function(error) {
                        console.log("error ", error);

                        if( failCallBack != null )
                            failCallBack(error);
                      })	
                } else {
                    var error = {
                        errorMsg : "Dados Inválidos, Beacon duplicado!"
                    }

                    if( failCallBack != null )
                        failCallBack(error);
                }
			  })
			  .fail(function(error) {
			  	console.log("error ", error);
                
                if( failCallBack != null )
                    failCallBack(error);
			  })	
            
            
		}, 
        
        Disponiveis: function( successCallBack, failCallBack) {
			BaasBox.loadCollectionWithParams("Beacons", {where: "Associated=false"})
			  .done(function(res) {
			  	console.log("res ", res['data']);
                
                if( successCallBack != null )
                    successCallBack(res['data']);
			  })
			  .fail(function(error) {
			  	console.log("error ", error);
                
                if( failCallBack != null )
                    failCallBack(error);
			  })	
		},
        
        Relatorio01: function( successCallBack, failCallBack) {
            
			BaasBox.loadCollectionWithParams("Beacons", {where: "Batery=weak"})
			  .done(function(res) {
			  	console.log("res ", res['data']);
                
                if( successCallBack != null )
                    successCallBack(res['data']);
			  })
			  .fail(function(error) {
			  	console.log("error ", error);
                
                if( failCallBack != null )
                    failCallBack(error);
			  })	
		},
        
        Todos: function( successCallBack, failCallBack) {
            
			BaasBox.loadCollection("Beacons")
			  .done(function(res) {
			  	console.log("res ", res);
                
                if( successCallBack != null )
                    successCallBack(res);
			  })
			  .fail(function(error) {
			  	console.log("error ", error);
                
                if( failCallBack != null )
                    failCallBack(error);
			  })
		},

        BeaconsNaoAssociadas: function( successCallBack, failCallBack) {
		  
            BaasBox.loadCollectionWithParams("Beacons", {where: "Associated = false" })
			  .done(function(res) {
			  	console.log("res ", res);
                
                if( successCallBack != null )
                    successCallBack(res);
			  })
			  .fail(function(error) {
			  	console.log("error ", error);
                
                if( failCallBack != null )
                    failCallBack(error);
			  })
		}
    },
	
}