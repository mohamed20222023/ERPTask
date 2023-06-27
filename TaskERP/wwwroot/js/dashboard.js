


$.get({

	url: '/Chart/Chart',
	success: function (data) {
		console.log(data)
		var options = {
			chart: {
				type: 'area'
			},
			series: [{
				name: 'Employee',
				data: /*data.map(i => i.Value)*/[10,20,30,10,70,70]
			}],
			xaxis: {
				categories:/* data.map(i => i.Label)*/ [0,20,40,60,80,100,]
			}
		}

		var chart = new ApexCharts(document.querySelector("#chart"), options);


		chart.render();
	}
	})

