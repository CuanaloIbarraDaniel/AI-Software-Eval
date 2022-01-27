<template>
  <div class="row" :key="componentKey">
    <div v-for="Order_List in GetOrderByStatus(status_ID)" :key="Order_List.order_ID" class="col-sm-6">
      <div class="card margin-all">
        <div class="row">
          <div class="col-8">
            <h3 class="text-start" style="padding-top: 15px; padding-left: 15px">Orden #{{GetFormatedID(Order_List.order_ID)}}</h3>
          </div>
          <div class="col-4">
            <span class="align-middle badge bg-secondary span-class">{{
              current_title
            }}</span>
          </div>
        </div>
        <hr />
        <div class="row">
          <div class="col-8" style="margin-left: 15px; text-align: left; min-height: 120px;">
            <h4 style="text-decoration: underline; text-decoration-color: grey">
              Productos
            </h4>
            <ul v-for="Product_List in Order_List.order_Product_List" :key="Product_List" style="list-style-type: none;">
              <li>{{Product_List.product_Name}} - {{Product_List.product_Quantity}}</li>
            </ul>
          </div>
          <div class="col-3 d-grid">
            <button v-if="next_Title" @click="SetOrderStatus(Order_List.order_ID, Order_List.order_Status)" class="btn d-md-block btn-outline-secondary product-button"><i class="bi bi-play-fill" style="margin-right: 7px"></i>{{ next_Title }}
            </button>
            <br />
            <button v-if="next_Title" @click="SetOrderStatus(Order_List.order_ID, 5)" class="btn btn-outline-secondary product-button alignBottom" style="margin-bottom: 20px"><i class="bi bi-trash" style="margin-right: 7px"></i>Cancel</button>
            <button v-if="!next_Title" @click="SetOrderStatus(Order_List.order_ID, 6)" class="btn btn-outline-secondary product-button alignBottom" style="margin-bottom: 20px"><i class="bi bi-trash" style="margin-right: 7px"></i>Delete</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "Order",
  data() {
    return {
      componentKey: 0,
    };
  },
  props: {
    current_title: String,
    next_Title: String,
    status_ID: String
  },
  methods: {
    GetOrderByStatus(order_Status) { return this.$store.getters.GetOrderByStatus(order_Status) },  

    SetOrderStatus(order_ID, order_Status) { this.$store.dispatch('OrderUpdate', { order_ID, order_Status }); this.componentKey += 1; },  

    GetFormatedID(order_Status) { return this.$store.getters.GetFormatedID(order_Status) },  
  },
};
</script>


<style scoped>
.margin-all {
  margin-top: 20px;
  margin-bottom: 20px;
  margin-right: 20px;
  margin-left: 20px;
}

hr {
  margin-top: 1px;
  margin-bottom: 1rem;
  margin-left: 15px;
  margin-right: 15px;
  border: 0;
  border-top: 1px solid rgba(0, 0, 0, 0.1);
}

.product-button {
  width: 115%;
  max-height: 40px;
}

.alignBottom {
  position: absolute;
  bottom: 0;
  width: 26%;
}

.span-class {
  width: 70%;
  height: 80%;
  margin-top: 6px;
  font-size: 20px;
  padding: 13px;
}
</style>