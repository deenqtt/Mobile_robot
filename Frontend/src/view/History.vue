<template>
  <div id="app">
    <button class="button-29" @click="startRobot">Start Robot</button>
    <button class="button-29" @click="stopRobot">Stop Robot</button>
    <button class="button-29" @click="handleEmergency">Emergency</button>
    <button class="button-29" @click="updateLocation('New Location')">
      Update
    </button>

    <br />
    <br />
    <div class="row">
      <div class="card">
        <div class="card-header">
          <h5 class="text-center">Robot Control Interface</h5>
        </div>
        <div class="card-body">
          <h5 class="mb-0">Riwayat Aktivitas Robot</h5>
          <br />
          <ul>
            <li v-for="activity in activities" :key="activity.id">
              {{ activity.timestamp }} - {{ activity.message }}
            </li>
          </ul>
        </div>
      </div>
      <div class="card">
        <div class="card-header">
          <h5 class="text-center">Robot Control 2</h5>
        </div>
        <div class="card-body">
          <h5 class="mb-0">Riwayat Aktivitas Robot</h5>
          <br />
          <ul>
            <li v-for="activity in activities" :key="activity.id">
              {{ activity.timestamp }} - {{ activity.message }}
            </li>
          </ul>
        </div>
      </div>
    </div>
    <button class="button-28" @click="clearData">Clear Data</button>
    <br />

    <div class="row">
      <div class="card">
        <div class="card-header">
          <h5 class="text-center">Robot Control Interface</h5>
        </div>
        <div class="card-body">
          <h5 class="mb-0">Catatan Log dan Peristiwa Penting</h5>
          <br />
          <ul>
            <li v-for="logEntry in log" :key="logEntry.id">
              {{ logEntry.timestamp }} - {{ logEntry.message }}
            </li>
          </ul>
        </div>
      </div>

      <br />

      <div class="card">
        <div class="card-header">
          <h5 class="text-center">Kinerja Robot</h5>
        </div>
        <div class="card-body">
          <ul>
            <li>Battery Information:</li>
            <ul>
              <li>Usage Time: {{ batteryUsageTime }}</li>
              <li>Charge Level: {{ batteryChargeLevel }}%</li>
            </ul>
            <li>Environmental Conditions:</li>
            <ul>
              <li>Temperature: {{ temperature }}°C</li>
              <li>Humidity: {{ humidity }}%</li>
            </ul>
            <li>Sensor Performance: {{ sensorPerformance }}</li>
          </ul>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      activities: this.retrieveData() || [],
      // Your existing data properties
      totalActiveTime: 0, // in seconds
      totalDistance: 0, // in meters
      totalMediaCount: 0,
      // ...
    };
  },
  methods: {
    logActivity(message) {
      const timestamp = new Date().toLocaleString();
      const newActivity = {
        id: Date.now(),
        timestamp,
        message,
      };
      this.activities.unshift(newActivity);
      this.saveData(); // Save data to local storage
    },

    startRobot() {
      this.logActivity("Robot diaktifkan");
    },
    stopRobot() {
      this.logActivity("Robot dimatikan");
    },
    handleEmergency() {
      this.logActivity("Robot mengalami keadaan darurat");
    },
    updateLocation(newLocation) {
      this.logActivity(`Lokasi robot berubah: ${newLocation}`);
    },
    clearData() {
      this.activities = [];
      this.saveData(); // Save empty data to local storage
    },
    saveData() {
      localStorage.setItem("robotActivities", JSON.stringify(this.activities));
    },
    retrieveData() {
      const storedData = localStorage.getItem("robotActivities");
      return storedData ? JSON.parse(storedData) : null;
    },
    updateStatistics(activity) {
      if (activity.message === "Robot diaktifkan") {
        this.totalActiveTime += 60; // Assuming each activity represents 1 minute
        this.totalDistance += 10; // Assuming each activity represents 10 meters traveled
      }

      if (
        activity.message === "Robot mengambil foto." ||
        activity.message === "Robot merekam video."
      ) {
        this.totalMediaCount += 1;
      }
    },

    // Example method to clear statistics
    clearStatistics() {
      this.totalActiveTime = 0;
      this.totalDistance = 0;
      this.totalMediaCount = 0;
    },
  },
  computed: {
    // Example computed property to format total active time
    formatTime() {
      const hours = Math.floor(this.totalActiveTime / 3600);
      const minutes = Math.floor((this.totalActiveTime % 3600) / 60);
      const seconds = this.totalActiveTime % 60;
      return `${hours}h ${minutes}m ${seconds}s`;
    },
  },
};
</script>

<style scoped>
.button-29 {
  align-items: center;
  appearance: none;
  background-image: radial-gradient(
    100% 100% at 100% 0,
    #5adaff 0,
    #5468ff 100%
  );
  border: 0;
  border-radius: 6px;
  box-shadow: rgba(45, 35, 66, 0.4) 0 2px 4px,
    rgba(45, 35, 66, 0.3) 0 7px 13px -3px, rgba(58, 65, 111, 0.5) 0 -3px 0 inset;
  box-sizing: border-box;
  color: #fff;
  cursor: pointer;
  display: inline-flex;
  font-family: "JetBrains Mono", monospace;
  height: 48px;
  justify-content: center;
  line-height: 1;
  list-style: none;
  overflow: hidden;
  padding-left: 16px;
  padding-right: 16px;
  position: relative;
  text-align: left;
  text-decoration: none;
  transition: box-shadow 0.15s, transform 0.15s;
  user-select: none;
  -webkit-user-select: none;
  touch-action: manipulation;
  white-space: nowrap;
  will-change: box-shadow, transform;
  font-size: 18px;
}

.button-29:focus {
  box-shadow: #3c4fe0 0 0 0 1.5px inset, rgba(45, 35, 66, 0.4) 0 2px 4px,
    rgba(45, 35, 66, 0.3) 0 7px 13px -3px, #3c4fe0 0 -3px 0 inset;
}

.button-29:hover {
  box-shadow: rgba(45, 35, 66, 0.4) 0 4px 8px,
    rgba(45, 35, 66, 0.3) 0 7px 13px -3px, #3c4fe0 0 -3px 0 inset;
  transform: translateY(-2px);
}

.button-29:active {
  box-shadow: #3c4fe0 0 3px 7px inset;
  transform: translateY(2px);
}

#app {
  margin: 40px;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  margin-bottom: 8px;
}

button {
  padding: 10px;
  margin: 5px;
  font-size: 16px;
  cursor: pointer;
}
.card {
  margin-right: 25px;
  width: 500px;
  height: 300px;
  box-shadow: 1px 4px 4px;
  margin-bottom: 10px;
  padding: 20px;
  border-radius: 10px;
  overflow: auto;
  backdrop-filter: blur(10px); /* Adjust the blur value as needed */
  background: rgba(
    255,
    255,
    255,
    0.1
  ); /* Adjust the background color and opacity */
}
.button-28 {
  align-items: center;
  appearance: none;
  background-image: radial-gradient(
    100% 100% at 100% 0,
    #cc1d1d 0,
    #ff0000 100%
  );
  border: 0;
  border-radius: 6px;
  box-shadow: rgba(45, 35, 66, 0.4) 0 2px 4px,
    rgba(45, 35, 66, 0.3) 0 7px 13px -3px, rgba(58, 65, 111, 0.5) 0 -3px 0 inset;
  box-sizing: border-box;
  color: #fff;
  cursor: pointer;
  display: inline-flex;
  font-family: "JetBrains Mono", monospace;
  height: 48px;
  justify-content: center;
  line-height: 1;
  list-style: none;
  overflow: hidden;
  padding-left: 16px;
  padding-right: 16px;
  position: relative;
  text-align: left;
  text-decoration: none;
  transition: box-shadow 0.15s, transform 0.15s;
  user-select: none;
  -webkit-user-select: none;
  touch-action: manipulation;
  white-space: nowrap;
  will-change: box-shadow, transform;
  font-size: 18px;
}

.button-28:focus {
  box-shadow: #3c4fe0 0 0 0 1.5px inset, rgba(45, 35, 66, 0.4) 0 2px 4px,
    rgba(45, 35, 66, 0.3) 0 7px 13px -3px, #3c4fe0 0 -3px 0 inset;
}

.button-28:hover {
  box-shadow: rgba(45, 35, 66, 0.4) 0 4px 8px,
    rgba(45, 35, 66, 0.3) 0 7px 13px -3px, #3c4fe0 0 -3px 0 inset;
  transform: translateY(-2px);
}

.button-28:active {
  box-shadow: #3c4fe0 0 3px 7px inset;
  transform: translateY(2px);
}
</style>
