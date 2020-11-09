import Vue from 'vue'
import axios from 'axios'

const client = axios.create({
  baseURL: 'http://localhost:5000/Item',
  json: true
})

export default {
  async execute(method, resource, data) {
    return client({
      method,
      url: resource,
      data
    }).then(req => {
      return req.data
    })
  },
  getAll() {
    return this.execute('get', '/getall')
  },
  create(data) {
    return this.execute('post', '/', data)
  },
  update(data) {
    return this.execute('put', `/`, data)
  },
  delete(data) {
    console.log(data);
    return this.execute('delete', `/`, data)
  }
}