import Axios from "axios";

const RESOURCE_NAME = "/session";

export default {
  getAll() {},

  getOnline() {},

  get(id) {},
  create(data) {
    return Axios.post(RESOURCE_NAME, data);
  },

  stop() {}
};
