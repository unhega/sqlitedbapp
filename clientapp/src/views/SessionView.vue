<template>
  <b-container>
    <b-row>
      <b-col cols="1">Name:</b-col>
      <b-col>{{session.name}}</b-col>
      <b-col cols="1">Date:</b-col>
      <b-col>{{session.begintime}}</b-col>
      <b-col>
        <template v-if="session.status == 1">
          <div style="float: left">Online</div>
          <div class="status green"></div>
        </template>
        <template v-else>
          <div style="float: left">Offline</div>
          <div class="status red"></div>
        </template>
      </b-col>
    </b-row>
    <b-row>
      <b-col cols="1">Comment:</b-col>
    </b-row>
    <b-row>
      <b-col>{{session.comment}}</b-col>
    </b-row>
    <b-row>
      <b-col v-if="plotRendered">
        <price-chart :dataset="dataset"></price-chart>
      </b-col>
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
      plotRendered: false,
      dataset: [
        {
          name: "Session name",
          data: []
        }
      ]
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
      console.log(response.data);
      this.dataset.data = response.data.prices.map(i => i.value);
    });
    this.plotRendered = true;
  },
  methods: {
    extendDataset(value) {
      this.dataset.data.push(value);
    }
  }
};
</script>
<style scoped>
.status {
  float: left;
  width: 15px;
  height: 15px;
  margin: 5px;
  border: 1px solid rgba(0, 0, 0, 0.2);
}

.green {
  background: #00ff00;
}

.red {
  background: #ff0000;
}

.wine {
  background: #ae163e;
}
</style>



