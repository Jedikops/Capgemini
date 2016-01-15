(function () {
    'use strict';

    window.app.directive('customerDetails', customerDetails);
    function customerDetails() {
        return {
            scope: { customer: '=' },
            templateUrl: '/Scripts/app/Home/templates/customerDetailstemplate.html',
            controller: controller,
            controllerAs: 'vm'
        }
    }

    controller.$inject = ['$scope', '$uibModal', 'customerService'];
    function controller($scope, $uibModal, customerService) {
        var vm = this;
        vm.customer = $scope.customer;
        vm.selectedView = 'details';
        vm.setView = setView;
        vm.edit = edit;
        vm.remove = remove;

        function setView(view) {
            vm.selectedView = view;
        }

        function edit() {
            $uibModal.open({
                template: '<edit-customer customer="customer"  />',
                scope: angular.extend($scope.$new(true), { customer: vm.customer })
            });
        }

        function remove() {
            if (confirm("Are you sure?")) {
                customerService.removeCustomer(vm.customer.Id)
            }
        }
    }
})();