<template>
  <b-container id="price-chart">
    <highcharts :options="chartOptions"></highcharts>
    <b-button @click="chartOptions.series.data.push({y: 10})"></b-button>
  </b-container>
</template>

<script>
// import Highcharts from 'highcharts'

export default {
  data() {
    return {
      title: "title",
      points: [10, 0, 8, 2, 6, 4, 5, 5],
      chartType: "Spline",
      seriesColor: "#6fcd98",
      colorInputIsSupported: null,
      animationDuration: 1000,
      updateArgs: [true, true, { duration: 1000 }],
      chartOptions: {
        chart: {
          type: "line"
        },
        title: {
          text: "Sin chart"
        },
        series: [
          {
            name: '123',
            data: [{y: 1}, {y: 2}, {y: 3}, {y: 2}, {y: 4}, {y: 7}, {y: 2}, {y: 5} ],
            // color: "#6fcd98",
            lineColor: this.$root.Highcharts.getOptions().colors[1],
            // color: Highcharts.getOptions().colors[2],
            marker: {
              enabled: false
            },  
            threshold: null,
            fillOpacity: 1
          }
        ]
      }
    };
  },
  props: ["dataset"]
};
</script>
