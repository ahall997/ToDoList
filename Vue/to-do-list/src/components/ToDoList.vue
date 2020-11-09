<template>
  <div class="todolist">
    <h1>{{ msg }}</h1>
    <div>
      <table id="toDoListTable" class="table b-table table-striped table-hover">
        <thead>
          <tr>
            <th>ID</th>
            <th>Description</th>
            <th>Completed</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="task in tasks" :key="task.Id">
            <td><button @click="deleteItem(task)" >Delete</button></td>
            <td>{{task.id}}</td>
            <td>{{task.description}}</td>
            <td>{{task.completed}}</td>
            <td><input type="checkbox" id="checkbox" v-model="task.completed" @click="changeStatus(task)"></td>
          </tr>
          <tr>
            <td><input v-model="newDescription" placeholder="New Task" @keydown.enter="createItem()"></td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import api from '../Records/ItemRecordApi';

export default {
  name: 'ToDoList',
  data () {
    return {
      msg: 'This is a task list in Vue Js',
      loading: 'true',
      items: [],
      newDescription: ""
    }
  },
  computed: {
    tasks() {
      return this.items
    }
  },
  async created() {
    this.getAll()

  },
  methods: {
    async getAll() {
      this.items = await api.getAll();
    },
    async changeStatus(task) {
      api.update(task.id);
      let updatedTask = task;
      updatedTask.completed = !task.completed;
      this.items[task.id] = updatedTask;
    },
    async createItem() {
      let newItem = await api.create(this.newDescription)
      this.items.push(newItem)
    },
    async deleteItem(task) {
      console.log(task.id)
      await api.delete(task.id);
      this.getAll();
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
h1, h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #35495E;
}
</style>
