<template>
  <router-link to="/home">
    <img src="../assets/left-arrow-7344.png" class="btn" alt="" />
  </router-link>
  <div class="container">
    <div class="card1">
      <div class="card">
        <div class="card-body">
          <img
            src="../assets/pngwing.com.png"
            width="100px"
            alt="yourprofile"
          />
          <br />
          <h2 class="text-center mt-3">Your Profile</h2>
          <br />
          <h5 class="text-center">PT Graha Sumber Prima Elekronik</h5>
          <p><router-link to="/logout"> Logout</router-link></p>
        </div>
      </div>
    </div>
    <div class="card2">
      <div class="card">
        <div class="card-body">
          <h2>Details</h2>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
// script for profile
import { mapState } from "vuex";
export default {
  data() {
    return {
      isEditing: false,
    };
  },
  computed: {
    ...mapState(["userData"]), // get the state of userdata in store
  },
  methods: {
    editProfile() {
      this.$router.push("/update");
    },
    goBack() {
      window.history.back();
    },
  },
};
</script>

<style scoped>
img {
  margin-left: 40px;
}
.container {
  display: flex;
}
.card2 .card {
  margin-left: 50px;
  width: 600px;
  align-items: center;
}
.card {
  width: 400px;
  height: 80vh;
  box-shadow: none;
  border: solid black;
}
.card1 .card-body {
  /* Set the height to fill the viewport */
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

/* Additional styles for h2, h5, and p if needed */
h2 {
  font-size: 1.5rem;
  color: #333;
}

h5 {
  font-size: 1rem;
  color: #555;
}

p {
  margin-top: auto; /* Push the "Logout" link to the bottom */
}
.container img {
  margin-left: -10px;
}
</style>
