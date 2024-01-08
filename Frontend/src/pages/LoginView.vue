<template>
  <div class="container">
    <h2 class="text-center">Login</h2>
    <div class="card">
      <div class="card-body">
        <form @submit.prevent="login">
          <div class="form-group">
            <label for="username">Username</label>
            <input
              type="text"
              v-model="user.username"
              class="form-control"
              required
            />
          </div>
          <div class="form-group">
            <label for="password">Password</label>
            <input
              type="password"
              v-model="user.password"
              class="form-control"
              required
            />
          </div>
          <p>
            <button class="btn btn-primary" @click="loginUser">Login</button>
          </p>
          <p>
            Don't have an account?
            <router-link to="/register">Register Here</router-link>
          </p>
        </form>
      </div>
    </div>
  </div>
</template>

<script setup>
import axios from "axios";
import { ref } from "vue";
import { useRouter } from "vue-router";

const user = ref({ username: "", password: "" });
const errorMessage = ref("");
const router = useRouter();

const login = async () => {
  // Validasi agar form tidak kosong
  if (!user.value.username || !user.value.password) {
    errorMessage.value = "Please fill out all fields";
    return;
  }

  try {
    console.log("Connecting to backend..."); // Tambahkan log ini

    // Fetch user data based on username
    const response = await axios.get(
      `http://localhost:5205/users?username=${user.value.username}`
    );
    const foundUser = response.data[0];

    // Check if user exists
    if (!foundUser) {
      errorMessage.value = "Username not found";
      console.error("Username not found");
      return;
    }

    console.log("Backend connection successful"); // Tambahkan log ini

    // Check if password matches
    if (foundUser.password !== user.value.password) {
      errorMessage.value = "Incorrect password";
      console.error("Incorrect password");
      return;
    }

    // Redirect to home after successful login
    router.push("/home");
    console.log("Login successful");
  } catch (error) {
    errorMessage.value = "Login failed: " + error.message;
    console.error("Login failed:", error.message);
  } finally {
    // Log any additional information or actions here
  }
};
</script>

<style scoped>
.card {
  width: 400px;
  margin: auto;
  margin-top: 50px;
}
.container .text-center {
  padding-top: -90;
}
</style>
