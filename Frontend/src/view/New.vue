<template>
  <main id="new-page">
    <button class="btn btn-primary" @click="openModal">Add New Robot</button>

    <!-- Display entered robot data in a card -->
    <div class="card mt-4" v-if="robots.length > 0">
      <div class="card-header">
        <h5 class="card-title">Robot Details</h5>
      </div>
      <div class="card-body">
        <table class="table">
          <thead>
            <tr>
              <th>Name</th>
              <th>Type</th>
              <th>Serial Number</th>

              <th>Image</th>
              <th>Active?</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="robot in robots" :key="robot.id">
              <td>{{ robot.robotName }}</td>
              <td>{{ robot.type }}</td>
              <td>{{ robot.serialNumber }}</td>
              <td v-if="robot.image">
                <img
                  :src="robot.Image"
                  alt="Robot Image"
                  class="img-thumbnail"
                  style="max-width: 50px"
                />
              </td>
              <td v-else>No Image</td>
              <td>
                <div class="form-group">
                  <div class="form-check">
                    <input
                      type="checkbox"
                      class="form-check-input"
                      id="activeCheckbox"
                      v-model="robot.isActive"
                    />
                    <label class="form-check-label" for="activeCheckbox"
                      >Active</label
                    >
                  </div>
                </div>
              </td>
              <td>
                <button
                  class="btn btn-primary btn-sm"
                  @click="editRobot(robot)"
                >
                  Edit
                </button>
                <br />
                <button
                  class="btn btn-danger btn-sm"
                  @click="deleteRobot(robot)"
                >
                  Delete
                </button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>

    <!-- modal edit -->
    <div
      class="modal fade"
      id="editRobotModal"
      tabindex="-1"
      role="dialog"
      aria-labelledby="editRobotModalLabel"
      aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="editRobotModalLabel">Edit Robot</h5>
            <button
              type="button"
              class="close"
              data-dismiss="modal"
              aria-label="Close"
              @click="closeEditModal"
            >
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <!-- Form for editing a robot -->
            <form @submit.prevent="updateRobot">
              <!-- ... (existing form fields) ... -->

              <!-- ... (existing form submit button) ... -->
              <button type="submit" class="btn btn-primary">
                Save Changes
              </button>
            </form>
          </div>
        </div>
      </div>
    </div>
    <!-- Modal for Add New Robot -->
    <div
      class="modal fade"
      id="addRobotModal"
      tabindex="-1"
      role="dialog"
      aria-labelledby="addRobotModalLabel"
      aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="addRobotModalLabel">Add New Robot</h5>
            <button
              type="button"
              class="close"
              data-dismiss="modal"
              aria-label="Close"
              @click="closeRobotModal"
            >
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <!-- Form for adding a new robot -->
            <form @submit.prevent="saveRobot">
              <div class="form-group">
                <label for="robotName">Robot Name:</label>
                <input
                  type="text"
                  class="form-control"
                  id="robotName"
                  v-model="newRobot.RobotName"
                  required
                />
              </div>
              <div class="form-group">
                <label for="robotType">Robot Type:</label>
                <select
                  class="form-control"
                  id="robotType"
                  v-model="newRobot.Type"
                  required
                >
                  <option value="Industrial">Industrial</option>
                  <option value="Exploration">Exploration</option>
                  <!-- Add more options as needed -->
                </select>
              </div>
              <div class="form-group">
                <label for="robotSerialNumber">Serial Number:</label>
                <input
                  type="text"
                  class="form-control"
                  id="robotSerialNumber"
                  v-model="newRobot.SerialNumber"
                  required
                />
              </div>

              <!-- Add more input fields as needed -->
              <div class="form-group">
                <label for="robotImage">Robot Image:</label>
                <input
                  type="file"
                  class="form-control-file"
                  id="robotImage"
                  @change="handleImageUpload"
                />
                <!-- Tampilkan preview gambar -->
                <img
                  v-if="newRobot.Image"
                  alt="Robot Image"
                  class="img-thumbnail mt-2"
                  style="max-width: 200px"
                />
              </div>

              <button type="submit" class="btn btn-primary">Save Robot</button>
            </form>
          </div>
        </div>
      </div>
    </div>
  </main>
</template>

<script setup>
import axios from "axios";
import { onMounted, ref } from "vue";

const robots = ref([]);
const newRobot = ref({
  RobotName: "",
  Type: "",
  SerialNumber: 0,
  Image: "0",
});

const editableRobot = ref({});
const editingRobotId = ref(null);
const errorMessage = ref("");
const apiUrl = "http://localhost:5205/robots";

const fetchRobots = async () => {
  try {
    const response = await axios.get(apiUrl);
    robots.value = response.data;
  } catch (error) {
    errorMessage.value = "Failed to fetch robots: " + error.message;
  }
};

const generateRandomSerialNumber = () => {
  return Math.floor(1000 + Math.random() * 9000);
};
const handleImageUpload = (event) => {
  const file = event.target.files[0];
  const reader = new FileReader();

  reader.onload = () => {
    newRobot.Image = reader.result;
  };

  if (file) {
    reader.readAsDataURL(file);
  }
};

const saveRobot = async () => {
  try {
    const response = await axios.post(apiUrl, newRobot.value);
    console.log(response.data);

    const robotsResponse = await axios.get(apiUrl);
    robots.value = robotsResponse.data;

    newRobot.value = {
      RobotName: "",
      Type: "",
      SerialNumber: 0,
      Image: null, // Ganti ke null untuk mereset gambar
    };

    // Tampilkan notifikasi sukses (gunakan library notifikasi atau buat sendiri)
    // Contoh sederhana dengan menggunakan window.alert
    window.alert("Robot successfully saved!");

    closeRobotModal();
  } catch (error) {
    console.error(error);
    errorMessage.value = "Failed to save robot: " + error.message;
  }
};
//delete
const deleteRobot = async (robot) => {
  const confirmDelete = window.confirm(
    "Are you sure you want to delete this robot?"
  );
  if (confirmDelete) {
    try {
      await axios.delete(`${apiUrl}/${robot.id}`);
      fetchRobots();
      window.alert("Robot successfully deleted!");
    } catch (error) {
      errorMessage.value = "Failed to delete robot: " + error.message;
    }
  }
};

const openModal = () => {
  newRobot.value.SerialNumber = generateRandomSerialNumber();
  $("#addRobotModal").modal("show");
};

const closeRobotModal = () => {
  $("#addRobotModal").modal("hide");
};

const startEditRobot = (robot) => {
  editingRobotId.value = robot.id;
  editableRobot.value = { ...robot };
};

const cancelEditRobot = () => {
  editingRobotId.value = null;
  editableRobot.value = {};
};

const updateRobot = async (id) => {
  try {
    await axios.put(`${apiUrl}/${id}`, editableRobot.value);
    cancelEditRobot();
    fetchRobots();
  } catch (error) {
    errorMessage.value = "Failed to update robot: " + error.message;
  }
};

onMounted(() => {
  console.log("Component mounted");
  fetchRobots();
});
</script>
<style scoped>
.img-thumbnail {
  max-height: 50px;
}
/* Style for the button */
button.btn-primary {
  margin-bottom: 20px;
}

/* Style for the modal */
.modal-content {
  border-radius: 10px;
}

.modal-header {
  background-color: #007bff;
  color: white;
  border-top-left-radius: 10px;
  border-top-right-radius: 10px;
}

.modal-title {
  font-weight: bold;
}

/* Style for the form */
form {
  margin-top: 20px;
}

.form-group {
  margin-bottom: 20px;
}

label {
  font-weight: bold;
}
.card-header {
  border-radius: 20px;
  margin: 10px;
}
.card {
  overflow: auto;
  height: 400px;
}
/* Add more styles as needed */
</style>
