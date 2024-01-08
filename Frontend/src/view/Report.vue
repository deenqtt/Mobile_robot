<template>
  <main id="about-page">
    <button
      type="button"
      class="btn btn-danger"
      data-toggle="modal"
      data-target="#report"
    >
      Report
    </button>

    <br />
    <br />
    <div class="card-container">
      <div class="card">
        <div class="card-header">Report</div>
        <div class="card-body">
          <table class="table table-hover">
            <thead>
              <tr>
                <th scope="col">#</th>
                <th scope="col">Robot</th>
                <th scope="col">Date</th>
                <th scope="col">Problem</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(item, index) in tableData" :key="index">
                <th scope="row">{{ item.id }}</th>
                <td>{{ item.robot }}</td>
                <td>{{ item.last }}</td>
                <td>{{ item.handle }}</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
      <br />
      <div class="card">
        <div class="card-header">Robot Fix</div>
        <form>
          <div class="card-body">
            <label for="robotSelect">Choose Robot:</label><br />
            <select
              v-model="selected"
              id="robotSelect"
              name="robotSelect"
              class="form-control"
              required
            >
              <option disabled value="">Please select one robot.</option>
              <option
                v-for="robot in getUniqueRobots"
                :key="robot"
                :value="robot"
              >
                {{ robot }}
              </option></select
            ><br />
            <button
              type="button"
              class="btn btn-primary mt-2"
              @click="loadOptions()"
            >
              Load options
            </button>
            <small class="text-muted"
              >If you don't see your robot, click the button above to load
              options from server.</small
            ><br /><br />
            <label for="lastField">Last report date</label>
            <input
              class="form-control"
              type="datetime-local"
              id="lastField"
              name="lastField"
            /><br />
            <label for="handleField">Handle by</label><br />
            <input
              class="form-control"
              type="text"
              id="handleField"
              name="handleField"
              placeholder="Enter name"
              required
            /><br />
            <input type="date" id="lastField" class="form-control mb-2" /><br />
            <button type="submit" class="btn btn-success">Submit</button>
          </div>
        </form>
      </div>
      <div class="card">
        <!-- tabel robot fix -->
        <div class="card-header">Fix Report Lists</div>
        <div class="card-body">
          <table class="table table-striped">
            <thead>
              <tr>
                <th scope="col">#</th>
                <th scope="col">Name of Robot</th>
                <th scope="col">Handled By</th>
                <th scope="col">Time Handled On</th>
                <th scope="col"></th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(item, index) in reports" :key="index">
                <td scope="row">{{ item.id }}</td>
                <td>
                  {{ item.name_of_robot }} (Serial Number:
                  {{ item.serial_number }})
                </td>
                <td>{{ item.handled_by }}</td>
                <td>
                  {{ new Date(item.time_handled).toLocaleString("en-US") }}
                </td>
                <td scope="row">
                  <a
                    href="#"
                    class="btn btn-warning"
                    data-toggle="modal"
                    data-target="#editModal"
                    @click="setValuesForEditing(index)"
                    >Edit Report</a
                  >
                  <a href="#" class="btn btn-danger" @click="deleteItem(index)"
                    >Delete Report</a
                  >
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>

    <!-- Modal for adding a report -->
    <div
      class="modal fade"
      id="report"
      tabindex="-1"
      role="dialog"
      aria-labelledby="exampleModalLabel"
      aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Add Report</h5>
            <button
              type="button"
              class="close"
              data-dismiss="modal"
              aria-label="Close"
            >
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form action="" @submit.prevent="addReport"></form>
            <label>Robot Issue:</label>
            <input type="text" class="form-control" id="issueInput" required />
            <!-- other form fields... -->

            <br />
            <select class="form-control" v-model="newReport.robotName">
              <option value="" selected disabled hidden>Choose robot...</option>
              <option
                v-for="robotName in robotOptions"
                :key="robotName"
                :value="robotName"
              >
                {{ robotName }}
              </option>
            </select>

            <label for="dateInput">Date:</label>
            <input type="date" class="form-control" id="dateInput" />
          </div>
          <div class="modal-footer">
            <button
              type="button"
              class="btn btn-secondary"
              data-dismiss="modal"
            >
              Close
            </button>
            <button type="button" class="btn btn-warning">Add Report</button>
          </div>
        </div>
      </div>
    </div>
  </main>
</template>
<script setup>
import axios from "axios";
import { onMounted, ref } from "vue";

const apiUrl = "http://localhost:5205/reports";

const newReport = ref({
  issue: "",
  robotName: "",
  date: "",
});

const reports = ref([]);
const robotOptions = ref([]);

const fetchRobots = async () => {
  try {
    const response = await axios.get("http://localhost:5205/robots");
    robotOptions.value = response.data.map((robot) => robot.robotName);
  } catch (error) {
    console.error("Error fetching robot names:", error);
  }
};

onMounted(fetchRobots);

const addReport = async () => {
  try {
    const response = await axios.post(apiUrl, newReport.value);
    const addedReport = response.data; // Assuming the API returns the newly added report
    reports.value.push(addedReport);
    resetReportForm();
  } catch (error) {
    console.error("Error adding report:", error);
  }
};

const resetReportForm = () => {
  newReport.value = {
    issue: "",
    robotName: "",
    date: "",
  };
};

const loadOptions = () => {
  // Implement your logic to load options from the server
};
</script>

<style scoped>
.card-container {
  display: inline-flex;
  justify-content: space-between;
  margin-left: -25px; /* Menempatkan kartu bersebelahan dengan jarak di antara mereka */
}
.card {
  padding-left: 16px;
  margin-left: 20px;
  width: 400px;
  height: 400px;
}
.card-container .card {
  overflow: auto;
}
.card-header {
  border-radius: 30px;
  margin: 20px;
  transition: 0.2s linear;
  cursor: pointer;
}
.card-header:hover {
  background-color: black;
  color: white;
}
</style>
