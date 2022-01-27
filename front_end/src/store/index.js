import { createStore } from 'vuex'
import axios from 'axios'
const URL = "http://localhost:5000/api/";

export default createStore({
  state: {
    order_Model_List: [],
    number_Zeroes: 5
  },
  mutations: {
    UPDATE_ORDER_STATUS(state, { order_ID, order_Status }) {
      var order_Index = state.order_Model_List.findIndex((x => x.order_ID === order_ID));
      switch(order_Status) {
        case 0:
          state.order_Model_List[order_Index].order_Status = 2;
          break;
        case 1:
          state.order_Model_List[order_Index].order_Status = 2;
          break;
        default:
          state.order_Model_List[order_Index].order_Status = order_Status;
          break;
      }
    },

    ADD_ORDER_LIST(state, order_List) {
      state.order_Model_List = order_List;
    }
  },
  actions: {
    OrderGetAll({ commit }) {
      axios.get(URL + "Order/Read")
        .then(function (response) { // handle success
          commit('ADD_ORDER_LIST', response.data.model)
        })
        .catch(function (error) { // handle error
          console.warn(error);
        })
    },

    OrderUpdate({ commit }, { order_ID, order_Status }) {
      // Upgrade the status if the order is not set to canceled or deleted
      if (order_Status != 5 && order_Status != 6) {
        if (order_Status == 0) {
          order_Status += 1;
        }
        order_Status += 1;
      }
      // Updates the order
      axios.put(URL + "Order/Update", {
        order_ID: order_ID,
        order_Status: order_Status,
      })
      .then(function () { // handle success
        commit('UPDATE_ORDER_STATUS', { order_ID, order_Status })
      })
      .catch(function (error) { // handle error
        console.warn(error);
      })
    },
  },
  getters: {
    GetOrderByStatus: (state) => (order_Status) => {
      if (order_Status == 1) {
        return state.order_Model_List.filter((x) => x.order_Status <= order_Status)
      }
      else {
        return state.order_Model_List.filter((x) => x.order_Status == order_Status)
      }
    },

    GetFormatedID: (state) => (order_ID) => {
      const num_Zeroes = state.number_Zeroes - order_ID.toString().length + 1;
      if (num_Zeroes > 0) {
        return Array(+num_Zeroes).join("0") + order_ID;
      }
      return order_ID
    },


    GetNewOrder: (state) => () => {
      return state.order_Model_List.filter((x => x.order_Status == 0));
    }
  }
})
