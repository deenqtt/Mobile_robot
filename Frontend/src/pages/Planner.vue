<template>
  <!-- modal addTask -->
  <div
    class="modal fade"
    id="addTask"
    tabindex="-1"
    role="dialog"
    aria-labelled
    aria-hidden="true"
  >
    <div class="modal-dialog" role="document">
      <form @submit.prevent="onSubmit">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">Add Task</h5>
          </div>
          <div class="modal-body">
            <form @submit.prevent="scheduleTask">
              <label for="taskName">Nama Tugas:</label>
              <input
                v-model="taskName"
                type="text"
                required
                class="form-control"
              />

              <label for="taskTime">Waktu Tugas:</label>
              <input
                v-model="taskTime"
                type="time"
                required
                class="form-control"
              />

              <label for="repeatTask">Ulangi Tugas:</label>
              <select v-model="repeatTask" class="form-control">
                <option value="Once">Satu Kali</option>
                <option value="Daily">Setiap Hari</option>
                <option value="Weekly">Setiap Minggu</option>
              </select>
              <br /><br />
              <button type="submit" class="btn btn-success">
                Jadwalkan Tugas
              </button>
            </form>
          </div>
        </div>
      </form>
    </div>
  </div>
  <div class="container">
    <div class="row">
      <div class="back">
        <router-link to="/settings">
          <a style="--clr: #7808d0" class="button" href="#">
            <span class="button__icon-wrapper">
              <svg
                width="10"
                class="button__icon-svg"
                xmlns="http://www.w3.org/2000/svg"
                fill="none"
                viewBox="0 0 14 15"
              >
                <path
                  fill="currentColor"
                  d="M13.376 11.552l-.264-10.44-10.44-.24.024 2.28 6.96-.048L.2 12.56l1.488 1.488 9.432-9.432-.048 6.912 2.304.024z"
                ></path>
              </svg>

              <svg
                class="button__icon-svg button__icon-svg--copy"
                xmlns="http://www.w3.org/2000/svg"
                width="10"
                fill="none"
                viewBox="0 0 14 15"
              >
                <path
                  fill="currentColor"
                  d="M13.376 11.552l-.264-10.44-10.44-.24.024 2.28 6.96-.048L.2 12.56l1.488 1.488 9.432-9.432-.048 6.912 2.304.024z"
                ></path>
              </svg>
            </span>
            Back
          </a>
        </router-link>
      </div>
      <div class="card">
        <div class="card-header">
          <h5>Task Robot</h5>
          <button
            class="btn btn-primary"
            data-toggle="modal"
            data-target="#addTask"
          >
            <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke-width="2"
              stroke="currentColor"
              aria-hidden="true"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                d="M13.5 3H12H8C6.34315 3 5 4.34315 5 6V18C5 19.6569 6.34315 21 8 21H11M13.5 3L19 8.625M13.5 3V7.625C13.5 8.17728 13.9477 8.625 14.5 8.625H19M19 8.625V11.8125"
                stroke="#fffffff"
                stroke-width="2"
              ></path>
              <path
                d="M17 15V18M17 21V18M17 18H14M17 18H20"
                stroke="#fffffff"
                stroke-width="2"
                stroke-linecap="round"
                stroke-linejoin="round"
              ></path>
            </svg>
            ADD FILE
          </button>
        </div>
        <div class="card-body">
          <div v-if="scheduledTasks.length > 0">
            <table class="table table-hover">
              <thead>
                <tr>
                  <td>Tugas</td>
                  <td>Waktu</td>
                  <td>Pengulangan</td>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>
                    <ul>
                      <li v-for="(task, index) in scheduledTasks" :key="index">
                        {{ task.name }}
                      </li>
                    </ul>
                  </td>
                  <td>
                    <li v-for="(task, index) in scheduledTasks" :key="index">
                      {{ task.time }}
                    </li>
                  </td>
                  <td>
                    <li v-for="(task, index) in scheduledTasks" :key="index">
                      {{ task.repeat }}
                    </li>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
          <button
            class="btn btn-warning"
            @click="clearTasks"
            v-if="scheduledTasks.length > 0"
          >
            Clear Tugas
          </button>
        </div>
      </div>
      <div class="card">
        <div class="card-header">
          <h5>Log Aktivitas</h5>
        </div>
        <ul>
          <li v-for="(log, index) in activityLog" :key="index">{{ log }}</li>
        </ul>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      taskName: "",
      taskTime: "",
      repeatTask: "once",
      scheduledTasks: [],
      activityLog: [], // Tambahkan properti activityLog
    };
  },
  methods: {
    scheduleTask() {
      // Validasi input
      if (!this.taskName || !this.taskTime) {
        alert("Silakan isi semua kolom");
        return;
      }

      // Tambahkan tugas ke daftar yang dijadwalkan
      this.scheduledTasks.push({
        name: this.taskName,
        time: this.taskTime,
        repeat: this.repeatTask,
      });

      // Reset input
      this.taskName = "";
      this.taskTime = "";
      this.repeatTask = "once";

      // Tambahkan log aktivitas
      const logMessage = `Tugas dijadwalkan: ${this.taskName} pada waktu ${this.taskTime} (${this.repeatTask})`;
      this.activityLog.push(logMessage);

      // Tampilkan notifikasi
      this.showNotification("Jadwal Tugas", "Tugas berhasil dijadwalkan!");
    },

    clearTasks() {
      // Tambahkan log aktivitas
      const logMessage = "Daftar tugas dihapus.";
      this.activityLog.push(logMessage);

      // Tampilkan notifikasi
      this.showNotification("Clear Tugas", "Daftar tugas berhasil dihapus.");

      // Bersihkan daftar tugas yang dijadwalkan
      this.scheduledTasks = [];
    },

    showNotification(title, message) {
      // Tampilkan notifikasi menggunakan API Notifikasi
      if ("Notification" in window && Notification.permission === "granted") {
        new Notification(title, { body: message });
      } else if (
        "Notification" in window &&
        Notification.permission !== "denied"
      ) {
        Notification.requestPermission().then((permission) => {
          if (permission === "granted") {
            new Notification(title, { body: message });
          }
        });
      }
    },
  },
};
</script>
<style scoped>
.button {
  line-height: 1;
  text-decoration: none;
  display: inline-flex;
  align-items: center;
  gap: 0.75rem;
  background-color: var(--clr);
  color: #fff;
  border-radius: 10rem;
  font-weight: 600;
  padding: 0.75rem 1.5rem;
  padding-left: 20px;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  transition: background-color 0.3s;
}

.button__icon-wrapper {
  flex-shrink: 0;
  width: 25px;
  height: 25px;
  position: relative;
  color: var(--clr);
  background-color: #fff;
  border-radius: 50%;
  display: grid;
  place-items: center;
  overflow: hidden;
}

.button:hover {
  background-color: #000;
}

.button:hover .button__icon-wrapper {
  color: #000;
}

.button__icon-svg--copy {
  position: absolute;
  transform: translate(-150%, 150%);
}

.button:hover .button__icon-svg:first-child {
  transition: transform 0.3s ease-in-out;
  transform: translate(150%, -150%);
}

.button:hover .button__icon-svg--copy {
  transition: transform 0.3s ease-in-out 0.1s;
  transform: translate(0);
}
.card-body {
  list-style-type: none;
}
.card {
  margin: 15px;
  height: 400px;
  width: 500px;
  border-radius: 10px 40px;
  box-shadow: 1px 2px 4px;
}
.card-header {
  margin: 10px;
  border-radius: 10px 40px;
  box-shadow: 1px 1px 4px;
}
button {
  border: none;
  display: flex;
  padding: 0.75rem 1.5rem;
  background-color: #488aec;
  color: #ffffff;
  font-size: 0.75rem;
  line-height: 1rem;
  font-weight: 700;
  text-align: center;
  text-transform: uppercase;
  vertical-align: middle;
  align-items: center;
  border-radius: 0.5rem;
  user-select: none;
  gap: 0.75rem;
  box-shadow: 0 4px 6px -1px #488aec31, 0 2px 4px -1px #488aec17;
  transition: all 0.6s ease;
}

button:hover {
  box-shadow: 0 10px 15px -3px #488aec4f, 0 4px 6px -2px #488aec17;
}

button:focus,
button:active {
  opacity: 0.85;
  box-shadow: none;
}

button svg {
  width: 1.25rem;
  height: 1.25rem;
}
.back {
  margin: 10px;
}
</style>
