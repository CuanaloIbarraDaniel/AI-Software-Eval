import { createStore } from 'vuex'
const URL = "http://localhost:5000/api/";

export default createStore({
  state: {
    order_Model_List: [{
      Order_ID: 1,
      Order_Status: 1,
      Order_Product_List: [{
        Product_ID: 1,
        Product_SKU: "Soda SKU",
        Product_Name: "Soda",
        Product_Quantity: 15,
      }, {
        Product_ID: 2,
        Product_SKU: "Late SKU",
        Product_Name: "Late",
        Product_Quantity: 12,
      }, {
        Product_ID: 3,
        Product_SKU: "Hamburger SKU",
        Product_Name: "Hamburger",
        Product_Quantity: 5,
      }]
    }, {
      Order_ID: 2,
      Order_Status: 1,
      Order_Product_List: [{
        Product_ID: 4,
        Product_SKU: "Meat SKU",
        Product_Name: "Meat",
        Product_Quantity: 4,
      }, {
        Product_ID: 5,
        Product_SKU: "Salad SKU",
        Product_Name: "Salad",
        Product_Quantity: 8,
      }, {
        Product_ID: 6,
        Product_SKU: "Taco SKU",
        Product_Name: "Taco",
        Product_Quantity: 12,
      }]
    }, {
      Order_ID: 3,
      Order_Status: 1,
      Order_Product_List: [{
        Product_ID: 4,
        Product_SKU: "Milk SKU",
        Product_Name: "Milk",
        Product_Quantity: 4,
      }, {
        Product_ID: 5,
        Product_SKU: "Dorito SKU",
        Product_Name: "Dorito",
        Product_Quantity: 8,
      }, {
        Product_ID: 3,
        Product_SKU: "Arizona SKU",
        Product_Name: "Arizona",
        Product_Quantity: 5,
      }]
    }]
  },
  mutations: {
    UPDATE_ORDER_STATUS(state, { order_ID, order_Status }) {
      var order_Index = state.order_Model_List.findIndex((x => x.Order_ID === order_ID));
      switch (order_Status) {
        case 1: // Set to in proccess
          state.order_Model_List[order_Index].Order_Status = 2;
          break;
        case 2: // Set to completed
          state.order_Model_List[order_Index].Order_Status = 3;
          break;
        case 3: // Set to delivered
          state.order_Model_List[order_Index].Order_Status = 4;
          break;
        case 5: // Set to canceled
          state.order_Model_List[order_Index].Order_Status = 5;
          break;
        case 6: // Set to deleted
          state.order_Model_List[order_Index].Order_Status = 6;
          break;

      }
    },

    ADD_ORDER_LIST(state, order_List) {
      state.order_Model_List = order_List;
    }


  },
  actions: {
    GetAll() {
      // Make a request for a user with a given ID
      axios.get(URL + "Order/GetAll")
        .then(function (response) { // handle success
          console.log(response);
        })
        .catch(function (error) { // handle error
          console.warn(error);
        })
        .then(function () { // always executed
        });
    }
  },
  getters: {
    GetOrderByStatus: (state) => (order_Status) => {
      if (order_Status == 0) { // Order is new    
        return state.order_Model_List.filter((x) => x.Order_Status === 0 && x.Order_Status === 1)
      }
      else {
        return state.order_Model_List.filter((x) => x.Order_Status == order_Status)
      }
    }
  }
})
