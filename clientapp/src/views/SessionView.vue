<template>
<b-container>
    <b-row>
        <b-col cols="1">Name:</b-col>
        <b-col>{{session.name}}</b-col>
        <b-col cols="1">Date:</b-col>
        <b-col>{{session.begintime}}</b-col>
        <b-col>Status: <span>{{session.status}}</span></b-col>
    </b-row>
    <b-row>
        <b-col cols="1">Comment:</b-col>
    </b-row>
    <b-row>
        <b-col>{{session.comment}}</b-col>
    </b-row>
    <b-row>
        <b-col v-if="plotRendered"><price-chart></price-chart></b-col>
        <b-col v-else>1</b-col>
    </b-row>
</b-container>
</template>

<script>
import SessionService from "@/api-services/mock-session.service";
import PriceService from "@/api-services/mock-price.service";
import PriceChart from "@/components/PriceChart";

export default {
  name: "Session",
  components: {
    PriceChart
  },
  data() {
    return {
      session: null,
      plotRendered: false
    };
  },
  mounted() {
    let id = this.$route.params.id;
    SessionService.get(id)
      .then(response => {
        this.session = response.data;
      })
      .catch(error => {
        console.log(error.response.data);
      });

    PriceService.get(id).then(response => {
      // set price data
    });
    this.plotRendered = true;
  }
};
</script>


