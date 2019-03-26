//var ctx = document.getElementById("ChartGraficoVolumeMensalPorModelo").getContext('2d');

//var myChart = new Chart(ctx, {
//    type: 'bar',
//    data: {

//        labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December']/*arrayName*/,
//        datasets: [{
//            label: 'dataset1',
//            backgroundColor: 'rgba(255, 99, 132, 0.2)',
//            borderColor: 'rgba(255,99,132,1)',
//            data: [10, 20, 30, 40, 50, 60, 10, 20, 30, 40, 50, 60]/*arrayValues*/,
//            borderWidth: 1
//        }, {
//            label: 'dataset2',
//            backgroundColor: 'rgba(54, 162, 235, 0.2)',
//            borderColor: 'rgba(54, 162, 235, 1)',
//            data: [15, 25, 35, 45, 55, 65, 10, 20, 30, 40, 50, 60]/*arrayValues*/,
//            borderWidth: 1
//        }, {
//            label: 'dataset3',
//            backgroundColor: 'rgba(255, 206, 86, 0.2)',
//            borderColor: 'rgba(255, 206, 86, 1)',

//            data: [10, 20, 30, 40, 50, 60, 10, 20, 30, 40, 50, 60]/*arrayValues*/,
//            borderWidth: 1
//        }, {
//            label: 'dataset4',
//            backgroundColor: 'rgba(75, 192, 192, 0.2)',
//            borderColor: 'rgba(75, 192, 192, 1)',

//            data: [1, 20, 3, 40, 5, 60, 10, 20, 30, 40, 50, 60]/*arrayValues*/,
//            borderWidth: 1
//        }]
//    },
//    options: {
//        scales: {
//            yAxes: [{
//                ticks: {
//                    beginAtZero: true
//                }
//            }]
//        },
//        responsive: true,
//        legend: {
//            position: 'top',
//        },
//        title: {
//            display: true,
//            text: 'Volume Mensal Por Modelo'
//        }
//    }

//});



function GraficoVolumeMensalPorModelo() {
    var url = '/Home/GraficoVolumeMensalPorModelo';

    $.ajax({
        url: url,
        type: 'POST',
        datatype: "json",
        success: function (result) {

            var obj = JSON.parse(result);
            console.log(obj[0]);

            var arrayValues = {};
            var arrayLabels = {};

            for (var i = 0; i < obj.length; i++) {
                arrayValues[i] = Object.values(obj[i]);
                arrayValues[i] = arrayValues[i].splice(3, 12);

                arrayLabels[i] = Object.values(obj[i]);
                arrayLabels[i] = arrayLabels[i].splice(1,1);
            }

            var ctx = document.getElementById("ChartGraficoVolumeMensalPorModelo").getContext('2d');

            var myChart = new Chart(ctx, {
                type: 'bar',
                data: {

                    labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December']/*arrayName*/,
                    datasets: [{
                        label: arrayLabels[0],
                        backgroundColor: 'rgba(255, 99, 132, 0.2)',
                        borderColor: 'rgba(255,99,132,1)',
                        data: arrayValues[0],
                        borderWidth: 1
                    }, {
                            label: arrayLabels[1],
                        backgroundColor: 'rgba(54, 162, 235, 0.2)',
                        borderColor: 'rgba(54, 162, 235, 1)',
                            data: arrayValues[1],
                        borderWidth: 1
                    }, {
                            label: arrayLabels[2],
                        backgroundColor: 'rgba(255, 206, 86, 0.2)',
                        borderColor: 'rgba(255, 206, 86, 1)',

                            data: arrayValues[2],
                        borderWidth: 1
                    }, {
                            label: arrayLabels[3],
                        backgroundColor: 'rgba(75, 192, 192, 0.2)',
                        borderColor: 'rgba(75, 192, 192, 1)',

                            data: arrayValues[3],
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    },
                    responsive: true,
                    legend: {
                        position: 'top',
                    },
                    title: {
                        display: true,
                        text: 'Volume Mensal Por Modelo'
                    }
                }

            });


        },
        erro: function () {
            alert("Erro ao carregar grafico!");
        }
    });
}