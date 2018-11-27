const usd = [
    { id: 1, sessionId: 1, timestamp: Date.UTC(), value: 10 },
    { id: 2, sessionId: 1, timestamp: Date.UTC(), value: 20 },
    { id: 3, sessionId: 1, timestamp: Date.UTC(), value: 30 },
    { id: 4, sessionId: 1, timestamp: Date.UTC(), value: 15 }
  ]

export default {
    get(id) {   
        return new Promise(res => res({data: {name: 'usd', prices: usd.filter((e)=> e.sessionId == id)}}));
    },

    // getData(id) {
    // return new Promise(res => res({data: usd.find((e)=> e.id == id)}));
    // }
}