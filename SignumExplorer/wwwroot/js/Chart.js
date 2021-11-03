
function CreateColumnChart() {


    am4core.ready(function () {

        // Themes begin
        am4core.useTheme(am4themes_animated);
        // Themes end

        // Create chart instance
        var chart = am4core.create("chartdiv", am4charts.XYChart3D);

        // Add data
        chart.data = [{
            "country": "USA",
            "visits": 4025
        }, {
            "country": "China",
            "visits": 1882
        }, {
            "country": "Japan",
            "visits": 1809
        }, {
            "country": "Germany",
            "visits": 1322
        }, {
            "country": "UK",
            "visits": 1122
        }, {
            "country": "France",
            "visits": 1114
        }, {
            "country": "India",
            "visits": 984
        }, {
            "country": "Spain",
            "visits": 711
        }, {
            "country": "Netherlands",
            "visits": 665
        }, {
            "country": "Russia",
            "visits": 580
        }, {
            "country": "South Korea",
            "visits": 443
        }, {
            "country": "Canada",
            "visits": 441
        }, {
            "country": "Brazil",
            "visits": 395
        }, {
            "country": "Italy",
            "visits": 386
        }, {
            "country": "Australia",
            "visits": 384
        }, {
            "country": "Taiwan",
            "visits": 338
        }, {
            "country": "Poland",
            "visits": 328
        }];

        // Create axes
        let categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
        categoryAxis.dataFields.category = "country";
        categoryAxis.renderer.labels.template.rotation = 270;
        categoryAxis.renderer.labels.template.hideOversized = false;
        categoryAxis.renderer.minGridDistance = 20;
        categoryAxis.renderer.labels.template.horizontalCenter = "right";
        categoryAxis.renderer.labels.template.verticalCenter = "middle";
        categoryAxis.tooltip.label.rotation = 270;
        categoryAxis.tooltip.label.horizontalCenter = "right";
        categoryAxis.tooltip.label.verticalCenter = "middle";

        let valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
        valueAxis.title.text = "Countries";
        valueAxis.title.fontWeight = "bold";

        // Create series
        var series = chart.series.push(new am4charts.ColumnSeries3D());
        series.dataFields.valueY = "visits";
        series.dataFields.categoryX = "country";
        series.name = "Visits";
        series.tooltipText = "{categoryX}: [bold]{valueY}[/]";
        series.columns.template.fillOpacity = .8;

        var columnTemplate = series.columns.template;
        columnTemplate.strokeWidth = 2;
        columnTemplate.strokeOpacity = 1;
        columnTemplate.stroke = am4core.color("#FFFFFF");

        columnTemplate.adapter.add("fill", function (fill, target) {
            return chart.colors.getIndex(target.dataItem.index);
        })

        columnTemplate.adapter.add("stroke", function (stroke, target) {
            return chart.colors.getIndex(target.dataItem.index);
        })

        chart.cursor = new am4charts.XYCursor();
        chart.cursor.lineX.strokeOpacity = 0;
        chart.cursor.lineY.strokeOpacity = 0;

    }); // end am4core.ready()
}

function CreateCandleStick() {

    am4core.ready(function () {

        // Themes begin
        am4core.useTheme(am4themes_animated);
        // Themes end

        // Create chart
        var chart = am4core.create("chartcandle", am4charts.XYChart);
        chart.padding(0, 15, 0, 15);

        // Load data
        chart.dataSource.url = "https://www.amcharts.com/wp-content/uploads/assets/stock/MSFT.csv";
        chart.dataSource.parser = new am4core.CSVParser();
        chart.dataSource.parser.options.useColumnNames = true;
        chart.dataSource.parser.options.reverse = true;

        // the following line makes value axes to be arranged vertically.
        chart.leftAxesContainer.layout = "vertical";

        // uncomment this line if you want to change order of axes
        //chart.bottomAxesContainer.reverseOrder = true;

        var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
        dateAxis.renderer.grid.template.location = 0;
        dateAxis.renderer.ticks.template.length = 8;
        dateAxis.renderer.ticks.template.strokeOpacity = 0.1;
        dateAxis.renderer.grid.template.disabled = true;
        dateAxis.renderer.ticks.template.disabled = false;
        dateAxis.renderer.ticks.template.strokeOpacity = 0.2;
        dateAxis.renderer.minLabelPosition = 0.01;
        dateAxis.renderer.maxLabelPosition = 0.99;
        dateAxis.keepSelection = true;
        dateAxis.minHeight = 30;

        dateAxis.groupData = true;
        dateAxis.minZoomCount = 5;

        // these two lines makes the axis to be initially zoomed-in
        // dateAxis.start = 0.7;
        // dateAxis.keepSelection = true;

        var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
        valueAxis.tooltip.disabled = true;
        valueAxis.zIndex = 1;
        valueAxis.renderer.baseGrid.disabled = true;
        // height of axis
        valueAxis.height = am4core.percent(65);

        valueAxis.renderer.gridContainer.background.fill = am4core.color("#000000");
        valueAxis.renderer.gridContainer.background.fillOpacity = 0.05;
        valueAxis.renderer.inside = true;
        valueAxis.renderer.labels.template.verticalCenter = "bottom";
        valueAxis.renderer.labels.template.padding(2, 2, 2, 2);

        //valueAxis.renderer.maxLabelPosition = 0.95;
        valueAxis.renderer.fontSize = "0.8em"

        var series = chart.series.push(new am4charts.CandlestickSeries());
        series.dataFields.dateX = "Date";
        series.dataFields.openValueY = "Open";
        series.dataFields.valueY = "Close";
        series.dataFields.lowValueY = "Low";
        series.dataFields.highValueY = "High";
        series.clustered = false;
        series.tooltipText = "open: {openValueY.value}\nlow: {lowValueY.value}\nhigh: {highValueY.value}\nclose: {valueY.value}";
        series.name = "MSFT";
        series.defaultState.transitionDuration = 0;

        var valueAxis2 = chart.yAxes.push(new am4charts.ValueAxis());
        valueAxis2.tooltip.disabled = true;
        // height of axis
        valueAxis2.height = am4core.percent(35);
        valueAxis2.zIndex = 3
        // this makes gap between panels
        valueAxis2.marginTop = 30;
        valueAxis2.renderer.baseGrid.disabled = true;
        valueAxis2.renderer.inside = true;
        valueAxis2.renderer.labels.template.verticalCenter = "bottom";
        valueAxis2.renderer.labels.template.padding(2, 2, 2, 2);
        //valueAxis.renderer.maxLabelPosition = 0.95;
        valueAxis2.renderer.fontSize = "0.8em"

        valueAxis2.renderer.gridContainer.background.fill = am4core.color("#000000");
        valueAxis2.renderer.gridContainer.background.fillOpacity = 0.05;

        var series2 = chart.series.push(new am4charts.ColumnSeries());
        series2.dataFields.dateX = "Date";
        series2.clustered = false;
        series2.dataFields.valueY = "Volume";
        series2.yAxis = valueAxis2;
        series2.tooltipText = "{valueY.value}";
        series2.name = "Series 2";
        // volume should be summed
        series2.groupFields.valueY = "sum";
        series2.defaultState.transitionDuration = 0;

        chart.cursor = new am4charts.XYCursor();

        var scrollbarX = new am4charts.XYChartScrollbar();

        var sbSeries = chart.series.push(new am4charts.LineSeries());
        sbSeries.dataFields.valueY = "Close";
        sbSeries.dataFields.dateX = "Date";
        scrollbarX.series.push(sbSeries);
        sbSeries.disabled = true;
        scrollbarX.marginBottom = 20;
        chart.scrollbarX = scrollbarX;
        scrollbarX.scrollbarChart.xAxes.getIndex(0).minHeight = undefined;



        /**
         * Set up external controls
         */

        // Date format to be used in input fields
        var inputFieldFormat = "yyyy-MM-dd";

        document.getElementById("b1m").addEventListener("click", function () {
            var max = dateAxis.groupMax["day1"];
            var date = new Date(max);
            am4core.time.add(date, "month", -1);
            zoomToDates(date);
        });

        document.getElementById("b3m").addEventListener("click", function () {
            var max = dateAxis.groupMax["day1"];
            var date = new Date(max);
            am4core.time.add(date, "month", -3);
            zoomToDates(date);
        });

        document.getElementById("b6m").addEventListener("click", function () {
            var max = dateAxis.groupMax["day1"];
            var date = new Date(max);
            am4core.time.add(date, "month", -6);
            zoomToDates(date);
        });

        document.getElementById("b1y").addEventListener("click", function () {
            var max = dateAxis.groupMax["day1"];
            var date = new Date(max);
            am4core.time.add(date, "year", -1);
            zoomToDates(date);
        });

        document.getElementById("bytd").addEventListener("click", function () {
            var max = dateAxis.groupMax["day1"];
            var date = new Date(max);
            am4core.time.round(date, "year", 1);
            zoomToDates(date);
        });

        document.getElementById("bmax").addEventListener("click", function () {
            var min = dateAxis.groupMin["day1"];
            var date = new Date(min);
            zoomToDates(date);
        });

        dateAxis.events.on("selectionextremeschanged", function () {
            updateFields();
        });

        dateAxis.events.on("extremeschanged", updateFields);

        function updateFields() {
            var minZoomed = dateAxis.minZoomed + am4core.time.getDuration(dateAxis.mainBaseInterval.timeUnit, dateAxis.mainBaseInterval.count) * 0.5;
            document.getElementById("fromfield").value = chart.dateFormatter.format(minZoomed, inputFieldFormat);
            document.getElementById("tofield").value = chart.dateFormatter.format(new Date(dateAxis.maxZoomed), inputFieldFormat);
        }

        document.getElementById("fromfield").addEventListener("keyup", updateZoom);
        document.getElementById("tofield").addEventListener("keyup", updateZoom);

        var zoomTimeout;
        function updateZoom() {
            if (zoomTimeout) {
                clearTimeout(zoomTimeout);
            }
            zoomTimeout = setTimeout(function () {
                var start = document.getElementById("fromfield").value;
                var end = document.getElementById("tofield").value;
                if ((start.length < inputFieldFormat.length) || (end.length < inputFieldFormat.length)) {
                    return;
                }
                var startDate = chart.dateFormatter.parse(start, inputFieldFormat);
                var endDate = chart.dateFormatter.parse(end, inputFieldFormat);

                if (startDate && endDate) {
                    dateAxis.zoomToDates(startDate, endDate);
                }
            }, 500);
        }

        function zoomToDates(date) {
            var min = dateAxis.groupMin["day1"];
            var max = dateAxis.groupMax["day1"];
            dateAxis.keepSelection = true;
            //dateAxis.start = (date.getTime() - min)/(max - min);
            //dateAxis.end = 1;

            dateAxis.zoom({ start: (date.getTime() - min) / (max - min), end: 1 });
        }

    }); // end am4core.ready()
}
    

function GeneratePieChart(countryInfos) {


    am4core.ready(function () {

        // Themes begin
        am4core.useTheme(am4themes_animated);
        // Themes end

        var chart = am4core.create("chartpie", am4charts.PieChart3D);
        chart.hiddenState.properties.opacity = 0; // this creates initial fade-in

        chart.legend = new am4charts.Legend();

        chart.data = countryInfos

        var series = chart.series.push(new am4charts.PieSeries3D());
        series.dataFields.value = "deathPercentage";
        series.dataFields.category = "name";

    }); // end am4core.ready()
}

function GenerateLineBarChart(tradeInfo) {



    am4core.ready(function () {

        // Themes begin
        am4core.useTheme(am4themes_animated);
        // Themes end

        // Create chart instance
        var chart = am4core.create("chartbarline", am4charts.XYChart);

        // Export
        chart.exporting.menu = new am4core.ExportMenu();

        var data = tradeInfo;

        // Data for both series
        //var data = [{
        //    "year": "2009",
        //    "income": 23.5,
        //    "expenses": 21.1
        //}, {
        //    "year": "2010",
        //    "income": 26.2,
        //    "expenses": 30.5
        //}, {
        //    "year": "2011",
        //    "income": 30.1,
        //    "expenses": 34.9
        //}, {
        //    "year": "2012",
        //    "income": 29.5,
        //    "expenses": 31.1
        //}, {
        //    "year": "2013",
        //    "income": 30.6,
        //    "expenses": 28.2,
        //    "lineDash": "5,5",
        //}, {
        //    "year": "2014",
        //    "income": 34.1,
        //    "expenses": 32.9,
        //    "strokeWidth": 1,
        //    "columnDash": "5,5",
        //    "fillOpacity": 0.2,
        //    "additional": "(projection)"
        //}];

        /* Create axes */
        var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
        categoryAxis.dataFields.category = "height";
        categoryAxis.renderer.minGridDistance = 30;

        /* Create value axis */
        var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());

        /* Create series */
        var columnSeries = chart.series.push(new am4charts.ColumnSeries());
        columnSeries.name = "Price";
        columnSeries.dataFields.valueY = "price";
        columnSeries.dataFields.categoryX = "height";

        columnSeries.columns.template.tooltipText = "[#fff font-size: 15px]{name} in {categoryX}:\n[/][#fff font-size: 20px]{valueY}[/] [#fff]{additional}[/]"
        columnSeries.columns.template.propertyFields.fillOpacity = "fillOpacity";
        columnSeries.columns.template.propertyFields.stroke = "stroke";
        columnSeries.columns.template.propertyFields.strokeWidth = "strokeWidth";
        columnSeries.columns.template.propertyFields.strokeDasharray = "columnDash";
        columnSeries.tooltip.label.textAlign = "middle";

        var lineSeries = chart.series.push(new am4charts.LineSeries());
        lineSeries.name = "Expenses";
        lineSeries.dataFields.valueY = "quantity";
        lineSeries.dataFields.categoryX = "height";

        lineSeries.stroke = am4core.color("#fdd400");
        lineSeries.strokeWidth = 3;
        lineSeries.propertyFields.strokeDasharray = "lineDash";
        lineSeries.tooltip.label.textAlign = "middle";

        var bullet = lineSeries.bullets.push(new am4charts.Bullet());
        bullet.fill = am4core.color("#fdd400"); // tooltips grab fill from parent by default
        bullet.tooltipText = "[#fff font-size: 15px]{name} in {categoryX}:\n[/][#fff font-size: 20px]{valueY}[/] [#fff]{additional}[/]"
        var circle = bullet.createChild(am4core.Circle);
        circle.radius = 4;
        circle.fill = am4core.color("#fff");
        circle.strokeWidth = 3;

        chart.data = data;

    }); // end am4core.ready()
}

export function GenerateStockChart(tradeInfo) {


    am4core.ready(function () {

        // Themes begin
        am4core.useTheme(am4themes_animated);
        // Themes end

       // var placeHolder = tradeInfo;

        // Create chart
        var chart = am4core.create("chartstockbasic", am4charts.XYChart);
        chart.padding(0, 15, 0, 15);

        // Load external data
        var data = tradeInfo;
        
        //chart.dataSource.url = "https://www.amcharts.com/wp-content/uploads/assets/stock/MSFT.csv";
        //chart.dataSource.parser = new am4core.CSVParser();
        //chart.dataSource.parser.options.useColumnNames = true;
        //chart.dataSource.parser.options.reverse = true;

        // the following line makes value axes to be arranged vertically.
        chart.leftAxesContainer.layout = "vertical";

        // uncomment this line if you want to change order of axes
        //chart.bottomAxesContainer.reverseOrder = true;

        var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
        dateAxis.renderer.grid.template.location = 0;
        dateAxis.renderer.ticks.template.length = 8;
        dateAxis.renderer.ticks.template.strokeOpacity = 0.1;
        dateAxis.renderer.grid.template.disabled = true;
        dateAxis.renderer.ticks.template.disabled = false;
        dateAxis.renderer.ticks.template.strokeOpacity = 0.2;
        dateAxis.renderer.minLabelPosition = 0.01;
        dateAxis.renderer.maxLabelPosition = 0.99;
        dateAxis.keepSelection = true;
       // dateAxis.minHeight = 30;

        dateAxis.groupData = false;
        dateAxis.minZoomCount = 5;

        // these two lines makes the axis to be initially zoomed-in
        // dateAxis.start = 0.7;
        // dateAxis.keepSelection = true;

        var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
        valueAxis.tooltip.disabled = true;
        valueAxis.zIndex = 1;
        valueAxis.renderer.baseGrid.disabled = true;
        // height of axis
        valueAxis.height = am4core.percent(65);

        valueAxis.renderer.gridContainer.background.fill = am4core.color("#000000");
        valueAxis.renderer.gridContainer.background.fillOpacity = 0.05;
        valueAxis.renderer.inside = true;
        valueAxis.renderer.labels.template.verticalCenter = "bottom";
        valueAxis.renderer.labels.template.padding(2, 2, 2, 2);

        //valueAxis.renderer.maxLabelPosition = 0.95;
        valueAxis.renderer.fontSize = "0.8em"

        var series = chart.series.push(new am4charts.LineSeries());
        series.dataFields.dateX = "date";
        series.dataFields.valueY = "average";
        series.tooltipText = "{valueY.value}";
        series.name = "MSFT: Value";
        series.defaultState.transitionDuration = 0;

        var valueAxis2 = chart.yAxes.push(new am4charts.ValueAxis());
        valueAxis2.tooltip.disabled = true;
        // height of axis
        valueAxis2.height = am4core.percent(35);
        valueAxis2.zIndex = 3
        // this makes gap between panels
        valueAxis2.marginTop = 30;
        valueAxis2.renderer.baseGrid.disabled = true;
        valueAxis2.renderer.inside = true;
        valueAxis2.renderer.labels.template.verticalCenter = "bottom";
        valueAxis2.renderer.labels.template.padding(2, 2, 2, 2);
        //valueAxis.renderer.maxLabelPosition = 0.95;
        valueAxis2.renderer.fontSize = "0.8em"

        valueAxis2.renderer.gridContainer.background.fill = am4core.color("#000000");
        valueAxis2.renderer.gridContainer.background.fillOpacity = 0.05;

        var series2 = chart.series.push(new am4charts.ColumnSeries());
        series2.dataFields.dateX = "date";
        series2.dataFields.valueY = "volume";
        series2.yAxis = valueAxis2;
        series2.tooltipText = "{valueY.value}";
        series2.name = "MSFT: Volume";
        // volume should be summed
        //series2.groupFields.valueY = "sum";
        series2.defaultState.transitionDuration = 0;

        chart.cursor = new am4charts.XYCursor();

        var scrollbarX = new am4charts.XYChartScrollbar();
        scrollbarX.series.push(series);
        scrollbarX.marginBottom = 20;
        scrollbarX.scrollbarChart.xAxes.getIndex(0).minHeight = undefined;
        chart.scrollbarX = scrollbarX;


        // Add range selector
        var selector = new am4plugins_rangeSelector.DateAxisRangeSelector();
        selector.container = document.getElementById("stockcontrols");
        selector.axis = dateAxis;

        chart.data = data;

    }); // end am4core.ready()
}