<template>
  <router-link to="/settings" class="btn btn-info"> Back </router-link>
  <main id="battery-page">
    <div class="row">
      <div class="card">
        <div class="card-header">
          <h3 class="text-center">Battery Level</h3>
        </div>
        <div class="card-body">
          <span class="ev-icons material-symbols-outlined">
            battery_charging_90
          </span>
          <div class="battery-container">
            <div class="battery-wrapper">
              <div
                class="battery-level"
                :style="{ width: batteryPercentage + '%' }"
              ></div>
            </div>
            <div class="battery-text">{{ batteryPercentage }}%</div>
          </div>
        </div>
      </div>
      <div class="card">
        <div class="card-header">
          <h3>Charging Status</h3>
        </div>
        <div class="card-body">
          <div class="charging-info">
            <span class="status-label">Charging:</span>
            <span class="status-value"> {{ isCharging ? "Yes" : "No" }}</span>
          </div>
        </div>
      </div>
      <div class="card">
        <div class="card-header">
          <h3>Remaining Time</h3>
        </div>
        <div class="card-body">
          <div class="remaining-time-info">
            <span class="time-label">Estimated Remaining Time:</span>
            <span class="time-value">{{ remainingTime }}</span>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="card">
        <div class="card-header">
          <h3>Battery Usage History</h3>
        </div>
        <div class="card-body">
          <canvas ref="batteryChart"></canvas>
        </div>
      </div>
      <div class="card">
        <div class="card-header">
          <h3>Low Battery Notification</h3>
        </div>
        <div class="card-body">
          <button @click="simulateLowBattery">Simulate Low Battery</button>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="card">
        <div class="card-header">
          <h3>Battery Information</h3>
        </div>
        <div class="card-body">
          <div class="battery-status">
            <span class="material-icons battery-icon">battery_full</span>
            <span class="battery-percentage">{{ batteryPercentage }}%</span>
          </div>
          <div class="technical-info">
            <p>Type: Lithium-ion</p>
            <p>Voltage: 12V</p>
            <p>Capacity: 5000 mAh</p>
            <p>Charging Time: 3 hours</p>
            <!-- Add more technical information as needed -->
          </div>
        </div>
      </div>
    </div>
  </main>
</template>

<script scoped>
import Chart from "chart.js/auto";

export default {
  data() {
    return {
      batteryPercentage: 50,
      batteryHistory1: [80, 70, 65, 50, 45, 40, 30],
      isCharging: false,
      remainingTime: "2 hours",
    };
  },
  mounted() {
    this.setupDateAdapter(); // Inisialisasi adapter tanggal
    this.renderChart();
    this.renderBatteryHistoryChart();
  },
  methods: {
    setupDateAdapter() {
      Chart.register({
        id: "dayjs",
        // Atur adapter tanggal di level aplikasi
        formatters: {
          datetime: (millis) => dayjs(millis).format("YYYY-MM-DDTHH:mm:ss"),
        },
      });
    },
    renderBatteryHistoryChart() {
      const ctx = this.$refs.batteryHistoryChart.getContext("2d");

      new Chart(ctx, {
        type: "line",
        data: {
          labels: this.batteryHistory.map((data) => data.timestamp),
          datasets: [
            {
              label: "Battery Level",
              data: this.batteryHistory.map((data) => data.percentage),
              borderColor: "#007bff",
              fill: false,
            },
          ],
        },
      });
    },
    renderChart() {
      const ctx = this.$refs.batteryChart.getContext("2d");

      new Chart(ctx, {
        type: "line",
        data: {
          labels: this.generateLabels(),
          datasets: [
            {
              label: "Battery Usage",
              data: this.batteryHistory1, // Ganti dengan properti yang sesuai
              borderColor: "#007bff",
              fill: false,
            },
          ],
        },
        options: {
          responsive: true,
          maintainAspectRatio: false,
          scales: {
            x: {
              type: "linear",
              position: "bottom",
              min: 0,
            },
            y: {
              min: 0,
              max: 100,
            },
          },
        },
      });
    },
    generateLabels() {
      // Generate labels for the chart (e.g., timestamps or indices)
      return Array.from(
        { length: this.batteryHistory1.length },
        (_, i) => i + 1
      );
    },
    simulateLowBattery() {
      const lowBatteryThreshold = 20;
      const currentBatteryLevel = 18;

      if (currentBatteryLevel <= lowBatteryThreshold) {
        this.showLowBatteryNotification();
      }
    },
    showLowBatteryNotification() {
      if ("Notification" in window) {
        Notification.requestPermission().then((permission) => {
          if (permission === "granted") {
            new Notification("Low Battery Warning", {
              body: "Battery level is low. cAS gOBLOK.",
              icon: "path/to/your/icon.png",
            });
          }
        });
      } else {
        console.error("Browser does not support notifications");
      }
    },
    openBatterySettings() {
      console.log("Opening battery settings...");
    },
    callEmergencyHotline() {
      console.log("Calling emergency hotline...");
    },
  },
};
</script>

<style scoped>
.card {
  width: auto;
  height: auto;
  padding: 10px;
  margin: 10px;
  display: flex;
  flex-direction: column;
  font-size: 20px;
}
.ev-icons {
  font-size: 4rem;
}
.card-body {
  display: flex;
  flex-direction: column;

  align-content: center;
}
</style>
