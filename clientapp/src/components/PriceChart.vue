<template>
  <b-container id="price-chart">
    <highcharts :options="chartOptions" :updateArgs="updateArgs"></highcharts>
  </b-container>
</template>

<script>
// import Highcharts from 'highcharts'

export default {
  data() {
    return {
      title: "Price chart",
      data: this.dataset,
      updateArgs: [true, true, {duration: 0}],
      chartOptions: {
        chart: {
          type: "line"
        },
        title: {
          text: "Price chart"
        },
        series: []
          // [
          // {
            
          //   name: this.data.title,
          //   data: this.data.data,
          //   // color: "#6fcd98",
          //   lineColor: this.$root.Highcharts.getOptions().colors[1],
          //   // color: Highcharts.getOptions().colors[2],
          //   marker: {
          //     enabled: false
          //   },  
          //   threshold: null,
          //   fillOpacity: 1
          // }
        // ]
      }
    };
  },
  props: ["dataset"],
  // watch: {
  //   dataset(newValue) {
  //     this.chartOptions.series[0].data = newValue;
  //   }
  // }
  mounted() {
    for(let item in this.dataset) {
      this.data.push(item)
    }
  }
};
</script>
