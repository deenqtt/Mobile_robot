<template>
  <div class="container">
    <div class="card">
      <label for="dateFormat">Select Date Format:</label>
      <select v-model="selectedFormat" @change="updateFormattedDate">
        <option value="full">Full</option>
        <option value="short">Short</option>
        <!-- Add more format options as needed -->
      </select>

      <div>
        <p>Current Date and Time:</p>
        <p>{{ formattedDate }}</p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      formattedDate: "",
      selectedFormat: "full", // Default format
    };
  },
  mounted() {
    this.updateFormattedDate();
  },
  methods: {
    updateFormattedDate() {
      const currentDate = new Date();
      this.formattedDate = this.formatDate(currentDate, this.selectedFormat);
    },
    formatDate(date, format) {
      const options = {
        year: "numeric",
        month: "long",
        day: "numeric",
        hour: "numeric",
        minute: "numeric",
        second: "numeric",
      };

      switch (format) {
        case "short":
          options.year = undefined;
          options.month = "numeric";
          options.day = "numeric";
          break;
        // Add more cases for additional formats if needed

        default:
          // 'full' format is already set in options
          break;
      }

      return date.toLocaleString(undefined, options);
    },
  },
};
</script>

<style>
/* Add your styles if needed */
.container {
  display: flex;
}

.card {
  margin-top: 30px;
  margin-left: -30px;
  width: 300px; /* Adjust the width as needed */
  padding: 20px;
  border: 1px solid #ccc;
  border-radius: 8px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}
</style>
