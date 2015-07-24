var ciceroneVirtual = {
	Init: function () {
		BaasBox.setEndPoint("http://54.232.251.170:9000");
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
				document.location.href = "login.html"; 
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
		
		Contador: function( successCallBack, failCallBack) {
			
		},	
	},

	Comentarios: {
		Novo: function() {
			return {
				Name: null,
				Email: null,
				Stars: 0,
				Comment: null
			};
		},
		
		Adicionar: function( model, successCallBack, failCallBack) {
			
		},
		
		Aprovar: function( model, successCallBack, failCallBack) {
		
		},
		
		Pendentes: function( successCallBack, failCallBack) {
			
		},
		
		Recentes: function( successCallBack, failCallBack) {
			
		},
		
		Contador: function( successCallBack, failCallBack) {
			
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
		
		Adicionar: 	function( successCallBack, failCallBack) {
			
		},
		
		Recuperar: function( deviceUID, PlatForm, successCallBack, failCallBack) {
			
		},
		
		Contador: function( successCallBack, failCallBack) {
			
		},
	},
	
	Obras: {
		Novo: function() {
			return {
				Title: null,
				CardHTML: null,
				ContentHTML: null,
				Visitors: 0,
				
			};
		},
		
		Adicionar: function( model, successCallBack, failCallBack) {
			
		},
		
		Aprovar: function( model, successCallBack, failCallBack) {
		
		},
		
		ConsultarPorBeacon: function( beaconUID, majorVersion, minorVersion, successCallBack, failCallBack) {
			
		},
		
		AdicionarVisualizacao: function( model, successCallBack, failCallBack ) {
			
		}, 
		
		MaisVisualizados: function( model, successCallBack, failCallBack ) {
			
		}, 
	},
	
	
	
	
}