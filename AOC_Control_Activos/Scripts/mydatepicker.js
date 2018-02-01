$(document).ready(function(){
	$.datetimepicker.setLocale('es');
	$('#search-from-date').datetimepicker({
		i18n:{
		  es:{
		   months:[
		    'Enero','Febrero','Marzo','Abril',
		    'Mayo','Junio','Julio','Agosto',
		    'Septiembre','Octubre','Noviembre','Diciembre',
		   ],
		   dayOfWeek:[
		    "Do", "Lu", "Ma", "Mi", 
		    "Ju", "Vi", "Sa",
		   ]
		  }
		 },
	 timepicker:false,
	 format:'Y-m-d'
	});	
	$('#search-to-date').datetimepicker({
	 timepicker:false,
	 format:'Y-m-d'
	});	
	$('#fromDateIcon').click(function(){
		$('#search-from-date').focus();

	});
	$('#toDateIcon').click(function(){
		$('#search-to-date').focus();
	});

	$('#search-to-date').change(function(){
		if($('#search-from-date').val()=="")
			$('#search-from-date').val($('#search-to-date').val());

		var fromDate=$('#search-from-date').val();
		var toDate=$('#search-to-date').val();
		if(fromDate>toDate)
			$('#search-from-date').val($('#search-to-date').val());
	});

	$('#search-from-date').change(function(){
		if($('#search-to-date').val()=="")
			$('#search-ti-date').val($('#search-from-date').val());

		var fromDate=$('#search-from-date').val();
		var toDate=$('#search-to-date').val();

		if(fromDate>toDate)
			$('#search-to-date').val($('#search-from-date').val());
	});
});