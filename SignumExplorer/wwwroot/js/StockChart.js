

export function StockChart(tradeInfo) {


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