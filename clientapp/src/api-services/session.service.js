import Axios from "axios";

const inst = Axios.create({
  headers: {'Content-Type': 'application/json'}
})

const RESOURCE_NAME = "/session";

export default {
  getAll() {},

  getOnline() {},

  get(id) {},
  create(data) {
    return inst.post(RESOURCE_NAME, data)
  },

  stop() {}
};
