<template>
    <div class="modal fade" id="OrderAlertModal" tabindex="-1" aria-labelledby="OrderAlertModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="OrderAlertModalLabel">New Orders</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
            <div class="modal-body" v-for="Order_List in GetNewOrder()" :key="Order_List">
                <h4 style="text-decoration: underline; text-decoration-color: grey">
                    Productos - #{{GetFormatedID(Order_List.order_ID)}}
                </h4>
                <div class="row">
                    <ul v-for="Product_List in Order_List.order_Product_List" :key="Product_List" style="list-style-type: none">
                        <li>{{Product_List.product_Name}} - {{Product_List.product_Quantity}}</li>
                    </ul>
                </div>
            </div>
        <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Ok</button>
        </div>
    </div>
  </div>
</div>
</template>


<script>
export default {
    name: 'Modal',
    methods: {
        GetFormatedID(order_Status) { return this.$store.getters.GetFormatedID(order_Status) },  
    },
    computed: {
        GetNewOrder() { return this.$store.getters.GetNewOrder; },
    }

}
</script>