<template>
  <main id="maps">
    <div class="card-container">
      <div class="card">
        <div class="card-body">
          <iframe
            src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d15866.241698280586!2d106.73526995!3d-6.189527200000001!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x2e69f7122267c067%3A0x26e6e27ab6082c99!2sPT%20Kawan%20Lama%20Sejahtera!5e0!3m2!1sid!2sid!4v1703579817686!5m2!1sid!2sid"
            width="600"
            height="450"
            style="border: 0"
            allowfullscreen=""
            loading="lazy"
            referrerpolicy="no-referrer-when-downgrade"
          ></iframe>
        </div>
      </div>
      <div class="card">
        <div class="card-header">
          Add Target Robot

          <button
            class="btn btn-primary"
            data-toggle="modal"
            data-target="#Add1"
          >
            Add
          </button>
        </div>
        <div class="card-body">
          <!-- ... -->
          <table class="table table-striped">
            <thead>
              <tr>
                <th scope="col">ID</th>
                <th scope="col">From</th>
                <th scope="col">To</th>
                <th scope="col">Action</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(robot, index) in robots" :key="robot.id">
                <td>{{ robot.id }}</td>
                <td>{{ robot.from }}</td>
                <td>{{ robot.to }}</td>
                <td>
                  <button
                    type="button"
                    class="btn btn-warning"
                    @click="editTarget(index)"
                  >
                    Edit
                  </button>
                  <button
                    type="button"
                    class="btn btn-danger"
                    @click="deleteTarget(index)"
                  >
                    Delete
                  </button>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>

    <!-- Modal -->

    <!-- Modal for adding a target robot -->
    <div
      class="modal fade"
      id="Add1"
      tabindex="-1"
      role="dialog"
      aria-labelledby="exampleModalLabel"
      aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Add Target</h5>
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
            <label for="Id">ID</label>
            <input
              type="number"
              placeholder="ID"
              class="form-control"
              v-model="newTarget.id"
            />
            <br />
            <label class="text-black">From</label>
            <input
              type="text"
              class="form-control"
              placeholder="Robot Darimana"
              v-model="newTarget.from"
            />
            <br />
            <label for="To">To</label>
            <input
              type="text"
              class="form-control"
              placeholder="Mau Kemana"
              v-model="newTarget.to"
            />
          </div>
          <div class="modal-footer">
            <button
              type="button"
              class="btn btn-secondary"
              data-dismiss="modal"
            >
              Close
            </button>
            <button type="button" class="btn btn-warning" @click="addTarget">
              Input
            </button>
          </div>
        </div>
      </div>
    </div>
  </main>
</template>
<script>
export default {
  data() {
    return {
      robots: this.getStoredData() || [], // Initialize with stored data
      newTarget: {
        id: null,
        from: "",
        to: "",
      },
      editingIndex: null, // Index of the robot being edited
    };
  },
  watch: {
    // Watch for changes in the robots data and store it in localStorage
    robots: {
      handler: "storeData",
      deep: true,
    },
  },
  methods: {
    addTarget() {
      // Validate the new target data
      if (!this.newTarget.id || !this.newTarget.from || !this.newTarget.to) {
        alert("Please fill in all fields.");
        return;
      }

      if (this.editingIndex !== null) {
        // If editing, update the existing target
        this.robots.splice(this.editingIndex, 1, {
          id: this.newTarget.id,
          from: this.newTarget.from,
          to: this.newTarget.to,
        });
        this.editingIndex = null; // Reset editing state
      } else {
        // If not editing, add the new target
        this.robots.push({
          id: this.newTarget.id,
          from: this.newTarget.from,
          to: this.newTarget.to,
        });
      }

      // Clear the form
      this.newTarget = {
        id: null,
        from: "",
        to: "",
      };

      // Close the modal
      $("#Add").modal("hide");
    },
    editTarget(index) {
      // Set the new target data and open the modal for editing
      this.newTarget = { ...this.robots[index] };
      this.editingIndex = index;
      $("#Add").modal("show");
    },
    deleteTarget(index) {
      // Confirm before deleting
      if (confirm("Are you sure you want to delete this target?")) {
        // Remove the target at the specified index
        this.robots.splice(index, 1);
      }
    },
    getStoredData() {
      // Retrieve data from localStorage
      const storedData = localStorage.getItem("targetRobots");
      // Parse the data or return null if it doesn't exist
      return storedData ? JSON.parse(storedData) : null;
    },
    storeData() {
      // Save data to localStorage
      localStorage.setItem("targetRobots", JSON.stringify(this.robots));
    },
  },
};
</script>

<style scoped>
.card-container {
  display: grid;
  gap: 20px;
}
.card {
  width: 650px;
}
</style>
