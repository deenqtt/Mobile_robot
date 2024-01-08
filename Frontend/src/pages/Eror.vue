<template>
  <!-- informasi dasar robot -->

  <ul class="cards">
    <li>
      <router-link to="/settings">
        <button class="btn btn-info">Back</button>
      </router-link>
    </li>
    <li>
      <div class="card-body">
        <div class="card">
          <img
            src="https://i.imgur.com/oYiTqum.jpg"
            class="card__image"
            alt=""
          />
          <div class="card__overlay">
            <div class="card__header">
              <svg class="card__arc" xmlns="http://www.w3.org/2000/svg">
                <path />
              </svg>
              <img class="card__thumb" src="" alt="" />
              <div class="card__header-text">
                <h3 class="card__title">Robot 1</h3>
                <p class="card__status">{{ connectionStatus }}</p>
              </div>
            </div>
            <p class="card__description">
              Lorem ipsum dolor sit amet consectetur adipisicing elit.
              Asperiores, blanditiis?
            </p>
          </div>
        </div>
        <div class="card1">
          <div class="card">
            <br />
            <h2>Riwayat Kerusakan</h2>
            <button
              class="btn btn-danger"
              data-toggle="modal"
              data-target="#cekRiwayat"
            >
              Cek Riwayat
            </button>
            <br /><br />
            <h2>Notifikasi Push</h2>
            <button
              @click="
                sendNotification(
                  'error',
                  'Kehilangan koneksi',
                  'Me-reboot sistem robot.'
                )
              "
            >
              Notifikasi Kesalahan
            </button>
            <button
              @click="
                sendNotification('info', 'Informasi', 'Pemberitahuan rutin.')
              "
            >
              Notifikasi Informasi
            </button>
            <br /><br />
            <h2>Rekomendasi Perbaikan</h2>
            <button
              class="btn btn-danger"
              data-toggle="modal"
              data-target="#cekRekomendasi"
            >
              Cek Rekomendasi
            </button>
          </div>
        </div>
      </div>
    </li>
    <li>
      <div class="card-body">
        <div class="card">
          <img
            src="https://i.imgur.com/2DhmtJ4.jpg"
            class="card__image"
            alt=""
          />
          <div class="card__overlay">
            <div class="card__header">
              <svg class="card__arc" xmlns="http://www.w3.org/2000/svg">
                <path />
              </svg>
              <img class="card__thumb" src="" alt="" />
              <div class="card__header-text">
                <h3 class="card__title">Robot 2</h3>
                <p class="card__status">{{ connectionStatus }}</p>
              </div>
            </div>
            <p class="card__description">
              Lorem ipsum dolor sit amet consectetur adipisicing elit.
              Asperiores, blanditiis?
            </p>
          </div>
        </div>
        <div class="card2">
          <div class="card">
            <br />
            <h2>Riwayat Kerusakan</h2>
            <button
              class="btn btn-danger"
              data-toggle="modal"
              data-target="#cekRiwayat"
            >
              Cek Riwayat
            </button>
            <br /><br />
            <h2>Notifikasi Push</h2>
            <button
              @click="
                sendNotification(
                  'error',
                  'Kehilangan koneksi',
                  'Me-reboot sistem robot.'
                )
              "
            >
              Notifikasi Kesalahan
            </button>
            <button
              @click="
                sendNotification('info', 'Informasi', 'Pemberitahuan rutin.')
              "
            >
              Notifikasi Informasi
            </button>
            <br /><br />
            <h2>Rekomendasi Perbaikan</h2>
            <button
              class="btn btn-danger"
              data-toggle="modal"
              data-target="#cekRekomendasi"
            >
              Cek Rekomendasi
            </button>
          </div>
        </div>
      </div>
    </li>
    <li>
      <div class="card-body">
        <div class="card">
          <img
            src="https://i.imgur.com/oYiTqum.jpg"
            class="card__image"
            alt=""
          />
          <div class="card__overlay">
            <div class="card__header">
              <svg class="card__arc" xmlns="http://www.w3.org/2000/svg">
                <path />
              </svg>
              <img class="card__thumb" src="" alt="" />
              <div class="card__header-text">
                <h3 class="card__title">Robot 3</h3>
                <p
                  :class="{
                    connected: isConnected,
                    disconnected: !isConnected,
                  }"
                  class="card__status"
                >
                  {{ connectionStatus }}
                </p>
              </div>
            </div>
            <p class="card__description">
              Lorem ipsum dolor sit amet consectetur adipisicing elit.
              Asperiores, blanditiis?
            </p>
          </div>
        </div>
        <div class="card3">
          <div class="card">
            <br />
            <h2>Riwayat Kerusakan</h2>
            <button
              class="btn btn-danger"
              data-toggle="modal"
              data-target="#cekRiwayat"
            >
              Cek Riwayat
            </button>
            <br /><br />
            <h2>Notifikasi Push</h2>
            <button
              @click="
                sendNotification(
                  'error',
                  'Kehilangan koneksi',
                  'Me-reboot sistem robot.'
                )
              "
            >
              Notifikasi Kesalahan
            </button>
            <button
              @click="
                sendNotification('info', 'Informasi', 'Pemberitahuan rutin.')
              "
            >
              Notifikasi Informasi
            </button>
            <br /><br />
            <h2>Rekomendasi Perbaikan</h2>
            <button
              class="btn btn-danger"
              data-toggle="modal"
              data-target="#cekRekomendasi"
            >
              Cek Rekomendasi
            </button>
          </div>
        </div>
      </div>
    </li>
  </ul>
  <div
    class="modal fade"
    id="cekRiwayat"
    tabindex="-1"
    role="dialog"
    aria-labelledby="exampleModalLabel"
    aria-hidden="true"
  >
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">
            Riwayat Kerusakan Robot
          </h5>
          <button type="button" class="close" data-dismiss="modal"></button>
        </div>
        <div class="modal-body">
          <table class="table table-hover">
            <thead>
              <tr>
                <th scope="col">No.</th>
                <th scope="col">Tanggal Kerusakan</th>
                <th scope="col">Kerusakan yang terjadi</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>1</td>
                <td>03/04/2021</td>
                <td>Pipa gigi robot rusak</td>
              </tr>
              <tr>
                <td>2<span style="display: none">hide this</span></td>
                <td id="tgl_kerusakan2">--/--/----</td>
                <td id="deskripsi_kerusakan2">Belum ada riwayat kerusakan</td>
              </tr>
            </tbody>
          </table>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-primary" onclick="showMore()">
            Lihat Lebih Banyak
          </button>
        </div>
      </div>
    </div>
    <!-- modal cekRekomendasi perbaikan Robot -->
  </div>
  <div
    class="modal fade"
    id="cekRekomendasi"
    tabindex="-1"
    role="dialog"
    aria-labelledby="exampleModalLabel"
    aria-hidden="true"
  >
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">
            Rekomendasi Perbaikan
          </h5>
          <button type="button" class="close" data-dismiss="modal"></button>
        </div>
        <div class="modal-body">
          <table
            class="table table-striped table-borderless text-center fs-6 fw-light"
          >
            <thead>
              <tr>
                <th colspan="2">
                  Pemeliharaan Untuk :
                  <strong id="judulPerbaikan"></strong>
                </th>
              </tr>
            </thead>
            <tbody id="isiPerbaikan">
              <!-- isi dari perbaikan akan diisi oleh javascript setelah load page -->
            </tbody>
          </table>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-dismiss="modal">
            Close
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      isConnected: true,
    };
  },
  computed: {
    connectionStatus() {
      return this.isConnected ? "Robot is connected" : "Robot is disconnected";
    },
  },
  methods: {
    sendNotification(priority, title, message) {
      // Prioritaskan notifikasi berdasarkan jenis kesalahan atau informasi
      const options = {
        body: message,
      };

      if (priority === "error") {
        options.icon = "path/to/error-icon.png"; // Ganti dengan path ke ikon kesalahan
      } else {
        options.icon = "path/to/info-icon.png"; // Ganti dengan path ke ikon informasi
      }

      // Minta izin untuk menampilkan notifikasi
      Notification.requestPermission().then((permission) => {
        if (permission === "granted") {
          // Tampilkan notifikasi
          const notification = new Notification(title, options);

          // Atur waktu notifikasi muncul
          setTimeout(() => {
            notification.close();
          }, 5000); // Notifikasi akan ditutup otomatis setelah 5 detik
        }
      });
    },

    simulateConnectionUpdate() {
      // Simulate updating the connection status (replace this with actual logic)
      this.isConnected = !this.isConnected;
    },
  },
  created() {
    // You might want to fetch the initial connection status or set up event listeners here
    // For the sake of example, let's simulate an initial connection status
    this.isConnected = false;
  },
};
</script>

<style lang="scss" scoped>
.back {
  margin-left: 50px;
}
button {
  padding: 10px 15px;
  font-size: 16px;
  cursor: pointer;
  border: none;
  border-radius: 4px;
  color: #fff;
  transition: background-color 0.3s;
}

.error {
  background-color: #ff4444;
}

.info {
  background-color: #3366ff;
}

button:hover {
  background-color: #222;
}
.card-body {
  background-color: #ffffff;
  width: 1000px;
  border-radius: 20px;
  margin: 0px 10px;
  display: flex;
  gap: 20px;
}
:root {
  --surface-color: #ffffff;
  --curve: 40;
}

.cards {
  display: grid;
  margin-top: 50px;
  margin-left: 0px;
  gap: 10px;
  list-style-type: none;
}

.card__image {
  width: 100%;
  height: auto;
}

.card__overlay {
  position: absolute;
  bottom: 0;
  left: 0;
  right: 0;
  z-index: 1;
  border-radius: calc(var(--curve) * 1px);
  background-color: white;
  transform: translateY(100%);
  transition: 0.3s ease-in-out;
}

.card:hover .card__overlay {
  transform: translateY(0);
}

.card__header {
  position: relative;
  display: flex;
  align-items: center;
  gap: 2em;
  padding: 2em;
  border-radius: calc(var(--curve) * 1px) 0 0 0;
  background-color: white;
  transform: translateY(-100%);
  transition: 0.2s ease-in-out;
}

.card__arc {
  width: 80px;
  height: 80px;
  position: absolute;
  bottom: 100%;
  right: 0;
  z-index: 1;
}

.card__arc path {
  fill: white;
  d: path("M 40 80 c 22 0 40 -22 40 -40 v 40 Z");
}

.card:hover .card__header {
  transform: translateY(0);
}

.card__thumb {
  flex-shrink: 0;
  width: 50px;
  height: 50px;
  border-radius: 50%;
}

.card__title {
  font-size: 1em;
  margin: 0 0 0.3em;
  color: #6a515e;
}

.card__tagline {
  display: block;
  margin: 1em 0;
  font-family: "MockFlowFont";
  font-size: 0.8em;
  color: #d7bdca;
}

.card__status {
  font-size: 0.8em;
  color: #d7bdca;
}

.card__description {
  padding: 0 2em 2em;
  margin: 0;
  color: #d7bdca;
  font-family: "MockFlowFont";
  display: -webkit-box;
  -webkit-box-orient: vertical;
  -webkit-line-clamp: 3;
  overflow: hidden;
}
.card {
  width: 350px;
  border-radius: 20px;
  box-shadow: 1px 1px 4px;
  overflow: hidden;
  text-decoration: none;
  display: block;
  position: relative;
}
.card1 .card {
  border: none;
  box-shadow: none;
  height: 300px;
  width: 500px;
}
.card1 .card h2 {
  font-size: 20px;
}
.card1 .card .btn {
  border-radius: 50px;
  background: linear-gradient(45deg, #c72c2c, #da9b9b);
  box-shadow: 1px -7px 3px #8d8d8d, -7px 7px 27px #ffffff;
  border: none;
  width: 200px;
}
.card2 .card {
  border: none;
  box-shadow: none;
}
.card2 .card .btn {
  border-radius: 50px;
  background: linear-gradient(45deg, #34da58, #6febad);
  box-shadow: 1px -7px 3px #8d8d8d, -7px 7px 27px #ffffff;
  border: none;
  width: 200px;
}
.card3 .card {
  border: none;
  box-shadow: none;
}
.card3 .card .btn {
  border-radius: 50px;
  background: linear-gradient(45deg, #2b75e3, #1d86ba);
  box-shadow: 1px -7px 3px #8d8d8d, -7px 7px 27px #ffffff;
  border: none;
  width: 200px;
}
.card2 .card h2 {
  font-size: 20px;
}
.card3 .card h2 {
  font-size: 20px;
}
button {
  color: #222;
  background: none;
}
button:hover {
  cursor: pointer;
  background-color: white;
}
</style>
