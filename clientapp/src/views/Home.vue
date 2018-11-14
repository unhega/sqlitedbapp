<template>
  <b-container>
    <h1>Session viewer</h1>
    <h4>Online sessions:</h4>
    <session/>
    <h4>Last sessions:</h4>
    <session/>
  </b-container>
</template>

<script>
// @ is an alias to /src
import Session from '@/components/Session'

export default {
  name: 'home',
  components: {
    Session
  }
}
</script>
