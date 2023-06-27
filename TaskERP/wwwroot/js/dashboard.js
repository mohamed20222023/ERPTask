


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
				data: data.map(i => i.Value)
			}],
			xaxis: {
				categories: data.map(i => i.Label)
			}
		}

		var chart = new ApexCharts(document.querySelector("#chart"), options);


		chart.render();
	}
	})

