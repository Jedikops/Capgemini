(function () {
    'use strict';
    window.app.directive('editCustomer', editCustomer);
    function editCustomer() {
        return {
            templateUrl: '/Scripts/app/Home/templates/editCustomertemplate.html',
            controller: controller,
            controllerAs: 'vm'
        }
    }

    controller.$inject = ['$scope', 'customerService'];
    function controller($scope, customerService) {
        var vm = this;
        vm.errorMessage = null;
        vm.saving = false;
        vm.update = update;
        vm.load = load;

        function load() {
            customerService.getCustomer($scope.customer.Id).success(function (data) {
                vm.customer = data;
            }).error(function (data) {
                vm.errorMessage = data;
            });
        }
        
        function update() {
            vm.saving = true;
            customerService.updateCustomer(vm.customer, $scope.customer).success(function () {
                $scope.$close();
            }).error(function (data) {
                vm.errorMessage = data;
            }).finally(function () {
                vm.saving = false;
            });
        }

    }
})();