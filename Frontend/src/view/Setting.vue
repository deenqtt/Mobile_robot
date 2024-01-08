<template>
  <main id="setting-page">
    <div class="kontainer">
      <div class="row">
        <div class="card">
          <router-link class="card-body" to="/battery">
            <span class="material-symbols-outlined ev-icon">map</span>
            <h5 class="text-black text-center">Battery</h5>
          </router-link>
        </div>
        <div class="card">
          <router-link class="card-body" to="/mapping">
            <span class="material-symbols-outlined ev-icon">map</span>
            <h5 class="text-black text-center">Mapping</h5>
          </router-link>
        </div>
        <div class="card">
          <router-link class="card-body" to="/docking">
            <span class="material-symbols-outlined ev-icon">map</span>
            <h5 class="text-black text-center">Docking</h5>
          </router-link>
        </div>
        <div class="card">
          <router-link class="card-body" to="/erorhandling">
            <span class="material-symbols-outlined ev-icon">gpp_bad</span>
            <h5 class="text-black text-center">Eror Handling</h5>
          </router-link>
        </div>
      </div>
      <div class="row">
        <div class="card">
          <router-link class="card-body" to="/planner">
            <span class="material-symbols-outlined ev-icon">history</span>
            <h5 class="text-black text-center mb-0">Planner</h5>
          </router-link>
        </div>
        <div class="card">
          <router-link class="card-body" to="/move">
            <span class="material-symbols-outlined ev-icon">open_with</span>
            <h5 class="text-black text-center mb-0">Relative Move</h5>
          </router-link>
        </div>
        <div class="card">
          <router-link class="card-body" to="/date">
            <span class="material-symbols-outlined ev-icon"
              >calendar_month</span
            >
            <h5 class="text-black text-center mb-0">Date & Time</h5>
          </router-link>
        </div>
        <div class="card">
          <router-link class="card-body" to="/wifi">
            <span class="material-symbols-outlined ev-icon">wifi</span>
            <h5 class="text-black text-center mb-0">Wifi</h5>
          </router-link>
        </div>
      </div>
    </div>
  </main>
</template>

<script>
export default {};
</script>

<style lang="scss" scoped>
h5 {
  color: #262626;
  font-size: 17px;
  line-height: 24px;
  font-weight: 700;
  margin-bottom: 4px;
}

p {
  font-size: 17px;
  font-weight: 400;
  line-height: 20px;
  color: #666666;

  &.small {
    font-size: 14px;
  }
}
.card {
  display: block;
  position: relative;
  max-width: 262px;
  background-color: #f2f8f9;
  border-radius: 4px;
  padding: 32px 24px;
  margin: 12px;
  text-decoration: none;
  z-index: 0;
  overflow: hidden;

  &:before {
    content: "";
    position: absolute;
    z-index: -1;
    top: -16px;
    right: -16px;
    background: #00838d;
    height: 32px;
    width: 32px;
    border-radius: 32px;
    transform: scale(1);
    transform-origin: 50% 50%;
    transition: transform 0.25s ease-out;
  }

  &:hover:before {
    transform: scale(21);
  }
}

.card:hover {
  p {
    transition: all 0.3s ease-out;
    color: rgba(255, 255, 255, 0.8);
  }
  h5 {
    transition: all 0.3s ease-out;
    color: #ffffff;
  }
}
.card .card-body {
  display: flex;
  flex-direction: column;
}
.card {
  margin-left: 60px;
  margin-top: 50px;
  width: 200px;
  box-shadow: 1px 1px 8px rgba(17, 39, 182, 0.716);
  border-radius: 10px;
  margin-bottom: 10px;
  padding: 16px;

  justify-content: center;
  align-items: center;
}
.go-corner {
  display: flex;
  align-items: center;
  justify-content: center;
  position: absolute;
  width: 32px;
  height: 32px;
  overflow: hidden;
  top: 0;
  right: 0;
  background-color: #00838d;
  border-radius: 0 4px 0 32px;
}

.card-body {
  transition: background-color 0.3s ease;
  justify-items: center;
  display: inline;
  align-items: center;
}
.card-body {
  transition: background-color 0.3s ease;
}
.ev-icon {
  font-size: 36px; /* Adjust the font size based on your design */
  transition: color 0.3s ease; /* Add transition for color change */
}

.card:hover .ev-icon {
  color: #e40e0e; /* Green color on hover */
}
</style>
