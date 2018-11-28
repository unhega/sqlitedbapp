<template>
  <b-container id="createform">
    <h5>Session creation form</h5>
    <b-form @submit="onSubmit">
      <b-form-group horizontal id="Name" label="Name" label-for="NameInput">
        <b-form-input id="NameInput" v-model="form.name"/>
      </b-form-group>
      <b-form-group horizontal id="Comment" label="Comment" label-for="CommentTextarea">
        <b-form-textarea id="CommentTextarea" :rows="3" :max-rows="6" v-model="form.comment"/>
      </b-form-group>
      <b-form-group label="Check concurencies">
        <b-checkbox-group v-model="form.concurencies" :options="currenciesVariants" state="null"></b-checkbox-group>
      </b-form-group>

      <b-form-row>
        <!-- Здесь когда-нибудь будет таймер остановки сессии -->
        <b-col></b-col>
        <!-- <b-col cols='*'><b-button type="reset">Reset</b-button></b-col> -->
        <b-col cols="*">
          <b-button type="submit">Start</b-button>
        </b-col>
      </b-form-row>
    </b-form>
  </b-container>
</template>
<script>
import SessionService from "@/api-services/session.service";
// import SessionService from "@/api-services/mock-session.service";

export default {
  data() {
    return {
      form: {
        name: "Session",
        comment: "Empty",
        concurencies: []
      },
      currenciesVariants: [
        { text: "USD", value: "USD" },
        { text: "RUB", value: "RUB" }
      ]
    };
  },
  methods: {
    onSubmit(evt) {
      evt.preventDefault();
      // alert(JSON.stringify(this.form));
      SessionService.create(JSON.stringify(this.form))
        .then(response => {
          console.log(response.data);
        })
        .catch(error => {
          console.log(error.response.data);
        });
    }
  }
};
</script>

