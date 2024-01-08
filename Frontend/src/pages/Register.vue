<template>
  <div class="container">
    <h2 class="text-center">Register</h2>
    <div class="card">
      <div class="card-body">
        <form @submit.prevent="register">
          <div class="form-group">
            <label for="username">Username</label>
            <input
              type="text"
              v-model="newUser.username"
              class="form-control"
              required
            />
          </div>
          <div class="form-group">
            <label for="email">Email*</label>
            <input
              type="email"
              v-model="newUser.email"
              class="form-control"
              required
            />
          </div>
          <div class="form-group">
            <label for="password">Password*</label>
            <input
              type="password"
              v-model="newUser.password"
              class="form-control"
              required
            />
          </div>
          <div class="form-group">
            <label for="confirmPassword">Confirm Password*</label>
            <input
              type="password"
              v-model="newUser.confirmPassword"
              class="form-control"
              required
            />
            <small class="text-danger" v-if="passwordsDoNotMatch">
              Passwords do not match
            </small>
          </div>
          <p>
            <button class="btn btn-primary" @click="createUser">
              Register
            </button>
          </p>
          <p>
            Do You Have An Account??
            <router-link to="/">Login Here</router-link>
          </p>
        </form>
      </div>
    </div>
  </div>
</template>

<script setup>
import axios from "axios";
import { useRouter } from "vue-router";
import { onMounted, ref, computed } from "vue";

// define users (much user), user (one user)
const users = ref([]);

//define for new user
const newUser = ref({ username: "", password: "", email: "" });

// define for edit user
const editableUser = ref({});

//define edit user by selected id is null
const editingUserId = ref(null);

// error messege
const errorMessage = ref("");

//Call api url from backend
const apiUrl = "http://localhost:5205/users";

const router = useRouter();

//Function fetch get data users
const fetchUsers = async () => {
  try {
    const response = await axios.get(apiUrl);
    users.value = response.data; //Condition if success fetch data user
  } catch (error) {
    errorMessage.value = "Failed to fetch users: " + error.message; //Condtion if error fetch data user
  }
};

// Computed property untuk menentukan apakah password dan confirmPassword cocok
const passwordsDoNotMatch = computed(
  () => newUser.value.password !== newUser.value.confirmPassword
);

//Function for created user
const createUser = async () => {
  // Validasi agar form tidak kosong
  if (
    !newUser.value.username ||
    !newUser.value.password ||
    !newUser.value.email
  ) {
    errorMessage.value = "Please fill out all fields";
    return;
  }

  // Validasi agar password dan confirmPassword sama
  if (passwordsDoNotMatch.value) {
    errorMessage.value = "Password and Confirm Password must match";
    return;
  }

  // Validasi agar username dan email tidak sama
  const existingUser = users.value.find(
    (user) =>
      user.username === newUser.value.username ||
      user.email === newUser.value.email
  );
  if (existingUser) {
    errorMessage.value = "Username or Email already exists";
    return;
  }

  try {
    const response = await axios.post(apiUrl, newUser.value);
    // Reset form setelah berhasil membuat pengguna
    newUser.value = {
      username: "",
      password: "",
      email: "",
      confirmPassword: "",
    };
    errorMessage.value = ""; // Reset pesan kesalahan
    fetchUsers();

    // Redirect ke halaman login setelah berhasil mendaftar
    // Gantilah '/login' dengan path yang sesuai
    router.push("/");
  } catch (error) {
    errorMessage.value = "Failed to create user: " + error.message;
  }
};

//delete user
const deleteUser = async (id) => {
  try {
    await axios.delete(`${apiUrl}/${id}`);
    fetchUsers();
  } catch (error) {
    errorMessage.value = "Failed to delete user: " + error.message;
  }
};

//update user
const updateUser = async (id) => {
  try {
    await axios.put(`${apiUrl}/${id}`, editableUser.value);
    cancelEdit();
    fetchUsers();
  } catch (error) {
    errorMessage.value = "Failed to update user: " + error.message;
  }
};

const startEdit = (user) => {
  editingUserId.value = user.id;
  editableUser.value = { ...user };
};

const cancelEdit = () => {
  editingUserId.value = null;
  editableUser.value = {};
};

//Define for get all data users
onMounted(() => {
  fetchUsers();
});
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
