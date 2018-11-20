<template>
  <b-table striped hover 
  :items="items"
  @row-clicked="rowToggleDetails">
    <template slot="row-details" slot-scope="row">
      <b-card>
        <b-row class="mb-2">
          <b-col sm="3" class="text-sm-right"><b>Age:</b></b-col>
          <b-col>{{ row.item.age }}</b-col>
        </b-row>
        <b-row class="mb-2">
          <b-col sm="3" class="text-sm-right"><b>Is Active:</b></b-col>
          <b-col>{{ row.item.isActive }}</b-col>
        </b-row>
      </b-card>
    </template>
  </b-table>
</template>

<script>
const items = [
  { isActive: true, age: 40, first_name: 'Dickerson', last_name: 'Macdonald', _showDetails: false },
  { isActive: false, age: 21, first_name: 'Larsen', last_name: 'Shaw', _showDetails: false },
  { isActive: false, age: 89, first_name: 'Geneva', last_name: 'Wilson', _showDetails: false },
  { isActive: true, age: 38, first_name: 'Jami', last_name: 'Carney', _showDetails: false }
]

export default {
  data () {
    return {
      items: items
    }
  },
  methods: {
      rowToggleDetails(row) {
          row._showDetails = !row._showDetails;
          
      }
  }
}
</script>
