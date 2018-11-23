<template>
  <b-container id="app">
    <b-row>
      <b-col>
        <navbar/>
      </b-col>
    </b-row>
    <b-row>
      <b-col>
        <router-view/>
      </b-col>
      <b-col md="2" lg="3">
        Last used sessions
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
import Navbar from '@/components/Navbar'

export default {
  name: 'App',
  components: {
    Navbar
  }
}
</script>

<style>
@media (max-width: 992px) {
  .container {
    width: 100%;
    max-width: none;
  }
}
</style>

