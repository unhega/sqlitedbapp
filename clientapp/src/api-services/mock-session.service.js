const items = [
  {
    id: 1,
    status: 1,
    name: "Dickerson",
    comment: "Macdonald",
    begintime: Date.now(),
    endtime: Date.now(),
    currencies: ["USD", "RUB"],
    _showDetails: false
  },
  {
    id: 2,
    status: 0,
    name: "Larsen",
    comment: "Shaw",
    begintime: Date.now(),
    endtime: Date.now(),
    currencies: ["USD"],
    _showDetails: false
  },
  {
    id: 3,
    status: 0,
    name: "Geneva",
    comment: "Wilson",
    begintime: Date.now(),
    endtime: Date.now(),
    currencies: ["USD"],
    _showDetails: false
  },
  {
    id: 4,
    status: 1,
    name: "Jami",
    comment: "Carney",
    begintime: Date.now(),
    endtime: Date.now(),
    currencies: ["USD"],
    _showDetails: false
  }
];

export default {
  getAll() {
    return new Promise(res => res({ data: items }));
  },

  getOnline() {
    return new Promise(res => res({ data: items.filter(e => e.status == 1) }));
  },

  getLast() {
    return new Promise(res => res({ data: items.slice(-2) }));
  },

  get(id) {
    return new Promise(res => res({ data: items.find(e => e.id == id) }));
  }
};
