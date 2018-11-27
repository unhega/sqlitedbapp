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
          <b-col>{{session.currencies.join(', ')}}</b-col>
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
        }
    },
    name: "Session",
    props:['session'],
    computed:{
        BeginDate: function () {
          if(!this.timeflag)
            return new Date(this.session.begintime).toLocaleDateString();
          else
            return new Date(this.session.begintime).toLocaleTimeString();
        }
    }
}
</script>

