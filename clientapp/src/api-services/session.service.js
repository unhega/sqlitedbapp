import Axios from "axios";

const inst = Axios.create({
  headers: {'Content-Type': 'application/json'}
})

const RESOURCE_NAME = "/session";

export default {
  getAll() {
    return inst.get(`${RESOURCE_NAME}/all`)
  },

  getOnline() {
    return inst.get(`${RESOURCE_NAME}/online`)
  },

  getLast() {
    return inst.get(`${RESOURCE_NAME}/last`)
  },

  get(id) {},
  create(session) {
    return inst.post(RESOURCE_NAME, session)
  },

  stop(id) {
    return inst.get(`${RESOURCE_NAME}/stop/${id}`)
  }
};
