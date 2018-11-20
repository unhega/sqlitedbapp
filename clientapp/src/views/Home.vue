<template>
  <b-container>
    <h1>Session viewer</h1>
    <h4>Online sessions:</h4>
    <session v-for="session in onlineSessions" :key="session.id" :session="session">
    </session>

    <h4>Last sessions:</h4>
    <session/>
  </b-container>
</template>

<script>
// @ is an alias to /src
import Session from '@/components/Session'
import SessionService from '@/api-services/session.service'

export default {
  name: 'home',
  components: {
    Session
  },
  data() {
    return {
      onlineSessions: [],
      lastSessions: []
    }
  },
  created() {
    SessionService.getOnline().then((response) => {
      console.log(response.data)
      this.onlineSessions = response.data
    }).catch((error) => {
      console.log(error.response.data)
    })
    SessionService.getLast().then((response) => {
      this.lastSessions = response.data
    }).catch((error) => {
      console.log(error.response.data)
    })
  }
}
</script>
