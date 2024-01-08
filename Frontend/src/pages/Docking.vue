<template>
  <main id="docking-page">
    <router-link to="/settings" class="btn btn-danger"> Back</router-link>
    <div class="row">
      <!-- Panduan Penggunaan -->
      <div class="card">
        <div class="user-guide">
          <h2>Panduan Penggunaan</h2>
          <p>
            1. Tempatkan robot di tempat yang benar di depan stasiun pengisian.
          </p>
          <p>
            2. Pastikan koneksi pengisian stabil sebelum memulai proses
            pengisian.
          </p>
          <!-- Add more user guide steps as needed -->
        </div>
      </div>
      <!-- Keamanan -->
      <div class="card">
        <div class="security">
          <h2>Keamanan</h2>
          <p>
            Pastikan untuk mengunci stasiun pengisian ketika tidak digunakan
            untuk mencegah akses yang tidak sah.
          </p>
          <!-- Add more security information as needed -->
        </div>
      </div>
    </div>
    <div class="row">
      <div class="card">
        <div class="charging-card">
          <h2>Status Pengisian Baterai</h2>
          <div class="battery-level">
            <p>Tingkat Baterai:</p>
            <div class="battery-indicator-container">
              <div
                class="battery-indicator"
                :style="{ width: batteryWidth }"
              ></div>
            </div>
          </div>
          <div class="status-docking">
            <p>Status Docking:</p>
            <img :src="dockingStatusIcon" alt="Docking Status" />
            <p>{{ dockingStatus }}</p>
          </div>
          <div class="charging-time">
            <p>Waktu Pengisian:</p>
            <p>{{ chargingTimeInfo }}</p>
          </div>
        </div>
      </div>
      <!-- Card untuk Riwayat Pengisian Baterai -->
      <div class="card">
        <div class="charging-history-card">
          <h2>Riwayat Pengisian Baterai</h2>
          <ul>
            <li v-for="history in chargingHistory" :key="history.id">
              <p>{{ history.date }} - {{ history.duration }}</p>
            </li>
          </ul>
        </div>
      </div>
      <div class="card">
        <div class="notification-card">
          <h2>Pemberitahuan dan Notifikasi</h2>
          <p>{{ notificationMessage }}</p>
        </div>
      </div>
      <div class="card">
        <div class="technical-info">
          <h2>Informasi Teknis</h2>
          <p>Tegangan Baterai: {{ batteryVoltage }} Volt</p>
          <p>Arus Pengisian: {{ chargingCurrent }} Ampere</p>
          <!-- Add more technical parameters as needed -->
        </div>
      </div>
    </div>
  </main>
</template>
<script>
export default {
  data() {
    return {
      batteryWidth: "70%", // Example width for the battery indicator
      isDocked: true,
      isCharging: false,
      chargingStartTime: null,
      chargingHistory: [
        { id: 1, date: "2023-01-01", duration: "2 jam 30 menit" },
        { id: 2, date: "2023-01-02", duration: "1 jam 45 menit" },
        // Add more historical data as needed
      ],
      hasChargingIssue: false,
      batteryVoltage: 48.5, // Example value for battery voltage
      chargingCurrent: 10.0, // Example value for charging current
    };
  },
  computed: {
    dockingStatus() {
      return this.isDocked ? "Ter-dock" : "Belum Ter-dock";
    },
    dockingStatusIcon() {
      return this.isDocked
        ? "https://example.com/docked-icon.png"
        : "https://example.com/undocked-icon.png";
      // Replace the URLs with actual image URLs from the web
    },
    chargingTimeInfo() {
      if (this.chargingStartTime) {
        const currentTime = new Date();
        const elapsedTime = currentTime - this.chargingStartTime;
        const hours = Math.floor(elapsedTime / (1000 * 60 * 60));
        const minutes = Math.floor(
          (elapsedTime % (1000 * 60 * 60)) / (1000 * 60)
        );
        return `${hours} jam ${minutes} menit`;
      } else {
        return "Belum mulai pengisian";
      }
    },
    notificationMessage() {
      return this.hasChargingIssue
        ? "Ada masalah dengan proses pengisian atau robot keluar dari docking tanpa selesai diisi baterainya."
        : "Semua sistem berjalan dengan baik.";
    },
  },
  methods: {
    startCharging() {
      if (this.isDocked && !this.isCharging) {
        this.isCharging = true;
        this.chargingStartTime = new Date();
        // Additional logic for starting the charging process
      }
    },
    stopCharging() {
      if (this.isCharging) {
        this.isCharging = false;
        // Additional logic for stopping the charging process
        // You may want to update the charging history here
        const chargingDuration = this.calculateChargingDuration();
        this.chargingHistory.push({
          id: this.chargingHistory.length + 1,
          date: new Date().toISOString().slice(0, 10),
          duration: chargingDuration,
        });
      }
    },
    calculateChargingDuration() {
      if (this.chargingStartTime) {
        const currentTime = new Date();
        const elapsedTime = currentTime - this.chargingStartTime;
        const hours = Math.floor(elapsedTime / (1000 * 60 * 60));
        const minutes = Math.floor(
          (elapsedTime % (1000 * 60 * 60)) / (1000 * 60)
        );
        return `${hours} jam ${minutes} menit`;
      } else {
        return "0 jam 0 menit";
      }
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
}
.btn {
  margin-top: -20px;
  font-size: 20px;
  background: none;
  border: none;
  color: black;
}
.btn:hover {
  background-color: red;
  color: rgb(0, 0, 0);
}
</style>
