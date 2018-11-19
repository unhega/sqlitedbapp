import Axios from "axios";

const inst = Axios.create({
  headers: {'Content-Type': 'application/json'}
})

const RESOURCE_NAME = "/session";

export default {
  getAll() {},

  getOnline() {},

  get(id) {},
  create(session) {
    return inst.post(RESOURCE_NAME, session)
  },

  stop(id) {
    return inst.get(`$RESOURCE_NAME/stop/$id`)
  }
};
