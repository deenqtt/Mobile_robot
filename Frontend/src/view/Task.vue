<template>
  <div>
    <button
      type="button"
      class="btn btn-success"
      data-toggle="modal"
      data-target="#AddNewModal"
    >
      Add
    </button>

    <div class="card">
      <h5 class="card-header">Tasks List</h5>
      <div class="card-body">
        <table class="table table-striped">
          <thead>
            <tr>
              <th scope="col">#ID</th>
              <th scope="col">Task Name</th>
              <th scope="col">Due Date & Time</th>
              <th scope="col">Actions</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(task, index) in tasks" :key="index">
              <th scope="row">{{ index + 1 }}</th>
              <td>{{ task.name }}</td>
              <td>{{ task.dueTime }}</td>
              <td>
                <button
                  type="button"
                  class="btn btn-info"
                  @click="viewTask(index)"
                  data-toggle="modal"
                  data-target="#detailModal"
                >
                  Detail
                </button>
                <button class="btn btn-success" @click="markTaskAsDone(index)">
                  Start
                </button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>

    <!-- Add New Task Modal -->
    <div
      class="modal fade"
      id="AddNewModal"
      tabindex="-1"
      role="dialog"
      aria-labelledby="AddNewLabel"
      aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="AddNewLabel">Add New Task for</h5>
            <button
              type="button"
              class="close"
              data-dismiss="modal"
              aria-label="Close"
            >
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <form @submit.prevent="addTask">
            <div class="modal-body">
              <div class="row justify-content-center mt-3">
                <select v-model="selectedRobot" class="form-control">
                  <option value="none">Select robot</option>
                  <option value="Robot1">Robot1</option>
                </select>
              </div>
              <div class="row justify-content-center mt-3">
                <input
                  v-model="newTask.name"
                  type="text"
                  name="name"
                  placeholder="Name"
                  required
                  class="form-control"
                />
              </div>
              <div class="row justify-content-center mt-2">
                <input
                  v-model="newTask.dueTime"
                  type="datetime-local"
                  name="duetime"
                  required
                  class="form-control"
                />
              </div>
            </div>
            <div class="modal-footer">
              <button
                type="button"
                class="btn btn-secondary"
                data-dismiss="modal"
              >
                Close
              </button>
              <input type="submit" value="Save Task" class="btn btn-primary" />
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
  <!-- Modal content goes here -->

  <!-- Modal content goes here -->
</template>

<script>
export default {
  data() {
    return {
      tasks: [
        { name: "Going To Warehouse", dueTime: "2021/8/7, 14:30:00" },
        // Add more tasks as needed
      ],
      newTask: {
        name: "",
        dueTime: "",
      },
      selectedTaskIndex: null,
      selectedRobot: "none",
    };
  },
  methods: {
    addTask() {
      if (
        this.newTask.name &&
        this.newTask.dueTime &&
        this.selectedRobot !== "none"
      ) {
        this.tasks.push({
          name: this.newTask.name,
          dueTime: this.newTask.dueTime,
          robot: this.selectedRobot,
        });

        this.newTask.name = "";
        this.newTask.dueTime = "";
        this.selectedRobot = "none";

        $("#AddNewModal").modal("hide");
      }
    },
    viewTask(index) {
      this.selectedTaskIndex = index;
      $("#detailModal").modal("show");
    },
    markTaskAsDone(index) {
      this.tasks.splice(index, 1);
      this.selectedTaskIndex = null;
      $("#detailModal").modal("hide");
    },
  },
  computed: {
    selectedTask() {
      return this.selectedTaskIndex !== null
        ? this.tasks[this.selectedTaskIndex]
        : null;
    },
  },
};
</script>

<style scoped>
/* Add your styles if needed */
.task-list {
  list-style: none;
  padding: 0;
}

.task-list li {
  margin-bottom: 10px;
  display: flex;
  align-items: center;
}

.task-name {
  flex-grow: 1;
  margin-right: 10px;
}

.control-button {
  padding: 8px 12px;
  background-color: #007bff;
  color: #fff;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  outline: none;
}

.control-button.disabled {
  background-color: #ccc;
  cursor: not-allowed;
}

.shuffle-button {
  margin-top: 10px;
  padding: 8px 12px;
  background-color: #28a745;
  color: #fff;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  outline: none;
}
.progress-container {
  width: 100%;
  height: 20px;
  background-color: #f0f0f0;
  border-radius: 10px;
  margin-bottom: 10px;
  overflow: hidden;
}

.progress-bar {
  height: 100%;
  background-color: #007bff; /* Adjust the color based on your design */
}

/* Style for the status indicator */
.status-indicator {
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
  text-align: center;
  font-weight: bold;
}

.in-progress {
  color: #007bff; /* Color for in-progress status */
}

.completed {
  color: #28a745; /* Color for completed status */
}
.card {
  margin-top: 10px;
}
</style>
