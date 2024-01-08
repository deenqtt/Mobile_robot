import { createApp } from "vue";
import App from "./App.vue";

// import './assets/app.css'
import router from "./router";

const app = createApp(App);

app.use(router);
app.mount("#app");

// public class User{
//     public int Id {get; set;}
//     public string Name {}
//     public string Name {}
//     public string Name {}
//     public string Name {}
// }
