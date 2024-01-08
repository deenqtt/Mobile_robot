<template>
  <main id="home-page">
    <!-- button add robot -->
    <button
      type="button"
      class="btn btn-success"
      data-toggle="modal"
      data-target="#exampleAddRobot"
    >
      AddRobot
    </button>
    <br />
    <!-- Modal Add Robot-->
    <div
      class="modal fade"
      id="exampleAddRobot"
      tabindex="-1"
      role="dialog"
      aria-labelled
      aria-hidden="true"
    >
      <div class="modal-dialog modal-lg" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Add a new robot</h5>
            <button
              type="button"
              class="close"
              data-dismiss="modal"
              aria-label="Close"
            >
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <form @submit.prevent="addRobot">
            <div class="modal-body">
              <div class="row">
                <div class="col-6">
                  Nama Robot
                  <textarea
                    v-model="onNewRobotAdded.robotName"
                    type="text"
                    class="form-control mb-2"
                    placeholder="Name of the robot"
                    required
                  />
                  Serial Number
                  <select
                    v-model="onNewRobotAdded.serialNumber"
                    class="custom-select mb-3"
                    @change="fetchRobotInfo"
                  >
                    <option value="" selected disabled hidden>
                      Choose serial number...
                    </option>
                    <option
                      v-for="serialNumber in serialNumbers"
                      :key="serialNumber"
                      :value="serialNumber"
                    >
                      {{ serialNumber }}
                    </option>
                  </select>

                  <input
                    type="file"
                    @change="handleFileChange"
                    class="form-control mb-2"
                  />
                  <img
                    v-if="onNewRobotAdded.image"
                    :src="onNewRobotAdded.image"
                    alt="preview image"
                    height="200px"
                  />
                  <br />
                </div>
                <div class="col-6">
                  <textarea
                    v-model="onNewRobotAdded.description"
                    rows="8"
                    cols="40"
                    placeholder="Description"
                    class="form-control mb-2"
                  ></textarea
                  ><br />
                </div>
                <div
                  class="w-100 d-flex justify-content-center align-items- center my-4"
                >
                  <button type="submit" class="btn btn-primary">Submit</button>
                </div>
              </div>
            </div>
          </form>
        </div>
      </div>
    </div>

    <br />
    <!-- card for waiting approval for new robot -->
    <div class="kontainer">
      <div class="card w-50">
        <!-- header of the card -->
        <div class="card-header bg-primary text-white">
          Waiting Approval For New Robots
        </div>
        <!-- body of the card tabel -->
        <table class="table table-striped mt-4">
          <!-- first row is the head of the table -->
          <thead>
            <tr>
              <th>Robot ID</th>
              <th>Name</th>
              <th>Info</th>
            </tr>
          </thead>
          <!-- show all robots in the list, using v-for to loop through the data array from Vuex store -->
          <tbody>
            <tr v-for="item in approval" :key="item.id">
              <td>{{ approval.serial_no }}</td>
              <td>{{ approval.NameRobot }}</td>
              <!-- show detail page when click on "view more" button -->
              <!-- <td>
                <button class="btn btn-info" @click="showDetailPage(item.id)">
                  View More
                </button>
              </td> -->
              <!-- delete this robot when click on "delete" button -->
              <td><button class="btn btn-danger">Delete</button></td>
            </tr>
          </tbody>
        </table>
        <div class="card-footer d-flex justify-content-end">
          <nav aria-label="Page navigation example">
            <ul class="pagination mb-0"></ul>
          </nav>
        </div>
      </div>
    </div>

    <div class="containe mt-4 mb-3">
      <div class="card1">
        <div class="card-body">
          <div class="col-md-6">
            <div class="card1 p-3 mb-2">
              <div class="d-flex justify-content-between">
                <div class="d-flex flex-row align-items-center">
                  <div class="icon"><i class="bx bxl-mailchimp"></i></div>
                  <div class="ms-2 c-details">
                    <h6 class="mb-0">Robot 1</h6>
                    <span>1 days ago</span>
                  </div>
                </div>
                <span>Service</span>
              </div>
              <div class="mt-4">
                <h3 class="heading">Warehouse<br /></h3>
                <div class="mt-5">
                  <div class="progress">
                    <div
                      class="progress-bar"
                      role="progressbar"
                      style="width: 50%"
                      aria-valuenow="50"
                      aria-valuemin="0"
                      aria-valuemax="100"
                    ></div>
                  </div>
                  <div class="mt-3">
                    <span class="text1"
                      >32% Tersisa
                      <span class="text2">of 100% capacity</span></span
                    >
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="card2">
        <div class="card-body">
          <div class="col-md-6">
            <div class="card1 p-3 mb-2">
              <div class="d-flex justify-content-between">
                <div class="d-flex flex-row align-items-center">
                  <div class="icon"><i class="bx bxl-dribbble"></i></div>
                  <div class="ms-2 c-details">
                    <h6 class="mb-0">Robot 2</h6>
                    <span>2 days ago</span>
                  </div>
                </div>
                <span>Product</span>
              </div>
              <div class="mt-4">
                <h3 class="heading">Assembly<br /></h3>
                <div class="mt-5">
                  <div class="progress">
                    <div
                      class="progress-bar"
                      role="progressbar"
                      style="width: 50%"
                      aria-valuenow="50"
                      aria-valuemin="0"
                      aria-valuemax="100"
                    ></div>
                  </div>
                  <div class="mt-3">
                    <span class="text1"
                      >42 % <span class="text2">of 70 capacity</span></span
                    >
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="card3">
        <div class="card-body">
          <div class="col-md-6">
            <div class="card1 p-3 mb-2">
              <div class="d-flex justify-content-between">
                <div class="d-flex flex-row align-items-center">
                  <div class="icon"><i class="bx bxl-reddit"></i></div>
                  <div class="ms-2 c-details">
                    <h6 class="mb-0">Robot 3</h6>
                    <span>2 days ago</span>
                  </div>
                </div>
                <span>Design</span>
              </div>
              <div class="mt-4">
                <h3 class="heading">Workshop <br /></h3>
                <div class="mt-5">
                  <div class="progress">
                    <div
                      class="progress-bar"
                      role="progressbar"
                      style="width: 50%"
                      aria-valuenow="50"
                      aria-valuemin="0"
                      aria-valuemax="100"
                    ></div>
                  </div>
                  <div class="mt-3">
                    <span class="text1"
                      >52 Remaining
                      <span class="text2">of 100 capacity</span></span
                    >
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </main>
</template>

<script setup>
import axios from "axios";
import { onMounted, ref } from "vue";

const apiUrl = "http://localhost:5205/approvals";

const serialNumbers = ref([]);
const onNewRobotAdded = ref({
  robotName: "",
  serialNumber: "",
  description: "",
});

const approval = ref([]);

const fetchRobotInfo = async () => {
  try {
    // Check if serialNumber is defined before making the request
    if (onNewRobotAdded.serialNumber) {
      const response = await axios.get(
        `http://localhost:5205/robots/${onNewRobotAdded.serialNumber}`
      );
      const robot = response.data;
      onNewRobotAdded.robotName = robot.robotName;
    }
  } catch (error) {
    console.error("Error fetching robot information:", error);
  }
};

onMounted(async () => {
  try {
    const response = await axios.get("http://localhost:5205/robots");
    serialNumbers.value = response.data.map((robot) => robot.serialNumber);
  } catch (error) {
    console.error("Error fetching serial numbers:", error);
  }
});

const addRobot = async () => {
  try {
    console.log("Connecting to backend...");
    console.log("Menambahkan robot...", onNewRobotAdded.value);
    const response = await axios.post(apiUrl, onNewRobotAdded.value);
    approval.value = response.data;
    console.log("Backend connection successful");
    console.log("Robot berhasil ditambahkan:", response.data);
  } catch (error) {
    console.error("Error menambahkan robot:", error);
  }
};

const handleFileChange = (event) => {
  const file = event.target.files[0];

  if (file) {
    const reader = new FileReader();
    reader.readAsDataURL(file);

    reader.onload = () => {
      onNewRobotAdded.image = reader.result;
    };
  }
};
</script>

<style scoped>
.card1 .card-body {
  background: linear-gradient(to right, #30cfd0 0%, #330867 100%);
  color: white;
  border-radius: 10px 40px;
  margin-bottom: 10px;
  transition: 0.3s ease;
}
/* Hover effect */
.card1:hover .card-body {
  cursor: pointer;
  transform: scale(1.05);
}
.card1 .card-body .badge span {
  background-color: #0e2c68;
  color: #fff;
  justify-content: center;
  align-items: center;
  font-size: 20px;
}
.card2 .card-body {
  background: linear-gradient(to right, #dda024 0%, #826801 100%);
  border-radius: 40px 10px;
  margin-bottom: 10px;
  color: #fff;
  transition: 0.3s ease;
}
.card2:hover .card-body {
  cursor: pointer;
  transform: scale(1.05);
  /*transform: translateY(-10%);*/
  box-shadow: 0 10px 10px rgba(0, 0, 0, 0.19 / rgba(0, 0, 0, 0.19));
}
.card2 .card-body .badge span {
  background-color: #c7801e;
  color: #fff;
  justify-content: center;
  align-items: center;
  font-size: 20px;
}
.card3 .card-body .badge span {
  background-color: #9c32d5;
  color: #fff;
  justify-content: center;
  align-items: center;
  font-size: 20px;
}
.card3 .card-body {
  background: linear-gradient(to right, #2199c5 0%, #330867 100%);
  border-radius: 40px 10px;
  margin-bottom: 10px;
  color: #fff;
  box-shadow: 4px 1px 8px #9c32d5;
  transition: 0.3s ease-in;
}

.card3:hover .card-body {
  cursor: pointer;
  transform: scale(1.05);
}
.card {
  border: none;
  border-radius: 10px;
  margin-bottom: 10px;
  padding: 16px;
  border: 1px solid #ccc;
  box-shadow: 1px 1px 8px rgba(17, 39, 182, 0.716);
}

.c-details span {
  font-weight: 300;
  font-size: 23px;
}

.icon {
  color: #000000;
  width: 50px;
  height: 50px;
  background-color: #ffffff;
  border-radius: 15px;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 39px;
}

.progress {
  height: 10px;
  border-radius: 10px;
}

.progress div {
  background-color: red;
}

.text1 {
  font-size: 14px;
  font-weight: 600;
}

.text2 {
  color: #a5aec0;
}
</style>
