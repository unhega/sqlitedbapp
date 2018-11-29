<template>
  <b-table striped hover :items="items" :fields="fields" @row-clicked="rowToggleDetails">
    <template
      slot="begintime"
      slot-scope="data"
    >{{(new Date(data.item.beginTime * 1000)).toLocaleString()}}</template>
    <template slot="endtime" slot-scope="data">
      <template v-if="data.item.status == 0">Online</template>
      <template v-else>{{(new Date(data.item.endTime * 1000)).toLocaleString()}}</template>
    </template>
    <template slot="row-details" slot-scope="row">
      <b-card>
        <b-row>
          <b-col>
            <b-row>
              <b-col md="3" lg="2">Name</b-col>
              <b-col>{{row.item.name}}</b-col>
            </b-row>
            <b-row>
              <b-col md="3" lg="2">Status</b-col>
              <b-col>{{row.item.status}}</b-col>
            </b-row>
            <b-row>
              <b-col md="3" lg="2">Comment</b-col>
              <b-col>{{row.item.comment}}</b-col>
            </b-row>
          </b-col>
          <b-col lg="*" md="2">
            <b-button :to="{name: 'session', params: {id: row.item.id}}">Detail</b-button>
          </b-col>
        </b-row>
      </b-card>
    </template>
  </b-table>
</template>

<script>
import SessionService from "@/api-services/session.service";

export default {
  name: "AllSessions",
  data() {
    return {
      items: [],
      fields: [
        { key: "name", sortable: true },
        { key: "comment" },
        { key: "begintime", label: "Begin time", sortable: true },
        { key: "endtime", label: "End time" }
      ]
    };
  },
  methods: {
    rowToggleDetails(row) {
      row._showDetails = !row._showDetails;
    }
  },
  mounted() {
    SessionService.getAll()
      .then(response => {
        response.data.forEach(e => (e._showDetails = false));
        this.items = response.data;
      })
      .catch(error => {
        console.log(error.response.data);
      });
  }
};
</script>
