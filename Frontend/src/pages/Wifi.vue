<template>
  <div class="container">
    <div class="row">
      <div class="card">
        <div class="card-header">
          <h2 class="text-center">Wi-Fi Networks</h2>
        </div>
        <div class="card-body">
          <!-- Display a list of available Wi-Fi networks -->
          <ul>
            <li v-for="network in availableNetworks" :key="network.id">
              {{ network.ssid }}
              <button @click="connectToNetwork(network)" :disabled="loading">
                {{
                  loading && selectedNetwork === network
                    ? "Connecting..."
                    : "Connect"
                }}
              </button>
            </li>
          </ul>
          <div v-if="loading" class="loading-spinner"></div>
          <p>{{ connectionStatus }}</p>
        </div>
      </div>
      <!-- Selected network details -->
      <div class="card" v-if="selectedNetwork">
        <div class="card-header"><h3>Selected Network</h3></div>
        <p>SSID: {{ selectedNetwork.ssid }}</p>
        <p>Signal Strength: {{ selectedNetwork.signalStrength }}</p>
        <button @click="disconnectFromNetwork" :disabled="loading">
          {{ loading ? "Disconnecting..." : "Disconnect" }}
        </button>
      </div>

      <!-- Loading spinner -->

      <!-- Connection status -->
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      availableNetworks: [
        { id: 1, ssid: "Network1", signalStrength: 80 },
        { id: 2, ssid: "Network2", signalStrength: 70 },
        // Add more networks as needed
      ],
      selectedNetwork: null,
      loading: false,
      connectionStatus: "",
    };
  },
  methods: {
    connectToNetwork(network) {
      // Simulate connection process with a timeout
      this.loading = true;
      setTimeout(() => {
        this.selectedNetwork = { ...network };
        this.loading = false;
        this.updateConnectionStatus();
      }, 2000); // Simulated 2 seconds connection time
    },
    disconnectFromNetwork() {
      // Simulate disconnection process with a timeout
      this.loading = true;
      setTimeout(() => {
        this.selectedNetwork = null;
        this.loading = false;
        this.updateConnectionStatus();
      }, 2000); // Simulated 2 seconds disconnection time
    },
    updateConnectionStatus() {
      // Check if the device is online
      this.connectionStatus = navigator.onLine
        ? "Connected to the internet."
        : "Unable to connect to the internet.";
    },
  },
  created() {
    // Initial connection status check
    this.updateConnectionStatus();

    // Add event listener for online/offline changes
    window.addEventListener("online", this.updateConnectionStatus);
    window.addEventListener("offline", this.updateConnectionStatus);
  },
  destroyed() {
    // Remove event listener when the component is destroyed
    window.removeEventListener("online", this.updateConnectionStatus);
    window.removeEventListener("offline", this.updateConnectionStatus);
  },
};
</script>

<style>
/* Add your styles here */

.card {
  width: 400px;
  margin-top: 40px;
  margin-left: -30px;
  margin-right: 50px;
}
.card .card-header {
  margin: 10px;
  border-radius: 10px;
}

.loading-spinner {
  border: 8px solid #f3f3f3;
  border-top: 8px solid #3498db;
  border-radius: 50%;
  width: 50px;
  height: 50px;
  animation: spin 1s linear infinite;
}

@keyframes spin {
  0% {
    transform: rotate(0deg);
  }
  100% {
    transform: rotate(360deg);
  }
}
ul li {
  list-style: none;
  margin-bottom: 20px;
}
button {
  border: none;
  background: none;
}
button:hover {
  cursor: pointer;
  color: #3498db;
}
</style>
