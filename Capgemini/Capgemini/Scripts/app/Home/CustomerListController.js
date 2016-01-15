(function () {
    'use strict';

    window.app.controller('CustomerListController', CustomerListController);

    CustomerListController.$inject = ['$uibModal', 'customerService'];
    function CustomerListController($uibModal, customerService) {
        var vm = this;
        vm.add = add;
        vm.customers =  customerService.customers;
    

        function add() {
            $uibModal.open({
              template: '<add-customer />'
            });
        }
    }
})();