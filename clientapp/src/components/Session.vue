<template>
  <b-container>
    <b-row>
      <b-col>
        <b-row>
          <b-col>
            <router-link :to="{name: 'session', params: {id: session.id}}">{{session.name}}</router-link>
          </b-col>
          <b-col @mouseover="timeflag = true" @mouseout="timeflag = false">{{BeginDate}}</b-col>
        </b-row>
        <b-row>
          <b-col>{{session.concurencies.join(', ')}}</b-col>
        </b-row>
      </b-col>
      <b-col>Place for image</b-col>
    </b-row>
  </b-container>
</template>

<script>
export default {
  data() {
    return {
      timeflag: false
    };
  },
  name: "Session",
  props: ["session"],
  computed: {
    BeginDate: function() {
      let date = new Date(this.session.beginTime * 1000);
      if (!this.timeflag) return date.toLocaleDateString();
      else return date.toLocaleTimeString();
    }
  }
};
</script>

