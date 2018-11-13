<template>
<b-navbar toggleable="md" type="dark" variant="info">
  <b-navbar-brand :to="{name: 'Home'}">NavBar</b-navbar-brand>
    <b-navbar-nav>
      <b-nav-item href="#">Action 1</b-nav-item>
      <b-nav-item href="#">Action 2</b-nav-item>
    </b-navbar-nav>
    <!-- <b-navbar-nav class="ml-auto">
      <b-nav-form>
        <b-form-input size="sm" class="mr-sm-2" type="text" placeholder="Search"/>
        <b-button size="sm" class="my-2 my-sm-0" type="submit">Search</b-button>
      </b-nav-form>
    </b-navbar-nav> -->
</b-navbar>
</template>

<script>
export default {
  name: 'Navbar'
}
</script>
