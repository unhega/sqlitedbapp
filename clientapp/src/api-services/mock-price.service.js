const usd = [
    { id: 1, sessionId: 0, timestamp: Date.now(), value: 10 },
    { id: 2, sessionId: 0, timestamp: Date.now(), value: 20 },
    { id: 3, sessionId: 0, timestamp: Date.now(), value: 30 },
    { id: 4, sessionId: 0, timestamp: Date.now(), value: 15 }
  ]

export default {
    get(id) {   
        return new Promise(res => res({data: {name: 'usd', prices: usd.filter((e)=> e.sessionId == id)}}));
    },

    // getData(id) {
    // return new Promise(res => res({data: usd.find((e)=> e.id == id)}));
    // }
}