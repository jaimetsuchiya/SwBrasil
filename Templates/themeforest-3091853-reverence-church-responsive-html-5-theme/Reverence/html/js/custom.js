jQuery.noConflict();



/*********** Hover ************/
	$(function() {
		// START
		$(".fade").css("opacity","0.40");
		
		// ON MOUSE OVER
		$(".fade").hover(function () { 
		$(this).stop().animate({
		opacity: 1.0
		}, "slow");
	},
 
	// ON MOUSE OUT
	function () {
		$(this).stop().animate({
		opacity: 0.40
		}, "slow");
	});
});
/**************************************/




/*********** Scroll to Top ************/
jQuery(function() {
	jQuery(window).scroll(function() {
		if(jQuery(this).scrollTop() != 0) {
			jQuery('#toTop').fadeIn();	
		} else {
			jQuery('#toTop').fadeOut();
		}
	});
	jQuery('#toTop').click(function() {
		jQuery('body,html').animate({scrollTop:0},800);
	});	
});
/**************************************/




/************* Top Menu ***************/

jQuery(document).ready(function(){	
	// Initialize menu
	jQuery('ul.sf-menu').supersubs({ 
		minWidth: 4,  
		maxWidth: 14
		}).superfish({
			autoArrows:false, 
			dropShadows:false,  
			delay: 500, 
			animation: {opacity:'show',height:'show'},  
			easing: 'swing', 
			speed:400
		}); 
	jQuery('ul.sf-menu > li').addClass('top');
});

/**************************************/



/********** Portfolio Hover ***********/

jQuery(function(){ 
	jQuery('#portfolio-list li').hover(function() {													  
		jQuery(this).find('.overlay').fadeIn(700);
	},function() {
		jQuery(this).find('.overlay').fadeOut(400);
	});
});

/**************************************/




/*************** TABS *****************/
jQuery(function() {
	jQuery("ul.tabs").tabs("div.panes > div", {effect:'fade'});
});
/**************************************/



// jQuery Input Hints plugin
// Copyright (c) 2009 Rob Volk
// http://www.robvolk.com
jQuery.fn.inputHints=function(){jQuery(this).each(function(i){jQuery(this).val(jQuery(this).attr('title'));});jQuery(this).focus(function(){if(jQuery(this).val()==jQuery(this).attr('title'))
jQuery(this).val('');}).blur(function(){if(jQuery(this).val()=='')
jQuery(this).val(jQuery(this).attr('title'));});};


jQuery(document).ready(function() {
	jQuery(function() {
		jQuery("#social-icons img")
			.mouseover(function() { 
				var src = jQuery(this).attr("src").match(/[^\.]+/) + "_hover.png";
				jQuery(this).attr("src", src);
			})
			.mouseout(function() {
				var src = jQuery(this).attr("src").replace("_hover", "");
				jQuery(this).attr("src", src);
			});
	});
	
	//jQuery('.sub-menu').append('<li class="shadow-container"><span class="shadow-left"></span><span class="shadow-right"></span></li>');
	//jQuery('.sub-menu li:last-child').prev().css('border-bottom', 'solid 5px #464f5c').css('padding-bottom', '10px');
	//jQuery('<div class="shadow-container"><span class="shadow-left"></span><span class="shadow-right"></span></div>').insertAfter('.sub-menu');
	
    jQuery('input[title], textarea[title]').inputHints();
	
	/*-- Toggles --*/
	jQuery(".toggle > li > div").hide();
	jQuery(".toggle > li > a").click(function(e){
	e.preventDefault;
	jQuery(this).toggleClass("active").next().slideToggle('normal');

		return false;
	});
	//jQuery('.happy-clients ul li:odd').css('float', 'right');
});




/********* Contact Widget *************/
function checkemail(emailaddress){
	var pattern = new RegExp(/^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i); 
	return pattern.test(emailaddress); 
}

jQuery(document).ready(function(){ 
	jQuery('#registerErrors, .widgetinfo').hide();								
	jQuery('#contactFormWidget input#wformsend').click(function(){ 
		var $name 	= jQuery('#wname').val();
		var $email 	= jQuery('#wemail').val();
		var $message = jQuery('#wmessage').val();
		var $contactemail = jQuery('#wcontactemail').val();
		var $contacturl = jQuery('#wcontacturl').val();
		
		if ($name != '' && $name.length < 3){ $nameshort = true; } else { $nameshort = false; }
		if ($name != '' && $name.length > 30){ $namelong = true; } else { $namelong = false; }
		if ($email != '' && checkemail($email)){ $emailerror = true; } else { $emailerror = false; }
		if ($message != '' && $message != 'Message' && $message.length < 3){ $messageshort = true; } else { $messageshort = false; }

		
		jQuery('#contactFormWidget .loading').animate({opacity: 1}, 250);
		
		if ($name != '' && $nameshort != true && $namelong != true && $email != '' && $emailerror != false && $message != '' && $messageshort != true && $contactemail != ''){ 
			jQuery.post($contacturl, 
				{type: 'widget', contactemail: $contactemail, name: $name, email: $email, message: $message}, 
				function(data){
					jQuery('#contactFormWidget .loading').animate({opacity: 0}, 250);
					jQuery('.form').fadeOut();
					jQuery('#bottom #wname, #bottom #wemail, #bottom #wmessage').css({'border':'0'});
					jQuery('.widgeterror').hide();
					jQuery('.widgetinfo').fadeIn('slow');
					jQuery('.widgetinfo').delay(2000).fadeOut(1000, function(){ 
						jQuery('#wname, #wemail, #wmessage').val('');
						jQuery('.form').fadeIn('slow');
					});
				}
			);
			
			return false;
		} else {
			jQuery('#contactFormWidget .loading').animate({opacity: 0}, 250);
			jQuery('.widgeterror').hide();
			jQuery('.widgeterror').fadeIn('fast');
			jQuery('.widgeterror').delay(3000).fadeOut(1000);
			
			if ($name == '' || $name == 'Name' || $nameshort == true || $namelong == true){ 
				jQuery('#wname').css({'border':'1px solid #941e1c'}); 
			} else { 
				jQuery('#wname').css({'border':'1px solid #787878'}); 
			}
			
			if ($email == '' || $email == 'Email' || $emailerror == false){ 
				jQuery('#wemail').css({'border':'1px solid #941e1c'}); 
			} else { 
				jQuery('#wemail').css({'border':'1px solid #787878'}); 
			}
			
			if ($message == '' || $message == 'Message' || $messageshort == true){ 
				jQuery('#wmessage').css({'border':'1px solid #941e1c'}); 
			} else { 
				jQuery('#wmessage').css({'border':'1px solid #787878'}); 
			}
			
			return false;
		}
	});
});



/**************************************/

jQuery(document).ready(function(){ 
	jQuery('.tooltip').hover(function() {
		this.tip = this.title;
		jQuery(this).append('<div class="toolTipWrapper"><span class="tip">'+this.tip+'</span></div>');
		this.title = "";
		this.width = jQuery(this).width();
		
		jQuery(this).find('.toolTipWrapper').css('left', -(this.width));
		jQuery('.toolTipWrapper').fadeIn(300);
	},
	function() {
		jQuery('.toolTipWrapper').fadeOut(100);
		jQuery(this).find('.toolTipWrapper').remove();
			this.title = this.tip;
		}
	);
    
	
	// Under construction form
	jQuery('#ucerror, .errorarr').css('display', 'none');
	jQuery('.ucform').submit(function() {
		var $email 	= jQuery('#ucemail').val();  
		if ($email != '' && checkemail($email)){ $emailerror = true; } else { $emailerror = false; }
		if ($email == '' || $emailerror == false){ 
			jQuery('#ucemail').css({'border-left':'4px solid red'}); 
			jQuery('#ucerror').html('Please enter a valid e-mail address')
			jQuery('#ucerror, .errorarr').show('normal');
		} else { 
			jQuery('#ucemail').css({'border':'none'});
			jQuery('#ucerror').html('We will inform you of the updates.');
			jQuery('#ucerror, .errorarr').show('normal');
		
		}
	  	
	  return false;
	}); 
});




jQuery(document).ready(function(){
	jQuery('.sf-menu').mobileMenu();
});