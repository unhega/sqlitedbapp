import Axios from "axios";

const inst = Axios.create({
  headers: { "Content-Type": "application/json" }
});

const RESOURCE_NAME = "/price";

export default {
  getAll(id) {
    return inst.get(`${RESOURCE_NAME}/all`);
  },

  get(id) {},
  create(session) {
    return inst.post(RESOURCE_NAME, session);
  }
};
