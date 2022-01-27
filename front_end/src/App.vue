<template>
  <div class="container-fluid" style="width: 90%">
    <ul class="nav nav-tabs">
      <li class="nav-item">
        <a href="#PE" class="nav-link active" data-bs-toggle="tab">Pending</a>
      </li>
      <li class="nav-item">
        <a href="#IP" class="nav-link" data-bs-toggle="tab">In Process</a>
      </li>
      <li class="nav-item">
        <a href="#CO" class="nav-link" data-bs-toggle="tab">Completed</a>
      </li>
      <li class="nav-item">
        <a href="#DE" class="nav-link" data-bs-toggle="tab">Delivered</a>
      </li>
      <li class="nav-item">
        <a href="#CA" class="nav-link" data-bs-toggle="tab">Canceled</a>
      </li>
    </ul>
    <div class="tab-content">
      <div class="tab-pane fade show active" id="PE">
        <div class="card overflow-tab">
          <Order current_title="Pending" next_Title="In Process" status_ID="1" />
        </div>
      </div>
      <div class="tab-pane fade" id="IP">
        <div class="card overflow-tab">
          <Order current_title="In Process" next_Title="Completed" status_ID="2" />
        </div>
      </div>
      <div class="tab-pane fade" id="CO">
        <div class="card overflow-tab">
          <Order current_title="Completed" next_Title="Delivered" status_ID="3" />
        </div>
      </div>
      <div class="tab-pane fade" id="DE">
        <div class="card overflow-tab">
          <Order current_title="Delivered" next_Title="" status_ID="4" />
        </div>
      </div>
      <div class="tab-pane fade" id="CA">
        <div class="card overflow-tab">
          <Order current_title="Canceled" next_Title="" status_ID="5" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Order from "./components/Order.vue";

export default {
  name: "App",
  components: {
    Order,
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

.overflow-tab {
  max-height: 88vh; 
  overflow:hidden; 
  overflow-y:auto;
}

.nav-link > .active > a {
  color: red;
}
</style>
